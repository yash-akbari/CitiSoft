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
            if (string.IsNullOrWhiteSpace(clientIDTxtBox.Text))
            {
                MessageBox.Show("Please provide client id");
                return; // Exit if no client ID is provided
            }

            using (SqlConnection connection = new SqlConnection(Variables.functionalityConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Start building the SQL command based on provided input
                    List<string> clientUpdates = new List<string>();
                    List<string> addressUpdates = new List<string>();

                    if (!string.IsNullOrWhiteSpace(companyNameTxtBox.Text))
                        clientUpdates.Add("compName = @CompName");

                    if (!string.IsNullOrWhiteSpace(phoneTxtBox.Text))
                        addressUpdates.Add("phone = @Phone");

                    if (!string.IsNullOrWhiteSpace(emailTxtBox.Text))
                        addressUpdates.Add("email = @Email");

                    if (!string.IsNullOrWhiteSpace(streetTxtBox.Text))
                        addressUpdates.Add("Street = @Street");

                    if (!string.IsNullOrWhiteSpace(cityTxtBox.Text))
                        addressUpdates.Add("City = @City");

                    if (!string.IsNullOrWhiteSpace(countryTxtBox.Text))
                        addressUpdates.Add("Cointry = @Country");

                    if (clientUpdates.Count == 0 && addressUpdates.Count == 0)
                    {
                        MessageBox.Show("No data provided to update.");
                        return;
                    }

                    string updateSql = "";
                    if (clientUpdates.Count > 0)
                        updateSql += "UPDATE Client SET " + string.Join(", ", clientUpdates) + " WHERE cid = @ClientID; ";

                    if (addressUpdates.Count > 0)
                        updateSql += "UPDATE CustAddress SET " + string.Join(", ", addressUpdates) + " WHERE cid = @ClientID;";

                    using (SqlCommand command = new SqlCommand(updateSql, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@ClientID", clientIDTxtBox.Text);

                        if (!string.IsNullOrWhiteSpace(companyNameTxtBox.Text))
                            command.Parameters.AddWithValue("@CompName", companyNameTxtBox.Text);

                        if (!string.IsNullOrWhiteSpace(phoneTxtBox.Text))
                            command.Parameters.AddWithValue("@Phone", phoneTxtBox.Text);

                        if (!string.IsNullOrWhiteSpace(emailTxtBox.Text))
                            command.Parameters.AddWithValue("@Email", emailTxtBox.Text);

                        if (!string.IsNullOrWhiteSpace(streetTxtBox.Text))
                            command.Parameters.AddWithValue("@Street", streetTxtBox.Text);

                        if (!string.IsNullOrWhiteSpace(cityTxtBox.Text))
                            command.Parameters.AddWithValue("@City", cityTxtBox.Text);

                        if (!string.IsNullOrWhiteSpace(countryTxtBox.Text))
                            command.Parameters.AddWithValue("@Country", countryTxtBox.Text);

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
            if(deleteIDTextBox.Text == "")
            {
                MessageBox.Show("Please provide client ID");
                return;
            }

            using (SqlConnection connection = new SqlConnection(Variables.functionalityConnectionString))
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

        private void clientIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyNumbers(textBox);
        }

        private void companyNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyLettersAndSpaces(textBox, 30, "Company");
        }

        private void countryTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyLetters(textBox, 30, "Country");
        }

        private void cityTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyLetters(textBox, 30, "City");

        }

        private void streetTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyAlphanumericOrWithDots(textBox, 30, "Street");

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
                if (textBox != null && !InputValidation.IsValidEmail(textBox.Text))
                {
                    MessageBox.Show("Invalid email format.");

                }
            }
        }

        private void phoneTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsPhoneNumberStructured(textBox, 15, "Phone number");
        }

        private void deleteIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyNumbers(textBox);
        }
    }
}