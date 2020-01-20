using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace kütüphane
{
    class Connection_sql
    {
        public static string conn()
        {
            string MyConn = @"SERVER=localhost;DATABASE=library;UID=root; PASSWORD=";
            return MyConn;
        }
        
    }
}
