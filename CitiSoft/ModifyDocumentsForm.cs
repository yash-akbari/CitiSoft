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

        void fileDropPBox_DragDrop(object sender, DragEventArgs e)
        {
            if (vendorIDTxtBox.Text == "")
            {
                MessageBox.Show("Please provide vendor ID first");
                return;
            }
            if (!InputValidation.CheckValueExists(DataBaseManager.citiSoftDatabaseConnectionString, "VendorInfo", "vid", vendorIDTxtBox.Text))
            {
                MessageBox.Show("Provided vendor ID does not exist");
                return;
            }
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                try
                {
                    byte[] fileData = File.ReadAllBytes(file);

                    using (SqlConnection connection = new SqlConnection(DataBaseManager.citiSoftDatabaseConnectionString))
                    {
                        //string query = "INSERT INTO VendorInfo (docAttach) VALUES (@Data) WHERE vid = @VendorID;";
                        string query = "UPDATE VendorInfo SET docAttach = @Data WHERE vid = @VendorID";


                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add("@Data", SqlDbType.VarBinary, -1).Value = fileData;
                            command.Parameters.AddWithValue("@VendorID", vendorIDTxtBox.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("File was successfully added");
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error uploading file" + exc);
                }
            }
        }
        private void vendorIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            InputValidation.IsOnlyNumbers(textBox);
        }

        private void removeDocumentBtn_Click(object sender, EventArgs e)
        {
            if (vendorIDTxtBox.Text == "")
            {
                MessageBox.Show("Please provide vendor ID first");
                return;
            }

            if (!InputValidation.CheckValueExists(DataBaseManager.citiSoftDatabaseConnectionString, "VendorInfo", "vid", vendorIDTxtBox.Text))
            {
                MessageBox.Show("Vendor ID you have provided does not exist");
                vendorIDTxtBox.Text = string.Empty;
                return;
            }
            if (InputValidation.IsValueNull(DataBaseManager.citiSoftDatabaseConnectionString, "VendorInfo", "docAttach", vendorIDTxtBox.Text))
            {
                MessageBox.Show("This Vendor has no document attached");
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
        public void showDataInTable()
        {
            RuntimeUI.dataBinding(DataBaseManager.citiSoftDatabaseConnectionString, "SELECT vid, compName, est, empCount, intProfServ, lstDemoDt, lstRevInt, lstRevDt FROM VendorInfo;", addDocumentDgv);
        }

        private void DownloadDocument()
        {
            if (addDocumentDgv.SelectedRows.Count > 0)
            {
                string documentName = addDocumentDgv.SelectedRows[0].Cells["DocumentName"].Value.ToString();

                using (SqlConnection connection = new SqlConnection(DataBaseManager.citiSoftDatabaseConnectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        using (SqlCommand command = new SqlCommand("SELECT docAttach FROM VendorInfo WHERE vid = @VendorID", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@VendorID", vendorIDTxtBox.Text);

                            byte[] documentData = (byte[])command.ExecuteScalar();

                            // Save document to a file
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.FileName = documentName;
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllBytes(saveFileDialog.FileName, documentData);
                                MessageBox.Show("Document downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                transaction.Commit();
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
            else
            {
                MessageBox.Show("Please select a document to download.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
