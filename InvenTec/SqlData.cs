using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvenTec
{
    internal class SqlData
    {
        private SqlConnection sqlConnection;

        public SqlData(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void Open()
        {
            sqlConnection.Open();
        }

        public void Close()
        {
            sqlConnection.Close();
        }

        public SqlDataReader ExecuteSqlQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            return cmd.ExecuteReader();
        }
    }

}
