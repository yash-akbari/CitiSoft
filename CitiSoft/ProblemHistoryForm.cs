﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
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

        // adds the client to the ProblemHistory table
        private void addClientBtn_Click(object sender, EventArgs e)
        {
            // checks if the user did not put text in any textboxes
            if (clientIDPHTxtBox.Text == "" || descriptionTxtBox.Text == "" || userIDPHTxtBox.Text == "")
            {
                MessageBox.Show("Please fill in all text boxes");
                return;
            }
            // checks if the user provided wrong Client ID
            if (!InputValidation.CheckValueExists(DataBaseManager.functionalityConnectionString, "Client", "cid", clientIDPHTxtBox.Text))
            {
                MessageBox.Show("Client ID you have provided does not exist");
                clientIDPHTxtBox.Text = string.Empty;
                return;
            }
            // checks if the user provided wrong User ID
            if (!InputValidation.CheckValueExists(DataBaseManager.functionalityConnectionString, "User", "uid", userIDPHTxtBox.Text))
            {
                MessageBox.Show("Your ID does not exist");
                userIDPHTxtBox.Text = string.Empty;
                return;
            }

            using (SqlConnection connection = new SqlConnection(DataBaseManager.functionalityConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO ProblemHistory (cid, uid, [date], [desc], isClosed, lstRevDate) VALUES (@ClientID, @UserID, @Date, @Description, @IsClosed, @LstRevDate);", connection, transaction))
                    {
                        // uses parameterizing to prevent from SQL injections
                        command.Parameters.AddWithValue("@ClientID", clientIDPHTxtBox.Text);
                        command.Parameters.AddWithValue("@UserID", userIDPHTxtBox.Text);
                        command.Parameters.AddWithValue("@Description", descriptionTxtBox.Text);
                        command.Parameters.AddWithValue("@Date", DateTime.Today.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@LstRevDate", DateTime.Today.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@IsClosed", 0);

                        // checks if any rows were added
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Problem Added.");
                            transaction.Commit(); // Only commit if no errors occurred
                            descriptionLabel.Text = string.Empty;
                            clientIDPHTxtBox.Text = string.Empty;
                            userIDPHTxtBox.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Nothing was added. Probably you have provided wrong IDs.");
                            transaction.Rollback(); // Rollback if no rows affected
                            clientIDPHTxtBox.Text = string.Empty;
                            userIDPHTxtBox.Text = string.Empty;
                        }
                    }
                }
                catch (SqlException error)
                {
                    transaction.Rollback(); // Rollback on error
                    MessageBox.Show("An error occurred while adding the problem" + error);
                    clientIDPHTxtBox.Text = string.Empty;
                    userIDPHTxtBox.Text = string.Empty;
                }
            }
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
            int length = 255; // 255 only characters can be in a description text
            InputValidation.LimitLength(textBox, length, "Description text");
        }
        private void userIDPHTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyNumbers(textBox);
        }

        // changes the value in isClosed column to True
        private void finishProblemBtn_Click(object sender, EventArgs e)
        {
            // checks if the user provided Problem ID
            if (problemIDTxtBox.Text == "")
            {
                MessageBox.Show("Please enter the ID");
                return;
            }
            // checks if the user provided wrong Problem ID
            if (!InputValidation.CheckValueExists(DataBaseManager.functionalityConnectionString, "ProblemHistory", "pid", problemIDTxtBox.Text))
            {
                MessageBox.Show($"Problem with id: {problemIDTxtBox.Text}, does not exist");
                problemIDTxtBox.Text = "";
                return;
            }

            using (SqlConnection connection = new SqlConnection(DataBaseManager.functionalityConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE ProblemHistory \r\n    SET isClosed = 1\r\nWHERE pid = @ProblemID;", connection, transaction))
                    {
                        // uses parameterizing to prevent from SQL injections
                        command.Parameters.AddWithValue("@ProblemID", problemIDTxtBox.Text);

                        // checks if the rows were affected
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
                catch (SqlException error)
                {
                    transaction.Rollback(); // Rollback on error
                    MessageBox.Show("An error occurred while finishing the problem" + error);
                }
            }
        }

        // displays a particular problem and updates the lstRevDate to True
        private void viewProblemBtn_Click(object sender, EventArgs e)
        {
            // checks if the user provided ID
            if (problemIDTxtBox.Text == "")
            {
                MessageBox.Show("Please enter the ID");
                return;
            }
            
            // checks if the user provided wrong id
            if(!InputValidation.CheckValueExists(DataBaseManager.functionalityConnectionString, "ProblemHistory", "pid", problemIDTxtBox.Text))
            {
                MessageBox.Show($"Problem with id: {problemIDTxtBox.Text}, does not exist");
                problemIDTxtBox.Text = "";
                return;
            }

            // displays this specific problem
            RuntimeUI.dataBinding(DataBaseManager.functionalityConnectionString, "SELECT \r\n    p.pid AS 'Problem ID', \r\n    c.compName AS 'Company name', \r\n    u.fn AS 'User first name', p.[date] AS 'Date of Creation', \r\n    p.[desc] AS 'Description', \r\n    p.isClosed AS 'Is Finished', \r\n    p.lstRevDate AS 'Last review date'\r\nFROM ProblemHistory p\r\nJOIN [User] u\r\n    ON u.uid = p.uid\r\nJOIN Client c\r\n    ON c.cid = p.cid", ProblemHistoryDgv, int.Parse(problemIDTxtBox.Text), "p.pid ");

            // updates the lstRevDate (Last review date)
            using (SqlConnection connection = new SqlConnection(DataBaseManager.functionalityConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (SqlCommand command = new SqlCommand($"UPDATE ProblemHistory SET lstRevDate = {DateTime.Today.ToString("yyyy-MM-dd")}  WHERE cid = @ClientID;", connection, transaction))
                    {
                        // uses parameterizing to prevent from SQL injections
                        command.Parameters.AddWithValue("@ClientID", problemIDTxtBox.Text);
                        int rowsAffected = command.ExecuteNonQuery();
                        transaction.Commit();
                    }

                }
                catch (SqlException error)
                {
                    transaction.Rollback(); // Rollback on error
                    MessageBox.Show("An error occurred while updating the Last review date" + error);
                }
            }
        }

        // displays all columns to the datagrid
        private void viewAllProblemsBtn_Click(object sender, EventArgs e)
        {
            RuntimeUI.dataBinding(DataBaseManager.functionalityConnectionString, "SELECT \r\n    p.pid AS 'Problem ID', \r\n    c.compName AS 'Company name', \r\n    u.fn AS 'User first name', p.[date] AS 'Date of Creation', \r\n    p.[desc] AS 'Description', \r\n    p.isClosed AS 'Is Finished', \r\n    p.lstRevDate AS 'Last review date'\r\nFROM ProblemHistory p\r\nJOIN [User] u\r\n    ON u.uid = p.uid\r\nJOIN Client c\r\n    ON c.cid = p.cid;", ProblemHistoryDgv);
        }
    }
}
