using System;

namespace Quasar.Server.Extensions.HttpApi
{
    /// <summary>
    /// 标记这个类是一个 HTTP API 处理器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class HttpApiAttribute : Attribute
    {
    }

    /// <summary>
    /// 标记方法处理 GET 请求
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpGetAttribute : Attribute
    {
        public string Route { get; }
        public HttpGetAttribute(string route) => Route = route;
    }

    /// <summary>
    /// 标记方法处理 POST 请求
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpPostAttribute : Attribute
    {
        public string Route { get; }
        public HttpPostAttribute(string route) => Route = route;
    }
}