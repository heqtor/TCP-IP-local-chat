using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatLan
{
    class ConnectData
    {
        //список сотрудников
        private List<string> newListIpAddress;
        public List<string> NewList
        {
            get { return newListIpAddress; }
            set { newListIpAddress = value; }
        }

        //переменная IP, как конечной точки соединения
        private IPAddress ipAddress;
        public IPAddress IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }
        //переменная box, для выбора точки соединения
        private ComboBox comboBox;
        public ComboBox ComboBox 
        {
            get { return comboBox; }
            set { comboBox = value; }
        }
        //перемення таблицы, содержания данных
        private DataTable newDataTable;
        public DataTable NewDataTable
        {
            get { return newDataTable; }
            set { newDataTable = value; }
        }
        //перемення выбора номера таблицы, содержащей данные
        private int newNumberTable;
        public int NewNumberTable
        {
            get { return newNumberTable = 0; }
        }

        private SqlConnection ConnectionData()
        {
            SqlConnection newConnection = new SqlConnection(@"Data Source = DEVELOP-ПК; Integrated Security=true; 
Initial Catalog = dulski;");
            newConnection.Open();
            return newConnection;
        }
     
        public void SelectData()
        {
            SqlDataReader newDataReader;
            SqlConnection connection = ConnectionData();
            string sqlCommand = string.Format("select IPAddress from IpAddress");
            SqlCommand newCommand = new SqlCommand(sqlCommand, connection);
            newDataReader = newCommand.ExecuteReader();


            newListIpAddress = new List<string>();
            while (newDataReader.Read())
            {
                for (int i = 0; i < newDataReader.FieldCount; i++)
                {
                    newListIpAddress.Add(newDataReader.GetValue(i).ToString().Trim());
                }
            }
        }

        public void SelectEmployeeNameIntreeView(TreeView newTreeViewNameEmployees)
        {
            TreeNode newNode = new TreeNode();
            for (int i = 0; i < newNode.Level; i++)
            {
                newNode.Nodes.Add(newListIpAddress[i]);
            }
            newTreeViewNameEmployees.Nodes.Add(newNode);
        }
        //запись элемента IP адреса
        //private void NameUser_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (NameUser.Text != "")
        //    {
        //        if (e.KeyData == Keys.Enter)
        //        {
        //            string addData = string.Format("set identity_insert IPAdress ON; " +
        //                                              "insert into IPAdress(IpID, IP, NameAdress)" +
        //                                              "values('{0}','{1}','{2}')",
        //                IdSelect(), IP.Text, NameUser.Text);
        //            NewConection.Close();
        //            NewConection.Open();
        //            NewCommand = new SqlCommand(addData, NewConection);
        //            NewCommand.ExecuteNonQuery();
        //            panelControl.Enabled = false;
        //            panelControl.Visible = false;
        //        }
        //    }
        //    else MessageBox.Show("Вы не ввели имя!");
        //}
        //добавление данных в котрол
        //private void AddDataInControl(ComboBox comboName)
        //{
        //    string addControl = string.Format("select NameAdress from IPAdress");
        //    NewConection.Close();
        //    NewConection.Open();
        //    NewCommand = new SqlCommand(addControl, NewConection);
        //    NewDataRead = NewCommand.ExecuteReader();
        //    while (NewDataRead.Read())
        //    {
        //        comboName.Items.Add(NewDataRead["NameAdress"]);
        //    }
        //}
        //выбор IP
        //private void ComboName_TextChanged(object sender, EventArgs e)
        //{
        //    string selectNew1 = string.Format("select IP, NameAdress from IPAdress");
        //    NewConection.Close();
        //    NewConection.Open();
        //    NewCommand = new SqlCommand(selectNew1, NewConection);
        //    NewDataRead = NewCommand.ExecuteReader();
        //    while (NewDataRead.Read())
        //    {
        //        if (ComboName.Text == NewDataRead["NameAdress"].ToString())
        //            IP.Text = NewDataRead["IP"].ToString();
        //    }
    }
}
