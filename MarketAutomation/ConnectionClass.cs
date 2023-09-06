using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace MarketAutomation
{
    class ConnectionClass
    {

        private static string mysqlcon = @"Server=localhost;Database=Market;Uid=root;Pwd='';";
        private static MySqlConnection con = new MySqlConnection();
        private static MySqlDataAdapter da = new MySqlDataAdapter();
        private static MySqlCommand cmd = new MySqlCommand();
        
        public static void baglanti()
        {
            con = new MySqlConnection(mysqlcon);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

        }
        
        public static object Command(string query)
        {

            object obj;
            cmd.Connection = con;
            cmd.CommandText = query;
            obj = cmd.ExecuteScalar();
           
            return obj;
           
        }

      

    }
}
