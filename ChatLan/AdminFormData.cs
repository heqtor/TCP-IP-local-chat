using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatLan
{
    public partial class AdminFormData : Form
    {
        private FtpServer deletFile;
        private ConnectDataAdmin newConnectData;
        private TreeViewFiling contentServer;

        public AdminFormData()
        {
            InitializeComponent();

            newConnectData = new ConnectDataAdmin();
            contentServer = new TreeViewFiling();
            deletFile = new FtpServer();
            newConnectData.DeleteData(15);
        }

        //вывод данных, сообщений
        private void Message_Click_1(object sender, EventArgs e)
        {
            newConnectData.SelectData(DataMessageGrid, "select * from Message");    
        }
        //содержание ftp
        private void FTPServer_Click_1(object sender, EventArgs e)
        {
            contentServer.SelectContentServerIntreeView(FTPServerTreeView);
        }
        //удаление файлов, с FTP
        private void FTPServerTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Вы точно хотите удалить данный файл ?", "Удаление файла",
                MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    deletFile.DeleteFile(FTPServerTreeView.SelectedNode.Text);
                    FTPServerTreeView.Nodes.Clear();
                    contentServer.SelectContentServerIntreeView(FTPServerTreeView);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }       
        }
        //удаление данных, содержащихся в базе данных
        private void DataMessageGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (DataMessageGrid.CurrentCell.OwningColumn.HeaderText == "Id")
                {
                    DialogResult result = MessageBox.Show("Вы точно хотите удалить данные этой строки ?", "Удаление данных",
                    MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(DataMessageGrid.CurrentCell.Value);
                        newConnectData.DeleteData(id);
                        newConnectData.SelectData(DataMessageGrid, "select * from Message");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }       
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
