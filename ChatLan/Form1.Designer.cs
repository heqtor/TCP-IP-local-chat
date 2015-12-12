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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.newForm = new System.Windows.Forms.ToolStripMenuItem();
            this.EnterIP = new System.Windows.Forms.ToolStripMenuItem();
            this.exitDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.fdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IPme = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProgramm = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSend = new System.Windows.Forms.Button();
            this.EmployeeName = new System.Windows.Forms.TreeView();
            this.IPtextBox = new System.Windows.Forms.TextBox();
            this.IPlabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
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
            this.ChatBox.Location = new System.Drawing.Point(11, 55);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.Size = new System.Drawing.Size(317, 262);
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
            this.MessageB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MessageB_KeyUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImage = global::ChatLan.Properties.Resources.steel;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu,
            this.IPme,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(575, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Transparent;
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newForm,
            this.EnterIP,
            this.exitDialog,
            this.fdToolStripMenuItem});
            this.Menu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(53, 20);
            this.Menu.Text = "Меню";
            // 
            // newForm
            // 
            this.newForm.Name = "newForm";
            this.newForm.Size = new System.Drawing.Size(322, 22);
            this.newForm.Text = "Создать новое подключение";
            this.newForm.Click += new System.EventHandler(this.newForm_Click);
            // 
            // EnterIP
            // 
            this.EnterIP.Name = "EnterIP";
            this.EnterIP.Size = new System.Drawing.Size(322, 22);
            this.EnterIP.Text = "Ввод IP";
            this.EnterIP.Click += new System.EventHandler(this.EnterIP_Click);
            // 
            // exitDialog
            // 
            this.exitDialog.Name = "exitDialog";
            this.exitDialog.Size = new System.Drawing.Size(322, 22);
            this.exitDialog.Text = "Закончить диалог с текущим пользователем";
            this.exitDialog.Click += new System.EventHandler(this.exitDialog_Click);
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
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutProgramm});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.справкаToolStripMenuItem.Text = "Спра&вка";
            // 
            // AboutProgramm
            // 
            this.AboutProgramm.Name = "AboutProgramm";
            this.AboutProgramm.Size = new System.Drawing.Size(156, 22);
            this.AboutProgramm.Text = "&О программе...";
            this.AboutProgramm.Click += new System.EventHandler(this.AboutProgramm_Click);
            // 
            // FileSend
            // 
            this.FileSend.Location = new System.Drawing.Point(223, 392);
            this.FileSend.Name = "FileSend";
            this.FileSend.Size = new System.Drawing.Size(105, 24);
            this.FileSend.TabIndex = 16;
            this.FileSend.Text = "Отправка файла";
            this.FileSend.UseVisualStyleBackColor = true;
            // 
            // EmployeeName
            // 
            this.EmployeeName.BackColor = System.Drawing.SystemColors.Control;
            this.EmployeeName.Location = new System.Drawing.Point(343, 22);
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Size = new System.Drawing.Size(232, 398);
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
            // ChatLan
            // 
            this.AcceptButton = this.Send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChatLan.Properties.Resources.fak_izvestnak;
            this.ClientSize = new System.Drawing.Size(575, 418);
            this.Controls.Add(this.IPlabel);
            this.Controls.Add(this.IPtextBox);
            this.Controls.Add(this.FileSend);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.MessageB);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.EmployeeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChatLan";
            this.Text = "ChatLan";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.RichTextBox MessageB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem fdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IPme;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutProgramm;
        private System.Windows.Forms.ToolStripMenuItem exitDialog;
        private System.Windows.Forms.ToolStripMenuItem newForm;
        private System.Windows.Forms.Button FileSend;
        private System.Windows.Forms.TreeView EmployeeName;
        private System.Windows.Forms.TextBox IPtextBox;
        private System.Windows.Forms.ToolStripMenuItem EnterIP;
        private System.Windows.Forms.Label IPlabel;
    }
}

