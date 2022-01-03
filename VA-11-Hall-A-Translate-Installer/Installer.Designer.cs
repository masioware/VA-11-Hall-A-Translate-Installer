namespace VA_11_Hall_A_Translate_Installer
{
    partial class Installer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installer));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_title = new System.Windows.Forms.Label();
            this.btn_install = new System.Windows.Forms.Button();
            this.btn_uninstall = new System.Windows.Forms.Button();
            this.lb_status_text = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label_title
            // 
            resources.ApplyResources(this.label_title, "label_title");
            this.label_title.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_title.Name = "label_title";
            // 
            // btn_install
            // 
            this.btn_install.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btn_install, "btn_install");
            this.btn_install.ForeColor = System.Drawing.Color.White;
            this.btn_install.Name = "btn_install";
            this.btn_install.UseVisualStyleBackColor = false;
            this.btn_install.Click += new System.EventHandler(this.btn_install_Click);
            // 
            // btn_uninstall
            // 
            this.btn_uninstall.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btn_uninstall, "btn_uninstall");
            this.btn_uninstall.ForeColor = System.Drawing.Color.White;
            this.btn_uninstall.Name = "btn_uninstall";
            this.btn_uninstall.UseVisualStyleBackColor = false;
            this.btn_uninstall.Click += new System.EventHandler(this.btn_uninstall_Click);
            // 
            // lb_status_text
            // 
            this.lb_status_text.BackColor = System.Drawing.Color.Black;
            this.lb_status_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.lb_status_text, "lb_status_text");
            this.lb_status_text.ForeColor = System.Drawing.Color.White;
            this.lb_status_text.FormattingEnabled = true;
            this.lb_status_text.Name = "lb_status_text";
            // 
            // Installer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lb_status_text);
            this.Controls.Add(this.btn_uninstall);
            this.Controls.Add(this.btn_install);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Installer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private Label label_title;
        private Button btn_install;
        private Button btn_uninstall;
        private ListBox lb_status_text;
        private FolderBrowserDialog folderBrowserDialog;
    }
}