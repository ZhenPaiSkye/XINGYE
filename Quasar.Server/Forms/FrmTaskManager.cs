using Quasar.Common.Enums;
using Quasar.Common.Messages;
using Quasar.Common.Models;
using Quasar.Server.Controls;
using Quasar.Server.Helper;
using Quasar.Server.Messages;
using Quasar.Server.Networking;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quasar.Server.Forms
{
    public partial class FrmTaskManager : Form
    {
        /// <summary>
        /// 可用于任务管理器的客户端实例。
        /// </summary>
        private readonly Client _connectClient;

        /// <summary>
        /// 用于处理与客户端通信的消息处理器。
        /// </summary>
        private readonly TaskManagerHandler _taskManagerHandler;

        /// <summary>
        /// 为每个客户端保存已打开的任务管理器窗体。
        /// </summary>
        private static readonly Dictionary<Client, FrmTaskManager> OpenedForms = new Dictionary<Client, FrmTaskManager>();

        /// <summary>
        /// 为客户端创建一个新的任务管理器窗体，如果已存在则获取当前打开的窗体。
        /// </summary>
        /// <param name="client">用于任务管理器窗体的客户端。</param>
        /// <returns>
        /// 如果当前没有打开的任务管理器窗体，则返回一个新的任务管理器窗体，否则创建并返回一个新的。
        /// </returns>
        public static FrmTaskManager CreateNewOrGetExisting(Client client)
        {
            if (OpenedForms.ContainsKey(client))
            {
                return OpenedForms[client];
            }
            FrmTaskManager f = new FrmTaskManager(client);
            f.Disposed += (sender, args) => OpenedForms.Remove(client);
            OpenedForms.Add(client, f);
            return f;
        }

        /// <summary>
        /// 使用指定的客户端初始化 <see cref="FrmTaskManager"/> 类的新实例。
        /// </summary>
        /// <param name="client">用于任务管理器窗体的客户端。</param>
        public FrmTaskManager(Client client)
        {
            _connectClient = client;
            _taskManagerHandler = new TaskManagerHandler(client);

            RegisterMessageHandler();
            InitializeComponent();
        }

        /// <summary>
        /// 注册任务管理器消息处理器以进行客户端通信。
        /// </summary>
        private void RegisterMessageHandler()
        {
            _connectClient.ClientState += ClientDisconnected;
            _taskManagerHandler.ProgressChanged += TasksChanged;
            _taskManagerHandler.ProcessActionPerformed += ProcessActionPerformed;
            MessageHandler.Register(_taskManagerHandler);
        }

        /// <summary>
        /// 注销任务管理器消息处理器。
        /// </summary>
        private void UnregisterMessageHandler()
        {
            MessageHandler.Unregister(_taskManagerHandler);
            _taskManagerHandler.ProcessActionPerformed -= ProcessActionPerformed;
            _taskManagerHandler.ProgressChanged -= TasksChanged;
            _connectClient.ClientState -= ClientDisconnected;
        }

        /// <summary>
        /// 当客户端断开连接时调用。
        /// </summary>
        /// <param name="client">断开连接的客户端。</param>
        /// <param name="connected">如果客户端已连接则为 true，如果断开连接则为 false</param>
        private void ClientDisconnected(Client client, bool connected)
        {
            if (!connected)
            {
                this.Invoke((MethodInvoker)this.Close);
            }
        }

        private void TasksChanged(object sender, Process[] processes)
        {
            lstTasks.Items.Clear();

            foreach (var process in processes)
            {
                ListViewItem lvi =
                    new ListViewItem(new[] { process.Name, process.Id.ToString(), process.MainWindowTitle });
                lstTasks.Items.Add(lvi);
            }

            processesToolStripStatusLabel.Text = $"进程数: {processes.Length}";
        }

        private void ProcessActionPerformed(object sender, ProcessAction action, bool result)
        {
            string text = string.Empty;
            switch (action)
            {
                case ProcessAction.Start:
                    text = result ? "进程启动成功" : "启动进程失败";
                    break;
                case ProcessAction.End:
                    text = result ? "进程结束成功" : "结束进程失败";
                    break;
            }

            processesToolStripStatusLabel.Text = text;
        }

        private void FrmTaskManager_Load(object sender, EventArgs e)
        {
            this.Text = WindowHelper.GetWindowTitle("任务管理器", _connectClient);
            _taskManagerHandler.RefreshProcesses();
        }

        private void FrmTaskManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterMessageHandler();
        }

        private void killProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstTasks.SelectedItems)
            {
                _taskManagerHandler.EndProcess(int.Parse(lvi.SubItems[1].Text));
            }
        }

        private void startProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string processName = string.Empty;
            if (InputBox.Show("进程名称", "请输入进程名称:", ref processName) == DialogResult.OK)
            {
                _taskManagerHandler.StartProcess(processName);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _taskManagerHandler.RefreshProcesses();
        }

        private void lstTasks_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lstTasks.LvwColumnSorter.NeedNumberCompare = (e.Column == 1);
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}