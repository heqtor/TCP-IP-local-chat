using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatLan
{
    class TreeViewFiling
    {
        //переменная для вызова метода "содержания сервера"
        private FtpServer newFtpServer = new FtpServer();
        
        //заполнение "дерева" содержим сервера
        public void SelectContentServerIntreeView(TreeView newTreeViewContentServer)
        {
            try
            {
                newFtpServer = new FtpServer();
                //коллекция изображений узлов
                ImageList newImageList = new ImageList();
                newImageList.ImageSize = new Size(16, 16);
                newImageList.Images.Add(Properties.Resources.exel);
                newImageList.Images.Add(Properties.Resources.word);
                newImageList.Images.Add(Properties.Resources.txt);
                newImageList.Images.Add(Properties.Resources.html);
                newImageList.Images.Add(Properties.Resources.dll);
                newImageList.Images.Add(Properties.Resources.pp);
                newImageList.Images.Add(Properties.Resources.image);
                newImageList.Images.Add(Properties.Resources.circle_green_6052);
                newTreeViewContentServer.ImageList = newImageList;
                //добавление узлов
                List<string> ListNodesName = new List<string>() { "XLSX", "DOC", "TXT", "HTML", "DLL", "PPTX", "JPG" };
                for (int i = 0; i < ListNodesName.Count; i++)
                {
                    newTreeViewContentServer.Nodes.Add(new TreeNode { Text = ListNodesName[i], ImageIndex = i, SelectedImageIndex = i });
                }
                //выделение имен файлов, содержащихся на сервере
                string[] nameFileResult1 = newFtpServer.ContentFileServer().Split(char.Parse("\r"));
                string[] nameFileResult2 = new string[nameFileResult1.Length - 1];
                for (int i = 0; i < nameFileResult1.Length - 1; i++)
                {
                    nameFileResult2[i] = nameFileResult1[i].Substring(nameFileResult1[i].LastIndexOf(' ') + 1);
                }
                //типы документов в нижнем регистре
                string[] ListFileName = new string[ListNodesName.Count];
                for (int i = 0; i < ListNodesName.Count; i++)
                {
                    ListFileName[i] = ListNodesName[i].ToLower().ToString();
                }
                //цикл добавления файлов
                for (int i = 0; i < nameFileResult2.Length; i++)
                {
                    for (int j = 0; j < ListFileName.Length; j++)
                    {
                        if (nameFileResult2[i].Substring(nameFileResult2[i].IndexOf(".") + 1) == ListFileName[j])
                        {
                            newTreeViewContentServer.Nodes[j].Nodes.Add(new TreeNode { Text = nameFileResult2[i], ImageIndex = j, SelectedImageIndex = j });
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
