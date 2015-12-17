namespace ChatLan
{
    partial class AdminFormData
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
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Message = new System.Windows.Forms.ToolStripMenuItem();
            this.FTPServer = new System.Windows.Forms.ToolStripMenuItem();
            this.DataMessageGrid = new System.Windows.Forms.DataGridView();
            this.FTPServerTreeView = new System.Windows.Forms.TreeView();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataMessageGrid)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(594, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(51, 20);
            this.Menu.Text = "Меню";
            // 
            // Message
            // 
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(115, 20);
            this.Message.Text = "Просмотр данных";
            this.Message.Click += new System.EventHandler(this.Message_Click_1);
            // 
            // FTPServer
            // 
            this.FTPServer.Name = "FTPServer";
            this.FTPServer.Size = new System.Drawing.Size(133, 20);
            this.FTPServer.Text = "Содержание сервера";
            this.FTPServer.Click += new System.EventHandler(this.FTPServer_Click_1);
            // 
            // DataMessageGrid
            // 
            this.DataMessageGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataMessageGrid.Location = new System.Drawing.Point(0, 27);
            this.DataMessageGrid.Name = "DataMessageGrid";
            this.DataMessageGrid.RowTemplate.Height = 23;
            this.DataMessageGrid.Size = new System.Drawing.Size(415, 272);
            this.DataMessageGrid.TabIndex = 1;
            this.DataMessageGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataMessageGrid_CellMouseDoubleClick);
            // 
            // FTPServerTreeView
            // 
            this.FTPServerTreeView.Location = new System.Drawing.Point(421, 27);
            this.FTPServerTreeView.Name = "FTPServerTreeView";
            this.FTPServerTreeView.Size = new System.Drawing.Size(173, 272);
            this.FTPServerTreeView.TabIndex = 2;
            this.FTPServerTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FTPServerTreeView_NodeMouseDoubleClick);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(152, 22);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // AdminFormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 299);
            this.Controls.Add(this.FTPServerTreeView);
            this.Controls.Add(this.DataMessageGrid);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminFormData";
            this.Text = "AdminFormData";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataMessageGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem Message;
        private System.Windows.Forms.ToolStripMenuItem FTPServer;
        private System.Windows.Forms.DataGridView DataMessageGrid;
        private System.Windows.Forms.TreeView FTPServerTreeView;
        private System.Windows.Forms.ToolStripMenuItem Exit;
    }
}