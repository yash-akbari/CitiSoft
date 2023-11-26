using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    public class Class1
    {

        public static void insertValues()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Variables.citiSoftDatabaseConnectionString))
                {
                    string query = @"
                INSERT INTO VendorInfo (compName, est, empCount, intProfServ, lstDemoDt, lstRevInt, lstRevDt) 
                VALUES (@compName, @est, @empCount, @intProfServ, @lstDemoDt, @lstRevInt, @lstRevDt);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Replace the following with actual values
                        command.Parameters.AddWithValue("@compName", "Your Company Name");
                        command.Parameters.AddWithValue("@est", 1990); // Example establishment year
                        command.Parameters.AddWithValue("@empCount", 50); // Example employee count
                        command.Parameters.AddWithValue("@intProfServ", true); // Example international professional services flag
                        command.Parameters.AddWithValue("@lstDemoDt", DateTime.Now); // Example last demo date
                        command.Parameters.AddWithValue("@lstRevInt", 6); // Example last review interval (in months)
                        command.Parameters.AddWithValue("@lstRevDt", DateTime.Now); // Example last review date

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
