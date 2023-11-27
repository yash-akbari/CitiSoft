using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiSoft
{
    partial class DataBaseManager
    {

        public static string functionalityConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Functionality.mdf;Integrated Security=True;Connect Timeout=30";
        public static string citiSoftDatabaseConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CitiSoftDatabase.mdf;Integrated Security=True;Connect Timeout=30";

        public static SqlConnection GetCitiSoftConnection()
        {
            return new SqlConnection(citiSoftDatabaseConnectionString);
        }
    }
}
