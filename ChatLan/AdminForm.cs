using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChatLan
{
    public partial class AdminForm : Form
    {

        private DataGridView MessageData;
        private RichTextBox FtpContent;

        ConnectDataAdmin newConnectData;

        public AdminForm()
        {
            InitializeComponent();
            newConnectData = new ConnectDataAdmin();
        }

        private void Message_Click(object sender, EventArgs e)
        {
            MessageData = new DataGridView();
            this.Controls.Remove(FtpContent);
            this.Controls.Add(this.MessageData);
            
            this.MessageData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MessageData.Location = new Point(0, 27);
            this.MessageData.Name = "MessageData";
            this.MessageData.RowTemplate.Height = 23;
            this.MessageData.Size = new Size(488, 284);
            this.MessageData.TabIndex = 1;
            newConnectData.SelectData(MessageData, "select * from Message");
        }

        private void FTPServer_Click(object sender, EventArgs e)
        {
            FtpContent = new RichTextBox();
            this.Controls.Remove(MessageData);
            this.Controls.Add(this.FtpContent);
            
            this.FtpContent.Location = new Point(0, 27);
            this.FtpContent.Name = "FtpContent";
            this.FtpContent.Size = new Size(488, 283);
            this.FtpContent.TabIndex = 1;
            this.FtpContent.Text = "";  
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            
        }
    }
}
