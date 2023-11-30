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

                    string query = "SELECT email, pwd, uType FROM [User] WHERE email=@Email AND pwd=@Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Задаем DialogResult как OK, если логин успешен
                            this.DialogResult = DialogResult.OK;
                            this.Hide(); // Прячем форму логина, не закрываем
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
    }


}
