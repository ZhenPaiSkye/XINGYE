using Quasar.Server.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quasar.Server.Forms
{
    public partial class FrmLanguage : Form
    {
        public FrmLanguage()
        {
            InitializeComponent();
            comboBox1.Items.Add("中文");
            comboBox1.Items.Add("English");
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem.ToString();

            if (selected == "中文")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh");
                ComponentResourceManager res = new ComponentResourceManager(typeof(FrmLanguage));
                lblDescription.Text = res.GetString("lblDescription.Text");
                comboBox1.SelectedIndex = 0;
            }
            else if  (selected == "English")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                ComponentResourceManager res = new ComponentResourceManager(typeof(FrmLanguage));
                lblDescription.Text = res.GetString("lblDescription.Text");
                comboBox1.SelectedIndex = 1;
            }

          
        }

        private void ReloadFormResources()
        {
            // 创建一个资源管理器，专门负责读取 FrmLanguage对应的资源文件（.resx）
            ComponentResourceManager res = new ComponentResourceManager(typeof(FrmLanguage));

            // 调用下面的方法，从资源管理器重新加载所有控件的文字
            ApplyResources(this, res);
        }

        private void ApplyResources(Control control, ComponentResourceManager res)
        {
            // 为当前控件重新加载文字资源（比如按钮的Text、标签的Text等）
            res.ApplyResources(control, control.Name);

            // 遍历当前控件里面的所有子控件（比如面板里的按钮、分组框里的标签）
            foreach (Control child in control.Controls)
            {
                ApplyResources(child, res);  // 递归调用自己，处理子控件的子控件
            }
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void FrmLanguage_Load(object sender, EventArgs e)
        {

        }
    }
}
