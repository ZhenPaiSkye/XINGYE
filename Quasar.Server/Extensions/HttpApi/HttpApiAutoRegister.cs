using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace Quasar.Server.Extensions.HttpApi
{
    public static class HttpApiAutoRegister
    {
        // 存储路由和方法映射
        public static Dictionary<string, Func<HttpListenerRequest, string>> GetRoutes { get; } = new Dictionary<string, Func<HttpListenerRequest, string>>();
        public static Dictionary<string, Func<HttpListenerRequest, string>> PostRoutes { get; } = new Dictionary<string, Func<HttpListenerRequest, string>>();

        /// <summary>
        /// 扫描并注册所有标记了 [HttpApi] 的类
        /// </summary>
        public static void RegisterAll()
        {
            GetRoutes.Clear();
            PostRoutes.Clear();

            // 获取当前程序集
            var assembly = Assembly.GetExecutingAssembly();

            // 遍历所有类型
            foreach (var type in assembly.GetTypes())
            {
                // 检查是否标记了 [HttpApi]
                var apiAttr = type.GetCustomAttribute<HttpApiAttribute>();
                if (apiAttr == null) continue;

                // 创建类的实例
                var instance = Activator.CreateInstance(type);

                // 遍历所有方法
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                {
                    // 处理 GET
                    var getAttr = method.GetCustomAttribute<HttpGetAttribute>();
                    if (getAttr != null)
                    {
                        var handler = CreateHandler(instance, method);
                        GetRoutes[getAttr.Route] = handler;
                        Console.WriteLine($"[注册] GET {getAttr.Route} → {type.Name}.{method.Name}");
                    }

                    // 处理 POST
                    var postAttr = method.GetCustomAttribute<HttpPostAttribute>();
                    if (postAttr != null)
                    {
                        var handler = CreateHandler(instance, method);
                        PostRoutes[postAttr.Route] = handler;
                        Console.WriteLine($"[注册] POST {postAttr.Route} → {type.Name}.{method.Name}");
                    }
                }
            }
        }

        private static Func<HttpListenerRequest, string> CreateHandler(object instance, MethodInfo method)
        {
            return (request) =>
            {
                try
                {
                    return (string)method.Invoke(instance, new object[] { request });
                }
                catch (Exception ex)
                {
                    return $"{{\"code\":500,\"msg\":\"{ex.InnerException?.Message ?? ex.Message}\"}}";
                }
            };
        }
    }
}