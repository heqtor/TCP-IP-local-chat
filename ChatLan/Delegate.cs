using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatLan
{
    class Delegate
    {
        public delegate void DelegateSendMsg(string txt, RichTextBox rtb);
        //объект делегата реализующий метод заполнения "ричбокса" сообщением 
        public DelegateSendMsg delegateSend = (string txt, RichTextBox rtb) =>
        {
            rtb.Text += txt;
        };

        public delegate void DelegateIpAddress(string txt, TextBox IpAddress, Button sendButton, RichTextBox messageBox);
        //объект делегата реализующий метод заполнения "ричбокса" сообщением 
        public DelegateIpAddress delegateIpAddress = (string txt, TextBox IpAddress, Button sendButton, RichTextBox messageBox) =>
        {
            IpAddress.Text = txt;
            messageBox.Enabled = true;
            sendButton.Enabled = true;
        };

        public delegate void DelegateRecFile(string txt, FtpServer neFtpServer, RichTextBox rtb);
        //объект делегата реализующий метод скачивания файла
        public DelegateRecFile delegateRecFile = (string txt, FtpServer neFtpServer, RichTextBox rtb) =>
        {
            string text = "Скачать файл: " + txt +" ?";
            DialogResult dialog = MessageBox.Show(text, "Принимаемый файл", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                neFtpServer.DowlandFile();
                rtb.Text += "Скачан файл: "+ txt + "\n";
            }
            else
            {
                rtb.Text += "Ошибка скачивания файла: " + txt + "\n";
            }
        };

        public delegate void DelegateReqFile(string txt,  RichTextBox rtb);
        //объект делегата реализующий метод отображения отправленного файла
        public DelegateReqFile delegateReqFile = (string txt, RichTextBox rtb) =>
        {
            rtb.Text += "Отправлен файл: " + txt + "\n";

        }; 
    } 
} 
