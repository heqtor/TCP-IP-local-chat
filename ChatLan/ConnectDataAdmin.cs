using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ChatLan
{
    class ConnectDataAdmin : ConnectData
    {
        //переменная для таблицы, для содержания данных
        private DataTable newDataTable;
        protected DataTable NewDataTable
        {
            get { return newDataTable; }
            set { newDataTable = value; }
        }
        //переменная служит для определения номера таблицы, выбранной из БД
        private int numberTable;
        protected int NumberTable
        {
            get { return numberTable = 0; }
        }
        //добавление данных в таблицу
        public void SelectData(DataGridView newGridView, String sqlCommand)
        {
            try
            {
                newGridView.Rows.Clear();
                DataSet newSet = new DataSet();

                SqlConnection connection = ConnectionData();
                SqlDataAdapter newDataAdapter = new SqlDataAdapter(sqlCommand, connection);
                newDataAdapter.Fill(newSet);
                connection.Close();

                PrintData(newSet, numberTable, newGridView);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        //добавление данных в "главный" DataGridView
        private void PrintData(DataSet newSet, int indexTable, DataGridView newGridView)
        {
            try
            {
                NewDataTable = newSet.Tables[indexTable];

                newGridView.ColumnCount = NewDataTable.Columns.Count;
                newGridView.Rows.Add(NewDataTable.Rows.Count);

                for (int c = 0; c < NewDataTable.Columns.Count; c++)
                {
                    newGridView.Columns[c].HeaderText = NewDataTable.Columns[c].ToString().Trim();
                }

                for (int r = 0; r < newGridView.Rows.Count - 1 ; r++)
                {
                    for (int c = 0; c < NewDataTable.Columns.Count; c++)
                    {
                        newGridView.Rows[r].Cells[c].Value = NewDataTable.Rows[r][c].ToString().Trim();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не найдено данных по вашему запросу!", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        //удаленние данных из базы данных
        public void DeleteData(int id)
        {
            try
            {
                SqlConnection connection = ConnectionData();
                string sqlCommandDelete = string.Format("Delete from Message where Id ='{0}'", id);
                SqlCommand sqlCommand = new SqlCommand(sqlCommandDelete, connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }
    }
}
