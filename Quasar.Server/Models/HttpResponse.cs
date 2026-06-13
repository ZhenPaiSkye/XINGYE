using System.Collections.Generic;
using Newtonsoft.Json;

namespace Quasar.Server.Models
{
    class HttpResponse
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }

        public HttpResponse(int Code, string Message, object Data) {
            this.Code = Code;
            this.Message = Message;
            this.Data = Data;
        }

        public static string Build(int Code,string Message, object Data)
        {
            var response = new HttpResponse(Code, Message, Data);
            return JsonConvert.SerializeObject(response);
        }
    }
}
