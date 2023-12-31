﻿using System;
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
            // checks if the user provided Client ID
            if(clientIDTxtBox.Text == "")
            {
                MessageBox.Show("Please provide client id");
                return;
            }

            // checks if the user provided wrong Client ID
            if(!InputValidation.CheckValueExists(DataBaseManager.functionalityConnectionString, "Client", "cid", clientIDTxtBox.Text))
            {
                DialogResult result = MessageBox.Show("Client ID you have provided does not exist. Do you want to add this client?", "Client Not Found", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Call a method to add the client
                    if(clientIDTxtBox.Text == "" || countryTxtBox.Text == "" || companyNameTxtBox.Text == "" || cityTxtBox.Text == "" || postcodeTxtBox.Text == "" || phoneTxtBox.Text == "" || addressLine1TxtBox.Text == "" || addressLine2TxtBox.Text == "" || emailTxtBox.Text == "")
                    {
                        MessageBox.Show("Please provide all data first");
                        return;
                    }
                    AddClient();
                }
                return;
            }
            using (SqlConnection connection = new SqlConnection(DataBaseManager.functionalityConnectionString))
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

                    if (!string.IsNullOrWhiteSpace(addressLine1TxtBox.Text))
                        addressUpdates.Add("AddressLine1 = @addressLine1");

                    if (!string.IsNullOrWhiteSpace(addressLine2TxtBox.Text))
                        addressUpdates.Add("AddressLine2 = @addressLine2");

                    if (!string.IsNullOrWhiteSpace(cityTxtBox.Text))
                        addressUpdates.Add("City = @City");

                    if (!string.IsNullOrWhiteSpace(countryTxtBox.Text))
                        addressUpdates.Add("Country = @Country");

                    if(!string.IsNullOrWhiteSpace(postcodeTxtBox.Text))
                        addressUpdates.Add("PostCode = @Postcode");

                    // checks if any data was provided
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

                        if(!string.IsNullOrWhiteSpace(addressLine1TxtBox.Text))
                            command.Parameters.AddWithValue("@AddressLine1", addressLine1TxtBox.Text);

                        if (!string.IsNullOrWhiteSpace(addressLine2TxtBox.Text))
                            command.Parameters.AddWithValue("@AddressLine2", addressLine2TxtBox.Text);

                        if (!string.IsNullOrWhiteSpace(cityTxtBox.Text))
                            command.Parameters.AddWithValue("@City", cityTxtBox.Text);

                        if (!string.IsNullOrWhiteSpace(countryTxtBox.Text))
                            command.Parameters.AddWithValue("@Country", countryTxtBox.Text);

                        if (!string.IsNullOrWhiteSpace(postcodeTxtBox.Text))
                            command.Parameters.AddWithValue("@Postcode", postcodeTxtBox.Text);

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
                catch (SqlException error)
                {
                    transaction.Rollback(); // Rollback on error
                    MessageBox.Show("An error occurred while updating the client" + error);
                }
            }
        }

        // adds the client to the database
        private void AddClient()
        {
            using (SqlConnection connection = new SqlConnection(DataBaseManager.functionalityConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // using SCOPE_IDENTITY() to retrieve last pk id from Client table
                    string insertSql = "INSERT INTO Client (compName) VALUES (@CompName); " +
                                       "INSERT INTO CustAddress (cid, phone, email, addressLine1, addressLine2, city, country, postCode) " +
                                       "VALUES (SCOPE_IDENTITY(), @Phone, @Email, @AddressLine1, @AddressLine2, @City, @Country, @Postcode);";

                    using (SqlCommand command = new SqlCommand(insertSql, connection, transaction))
                    {
                        if(!string.IsNullOrWhiteSpace(companyNameTxtBox.Text))
                            command.Parameters.AddWithValue("@CompName", companyNameTxtBox.Text);

                        if(!string.IsNullOrWhiteSpace(phoneTxtBox.Text))
                            command.Parameters.AddWithValue("@Phone", phoneTxtBox.Text);

                        if(!string.IsNullOrWhiteSpace(emailTxtBox.Text))
                            command.Parameters.AddWithValue("@Email", emailTxtBox.Text);

                        if(!string.IsNullOrWhiteSpace(addressLine1TxtBox.Text))
                            command.Parameters.AddWithValue("@AddressLine1", addressLine1TxtBox.Text);

                        if(!string.IsNullOrWhiteSpace(addressLine2TxtBox.Text))
                            command.Parameters.AddWithValue("@AddressLine2", addressLine2TxtBox.Text);

                        if(!string.IsNullOrWhiteSpace(cityTxtBox.Text))
                            command.Parameters.AddWithValue("@City", cityTxtBox.Text);

                        if(!string.IsNullOrWhiteSpace(countryTxtBox.Text))
                            command.Parameters.AddWithValue("@Country", countryTxtBox.Text);

                        if(!string.IsNullOrWhiteSpace(postcodeTxtBox.Text))
                            command.Parameters.AddWithValue("@Postcode", postcodeTxtBox.Text);

                        // ExecuteNonQuery is used for INSERT, UPDATE, DELETE operations
                        int rowsAffected = command.ExecuteNonQuery();

                        if(rowsAffected > 0)
                        {
                            // Retrieve the last inserted ID
                            string selectLastIdSql = "SELECT SCOPE_IDENTITY();";
                            command.CommandText = selectLastIdSql;

                            object result = command.ExecuteScalar();

                            if(result != null)
                            {
                                MessageBox.Show("Insertion successful.");
                            }
                            else
                            {
                                MessageBox.Show("No rows inserted. Failed to retrieve the last inserted ID.");
                            }

                            transaction.Commit(); // Only commit if no errors occurred
                        }
                        else
                        {
                            MessageBox.Show("No rows inserted. Failed to add the client.");
                            transaction.Rollback(); // Rollback if no rows affected
                        }
                    }
                }
                catch (SqlException error)
                {
                    transaction.Rollback(); // Rollback on error
                    MessageBox.Show("An error occurred while adding the client" + error);
                }
            }
        }

        private void deleteClientBtn_Click(object sender, EventArgs e)
        {
            // checks if the user provided Client ID
            if(deleteIDTextBox.Text == "")
            {
                MessageBox.Show("Please provide client ID");
                return;
            }

            // checks if the user provided wrong ID
            if (!InputValidation.CheckValueExists(DataBaseManager.functionalityConnectionString, "Client", "cid", deleteIDTextBox.Text))
            {
                MessageBox.Show("Client ID you have provided does not exist");
                deleteIDTextBox.Text = string.Empty;
                return;
            }

            using (SqlConnection connection = new SqlConnection(DataBaseManager.functionalityConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand("DELETE FROM CustAddress WHERE cid = @ClientID DELETE FROM Client WHERE cid = @ClientID;", connection, transaction))
                    {
                        // uses parameterizing to prevent from SQL injections
                        command.Parameters.AddWithValue("@ClientID", deleteIDTextBox.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Delete successful.");
                            transaction.Commit(); // Only commit if no errors occurred
                            deleteIDTextBox.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("No rows deleted. It's possible that the client did not exist.");
                            transaction.Rollback(); // Rollback if no rows affected
                            deleteIDTextBox.Text = "";
                        }
                    }
                }
                catch (SqlException error)
                {
                    transaction.Rollback(); // Rollback on error
                    MessageBox.Show("An error occurred while deleting the client" + error);
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

        private void addressLine1TxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyAlphanumericOrWithDots(textBox, 30, "Address Line 1");
        }

        private void addressLine2TxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyAlphanumericOrWithDots(textBox, 30, "Address Line 2");
        }

        private void deleteIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyNumbers(textBox);
        }

        private void postcodeTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyAlphanumericOrWithDots(textBox, 30, "Postcode");
        }
        
        // refreshes the table
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RuntimeUI.dataBinding(DataBaseManager.functionalityConnectionString, "SELECT c.cid AS 'Client ID', c.compName AS 'Company Name', cu.phone AS 'Phone', cu.email AS 'Email', CONCAT(cu.addressLine1, ' ', cu.addressLine2) AS 'Address', cu.city AS 'City', cu.country AS 'Country', cu.postCode AS 'Postcode' FROM Client c JOIN CustAddress cu ON c.cid = cu.cid; ", ModifyClientDvg);

        }
    }
}