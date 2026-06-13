using Newtonsoft.Json;
using Quasar.Common.Enums;
using Quasar.Common.Messages;
using Quasar.Server.Messages;
using Quasar.Server.Models;
using Quasar.Server.Networking;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Quasar.Server.Extensions.HttpApi
{
    [HttpApi]
    public class HttpAllApi
    {
        private QuasarServer _listenServer = QuasarServer.Instance;

        /// <summary>
        /// 获取所有客户端信息
        /// </summary>
        [HttpGet("/get_clis")]
        public string GetClients(HttpListenerRequest request)
        {
            //获取所有客户端
            Client[] clients = _listenServer.ConnectedClients;
            //客户端的数量
            int total = clients.Length;

            var clientList = new List<object>();
            foreach (Client c in clients)
            {
                clientList.Add(new
                {
                    pcname = c.Value?.PcName ?? "未知",
                    username = c.Value?.Username ?? "未知",
                    ip = c.EndPoint?.Address?.ToString() ?? "未知",
                    os = c.Value?.OperatingSystem ?? "未知",
                    id = c.Value?.Id ?? "未知"
                });
            }

            string response = HttpResponse.Build(0, "ok", new
            {
                total = clientList.Count,
                clients = clientList
            });

            return response;
        }

        /// <summary>
        /// 指定客户端执行cmd命令
        /// </summary>
        [HttpPost("/send_command")]
        public string PostSendCommend(HttpListenerRequest request)
        {

            string response = HttpResponse.Build(-1, "err", null);
            //解析post参数
            using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                string jsonData = reader.ReadToEnd();

                // 解析 JSON
                var data = JsonConvert.DeserializeObject<dynamic>(jsonData);

                string commend = data.commend;
                List<string> ids = data.id.ToObject<List<string>>();

                //获取所有客户端
                Client[] clients = _listenServer.ConnectedClients;

                //执行命令
                foreach (string id in ids)
                {
                    foreach (Client c in clients)
                    {
                        if (c.Value?.Id == id)
                        {
                            new RemoteShellHandler(c).SendCommand(commend);
                            break;
                        }
                    }

                    response = HttpResponse.Build(0, "ok", null);
                }
            }


            return response;
        }

        /// <summary>
        /// 指定客户端执行电源操作
        /// </summary>
        [HttpPost("/power_control")]
        public string PowerControl(HttpListenerRequest request)
        {
            string response = HttpResponse.Build(-1, "err", null);
            //解析post参数
            using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                string jsonData = reader.ReadToEnd();

                // 解析 JSON
                var data = JsonConvert.DeserializeObject<dynamic>(jsonData);

                int action = data.action;
                List<string> ids = data.id.ToObject<List<string>>();

                Client[] clients = _listenServer.ConnectedClients;
                foreach (string targetId in ids)
                {
                    foreach (Client c in clients)
                    {
                        if (c.Value?.Id == targetId)
                        {
                            //判断执行电源操作
                            switch (action)
                            {
                                case 0:
                                    //关机
                                    c.Send(new DoShutdownAction { Action = ShutdownAction.Shutdown });
                                    break;
                                case 1:
                                    //重启
                                    c.Send(new DoShutdownAction { Action = ShutdownAction.Restart });
                                    break;
                                case 2:
                                    //睡眠
                                    c.Send(new DoShutdownAction { Action = ShutdownAction.Standby });
                                    break;
                                default:
                                    // 无效的操作码
                                    break;
                            }
                            break;
                        }
                    }
                }
            }


            return response;
        }

        /// <summary>
        /// 指定客户端弹出弹窗
        /// </summary>
        [HttpPost("/show_messagebox")]
        public string ShowMessageBox(HttpListenerRequest request)
        {
            return "ok";
        }

    }
}
