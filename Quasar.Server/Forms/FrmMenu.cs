using Quasar.Server.Plugin;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quasar.Server.Forms
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();

            PluginManager manager = PluginManager.Instance;
            manager.LoadPlugins();
            RefreshPluginList();
        }


        private void RefreshPluginList()
        {
            // 清空现有行
            lstTasks.Items.Clear();

            // 获取所有插件
            var plugins = PluginManager.Instance.Plugins;

            if (plugins.Count == 0)
            {
                // 没有插件时显示提示
                ListViewItem emptyItem = new ListViewItem("(无可用插件)");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("请将插件DLL放入 Plugins 文件夹");
                lstTasks.Items.Add(emptyItem);
                return;
            }

            // 遍历插件，逐行添加到 ListView
            foreach (var plugin in plugins)
            {
                // 第1列：插件名称
                ListViewItem item = new ListViewItem(plugin.Info.Name ?? "未知插件");

                // 第2列：版本号
                item.SubItems.Add(plugin.Info.Version ?? "1.0.0");

                // 第3列：状态（默认已加载）
                item.SubItems.Add("已加载");

                // 第4列：描述
                item.SubItems.Add(plugin.Info.Description ?? "");

                // 把插件ID存到 Tag 中
                item.Tag = plugin.Info.Id;

                // 添加到 ListView
                lstTasks.Items.Add(item);
            }
        }
        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lstTasks_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void generalPage_Click(object sender, EventArgs e)
        {

        }
    }
}
