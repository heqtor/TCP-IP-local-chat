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

        //переменная для записи имени отправляемого (получаемого) файла
        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        //переменная адреса ftp
        private string ftpName;
        public string FtpName
        {
            get { return ftpName = "ftp://192.168.1.7/"; }
        }

        //метод получения файла
        public string FileNameMethod(OpenFileDialog openFileDialog)
        {
            try
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
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return FileName;
        }
        //отправка файла на сервер
        public void UploadFileOnFtp()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string requstString = string.Format(FtpName + FileNameMethod(openFileDialog));
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(requstString);
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
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    string responce = string.Format("Загрузка файла завершена. Статус: {0}", response.StatusDescription);
                    MessageBox.Show(responce);
                    response.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            } 
        }
        //скачивание файла с сервера
        public void DowlandFile()
        {
            try
            {
                string requstString = string.Format(FtpName + FileName);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(requstString);
                // устанавливаем метод на загрузку файлов 
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                // получаем ответ от сервера в виде объекта FtpWebResponse 
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                // получаем поток ответа 
                Stream responseStream = response.GetResponseStream();
                // сохраняем файл в дисковой системе 
                // создаем поток для сохранения файла 
                FileStream fs = new FileStream(FileName, FileMode.Create);
                //Буфер для считываемых данных 
                byte[] buffer = new byte[64];
                int size = 0;
                while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, size);
                }
                fs.Close();
                response.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        //содержание сервера
        public string ContentFileServer()
        {
            string result = null;
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FtpName);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responceStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responceStream);
                result = reader.ReadToEnd();
                reader.Close();
                responceStream.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return result;
        }
        //удаление файла с сервера
        public void DeleteFile(string nameFile)
        {
            try
            {
                string requstString = string.Format(FtpName + nameFile);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(requstString);
                // устанавливаем метод на загрузку файлов 
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                // получаем ответ от сервера в виде объекта FtpWebResponse 
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                string responce = string.Format("Файл удален. Статус: {0}", response.StatusDescription);
                MessageBox.Show(responce);
                response.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            } 
        }
    }
}
