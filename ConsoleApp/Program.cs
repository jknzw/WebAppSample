using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppLib;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteUtility util = new SQLiteUtility("ConsolApp.db");
            util.Connect();

            string sql = "CREATE TABLE IF NOT EXISTS decimal_table(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "decimal REAL)";

            util.Execute(sql);


        }
    }
}
