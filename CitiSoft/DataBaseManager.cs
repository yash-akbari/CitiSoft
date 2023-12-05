using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CitiSoft
{
    // class that contains all commonly used constants and methods
    partial class DataBaseManager
    {

        public static string functionalityConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Functionality.mdf;Integrated Security=True;Connect Timeout=30";
        public static string citiSoftDatabaseConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CitiSoftDatabase.mdf;Integrated Security=True;";//Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;";

        public Controller Controller
        {
            get => default;
            set
            {
            }
        }

        public static SqlConnection GetCitiSoftConnection()
        {
            return new SqlConnection(citiSoftDatabaseConnectionString);
        }
        public static SqlConnection GetFunctionalityConnection()
        {
            return new SqlConnection(functionalityConnectionString);
        }
    }
}
