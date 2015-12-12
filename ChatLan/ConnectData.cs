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
        //имя текущего хоста
        private String hostName = null;
        public String HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }
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
        private SqlConnection ConnectionData()
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
                string indexIdSelect = string.Format("select IndexIP from IpAddress where IpAddress = '{0}'", IpAddressHost);
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
            try
            {
                string selectName = string.Format("select Employee.SecondName, Employee.Name from Employee, " +
                                "IpAddress where IpAddress = '{0}' and IpAddress.IndexIP = Employee.IndexIP", IpAddressHost.ToString());
                SelectData(selectName, nameList);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return nameList[0] + " " + nameList[1];
        }
    }
}
