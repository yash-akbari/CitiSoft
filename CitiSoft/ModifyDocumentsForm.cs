using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class ModifyDocumentsForm : Form
    {
        public ModifyDocumentsForm()
        {
            InitializeComponent();
            InitializeDragDrop();
            showDataInTable();

        }
        private void InitializeDragDrop()
        {
            fileDropPBox.AllowDrop = true;
            fileDropPBox.DragEnter += new DragEventHandler(fileDropPBox_DragEnter);
            fileDropPBox.DragDrop += new DragEventHandler(fileDropPBox_DragDrop);
        }

        // the following two methods are used to enable drag and drop functionality to upload document
        void fileDropPBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        // adds the dropped file to the database
        void fileDropPBox_DragDrop(object sender, DragEventArgs e)
        {
            // checks if the user provided Vendor ID
            if (vendorIDTxtBox.Text == "")
            {
                MessageBox.Show("Please provide vendor ID first");
                return;
            }
            // checks if the user provided wrong Vendor ID
            if (!InputValidation.CheckValueExists(DataBaseManager.citiSoftDatabaseConnectionString, "VendorInfo", "vid", vendorIDTxtBox.Text))
            {
                MessageBox.Show("Provided vendor ID does not exist");
                vendorIDTxtBox.Text = string.Empty;
                return;
            }
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                try
                {
                    byte[] fileData = File.ReadAllBytes(file);
                    string fileName = $"{vendorIDTxtBox.Text}_{Path.GetFileName(file)}"; // Include Vendor ID in the file name

                    using (SqlConnection connection = new SqlConnection(DataBaseManager.citiSoftDatabaseConnectionString))
                    {
                        string query = "UPDATE VendorInfo SET docAttach = @Data, FileName = @FileName WHERE vid = @VendorID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add("@Data", SqlDbType.VarBinary, -1).Value = fileData;
                            command.Parameters.AddWithValue("@VendorID", vendorIDTxtBox.Text);
                            command.Parameters.AddWithValue("@FileName", fileName);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("File was successfully added");
                    vendorIDTxtBox.Text = string.Empty;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error uploading file" + exc);
                    vendorIDTxtBox.Text = string.Empty;
                }
            }
        }


        private void vendorIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyNumbers(textBox);
        }

        // removes the attached document if it exists
        private void removeDocumentBtn_Click(object sender, EventArgs e)
        {
            // checks if the user provied Vendor ID
            if (vendorIDTxtBox.Text == "")
            {
                MessageBox.Show("Please provide vendor ID first");
                return;
            }
            
            // checks if the user provided wrong Vendor ID
            if (!InputValidation.CheckValueExists(DataBaseManager.citiSoftDatabaseConnectionString, "VendorInfo", "vid", vendorIDTxtBox.Text))
            {
                MessageBox.Show("Vendor ID you have provided does not exist");
                vendorIDTxtBox.Text = string.Empty;
                return;
            }
            if (InputValidation.IsValueNull(DataBaseManager.citiSoftDatabaseConnectionString, "VendorInfo", "docAttach", vendorIDTxtBox.Text))
            {
                MessageBox.Show("This Vendor has no document attached");
                vendorIDTxtBox.Text = string.Empty;
                return;
            }

            using (SqlConnection connection = new SqlConnection(DataBaseManager.citiSoftDatabaseConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE VendorInfo SET docAttach = NULL WHERE vid = @VendorID;", connection, transaction))
                    {
                        // uses parameterizing to prevent from SQL injections
                        command.Parameters.AddWithValue("@VendorID", vendorIDTxtBox.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Delete successful.");
                            transaction.Commit(); // Only commit if no errors occurred
                            vendorIDTxtBox.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("No document deleted. It's possible that the vendor ID did not exist.");
                            transaction.Rollback(); // Rollback if no rows affected
                            vendorIDTxtBox.Text = string.Empty;
                        }
                    }
                }
                catch (SqlException)
                {
                    transaction.Rollback(); // Rollback on error
                    MessageBox.Show("An error occurred while deleting the document");
                    vendorIDTxtBox.Text = string.Empty;
                }
            }
        }

        // inserts data from the database into the datagrid view
        public void showDataInTable()
        {
            RuntimeUI.dataBinding(DataBaseManager.citiSoftDatabaseConnectionString, "SELECT vid AS 'Vendor ID', compName AS 'Company Name', est AS 'Establishments', empCount AS 'Employees', intProfServ AS 'International Professional Services',  FROM VendorInfo;", addDocumentDgv);
        }

        // downloads a document into the user's PC
        private void DownloadDocument()
        {

            using (SqlConnection connection = new SqlConnection(DataBaseManager.citiSoftDatabaseConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT docAttach, FileName FROM VendorInfo WHERE vid = @VendorID", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@VendorID", vendorIDTxtBox.Text);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                byte[] documentData = (byte[])reader["docAttach"];
                                string fileName = reader["FileName"].ToString();

                                // Use SaveFileDialog to let the user choose the save location and file name
                                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                                {
                                    saveFileDialog.FileName = fileName;
                                    DialogResult result = saveFileDialog.ShowDialog();

                                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                                    {
                                        // Save document to the selected file
                                        File.WriteAllBytes(saveFileDialog.FileName, documentData);

                                        MessageBox.Show("Document downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        transaction.Commit();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Download canceled by the user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No data found for Vendor ID: {vendorIDTxtBox.Text}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error downloading document: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    transaction.Rollback();
                }
            }
        }


        // Uses a small validation before download a document
        private void downloadDocumentBtn_Click(object sender, EventArgs e)
        {
            // checks if the user provided Vendor ID
            if (vendorIDTxtBox.Text == "")
            {
                MessageBox.Show("Please provide vendor ID first");
                return;
            }
            // checks if the user provided existing Vendor ID
            if (!InputValidation.CheckValueExists(DataBaseManager.citiSoftDatabaseConnectionString, "VendorInfo", "vid", vendorIDTxtBox.Text))
            {
                MessageBox.Show("Provided vendor ID does not exist");
                vendorIDTxtBox.Text = string.Empty;
                return;
            }
            // checks if the Vendor has any documents 
            if (InputValidation.IsValueNull(DataBaseManager.citiSoftDatabaseConnectionString, "VendorInfo", "docAttach", vendorIDTxtBox.Text))
            {
                MessageBox.Show("This Vendor has no document attached");
                vendorIDTxtBox.Text = string.Empty;
                return;
            }
            DownloadDocument();
        }
    }
}
