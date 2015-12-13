using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
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
            //создание потоков для вывова метода чтения
            new Thread(new ThreadStart(Receivers)).Start();
            new Thread(new ThreadStart(ReceiversIP)).Start();
            

            //текущий ip addres
            IpAddressThisHost = Dns.Resolve(Dns.GetHostName()).AddressList[0];
            newConnect.IpAddressHost = IpAddressThisHost;
            //добавление сотрудников
            newConnect.SelectEmployeeNameIntreeView(EmployeeName);
            //имя пользователя
            thisName = newConnect.NameEmployee();

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

        //отправка сообщения
        private void SendMessage()
        {
            newConnect.InsertDataInBase(MessageB); 
            IPConnect = IPtextBox.Text;
            //передача сообщения
            Thread threadSendName = new Thread(new ParameterizedThreadStart(ThreadSendMes));
            threadSendName.Start(thisName + ": ");
            threadSendName.Join();
            Thread threadSend = new Thread(new ParameterizedThreadStart(ThreadSendMes));
            threadSend.Start(MessageB.Text + "\n");
            threadSend.Join();
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
            }
        }
        //метод позволяющий выполнять функцию Send_Click, по средствам нажатия клавиши Enter
        private void MessageB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Send_Click(sender, e);
        }
        //справка
        private void newForm_Click(object sender, EventArgs e)
        {
            Application.Run(new ChatLan());
        }
        //присвоение ip-адресу, значения 
        private void EmployeeName_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            IpConnect = newConnect.IpAddressList[EmployeeName.SelectedNode.Index];
            MessageB.Enabled = true;
            Send.Enabled = true;
        }
        //выбор ввода IP
        private void EnterIP_Click(object sender, EventArgs e)
        {
            IPtextBox.Enabled = true;
        }
        //ввод IP
        private void IPtextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                IPtextBox.Enabled = false;
                IPConnect = IPtextBox.Text;
                MessageB.Enabled = true;
                Send.Enabled = true;
            }
        }
        #endregion

       

        /*#region
        //прослушка файла
        
        private void ListenerFile()
        {
            TcpListener tcpListener = new TcpListener(6000);
            tcpListener.Start();
            Socket reciveSocket;
            while (true)
            {
                try
                {
                    reciveSocket = tcpListener.AcceptSocket();
                    byte[] recervesBytes = new byte[256];
                    //сообщение в поток
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        int CountRecervByte; //количество считаных байт
                        int First256Bytes = 0; //переменная первых 256 байт
                        string FilePath = ""; //имя файла
                        do
                        {
                            //читаем файл
                            CountRecervByte = reciveSocket.Receive(recervesBytes, recervesBytes.Length, 0);
                            //первые 256 байт
                            if (First256Bytes < 256)
                            {
                                First256Bytes += CountRecervByte;
                                byte[] str = recervesBytes;
                                //если больше 256 байт
                                if (First256Bytes > 256)
                                {
                                    int start = First256Bytes - CountRecervByte;
                                    int countToGet = 265 - start;
                                    First256Bytes = 256;
                                    //В случае если было принято > 256 байт (двумя сообщениями к примеру)
                                    //Остаток (до 256) записываем в "путь файла"
                                    str = recervesBytes.Take(countToGet).ToArray(); 
                                    //А остальную часть - в будующий файл
                                    recervesBytes = recervesBytes.Skip(countToGet).ToArray();
                                    memoryStream.Write(recervesBytes, 0 , CountRecervByte);
                                }
                                //Накапливаем имя файла
                                FilePath += Encoding.Default.GetString(str);
                            }
                            else
                            // Записываем имя файла в поток   
                            memoryStream.Write(recervesBytes, 0, CountRecervByte);    
                        } while (CountRecervByte == recervesBytes.Length);
                        //убираем лишние байты
                        string resFilePath = FilePath.Substring(0, FilePath.IndexOf('\0'));
                        //записываем в файл
                        using (FileStream fileStream = new FileStream(resFilePath, FileMode.Create) )
                        { 
                            fileStream.Write(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
                        }
                        //уведомим пользователя о файле
                        ChatBox.BeginInvoke(delegateSend, new object[] {resFilePath, ChatBox});
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        //Отправляем файл
        private void FileSend_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IPEndPoint newIP = new IPEndPoint(IPAddress.Parse(IP.Text), 6000);
                    Socket newSocket = new Socket(newIP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    newSocket.Connect(newIP);
                    //Получаем имя из полного пути к файлу
                    StringBuilder fileName = new StringBuilder(openFileDialog.FileName);
                    //Выделяем имя файла
                    int index = fileName.Length - 1;
                    while (fileName[index] != '\\' && fileName[index] != '/')
                    {
                        index--;
                    }
                    //Получаем имя файла
                    string resFileName = "";
                    for (int i = index + 1; i < fileName.Length; i++)
                    {
                        resFileName += fileName[i];
                    }
                    //Записываем в лист
                    List<byte> First256Bytes = Encoding.Default.GetBytes(resFileName).ToList();
                    int count = 256 - First256Bytes.Count;
                    for (int i = 0; i < count; i++)
                    {
                        First256Bytes.Add(0);
                    }
                    //Начиначение отправки данных
                    byte[] readBytes = new byte[256]; //кол байтов для записи
                    using (FileStream newFileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        using (BinaryReader newReader = new BinaryReader(newFileStream))
                        {
                            int CurrentReadedBytesCount;
                            //отправление названия файла
                            newSocket.Send(First256Bytes.ToArray());
                            do
                            {
                                //сам файл по частям
                                CurrentReadedBytesCount = newReader.Read(readBytes, 0, readBytes.Length);
                                newSocket.Send(readBytes, CurrentReadedBytesCount, SocketFlags.None);
                            }
                            while (CurrentReadedBytesCount == readBytes.Length);
                        }
                    }
                    newSocket.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }
        }
        #endregion*/
        
       

    }
}
