using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KPG
{
    class SQL
    {
        private static SqlConnection m_sql = null;

        private static string connectionString = "Data Source=QI2012DEV;" +
                                                    "Initial Catalog=QI_V_11780_KPG;" +
                                                    "User id=sa;" +
                                                    "Password=qw789as*;";

        public static SqlConnection GetConnection()
        {
            if (m_sql == null)
            {
                m_sql = new SqlConnection(connectionString);
                m_sql.Open();
            }

            return m_sql;
        }

        public static string GetProperty(string column, string table)
        {
            SqlCommand Command = new SqlCommand("SELECT " + column + " FROM " + table, GetConnection());
            return Command.ExecuteScalar().ToString();
        }
    }
}
