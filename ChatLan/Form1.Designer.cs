namespace ChatLan
{
    partial class ChatLan
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatLan));
            this.Send = new System.Windows.Forms.Button();
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.MessageB = new System.Windows.Forms.RichTextBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.EnterIP = new System.Windows.Forms.ToolStripMenuItem();
            this.EnterName = new System.Windows.Forms.ToolStripMenuItem();
            this.exitDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IPme = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSend = new System.Windows.Forms.Button();
            this.EmployeeName = new System.Windows.Forms.TreeView();
            this.IPtextBox = new System.Windows.Forms.TextBox();
            this.IPlabel = new System.Windows.Forms.Label();
            this.Namelabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            this.SuspendLayout();
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(11, 392);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(124, 24);
            this.Send.TabIndex = 0;
            this.Send.Text = "Отправка сообщения";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(11, 80);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.Size = new System.Drawing.Size(317, 237);
            this.ChatBox.TabIndex = 2;
            this.ChatBox.Text = "";
            // 
            // MessageB
            // 
            this.MessageB.BackColor = System.Drawing.SystemColors.Control;
            this.MessageB.Location = new System.Drawing.Point(11, 323);
            this.MessageB.Name = "MessageB";
            this.MessageB.Size = new System.Drawing.Size(317, 63);
            this.MessageB.TabIndex = 3;
            this.MessageB.Tag = "Введите сообщение...";
            this.MessageB.Text = "Введите сообщение...";
            this.MessageB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MessageB_MouseClick);
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.MenuStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MenuStrip.BackgroundImage")));
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu,
            this.IPme});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuStrip.Size = new System.Drawing.Size(536, 24);
            this.MenuStrip.TabIndex = 7;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Transparent;
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EnterIP,
            this.EnterName,
            this.exitDialog,
            this.adminToolStripMenuItem,
            this.fdToolStripMenuItem});
            this.Menu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(53, 20);
            this.Menu.Text = "Меню";
            // 
            // EnterIP
            // 
            this.EnterIP.Name = "EnterIP";
            this.EnterIP.Size = new System.Drawing.Size(322, 22);
            this.EnterIP.Text = "Ввод IP";
            this.EnterIP.Click += new System.EventHandler(this.EnterIP_Click);
            // 
            // EnterName
            // 
            this.EnterName.Name = "EnterName";
            this.EnterName.Size = new System.Drawing.Size(322, 22);
            this.EnterName.Text = "Ввод Имени";
            this.EnterName.Click += new System.EventHandler(this.EnterName_Click);
            // 
            // exitDialog
            // 
            this.exitDialog.Name = "exitDialog";
            this.exitDialog.Size = new System.Drawing.Size(322, 22);
            this.exitDialog.Text = "Закончить диалог с текущим пользователем";
            this.exitDialog.Click += new System.EventHandler(this.exitDialog_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // fdToolStripMenuItem
            // 
            this.fdToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.fdToolStripMenuItem.Name = "fdToolStripMenuItem";
            this.fdToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.fdToolStripMenuItem.Text = "Выход";
            this.fdToolStripMenuItem.Click += new System.EventHandler(this.fdToolStripMenuItem_Click);
            // 
            // IPme
            // 
            this.IPme.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IPme.Name = "IPme";
            this.IPme.Size = new System.Drawing.Size(97, 20);
            this.IPme.Text = "Узнать свой IP";
            this.IPme.Click += new System.EventHandler(this.IPme_Click);
            // 
            // FileSend
            // 
            this.FileSend.Enabled = false;
            this.FileSend.Location = new System.Drawing.Point(214, 392);
            this.FileSend.Name = "FileSend";
            this.FileSend.Size = new System.Drawing.Size(114, 24);
            this.FileSend.TabIndex = 16;
            this.FileSend.Text = "Отправка файла";
            this.FileSend.UseVisualStyleBackColor = true;
            this.FileSend.Click += new System.EventHandler(this.FileSend_Click);
            // 
            // EmployeeName
            // 
            this.EmployeeName.BackColor = System.Drawing.SystemColors.Control;
            this.EmployeeName.Location = new System.Drawing.Point(343, 22);
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Size = new System.Drawing.Size(193, 398);
            this.EmployeeName.TabIndex = 17;
            this.EmployeeName.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.EmployeeName_NodeMouseDoubleClick);
            // 
            // IPtextBox
            // 
            this.IPtextBox.Enabled = false;
            this.IPtextBox.Location = new System.Drawing.Point(105, 28);
            this.IPtextBox.Multiline = true;
            this.IPtextBox.Name = "IPtextBox";
            this.IPtextBox.Size = new System.Drawing.Size(128, 21);
            this.IPtextBox.TabIndex = 18;
            this.IPtextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IPtextBox_KeyUp);
            // 
            // IPlabel
            // 
            this.IPlabel.AutoSize = true;
            this.IPlabel.BackColor = System.Drawing.Color.Transparent;
            this.IPlabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IPlabel.Location = new System.Drawing.Point(30, 30);
            this.IPlabel.Name = "IPlabel";
            this.IPlabel.Size = new System.Drawing.Size(69, 14);
            this.IPlabel.TabIndex = 19;
            this.IPlabel.Text = "IP-Address:";
            // 
            // Namelabel
            // 
            this.Namelabel.AutoSize = true;
            this.Namelabel.BackColor = System.Drawing.Color.Transparent;
            this.Namelabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Namelabel.Location = new System.Drawing.Point(57, 55);
            this.Namelabel.Name = "Namelabel";
            this.Namelabel.Size = new System.Drawing.Size(42, 14);
            this.Namelabel.TabIndex = 21;
            this.Namelabel.Text = "Name:";
            // 
            // NameBox
            // 
            this.NameBox.Enabled = false;
            this.NameBox.Location = new System.Drawing.Point(105, 53);
            this.NameBox.Multiline = true;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(128, 21);
            this.NameBox.TabIndex = 20;
            this.NameBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NameBox_KeyUp);
            // 
            // ChatLan
            // 
            this.AcceptButton = this.Send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChatLan.Properties.Resources.fak_izvestnak;
            this.ClientSize = new System.Drawing.Size(536, 418);
            this.Controls.Add(this.Namelabel);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.IPlabel);
            this.Controls.Add(this.IPtextBox);
            this.Controls.Add(this.FileSend);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.MessageB);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.EmployeeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChatLan";
            this.Text = "ChatLan";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.RichTextBox MessageB;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem fdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IPme;
        private System.Windows.Forms.ToolStripMenuItem exitDialog;
        private System.Windows.Forms.Button FileSend;
        private System.Windows.Forms.TreeView EmployeeName;
        private System.Windows.Forms.TextBox IPtextBox;
        private System.Windows.Forms.ToolStripMenuItem EnterIP;
        private System.Windows.Forms.Label IPlabel;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnterName;
        private System.Windows.Forms.Label Namelabel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
    }
}

