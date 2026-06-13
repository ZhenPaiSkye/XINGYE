using Newtonsoft.Json;
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

        [HttpGet("/get_clis")]
        public string GetClients(HttpListenerRequest request)
        {
            Client[] clients = _listenServer.ConnectedClients;
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

        [HttpPost("/send_command")]
        public string PostSendCommend(HttpListenerRequest request)
        {
            string response = HttpResponse.Build(-1, "err", null);
            using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                string jsonData = reader.ReadToEnd();

                // 解析 JSON
                var data = JsonConvert.DeserializeObject<dynamic>(jsonData);

                string commend = data.commend;
                string clientId = data.clientId;

                Client[] clients = _listenServer.ConnectedClients;
                foreach (Client c in clients)
                {
                    if (c.Value?.Id == clientId)
                    {
                        new RemoteShellHandler(c).SendCommand(commend);
                        response = HttpResponse.Build(0, "ok", null);
                        break;
                    }
                }

                //response = HttpResponse.Build(1, "no", "没有找到客户端");
            }


            return response;
        }
    }
}
