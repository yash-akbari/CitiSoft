using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CitiSoft
{
    internal class ViewDataByVendor : Form
    {
        public DataGridView VendorDataGridView = new DataGridView();
        public DataGridView AddressDataGridView = new DataGridView();
        public DataGridView SoftwareDataGridView = new DataGridView();
        public DataGridView CommentsDataGridView = new DataGridView(); 

        int Vid = 0;
        String DocName = "";
        private System.Windows.Forms.PictureBox fileDropPBox = new PictureBox();
        private System.Windows.Forms.Label dragAndDropLabel = new Label();
        private System.Windows.Forms.Label vendorIDLabel = new Label();
        private System.Windows.Forms.TextBox vendorIDTxtBox = new TextBox();
        private Button removeDocumentBtn = new Button();
        private Button downloadDocumentBtn = new Button();
        public ViewDataByVendor() 
        {
            
            this.InitializeComponent();
            
        }
        public ViewDataByVendor(int i)
        {
            VendorDataGridView.DataSource = Controller.getDeliverVendor();
        }    
        private void InitializeComponent() 
        {
            VendorDataGridView.DataSource = Controller.getDeliverVendor();
            VendorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            VendorDataGridView.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            VendorDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            
            VendorDataGridView.Name = "VendorDataGridView";
            this.SizeChanged += ViewDataByVendor_SizeChanged;
            Controls.Add(VendorDataGridView);
            VendorDataGridView.ReadOnly = true;
            VendorDataGridView.DataBindingComplete += VendorDataGridView_DataBindingComplete;
            VendorDataGridView.SelectionChanged += VendorDataGridView_SelectionChanged;



            AddressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AddressDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AddressDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            AddressDataGridView.Name = "AddressDataGridView";
            Controls.Add(AddressDataGridView);
            AddressDataGridView.ReadOnly = true;
            AddressDataGridView.DataBindingComplete += AddressDataGridView_DataBindingComplete;


            SoftwareDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SoftwareDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SoftwareDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            SoftwareDataGridView.Name = "SoftwareDataGridView";
            Controls.Add(SoftwareDataGridView);
            SoftwareDataGridView.ReadOnly = true;
            SoftwareDataGridView.DataBindingComplete += SoftwareDataGridView_DataBindingComplete;
            SoftwareDataGridView.CellContentClick += SoftwareDataGridView_CellContentClick;


            InitializeDragDrop();
            this.fileDropPBox.BackColor = System.Drawing.SystemColors.Info;
            this.fileDropPBox.Name = "fileDropPBox";
            this.fileDropPBox.Size = new System.Drawing.Size(461, 314);
            this.fileDropPBox.TabStop = false;
            Controls.Add(fileDropPBox);
            // 
            // dragAndDropLabel
            // 
            this.dragAndDropLabel.AutoSize = true;
            
            this.dragAndDropLabel.Name = "dragAndDropLabel";
            this.dragAndDropLabel.Size = new System.Drawing.Size(352, 25);
            this.dragAndDropLabel.Text = "Drag and drop your document here:";
            Controls.Add(dragAndDropLabel);
            // 
            // vendorIDLabel
            // 
            this.vendorIDLabel.AutoSize = true;
            this.vendorIDLabel.Size = new System.Drawing.Size(107, 25);
            this.vendorIDLabel.Text = "Vendor ID";
            Controls.Add(vendorIDLabel);
            // 
            // vendorIDTxtBox
            // 
            this.vendorIDTxtBox.Size = new System.Drawing.Size(50, 31);
            this.vendorIDTxtBox.TextChanged += new System.EventHandler(this.vendorIDTxtBox_TextChanged);
            Controls.Add(vendorIDTxtBox);
            // 
            // removeDocumentBtn
            // 
            this.removeDocumentBtn.Name = "removeDocumentBtn";
            this.removeDocumentBtn.Size = new System.Drawing.Size(110,40);
            this.removeDocumentBtn.Text = "Remove\nDocument";
            this.removeDocumentBtn.UseVisualStyleBackColor = true;
            this.removeDocumentBtn.Click += new System.EventHandler(this.removeDocumentBtn_Click);
            Controls.Add(removeDocumentBtn);
            // 
            // downloadDocumentBtn
            // 
            this.downloadDocumentBtn.Size = new System.Drawing.Size(110, 40);
            this.downloadDocumentBtn.Text = "Download Document";
            this.downloadDocumentBtn.UseVisualStyleBackColor = true;
            this.downloadDocumentBtn.Click += new System.EventHandler(this.downloadDocumentBtn_Click);
            Controls.Add(downloadDocumentBtn);
        }

        private void SoftwareDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SoftwareDataGridView.Columns[0].Visible = false;
            SoftwareDataGridView.Columns[1].Visible = false;
            SoftwareDataGridView.RowHeadersVisible = false;
        }

        private void AddressDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AddressDataGridView.Columns[0].Visible = false;
            AddressDataGridView.Columns[1].Visible = false;
            AddressDataGridView.RowHeadersVisible = false;
        }

        private void VendorDataGridView_DataBindingComplete(object sender, EventArgs e)
        {
            VendorDataGridView.Columns[0].Visible = false;
            VendorDataGridView.RowHeadersVisible= false;
            
        }

        private void SoftwareDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the LinkColumn
            if (e.ColumnIndex == SoftwareDataGridView.Columns["SoftwareWebsite"].Index && e.RowIndex >= 0)
            {
                // Get the value of the clicked cell
                string link = SoftwareDataGridView.Rows[e.RowIndex].Cells["SoftwareWebsite"].Value.ToString();

                // Open the link in the default web browser
                System.Diagnostics.Process.Start(link);
            }
        }

        private void VendorDataGridView_SelectionChanged(object sender, System.EventArgs e)
        {
            
            if (VendorDataGridView.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in VendorDataGridView.SelectedCells)
                {
                    VendorDataGridView.Rows[cell.RowIndex].Selected = true;
                }
                foreach (DataGridViewRow row in VendorDataGridView.SelectedRows)
                {
                    DocName = Convert.ToString(row.Cells["CompanyName"].Value);
                    Vid = Convert.ToInt32(row.Cells["Vid"].Value);
                    vendorIDTxtBox.Text=Vid.ToString();
                    AddressDataGridView.DataSource = Controller.getDeliverAddress(Vid);
                    SoftwareDataGridView.DataSource = Controller.getDeliverSoftware(Vid);
                }
            }

        }

        private void ViewDataByVendor_SizeChanged(object sender, System.EventArgs e)
        {
            int widthdgv = 0, heightdgv=0;
            widthdgv = (((this.Width) * 3) / 10);
            heightdgv = (((this.Height) * 5) / 10);
            VendorDataGridView.Size = new System.Drawing.Size(widthdgv, heightdgv);
            SoftwareDataGridView.Location = new System.Drawing.Point(widthdgv + 10, 0);
            SoftwareDataGridView.Size = new System.Drawing.Size(this.Width-widthdgv, heightdgv/2);
            fileDropPBox.Location = new System.Drawing.Point(widthdgv+10, (heightdgv/2)+20);
            fileDropPBox.Size = new System.Drawing.Size(widthdgv/2, heightdgv/2-20);
            dragAndDropLabel.Location = new System.Drawing.Point(widthdgv + 10, (heightdgv / 2) + 5);
            vendorIDLabel.Location = new System.Drawing.Point(widthdgv + (widthdgv / 2) + 20,heightdgv/2+30);
            vendorIDTxtBox.Location = new System.Drawing.Point(widthdgv+(widthdgv/2) + 77, heightdgv/2+26);
            removeDocumentBtn.Location = new System.Drawing.Point(widthdgv + (widthdgv / 2) + 20, heightdgv / 2 + 30+31);
            downloadDocumentBtn.Location = new System.Drawing.Point(widthdgv + (widthdgv / 2) + 20, heightdgv / 2 + +61+ 50);
            AddressDataGridView.Location = new System.Drawing.Point(0, heightdgv+10);
            heightdgv = (((this.Height) * 5) / 10)-10;
            AddressDataGridView.Size = new System.Drawing.Size(this.Width/2 -10, heightdgv);
        }


        //All following made by Ilyas, SID: 2216574. part of code from: ModifyDocumentForm.cs
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
                    byte[] fileData = System.IO.File.ReadAllBytes(file);

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

        private void DownloadDocument()
        {
               
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
                        saveFileDialog.FileName = DocName;
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            System.IO.File.WriteAllBytes(saveFileDialog.FileName, documentData);
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

        

        private void downloadDocumentBtn_Click(object sender, EventArgs e)
        {
            if (vendorIDTxtBox.Text == "")
            {
                MessageBox.Show("Please provide vendor ID first");
                return;
            }
            if (!InputValidation.CheckValueExists(DataBaseManager.citiSoftDatabaseConnectionString, "VendorInfo", "vid", vendorIDTxtBox.Text))
            {
                MessageBox.Show("Provided vendor ID does not exist");
                vendorIDTxtBox.Text = string.Empty;
                return;
            }
            if (InputValidation.IsValueNull(DataBaseManager.citiSoftDatabaseConnectionString, "VendorInfo", "docAttach", vendorIDTxtBox.Text))
            {
                MessageBox.Show("This Vendor has no document attached");
                return;
            }
            DownloadDocument();
        }
    }
}
