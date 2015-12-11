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

        #region Delegate

        private delegate void DelegateSendMsg(string txt, RichTextBox rtb);
        //объект делегата реализущий метод заполнения "ричбокса" сообщением 
        private DelegateSendMsg delegateSend = (string txt, RichTextBox rtb) =>
        {
            rtb.Text += txt;           
        };
        #endregion

        ConnectData newConnect = new ConnectData();

        public ChatLan()
        {
            InitializeComponent();
            //создание потока для вывова метода Recivers
            new Thread(new ThreadStart(Receivers)).Start();
            newConnect.SelectEmployeeNameIntreeView(EmployeeName);
            
            //treeView1.BeginUpdate();
            //treeView1.Nodes.Add("Сотрудники");
            //treeView1.Nodes.Add("Rjkz");
            //treeView1.Nodes[0].Nodes.Add("Специалист по кредитам");
            //for (int i = 1; i < 5; i++)
            //{
            //    treeView1.Nodes[0].Nodes.Add("Специалист по кредитам");
            //}
            //treeView1.Nodes[0].ImageIndex = 0;
            //for (int i = 1; i < 10; i++)
            //{
            //    treeView1.Nodes[1].Nodes.Add("Специалист по кредитам");
            //}
            
        }

        #region Send and Receivers message
        //метод реализующий отправку сообщения 
        private void ThreadSendMes(object Message)
        {   
            try
            {
                String MessageText = "";

                if (Message is String)
                {
                    MessageText = Message as String;
                }
                else
                {
                    throw new Exception("Нужна строка!");
                }
                //создание точки подключения к удалёному узлу по IP
                IPEndPoint newPoint = new IPEndPoint(IPAddress.Parse(IP.Text), 7000);
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
                ChatBox.BeginInvoke(delegateSend, new object[] {MessageText, ChatBox});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //метод реализующий отправку имени
        private void ThreadSendName(object name)
        {
            try
            {
                String NameText = "";
                //проверка наличия строки имени
                if (name is String)
                {
                    NameText = name as String;
                }
                else
                {
                    throw new Exception("Нужна строка!");
                }
                //создание точки подключения к удалёному узлу по IP
                IPEndPoint newPoint = new IPEndPoint(IPAddress.Parse(IP.Text), 7000);
                //подключение у удалённому узлу 
                Socket socket = new Socket(newPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(newPoint);
                //кодировка текста сообщения 
                Byte[] convertBytesName = Encoding.Default.GetBytes(NameText);
                //передача сообщения
                socket.Send(convertBytesName);
                socket.Close();
                //отображение сообщения 
                ChatBox.BeginInvoke(delegateSend, new object[] {NameText, ChatBox});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //обработчик кнопки отправки сообщения
        private void Send_Click(object sender, EventArgs e)
        {
            IP.ReadOnly = true;
            Thread threadSendName = new Thread(new ParameterizedThreadStart(ThreadSendName));
            threadSendName.Start(NameBox.Text + ": ");
            threadSendName.Join();
            Thread threadSend = new Thread(new ParameterizedThreadStart(ThreadSendMes));
            threadSend.Start(MessageB.Text + "\n");
            threadSend.Join();
            MessageB.Text = "";
            ComboName.Enabled = false;
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
                        ChatBox.BeginInvoke(delegateSend, new object[] {Encoding.Default.GetString(memoryMes.ToArray()), ChatBox });
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
        //пустая строка
        private void MessageB_MouseClick(object sender, MouseEventArgs e)
        {
            MessageB.Text = "";
        }
        //метод определяющий IP текущего компьютера
        private void IPme_Click(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName();
            IPAddress ip = Dns.Resolve(hostName).AddressList[0];
            MessageBox.Show("Ваш IP адрес: " + ip, "AdressIP");
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
                IP.ReadOnly = false;
                ChatBox.Text = "";
                IP.Text = "";
                MessageB.Text = "";
                ComboName.Enabled = true;
                Send.Enabled = false;
                ComboName.Items.Clear();    
            }
        }
        //метод позволяющий выполнять функцию Send_Click, по средствам нажатия клавиши Enter
        private void MessageB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Send_Click(sender, e);
        }
        //изменение имени пользователя
        private void NameFormat_Click(object sender, EventArgs e)
        {
            NameBox.Enabled = true;
            NameBox.Focus();
        }
        //событие подтверждения имени
        private void NameBox_Leave(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show("Использовать это имя?", "", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.No)
            {
                NameBox.Focus();
            }
            else if (result == DialogResult.Yes)
            {
                NameBox.Enabled = false;
            }        
        }

        private void newForm_Click(object sender, EventArgs e)
        {
            Application.Run(new ChatLan());
        }
        #endregion

        private void EmployeeName_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            IP.Text = newConnect.IpAddressList[EmployeeName.SelectedNode.Index];
        }

        

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
