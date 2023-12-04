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
        public int UserType { get; private set; }
        public int UserId { get; private set; }
        public Login()
        {
            InitializeComponent();

        }

        public RuntimeUI RuntimeUI
        {
            get => default;
            set
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DataBaseManager.functionalityConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT uid, userName, pwd, uType FROM [User] WHERE userName=@userName AND pwd=@Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(reader.GetOrdinal("uid"));
                            int userType = reader.GetInt32(reader.GetOrdinal("uType"));

                            // Hide the login form
                            this.Hide();

                            // Create and show the main window (RuntimeUI)
                            using (var runtimeUi = new RuntimeUI(userType, userId))
                            {
                                runtimeUi.ShowDialog();
                            }

                            // If the RuntimeUI is closed, close the login form as well (this exits the application)
                            this.Close();
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
