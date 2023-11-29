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
    }
}
