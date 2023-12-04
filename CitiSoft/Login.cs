using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CitiSoft
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DataBaseManager.functionalityConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT userName, pwd, uType FROM [User] WHERE userName=@userName AND pwd=@Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Assume uType is the second column in the result
                            int userType = Convert.ToInt32(reader["uType"]);
                            int userId = Convert.ToInt32(reader["uid"]);

                            // Close the reader and open the RuntimeUI form with user type
                            reader.Close();
                            this.Hide();
                            RuntimeUI runtimeUI = new RuntimeUI(userType, userId);
                            runtimeUI.Closed += (s, args) => this.Close();
                            runtimeUI.Show();
                        }
                        else
                        {
                            MessageBox.Show("USER OR PASSWORD ARE INCORRECT");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }


}
