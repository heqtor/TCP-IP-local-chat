using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;

namespace ChatLan
{
    class ConnectData
    {
        //ip текущего хоста
        private IPAddress ipAddressHost;
        public IPAddress IpAddressHost
        {
            get { return ipAddressHost; }
            set { ipAddressHost = value; }
        }

        //список Ip-адресов, сотрудников
        private List<string> ipAddressList=new List<string>();
        public List<string> IpAddressList
        {
            get { return ipAddressList; }
            set { ipAddressList = value; }
        }

        //список Имен, сотрудников
        private List<string> employeeListName = new List<string>();
        //список Фамилий, сотрудников
        private List<string> employeeListSecondName = new List<string>();

        //переменная IP, как конечной точки соединения
        private IPAddress ipAddress;
        public IPAddress IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        //метод соединения с базой данных
        virtual public SqlConnection ConnectionData()
        {
            SqlConnection newConnection = new SqlConnection(@"Data Source = DEVELOP-ПК; Integrated Security=true; 
Initial Catalog = dulski;");
            newConnection.Open();
            return newConnection;
        }
        //метод выяполнени sql запросов, заполнения списков
        public void SelectData(string select, List<string> nameList )
        {

            SqlConnection connectionDataBase = ConnectionData();
            string sqlCommand = select;
            SqlCommand newSqlCommand = new SqlCommand(sqlCommand, connectionDataBase);
            SqlDataReader newSqlDataReader = newSqlCommand.ExecuteReader();

            
            while (newSqlDataReader.Read())
            {
                for (int i = 0; i < newSqlDataReader.FieldCount; i++)
                {
                    nameList.Add(newSqlDataReader.GetValue(i).ToString().Trim());
                }
            }
            newSqlDataReader.Close();  
            connectionDataBase.Close();
        }

        private void SelectDataLists()
        {
            SelectData("select IpAddress from IpAddress, Employee where Employee.IndexIP=IpAddress.IndexIP", ipAddressList);
            SelectData("select Employee.Name from IpAddress, Employee where Employee.IndexIP=IpAddress.IndexIP", employeeListName);
            SelectData("select Employee.SecondName from IpAddress, Employee where Employee.IndexIP=IpAddress.IndexIP", employeeListSecondName);

        }
        //заполнение "сотрудниками" "дерева"
        public void SelectEmployeeNameIntreeView(TreeView newTreeViewNameEmployees)
        {
            SelectDataLists();
            newTreeViewNameEmployees.Nodes.Add("Сотрудники");

            for (int i = 0; i < ipAddressList.Count; i++)
            {
                newTreeViewNameEmployees.Nodes[0].Nodes.Add(employeeListName[i] +" "+ employeeListSecondName[i]);
            }
        }
        //запись элемента IP адреса
        public void InsertDataInBase(RichTextBox messageBox)
        {
            List<string> indexList = new List<string>();
            try
            {
                //получение индекса IP
                string indexIdSelect = string.Format("select IndexIP from IpAddress where IpAddress = '{0}'", IpAddressHost.ToString().Trim());
                SelectData(indexIdSelect, indexList);
                int indexIp = Convert.ToInt32(indexList[0]);

                string sql = string.Format("insert into Message" +
                      "(DateTime, Text, IndexIP) Values('{0}', '{1}', {2})", DateTime.Now, messageBox.Text, indexIp);
                SqlConnection newSqlConnection = ConnectionData();
                SqlCommand cmd = new SqlCommand(sql, newSqlConnection);
                cmd.ExecuteNonQuery();
                newSqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }       
        }
        //метод индетификации имени
        public string NameEmployee()
        {
            List<string> nameList = new List<string>();
            string name = null;
            try
            {
                string selectName = string.Format("select Employee.SecondName, Employee.Name from Employee, " +
                                "IpAddress where IpAddress = '{0}' and IpAddress.IndexIP = Employee.IndexIP", IpAddressHost.ToString().Trim());
                SelectData(selectName, nameList);
                name = nameList[0] + " " + nameList[1];
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return name;
        }
    }
}
