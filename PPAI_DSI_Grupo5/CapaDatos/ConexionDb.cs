using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class ConexionDb
    {
        SqlConnection connection;
        SqlCommand cmd;

        string url_con = "Data Source=NALINO-PC\\SQLEXPRESS;Initial Catalog=DSI2022;Integrated Security=True";
        SqlDataReader reader;

        private void Connect(string sql)
        {
            connection = new SqlConnection(url_con);
            cmd = new SqlCommand(sql, connection);
            cmd.CommandTimeout = 60;
        }

        private void Disconnect()
        {
            connection.Close();
        }

        public DataTable Query(string sql)
        {
            Connect(sql);

            DataTable res = new DataTable();
            try
            {
                connection.Open();
                reader = cmd.ExecuteReader();

                res.Load(reader);
                Disconnect();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void NonQuery(string sql)
        {
            Connect(sql);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();

                Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Del_Upd(string sql)
        {
            Connect(sql);
            try
            {
                connection.Open();
                cmd.ExecuteReader();
                Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
