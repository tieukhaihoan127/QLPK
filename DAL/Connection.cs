using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Connection
    {
        private static SqlConnection cn;

        public static void connect()
        {
            string connect = "Server=LAPTOP-JJ3K8KOK; Database=QuanLyPhongKham; Integrated Security=True;TrustServerCertificate=true";
            cn = new SqlConnection(connect);
            cn.Open();
        }

        public static void close()
        {
            cn.Close();
        }

        public static void actionQuery(string query)
        {
            connect();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
            close();
        }

        public static Boolean haveQuery(string query)
        {
            connect();
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataTable selectQuery(string query)
        {
            connect();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query,cn);
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);
            return dt;
        }
    }
}
