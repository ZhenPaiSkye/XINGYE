namespace Quasar.Server.Forms
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Quasar.Server.Utilities.ListViewColumnSorter listViewColumnSorter1 = new Quasar.Server.Utilities.ListViewColumnSorter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.builderTabs = new Quasar.Server.Controls.DotNetBarTabControl();
            this.generalPage = new System.Windows.Forms.TabPage();
            this.connectionPage = new System.Windows.Forms.TabPage();
            this.installationPage = new System.Windows.Forms.TabPage();
            this.assemblyPage = new System.Windows.Forms.TabPage();
            this.monitoringTab = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstTasks = new Quasar.Server.Controls.AeroListView();
            this.PluginsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PluginVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlugginStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PluginDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.builderTabs.SuspendLayout();
            this.generalPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // builderTabs
            // 
            this.builderTabs.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.builderTabs.Controls.Add(this.generalPage);
            this.builderTabs.Controls.Add(this.connectionPage);
            this.builderTabs.Controls.Add(this.installationPage);
            this.builderTabs.Controls.Add(this.assemblyPage);
            this.builderTabs.Controls.Add(this.monitoringTab);
            this.builderTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.builderTabs.ItemSize = new System.Drawing.Size(44, 136);
            this.builderTabs.Location = new System.Drawing.Point(0, 0);
            this.builderTabs.Multiline = true;
            this.builderTabs.Name = "builderTabs";
            this.builderTabs.SelectedIndex = 0;
            this.builderTabs.Size = new System.Drawing.Size(800, 450);
            this.builderTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.builderTabs.TabIndex = 10;
            // 
            // generalPage
            // 
            this.generalPage.BackColor = System.Drawing.SystemColors.Control;
            this.generalPage.Controls.Add(this.button3);
            this.generalPage.Controls.Add(this.button2);
            this.generalPage.Controls.Add(this.button1);
            this.generalPage.Controls.Add(this.btnSave);
            this.generalPage.Controls.Add(this.lstTasks);
            this.generalPage.Location = new System.Drawing.Point(140, 4);
            this.generalPage.Name = "generalPage";
            this.generalPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalPage.Size = new System.Drawing.Size(656, 442);
            this.generalPage.TabIndex = 4;
            this.generalPage.Text = "插件管理";
            this.generalPage.Click += new System.EventHandler(this.generalPage_Click);
            // 
            // connectionPage
            // 
            this.connectionPage.BackColor = System.Drawing.SystemColors.Control;
            this.connectionPage.Location = new System.Drawing.Point(140, 4);
            this.connectionPage.Name = "connectionPage";
            this.connectionPage.Padding = new System.Windows.Forms.Padding(3);
            this.connectionPage.Size = new System.Drawing.Size(656, 399);
            this.connectionPage.TabIndex = 0;
            this.connectionPage.Text = "连接设置";
            // 
            // installationPage
            // 
            this.installationPage.BackColor = System.Drawing.SystemColors.Control;
            this.installationPage.Location = new System.Drawing.Point(140, 4);
            this.installationPage.Name = "installationPage";
            this.installationPage.Padding = new System.Windows.Forms.Padding(3);
            this.installationPage.Size = new System.Drawing.Size(656, 399);
            this.installationPage.TabIndex = 1;
            this.installationPage.Text = "安装设置(持久化)";
            // 
            // assemblyPage
            // 
            this.assemblyPage.BackColor = System.Drawing.SystemColors.Control;
            this.assemblyPage.Location = new System.Drawing.Point(140, 4);
            this.assemblyPage.Name = "assemblyPage";
            this.assemblyPage.Size = new System.Drawing.Size(656, 399);
            this.assemblyPage.TabIndex = 2;
            this.assemblyPage.Text = "组件设置(没啥用不翻译)";
            // 
            // monitoringTab
            // 
            this.monitoringTab.BackColor = System.Drawing.SystemColors.Control;
            this.monitoringTab.Location = new System.Drawing.Point(140, 4);
            this.monitoringTab.Name = "monitoringTab";
            this.monitoringTab.Size = new System.Drawing.Size(656, 399);
            this.monitoringTab.TabIndex = 3;
            this.monitoringTab.Text = "监控设置";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(508, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 24);
            this.button2.TabIndex = 13;
            this.button2.Text = "激活/关闭";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(583, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 24);
            this.button1.TabIndex = 12;
            this.button1.Text = "删除";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(27, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 24);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "导入";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lstTasks
            // 
            this.lstTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PluginsName,
            this.PluginVersion,
            this.PlugginStatus,
            this.PluginDescription});
            this.lstTasks.FullRowSelect = true;
            this.lstTasks.GridLines = true;
            this.lstTasks.HideSelection = false;
            this.lstTasks.Location = new System.Drawing.Point(27, 55);
            listViewColumnSorter1.NeedNumberCompare = false;
            listViewColumnSorter1.Order = System.Windows.Forms.SortOrder.None;
            listViewColumnSorter1.SortColumn = 0;
            this.lstTasks.LvwColumnSorter = listViewColumnSorter1;
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(621, 358);
            this.lstTasks.TabIndex = 10;
            this.lstTasks.UseCompatibleStateImageBehavior = false;
            this.lstTasks.View = System.Windows.Forms.View.Details;
            this.lstTasks.SelectedIndexChanged += new System.EventHandler(this.lstTasks_SelectedIndexChanged_1);
            // 
            // PluginsName
            // 
            this.PluginsName.Text = "插件名";
            this.PluginsName.Width = 200;
            // 
            // PluginVersion
            // 
            this.PluginVersion.Text = "版本";
            this.PluginVersion.Width = 70;
            // 
            // PlugginStatus
            // 
            this.PlugginStatus.Text = "状态";
            // 
            // PluginDescription
            // 
            this.PluginDescription.Text = "描述";
            this.PluginDescription.Width = 430;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(102, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 24);
            this.button3.TabIndex = 14;
            this.button3.Text = "刷新";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.builderTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "菜单";
            this.builderTabs.ResumeLayout(false);
            this.generalPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.DotNetBarTabControl builderTabs;
        private System.Windows.Forms.TabPage generalPage;
        private System.Windows.Forms.TabPage connectionPage;
        private System.Windows.Forms.TabPage installationPage;
        private System.Windows.Forms.TabPage assemblyPage;
        private System.Windows.Forms.TabPage monitoringTab;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private Controls.AeroListView lstTasks;
        private System.Windows.Forms.ColumnHeader PluginsName;
        private System.Windows.Forms.ColumnHeader PluginVersion;
        private System.Windows.Forms.ColumnHeader PlugginStatus;
        private System.Windows.Forms.ColumnHeader PluginDescription;
        private System.Windows.Forms.Button button3;
    }
}