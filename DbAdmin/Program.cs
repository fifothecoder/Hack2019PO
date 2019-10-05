using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DbAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "stcmicrosoft";
            string password = "MatejPenis123";
            string connectionstring = "";

            using (SqlConnection conn = new SqlConnection())
            {

            }

            Console.WriteLine("Connection open");
            Console.ReadLine();
        }



        
    }
}
