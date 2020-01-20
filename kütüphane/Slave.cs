using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace kütüphane
{
    class Slave
    {

        public static string conn()
        {
            string MyConn = @"SERVER=localhost;DATABASE=library;UID=root; PASSWORD=";
            return MyConn;
        }

        public static DataTable BringData(string Mypar1)
        {
            MySqlConnection MyConnection = new MySqlConnection();
            MyConnection.ConnectionString = Connection_sql.conn();
            MyConnection.Open();
            string myQuery = Mypar1;
            MySqlDataAdapter MyAsistant = new MySqlDataAdapter(myQuery, MyConnection);
            DataTable dt = new DataTable();
            MyAsistant.Fill(dt);
            MyConnection.Close();
            return dt;
        }

        public static void SendData(string Mypar1)
        {
            MySqlConnection MyConnection = new MySqlConnection();
            MyConnection.ConnectionString = Connection_sql.conn();
            MyConnection.Open();
            string myQuery = Mypar1;
            //MySqlCommand cmd = new MySqlCommand(myQuery, MyConnection);
           MySqlDataAdapter MyAsistant = new MySqlDataAdapter(myQuery, MyConnection);
            DataTable dt = new DataTable();
            MyAsistant.Fill(dt);
            //cmd.ExecuteNonQuery();
            MyConnection.Close();
        }
    }
}
