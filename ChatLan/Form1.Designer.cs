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
            this.IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.newForm = new System.Windows.Forms.ToolStripMenuItem();
            this.exitDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.NameFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.fdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IPme = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProgramm = new System.Windows.Forms.ToolStripMenuItem();
            this.ComboName = new System.Windows.Forms.ToolStripComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.RichTextBox();
            this.FileSend = new System.Windows.Forms.Button();
            this.EmployeeName = new System.Windows.Forms.TreeView();
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
            this.ChatBox.Location = new System.Drawing.Point(11, 121);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.Size = new System.Drawing.Size(317, 196);
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
            // IP
            // 
            this.IP.BackColor = System.Drawing.SystemColors.Control;
            this.IP.Location = new System.Drawing.Point(113, 44);
            this.IP.Multiline = true;
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(91, 20);
            this.IP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(25, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP Adress:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImage = global::ChatLan.Properties.Resources.steel;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu,
            this.IPme,
            this.справкаToolStripMenuItem,
            this.ComboName});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(575, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Transparent;
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newForm,
            this.exitDialog,
            this.NameFormat,
            this.fdToolStripMenuItem});
            this.Menu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(53, 21);
            this.Menu.Text = "Меню";
            // 
            // newForm
            // 
            this.newForm.Name = "newForm";
            this.newForm.Size = new System.Drawing.Size(322, 22);
            this.newForm.Text = "Создать новое подключение";
            this.newForm.Click += new System.EventHandler(this.newForm_Click);
            // 
            // exitDialog
            // 
            this.exitDialog.Name = "exitDialog";
            this.exitDialog.Size = new System.Drawing.Size(322, 22);
            this.exitDialog.Text = "Закончить диалог с текущим пользователем";
            this.exitDialog.Click += new System.EventHandler(this.exitDialog_Click);
            // 
            // NameFormat
            // 
            this.NameFormat.Name = "NameFormat";
            this.NameFormat.Size = new System.Drawing.Size(322, 22);
            this.NameFormat.Text = "Изменить имя";
            this.NameFormat.Click += new System.EventHandler(this.NameFormat_Click);
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
            this.IPme.Size = new System.Drawing.Size(97, 21);
            this.IPme.Text = "Узнать свой IP";
            this.IPme.Click += new System.EventHandler(this.IPme_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutProgramm});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(71, 21);
            this.справкаToolStripMenuItem.Text = "Спра&вкач";
            // 
            // AboutProgramm
            // 
            this.AboutProgramm.Name = "AboutProgramm";
            this.AboutProgramm.Size = new System.Drawing.Size(156, 22);
            this.AboutProgramm.Text = "&О программе...";
            this.AboutProgramm.Click += new System.EventHandler(this.AboutProgramm_Click);
            // 
            // ComboName
            // 
            this.ComboName.Name = "ComboName";
            this.ComboName.Size = new System.Drawing.Size(115, 21);
            this.ComboName.Text = "Выберите имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(19, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ваше имя:";
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.SystemColors.Control;
            this.NameBox.Location = new System.Drawing.Point(113, 87);
            this.NameBox.Name = "NameBox";
            this.NameBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.NameBox.Size = new System.Drawing.Size(169, 21);
            this.NameBox.TabIndex = 10;
            this.NameBox.Text = "";
            this.NameBox.Leave += new System.EventHandler(this.NameBox_Leave);
            // 
            // FileSend
            // 
            this.FileSend.Location = new System.Drawing.Point(191, 392);
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
            // 
            // ChatLan
            // 
            this.AcceptButton = this.Send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChatLan.Properties.Resources.fak_izvestnak;
            this.ClientSize = new System.Drawing.Size(575, 418);
            this.Controls.Add(this.FileSend);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IP);
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
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem fdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IPme;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutProgramm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox NameBox;
        private System.Windows.Forms.ToolStripMenuItem exitDialog;
        private System.Windows.Forms.ToolStripMenuItem NameFormat;
        private System.Windows.Forms.ToolStripComboBox ComboName;
        private System.Windows.Forms.ToolStripMenuItem newForm;
        private System.Windows.Forms.Button FileSend;
        private System.Windows.Forms.TreeView EmployeeName;
    }
}

