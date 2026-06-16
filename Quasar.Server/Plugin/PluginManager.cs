
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Quasar.Server.Plugin
{
    public class PluginManager
    {
        private static readonly object _lock = new object();
        private static PluginManager _instance;
        public static PluginManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new PluginManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public PluginManager() { }

        private readonly List<IPlugin> _plugins = new List<IPlugin>();
        private readonly Dictionary<string, IPlugin> _pluginDict = new Dictionary<string, IPlugin>();


        /// <summary>
        /// 所有已加载的插件（只读）
        /// </summary>
        public IReadOnlyList<IPlugin> Plugins => _plugins;

        /// <summary>
        /// 插件数量
        /// </summary>
        public int Count => _plugins.Count;

        /// <summary>
        /// 加载所有插件
        /// </summary>
        public void LoadPlugins( Action<string> logger = null)
        {
            string pluginDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins"); 

            if (!Directory.Exists(pluginDirectory))
            {
                logger?.Invoke($"[插件] 目录不存在，创建: {pluginDirectory}");
                Directory.CreateDirectory(pluginDirectory);
                return;
            }

            logger?.Invoke($"[插件] 开始扫描: {pluginDirectory}");

            string[] dllFiles = Directory.GetFiles(pluginDirectory, "*.dll", SearchOption.TopDirectoryOnly);

            foreach (string dllPath in dllFiles)
            {
                try
                {
                    logger?.Invoke($"[插件] 加载: {Path.GetFileName(dllPath)}");
                    Assembly assembly = Assembly.LoadFrom(dllPath);

                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.IsClass && !type.IsAbstract && typeof(IPlugin).IsAssignableFrom(type))
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugin.Initialize();

                            _plugins.Add(plugin);
                            _pluginDict[plugin.Info.Id] = plugin;

                            logger?.Invoke($"[插件]  加载成功: {plugin.Info.Name} v{plugin.Info.Version}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger?.Invoke($"[插件]  加载失败: {Path.GetFileName(dllPath)} - {ex.Message}");
                }
            }

            logger?.Invoke($"[插件] 加载完成，共 {_plugins.Count} 个插件");
        }

        /// <summary>
        /// 根据 ID 获取插件
        /// </summary>
        public IPlugin GetPlugin(string id)
        {
            _pluginDict.TryGetValue(id, out IPlugin plugin);
            return plugin;
        }

        /// <summary>
        /// 卸载所有插件
        /// </summary>
        public void UnloadAll()
        {
            foreach (var plugin in _plugins)
            {
                try
                {
                    plugin.Unload();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[插件] 卸载失败: {plugin.Info.Name} - {ex.Message}");
                }
            }
            _plugins.Clear();
            _pluginDict.Clear();
        }

        /// <summary>
        /// 刷新插件列表（重新加载）
        /// </summary>
        public void Reload()
        {
            UnloadAll();
            LoadPlugins();
        }
    }
}
