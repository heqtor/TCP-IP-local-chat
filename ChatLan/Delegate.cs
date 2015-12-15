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
        //объект делегата реализущий метод заполнения "ричбокса" сообщением 
        public DelegateSendMsg delegateSend = (string txt, RichTextBox rtb) =>
        {
            rtb.Text += txt;
        };

        public delegate void DelegateIpAddress(string txt, TextBox IpAddress, Button sendButton, RichTextBox messageBox);
        //объект делегата реализущий метод заполнения "ричбокса" сообщением 
        public DelegateIpAddress delegateIpAddress = (string txt, TextBox IpAddress, Button sendButton, RichTextBox messageBox) =>
        {
            IpAddress.Text = txt;
            messageBox.Enabled = true;
            sendButton.Enabled = true;
        };

        public delegate void DelegateRecFile(string txt, FtpServer neFtpServer);
        //объект делегата реализущий метод заполнения "ричбокса" сообщением 
        public DelegateRecFile delegateRecFile = (string txt, FtpServer neFtpServer) =>
        {
            string a = "Имя файла " + txt;
            DialogResult dialog = MessageBox.Show(a, "Принимаемый файл", MessageBoxButtons.OKCancel);

            if (dialog == DialogResult.OK)
            {
                neFtpServer.DowlandFile();
            }
        }; 
    } 
} 
