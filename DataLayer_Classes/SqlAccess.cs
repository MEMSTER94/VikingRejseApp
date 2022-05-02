using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace VikingRejseApp
{
    public class SqlAccess
    {
        SqlConnection connection = null;

        public SqlAccess()
        {
            SqlConnect();
        }

        bool SqlConnect()
        {
            string cs;
            cs = "Data Source=(LocalDB)\\MSSQLLocalDB;Database=VikingRejser";
            connection = new SqlConnection();
            connection.ConnectionString = cs;
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (SqlException)
            {
                return false;
            }
            return true;
        }
        public DataTable ExecuteSql(string sql)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            DataTable table = ExecuteCmd(cmd);
            connection.Close();
            return table;
        }
        private DataTable ExecuteCmd(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            return table;
        }
    }
}
