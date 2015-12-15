namespace ChatLan
{
    partial class AdminForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Message = new System.Windows.Forms.ToolStripMenuItem();
            this.FTPServer = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu,
            this.Message,
            this.FTPServer});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(488, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Message
            // 
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(127, 20);
            this.Message.Text = "Показать переписку";
            this.Message.Click += new System.EventHandler(this.Message_Click);
            // 
            // FTPServer
            // 
            this.FTPServer.Name = "FTPServer";
            this.FTPServer.Size = new System.Drawing.Size(107, 20);
            this.FTPServer.Text = "Содержание FTP";
            this.FTPServer.Click += new System.EventHandler(this.FTPServer_Click);
            // 
            // Menu
            // 
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(51, 20);
            this.Menu.Text = "Меню";
            this.Menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 310);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Message;
        private System.Windows.Forms.ToolStripMenuItem FTPServer;
        private System.Windows.Forms.ToolStripMenuItem Menu;


    }
}