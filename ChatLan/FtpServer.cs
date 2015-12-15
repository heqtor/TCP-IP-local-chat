using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatLan
{
    internal class FtpServer
    {


        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string FileNameMethod(OpenFileDialog openFileDialog)
        {
            //Получаем имя из полного пути к файлу
            StringBuilder fileName = new StringBuilder(openFileDialog.FileName);
            //Выделяем имя файла
            int index = fileName.Length - 1;
            while (fileName[index] != '\\' && fileName[index] != '/')
            {
                index--;
            }
            //Получаем имя файла
            
            for (int i = index + 1; i < fileName.Length; i++)
            {
                FileName += fileName[i];
            }
            return FileName;
        }

        public void UploadFileOnFtp()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string requstString = string.Format("ftp://10.37.2.224/" + FileNameMethod(openFileDialog));
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(requstString);
                // устанавливаем метод на загрузку файлов
                request.Method = WebRequestMethods.Ftp.UploadFile;
                // создаем поток для загрузки файла 
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                byte[] fileContents = new byte[fs.Length];
                fs.Read(fileContents, 0, fileContents.Length);
                fs.Close();
                request.ContentLength = fileContents.Length;
                // пишем считанный в массив байтов файл в выходной поток 
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();
                // получаем ответ от сервера в виде объекта FtpWebResponse 
                FtpWebResponse response = (FtpWebResponse) request.GetResponse();
                MessageBox.Show("Загрузка файлов завершена. Статус: {0}", response.StatusDescription);
                response.Close();
            }
        }

        public void DowlandFile()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://10.37.2.224/newtest12.txt");
            // устанавливаем метод на загрузку файлов 
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            // получаем ответ от сервера в виде объекта FtpWebResponse 
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            // получаем поток ответа 
            Stream responseStream = response.GetResponseStream();
            // сохраняем файл в дисковой системе 
            // создаем поток для сохранения файла 
            FileStream fs = new FileStream("newtest12.txt", FileMode.Create);
            //Буфер для считываемых данных 
            byte[] buffer = new byte[64];
            int size = 0;
            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, size);
            }
            fs.Close();
            response.Close();
            Console.WriteLine("Загрузка и сохранение файла завершены");
            Console.Read();
        }
    }
}
