using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CitiSoft
{
    public partial class ProblemHistoryForm : Form
    {
        public ProblemHistoryForm()
        {
            InitializeComponent();
        }

        private void addClientBtn_Click(object sender, EventArgs e)
        {

        }

        private void clientIDPHTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyNumbers(textBox);
        }

        private void problemIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyNumbers(textBox);
        }

        private void descriptionTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int length = 300; // 300 only characters can= be in a description text
            InputValidation.LimitLength(textBox, length, "Description text");
        }

        private void finishProblemBtn_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Functionality.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE ProblemHistory \r\n    SET isClosed = 1\r\nWHERE pid = @ProblemID;", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@ProblemID", problemIDTxtBox.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Problem finished.");
                            transaction.Commit(); // Only commit if no errors occurred
                        }
                        else
                        {
                            MessageBox.Show("Nothing was changed. It's possible that the problem did not exist.");
                            transaction.Rollback(); // Rollback if no rows affected
                        }
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback(); // Rollback on error
                    MessageBox.Show("An error occurred while finishing the problem: " + ex.Message);
                }
            }
        }

        private void clientIDPHLabel_Click(object sender, EventArgs e)
        {

        }
    }
}