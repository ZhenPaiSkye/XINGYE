using Quasar.Server.Extensions.HttpApi;
using Quasar.Server.Models;
using System;
using System.Net;
using System.Text;

public class HttpApiHandler
{
    private HttpListener _listener;
    private bool _running = false;

    public int Start(string ip, string port)
    {
        if (!_running)
        {
            // 启动时自动注册所有 API
            HttpApiAutoRegister.RegisterAll();  // 必须调用

            // 添加调试日志
            //Console.WriteLine($"注册结果 - GET路由数: {HttpApiAutoRegister.GetRoutes.Count}");
            //Console.WriteLine($"注册结果 - POST路由数: {HttpApiAutoRegister.PostRoutes.Count}");

            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://{ip}:{port}/");
            _listener.Start();
            _running = true;
            _listener.BeginGetContext(OnRequest, null);
            return 1;
        }
        return 0;
    }
    public int Stop()
    {
        if (_running)
        {
            _listener.Stop();
            _running = false;
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private void OnRequest(IAsyncResult result)
    {
        try
        {
            var context = _listener.EndGetContext(result);
            var request = context.Request;
            var response = context.Response;

            string path = request.RawUrl.Split('?')[0];
            string method = request.HttpMethod;

            Func<HttpListenerRequest, string> handler = null;

            if (method == "GET")
                HttpApiAutoRegister.GetRoutes.TryGetValue(path, out handler);
            else if (method == "POST")
                HttpApiAutoRegister.PostRoutes.TryGetValue(path, out handler);

            string responseText;
            if (handler != null)
            {
                responseText = handler(request);
            }
            else
            {
                response.StatusCode = 404;
                responseText = "可爱的开发者,你访问的页面不存在哦";
            }

            var data = Encoding.UTF8.GetBytes(responseText);
            response.ContentType = "application/json; charset=utf-8";
            response.OutputStream.Write(data, 0, data.Length);
            response.OutputStream.Close();

            if (_running)
                _listener.BeginGetContext(OnRequest, null);
        }
        catch (Exception) { }
    }
}


//using Newtonsoft.Json;
//using Quasar.Server.Messages;
//using Quasar.Server.Models;
//using Quasar.Server.Networking;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net;
//using System.Text;

//namespace Quasar.Server.Extensions.HttpApi
//{
//    public class HttpApiHandler
//    {
//        private QuasarServer _listenServer;
//        private readonly Dictionary<string, Func<HttpListenerRequest, string>> _getRoutes;
//        private readonly Dictionary<string, Func<HttpListenerRequest, string>> _postRoutes;
//        private HttpListener _listener;
//        private bool runing = false;

//        public HttpApiHandler()
//        {
//            _listenServer = QuasarServer.Instance;
//            _getRoutes = new Dictionary<string, Func<HttpListenerRequest, string>>();
//            _postRoutes = new Dictionary<string, Func<HttpListenerRequest, string>>();

//            _getRoutes.Add("/get_clients", GetClients);
//            _postRoutes.Add("/send_commend", PostSendCommend);
//        }

//        public int Start(string ip_address,string port)
//        {
//            if (!runing)
//            {
//                _listener = new HttpListener();
//                _listener.Prefixes.Add("http://" + ip_address + ":" + port + "/");
//                _listener.Start();
//                runing = true;
//                _listener.BeginGetContext(OnRequest, null);

//                return 1;
//            }else
//            {
//                return 0;
//            }        
//        }

//        public int Stop()
//        {
//            if (runing)
//            {
//                _listener.Stop();
//                runing = false;
//                return 1;
//            }
//            else
//            {
//                return 0;
//            }
//        }

//        private void OnRequest(IAsyncResult result)
//        {
//            try
//            {

//                var context = _listener.EndGetContext(result);

//                var request = context.Request;
//                var response = context.Response;

//                string method = request.HttpMethod;
//                string url = request.RawUrl;
//                string path = url.Split('?')[0];


//                string responseText;
//                byte[] data;
//                if (_getRoutes.ContainsKey(path))
//                {
//                    responseText = _getRoutes[path](request);
//                    data = Encoding.UTF8.GetBytes(responseText);
//                } else if (_postRoutes.ContainsKey(path)) 
//                {
//                    responseText = _postRoutes[path](request);
//                    data = Encoding.UTF8.GetBytes(responseText);
//                }
//                else
//                {
//                    response.StatusCode = 404;
//                    data = Encoding.UTF8.GetBytes("可爱的开发者,你访问的页面不存在哦");
//                }

//                response.ContentType = "text/plain; charset=utf-8";
//                response.OutputStream.Write(data, 0, data.Length);
//                response.OutputStream.Close();

//                if (runing)
//                {
//                    _listener.BeginGetContext(OnRequest, null);
//                }
//            }
//            catch (HttpListenerException)
//            {

//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }

//        private string GetClients(HttpListenerRequest request)
//        {
//            Client[] clients = _listenServer.ConnectedClients;
//            int total = clients.Length;

//            var clientList = new List<object>();
//            foreach (Client c in clients)
//            {
//                clientList.Add(new
//                {
//                    pcname = c.Value?.PcName ?? "未知",
//                    username = c.Value?.Username ?? "未知",
//                    ip = c.EndPoint?.Address?.ToString() ?? "未知",
//                    os = c.Value?.OperatingSystem ?? "未知",
//                    id = c.Value?.Id ?? "未知"
//                });
//            }

//            string response = HttpResponse.Build(0, "ok", new
//            {
//                total = clientList.Count,
//                clients = clientList
//            });

//            return response;
//        }

//        private string PostSendCommend(HttpListenerRequest request)
//        {
//            string response = HttpResponse.Build(-1,"err",null);
//            using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
//            {
//                string jsonData = reader.ReadToEnd();

//                // 解析 JSON
//                var data = JsonConvert.DeserializeObject<dynamic>(jsonData);

//                string commend = data.commend;
//                string clientId = data.clientId;

//                Client[] clients = _listenServer.ConnectedClients;
//                foreach (Client c in clients)
//                {
//                    if (c.Value?.Id == clientId)
//                    {
//                        new RemoteShellHandler(c).SendCommand(commend);
//                        response = HttpResponse.Build(0, "ok", null);
//                        break;
//                    }
//                }

//                //response = HttpResponse.Build(1, "no", "没有找到客户端");
//            }


//            return response;
//        }
//    }
//}
