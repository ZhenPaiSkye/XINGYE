using Quasar.Server.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Quasar.Server.Forms
{
    partial class FrmHttpApi
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHttpApi));
            this.lblProxyInfo = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.nudServerPort = new System.Windows.Forms.NumericUpDown();
            this.lblLocalServerPort = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.stripLblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProxyInfo
            // 
            this.lblProxyInfo.AutoSize = true;
            this.lblProxyInfo.Location = new System.Drawing.Point(19, 52);
            this.lblProxyInfo.Name = "lblProxyInfo";
            this.lblProxyInfo.Size = new System.Drawing.Size(59, 13);
            this.lblProxyInfo.TabIndex = 13;
            this.lblProxyInfo.Text = "测试文本";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(499, 14);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(114, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "停止服务";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // nudServerPort
            // 
            this.nudServerPort.Location = new System.Drawing.Point(253, 16);
            this.nudServerPort.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            this.nudServerPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudServerPort.Name = "nudServerPort";
            this.nudServerPort.Size = new System.Drawing.Size(120, 22);
            this.nudServerPort.TabIndex = 10;
            this.nudServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudServerPort.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // lblLocalServerPort
            // 
            this.lblLocalServerPort.AutoSize = true;
            this.lblLocalServerPort.Location = new System.Drawing.Point(19, 21);
            this.lblLocalServerPort.Name = "lblLocalServerPort";
            this.lblLocalServerPort.Size = new System.Drawing.Size(65, 13);
            this.lblLocalServerPort.TabIndex = 9;
            this.lblLocalServerPort.Text = "API 服务器";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(379, 14);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(114, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "启动服务";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(118, 16);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(129, 22);
            this.txtHost.TabIndex = 14;
            this.txtHost.Text = "127.0.0.1";
            this.txtHost.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // stripLblStatus
            // 
            this.stripLblStatus.AutoSize = true;
            this.stripLblStatus.Location = new System.Drawing.Point(2, 390);
            this.stripLblStatus.Name = "stripLblStatus";
            this.stripLblStatus.Size = new System.Drawing.Size(20, 13);
            this.stripLblStatus.TabIndex = 15;
            this.stripLblStatus.Text = "无";
            this.stripLblStatus.Click += new System.EventHandler(this.label1_Click);
            // 
            // FrmHttpApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(777, 402);
            this.Controls.Add(this.stripLblStatus);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblProxyInfo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.nudServerPort);
            this.Controls.Add(this.lblLocalServerPort);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHttpApi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "API 设置";
            this.Load += new System.EventHandler(this.FrmHttpApi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblProxyInfo;
        private Button btnStop;
        private NumericUpDown nudServerPort;
        private Label lblLocalServerPort;
        private Button btnStart;
        private TextBox txtHost;
        private Label stripLblStatus;
    }
}