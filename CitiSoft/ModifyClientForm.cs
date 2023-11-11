using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class ModifyClientForm : Form
    {
        public ModifyClientForm()
        {
            InitializeComponent();
        }

        private void updateClientBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Functionality.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand($"UPDATE Client\r\nSET compName = {companyNameTxtBox.Text}\r\nWHERE cid = {clientIDTxtBox.Text}\r\n\r\nUPDATE CustAddress\r\nSET phone = {phoneTxtBox.Text}, email = {emailTxtBox.Text}, Street = {streetTxtBox.Text}, City = {cityTxtBox.Text}, Cointry = {countryTxtBox.Text}\r\nWHERE cid = {clientIDTxtBox.Text};", connection, transaction))
                    {
                        //command.Parameters.AddWithValue("@ClientID", deleteIDTextBox.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Update successful.");
                            transaction.Commit(); // Only commit if no errors occurred
                        }
                        else
                        {
                            MessageBox.Show("No rows Updated. It's possible that the client did not exist.");
                            transaction.Rollback(); // Rollback if no rows affected
                        }
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback(); // Rollback on error
                    MessageBox.Show("An error occurred while updating the client: " + ex.Message);
                }
            }
        }

        private void deleteClientBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Functionality.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand("DELETE FROM CustAddress WHERE cid = @ClientID DELETE FROM Client WHERE cid = @ClientID;", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@ClientID", deleteIDTextBox.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Delete successful.");
                            transaction.Commit(); // Only commit if no errors occurred
                        }
                        else
                        {
                            MessageBox.Show("No rows deleted. It's possible that the client did not exist.");
                            transaction.Rollback(); // Rollback if no rows affected
                        }
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback(); // Rollback on error
                    MessageBox.Show("An error occurred while deleting the client: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ModifyClientForm_Load(object sender, EventArgs e)
        {

        }

        private void clientIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string input = textBox.Text;
                foreach (char c in input)
                {
                    if (!char.IsDigit(c))
                    {
                        // Show a message or handle the invalid character
                        MessageBox.Show("Only numbers are allowed.");

                        // Remove the last character
                        textBox.Text = input.Substring(0, input.Length - 1);

                        // Set the cursor position to the end of the text
                        textBox.SelectionStart = textBox.Text.Length;
                        textBox.SelectionLength = 0;

                        break;
                    }
                }
            }
        }

        private void companyNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string input = textBox.Text;
                // checks for length
                if (textBox.Text.Length > 30)
                {
                    MessageBox.Show("Company Name is too long");
                }
                else
                {
                    foreach (char c in input)
                    {
                        if (!char.IsLetter(c) && c != ' ') // Allow letters and spaces
                        {
                            // Show a message or handle the invalid character
                            MessageBox.Show("Only letters and spaces are allowed.");

                            // Remove the last character
                            textBox.Text = input.Substring(0, input.Length - 1);

                            // Set the cursor position to the end of the text
                            textBox.SelectionStart = textBox.Text.Length;
                            textBox.SelectionLength = 0;

                            break;
                        }
                    }
                }
            }
        }

        private void countryTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string input = textBox.Text;
                // checks for length
                if (input.Length > 30)
                {
                    MessageBox.Show("Country name is too long");
                }
                else
                {
                    foreach (char c in input)
                    {
                        if (!char.IsLetter(c)) // Allow letters
                        {
                            // Show a message or handle the invalid character
                            MessageBox.Show("Only letters are allowed.");

                            // Remove the last character
                            textBox.Text = input.Substring(0, input.Length - 1);

                            // Set the cursor position to the end of the text
                            textBox.SelectionStart = textBox.Text.Length;
                            textBox.SelectionLength = 0;

                            break;
                        }
                    }
                }
            }
        }

        private void cityTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string input = textBox.Text;
                // checks for length
                if (input.Length > 30)
                {
                    MessageBox.Show("City name is too long");
                }
                else
                {
                    foreach (char c in input)
                    {
                        if (!char.IsLetter(c)) // Allow letters
                        {
                            // Show a message or handle the invalid character
                            MessageBox.Show("Only letters are allowed.");

                            // Remove the last character
                            textBox.Text = input.Substring(0, input.Length - 1);

                            // Set the cursor position to the end of the text
                            textBox.SelectionStart = textBox.Text.Length;
                            textBox.SelectionLength = 0;

                            break;
                        }
                    }
                }
            }
        }

        private void streetTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string input = textBox.Text;
                // checks for length
                if (input.Length > 30)
                {
                    MessageBox.Show("Street address is too long");
                }
                else
                {
                    foreach (char c in input)
                    {
                        if (!char.IsLetterOrDigit(c) && c != ' ' && c != '.') // Allow letters spaces and numbers
                        {
                            // Show a message or handle the invalid character
                            MessageBox.Show("Only letters, spaces and numbers are allowed.");

                            // Remove the last character
                            textBox.Text = input.Substring(0, input.Length - 1);

                            // Set the cursor position to the end of the text
                            textBox.SelectionStart = textBox.Text.Length;
                            textBox.SelectionLength = 0;

                            break;
                        }
                    }
                }
            }
        }

        // checks only after the enter key was pressed
        private void emailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textBox = sender as TextBox;
                // checks for length
                if (textBox.Text.Length > 30)
                {
                    MessageBox.Show("Email is too long.");
                }
                if (textBox != null && !IsValidEmail(textBox.Text))
                {
                    MessageBox.Show("Invalid email format.");
                
                }
            }
        }

        // checks if the text is email structured
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    var idn = new System.Globalization.IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }

                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        private void phoneTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string input = textBox.Text;

                // checks for length
                if (input.Length > 15)
                {
                    MessageBox.Show("Number is too long");
                }
                else
                {
                    foreach (char c in input)
                    {
                        if (!char.IsDigit(c) && c != ' ' && c != '+') // Allow letters spaces and numbers
                        {
                            // Show a message or handle the invalid character
                            MessageBox.Show("Please don't inlcude any characters.");

                            // Remove the last character
                            textBox.Text = input.Substring(0, input.Length - 1);

                            // Set the cursor position to the end of the text
                            textBox.SelectionStart = textBox.Text.Length;
                            textBox.SelectionLength = 0;

                            break;
                        }
                    }
                }
                
            }
        }
        private void deleteIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string input = textBox.Text;
                foreach (char c in input)
                {
                    if (!char.IsDigit(c))
                    {
                        // Show a message or handle the invalid character
                        MessageBox.Show("Only numbers are allowed.");

                        // Remove the last character
                        textBox.Text = input.Substring(0, input.Length - 1);

                        // Set the cursor position to the end of the text
                        textBox.SelectionStart = textBox.Text.Length;
                        textBox.SelectionLength = 0;

                        break;
                    }
                }
            }
        }


    }
}
