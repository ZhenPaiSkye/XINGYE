using System;
using System.Windows.Forms;

namespace Quasar.Server.Forms
{
    public partial class FrmHttpApi : Form
    {
        private HttpApiHandler _httpServer = new HttpApiHandler();
        public FrmHttpApi()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmHttpApi_Load(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Button currentBtn = sender as Button;
            currentBtn.Enabled = false;
           
            string ip_addres = this.txtHost.Text;
            string port = this.nudServerPort.Text;
            if (_httpServer.Start(ip_addres,port) == 1)
            {
                this.stripLblStatus.Text = "服务启动成功";
                this.btnStop.Enabled = true;
            }
            else
            {
                this.stripLblStatus.Text = "服务未能启动";
                currentBtn.Enabled = true;
            }
 
        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Button currentBtn = sender as Button;
            currentBtn.Enabled = false;

            if (_httpServer.Stop() == 1)
            {
                this.stripLblStatus.Text = "服务已关闭";
            }

            this.btnStart.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}