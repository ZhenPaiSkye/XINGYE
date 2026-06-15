namespace Quasar.Server.Forms
{
    partial class FrmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnOkay = new System.Windows.Forms.Button();
            this.rtxtContent = new System.Windows.Forms.RichTextBox();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lnkCredits = new System.Windows.Forms.LinkLabel();
            this.lnkGithubPage = new System.Windows.Forms.LinkLabel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            resources.ApplyResources(this.picIcon, "picIcon");
            this.picIcon.Image = global::Quasar.Server.Properties.Resources.XINGYE;
            this.picIcon.Name = "picIcon";
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.picIcon_Click);
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.Name = "lblVersion";
            // 
            // btnOkay
            // 
            resources.ApplyResources(this.btnOkay, "btnOkay");
            this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // rtxtContent
            // 
            resources.ApplyResources(this.rtxtContent, "rtxtContent");
            this.rtxtContent.Name = "rtxtContent";
            this.rtxtContent.ReadOnly = true;
            this.rtxtContent.TextChanged += new System.EventHandler(this.rtxtContent_TextChanged);
            // 
            // lblLicense
            // 
            resources.ApplyResources(this.lblLicense, "lblLicense");
            this.lblLicense.Name = "lblLicense";
            // 
            // lnkCredits
            // 
            resources.ApplyResources(this.lnkCredits, "lnkCredits");
            this.lnkCredits.Name = "lnkCredits";
            this.lnkCredits.TabStop = true;
            this.lnkCredits.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCredits_LinkClicked);
            // 
            // lnkGithubPage
            // 
            resources.ApplyResources(this.lnkGithubPage, "lnkGithubPage");
            this.lnkGithubPage.Name = "lnkGithubPage";
            this.lnkGithubPage.TabStop = true;
            this.lnkGithubPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGithubPage_LinkClicked);
            // 
            // lblSubTitle
            // 
            resources.ApplyResources(this.lblSubTitle, "lblSubTitle");
            this.lblSubTitle.Name = "lblSubTitle";
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.btnOkay;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnOkay;
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lnkGithubPage);
            this.Controls.Add(this.lnkCredits);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.rtxtContent);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.RichTextBox rtxtContent;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.LinkLabel lnkCredits;
        private System.Windows.Forms.LinkLabel lnkGithubPage;
        private System.Windows.Forms.Label lblSubTitle;
    }
}