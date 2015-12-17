using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ChatLan.Properties;

namespace ChatLan
{
    public partial class ChatLan : Form
    {

 
        //экземпляр класса ConnectData
        private ConnectData newConnect;
        //экземпляр класса Delegate
        private Delegate newDelegate;
        private FtpServer neFtpServer;
        private TreeViewFiling newTreeFiling;

        //ip-адрес конечной точки подключения
        private string IpConnect;
        public string IPConnect
        {
            get { return IpConnect; }
            set { IpConnect = value; }
        }
        //переменная текущего имени пользователя
        private string thisName;
        public string ThisName
        {
            get { return thisName; }
            set { thisName = value; }
        }
        //ip-адресс текущего pc
        private IPAddress ipAddressThisHost;
        public IPAddress IpAddressThisHost
        {
            get { return ipAddressThisHost; }
            set { ipAddressThisHost = value; }
        }

        public ChatLan()
        {
            InitializeComponent();

            newConnect = new ConnectData();
            newDelegate = new Delegate(); 
            
            neFtpServer = new FtpServer();
            newTreeFiling = new TreeViewFiling();
            //создание потоков для вывова метода чтения
            new Thread(new ThreadStart(Receivers)).Start();
            new Thread(new ThreadStart(ReceiversIP)).Start();
            new Thread(new ThreadStart(ReceiversFileDowland)).Start();
            

            //текущий ip addres
            IpAddressThisHost = Dns.Resolve(Dns.GetHostName()).AddressList[0];
            newConnect.IpAddressHost = IpAddressThisHost;
            //добавление сотрудников
            newConnect.SelectEmployeeNameIntreeView(EmployeeName);
            //имя пользователя
            thisName = newConnect.NameEmployee();

            EmployeeName.ExpandAll();

            if (IPConnect == null)
            {
                Send.Enabled = false;
                MessageB.Enabled = false;
            }
        }

        #region Send and Receivers message
        //метод реализующий отправку сообщения 
        private void ThreadSendMes(object message)
        {   
            try
            {
                String MessageText = "";

                if (message is String)
                {
                    MessageText = message as String;
                }
                else
                {
                    throw new Exception("Нужна строка!");
                }
                //создание точки подключения к удалёному узлу по IP
                IPEndPoint newPoint = new IPEndPoint(IPAddress.Parse(IPConnect), 7000);
                //подключение у удалённому узлу 
                Socket socket = new Socket(newPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(newPoint);
                //кодировка текста сообщения
                Byte[] convertBytesMes = Encoding.Default.GetBytes(MessageText);
                //передача сообщения
                socket.Send(convertBytesMes);
                //socket.Send(convertBytesMes);
                socket.Close();
                //отображение сообщения 
                ChatBox.BeginInvoke(newDelegate.delegateSend, new object[] {MessageText, ChatBox});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //метод реализующий отправку сообщения 
        private void ThreadSendFileName(object message)
        {
            try
            {
                String MessageText = "";

                if (message is String)
                {
                    MessageText = message as String;
                }
                else
                {
                    throw new Exception("Нужна строка!");
                }
                //создание точки подключения к удалёному узлу по IP
                IPEndPoint newPoint = new IPEndPoint(IPAddress.Parse(IPConnect), 8000);
                //подключение у удалённому узлу 
                Socket socket = new Socket(newPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(newPoint);
                //кодировка текста сообщения
                Byte[] convertBytesMes = Encoding.Default.GetBytes(MessageText);
                //передача сообщения
                socket.Send(convertBytesMes);
                //socket.Send(convertBytesMes);
                socket.Close();
                ChatBox.BeginInvoke(newDelegate.delegateReqFile, new object[] { MessageText, ChatBox });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //отправка ip
        private void ThreadSendIpAddress(object ipAddress)
        {
            try
            {
                String MessageText = "";

                if (ipAddress is String)
                {
                    MessageText = ipAddress as String;
                }
                else
                {
                    throw new Exception("Нужна строка!");
                }
                //создание точки подключения к удалёному узлу по IP
                IPEndPoint newPoint = new IPEndPoint(IPAddress.Parse(IPConnect), 6000);
                //подключение у удалённому узлу 
                Socket socket = new Socket(newPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(newPoint);
                //кодировка текста сообщения
                Byte[] convertBytesMes = Encoding.Default.GetBytes(MessageText);
                //передача сообщения
                socket.Send(convertBytesMes);
                //socket.Send(convertBytesMes);
                socket.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //отправка файла
        private void FileSend_Click(object sender, EventArgs e)
        {
            neFtpServer.UploadFileOnFtp();
            Thread threadSendFileName = new Thread(new ParameterizedThreadStart(ThreadSendFileName));
            threadSendFileName.Start(neFtpServer.FileName);
            threadSendFileName.Join();
        }

        //отправка сообщения
        private void SendMessage()
        {
            newConnect.InsertDataInBase(MessageB); 
            IPConnect = IPtextBox.Text;

            //передача сообщения
            Thread threadSendName = new Thread(new ParameterizedThreadStart(ThreadSendMes));
            threadSendName.Start(thisName + ": " + MessageB.Text + "\n");
            threadSendName.Join();
            
            Thread threadSendIpAddress = new Thread(new ParameterizedThreadStart(ThreadSendIpAddress));
            threadSendIpAddress.Start(ipAddressThisHost.ToString());
            threadSendIpAddress.Join();
            MessageB.Text = "";
        }
           
        //метод реализующий приём сообщения 
        private void Receivers()
        {        
            TcpListener reListener = new TcpListener(7000);
            reListener.Start();
            Socket socketReciver;
            while (true)
            {
                try
                {
                    socketReciver = reListener.AcceptSocket();
                    Byte[] receBytes = new Byte[256];
                    //Чтение сообщения в поток
                    using (MemoryStream memoryMes = new MemoryStream())
                    {
                        //количество байт
                        Int32 receiverBytes;
                        do
                        {
                            //получаем число байтов
                            receiverBytes = socketReciver.Receive(receBytes, receBytes.Length, 0);
                            memoryMes.Write(receBytes, 0, receiverBytes);
                            //цикл продолжается до тех пор пока есть данные для считывания 
                        } while (socketReciver.Available > 0);
                        //отображение сообщения   
                        ChatBox.BeginInvoke(newDelegate.delegateSend, new object[] {Encoding.Default.GetString(memoryMes.ToArray()), ChatBox });
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }


        //метод реализующий приём сообщения 
        private void ReceiversFileDowland()
        {
            TcpListener reListener = new TcpListener(8000);
            reListener.Start();
            Socket socketReciver;
            while (true)
            {
                try
                {
                    socketReciver = reListener.AcceptSocket();
                    Byte[] receBytes = new Byte[256];
                    //Чтение сообщения в поток
                    using (MemoryStream memoryMes = new MemoryStream())
                    {
                        //количество байт
                        Int32 receiverBytes;
                        do
                        {
                            //получаем число байтов
                            receiverBytes = socketReciver.Receive(receBytes, receBytes.Length, 0);
                            memoryMes.Write(receBytes, 0, receiverBytes);
                            //цикл продолжается до тех пор пока есть данные для считывания 
                        } while (socketReciver.Available > 0);
                        //отображение сообщения    
                        BeginInvoke(newDelegate.delegateRecFile,
                           new object[] {Encoding.Default.GetString(memoryMes.ToArray()), neFtpServer, ChatBox});
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        //метод реализующий приём IP-адреса
        private void ReceiversIP()
        {
            TcpListener reListener = new TcpListener(6000);
            reListener.Start();
            Socket socketReciver;
            while (true)
            {
                try
                {
                    socketReciver = reListener.AcceptSocket();
                    Byte[] receBytes = new Byte[256];
                    //Чтение сообщения в поток
                    using (MemoryStream memoryMes = new MemoryStream())
                    {
                        //количество байт
                        Int32 receiverBytes;
                        do
                        {
                            //получаем число байтов
                            receiverBytes = socketReciver.Receive(receBytes, receBytes.Length, 0);
                            memoryMes.Write(receBytes, 0, receiverBytes);
                            //цикл продолжается до тех пор пока есть данные для считывания 
                        } while (socketReciver.Available > 0);
                        //отображение сообщения   
                        BeginInvoke(newDelegate.delegateIpAddress, new object[] { Encoding.Default.GetString(memoryMes.ToArray()), IPtextBox, Send, MessageB });
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
        #endregion

        #region Functional Application
        //отправка сообщения
        private void Send_Click(object sender, EventArgs e)
        {
            SendMessage();
        } 
        //пустая строка
        private void MessageB_MouseClick(object sender, MouseEventArgs e)
        {
            MessageB.Text = "";
        }
        //метод определяющий IP текущего компьютера
        private void IPme_Click(object sender, EventArgs e)
        { 
            MessageBox.Show("Ваш IP адрес: " + IpAddressThisHost, "AdressIP");
        }
        //инф. о программе
        private void AboutProgramm_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }
        //выход из программы
        private void fdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        //выход из диалога
        private void exitDialog_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Вы уверены, что хотите закончить диалог?", "",
                MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                IPConnect = "";
                ChatBox.Text = "";
                MessageB.Text = "";
                Send.Enabled = false;
                FileSend.Enabled = false;
                IPtextBox.Text = "";
            }
        }
        //метод позволяющий выполнять функцию Send_Click, по средствам нажатия клавиши Enter
        private void MessageB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Send_Click(sender, e);
        }
        //присвоение ip-адресу, значения 
        private void EmployeeName_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                IpConnect = newConnect.IpAddressList[EmployeeName.SelectedNode.Index];
                IPtextBox.Text = IpConnect;
                MessageB.Enabled = true;
                Send.Enabled = true;
                FileSend.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        //выбор ввода IP
        private void EnterIP_Click(object sender, EventArgs e)
        {
            IPtextBox.Enabled = true;
        }
        //ввод IP
        private void IPtextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    IPtextBox.Enabled = false;
                    IPConnect = IPtextBox.Text;
                    MessageB.Enabled = true;
                    Send.Enabled = true;
                    FileSend.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }      
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminFormData newForm = new AdminFormData();
            newForm.Show();
        }
        #endregion

        

    }
}
