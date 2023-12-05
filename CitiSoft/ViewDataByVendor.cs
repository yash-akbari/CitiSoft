using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CitiSoft
{

    public class ViewDataByVendor : Form
    {
        public DataGridView VendorDataGridView = new DataGridView();
        public DataGridView AddressDataGridView = new DataGridView();
        public DataGridView SoftwareDataGridView = new DataGridView();
        public DataGridView SoftCompDataGridView = new DataGridView();
        public Button refreshButton = new Button();
        public Panel commentPanel = new Panel();
        public Panel dataRetPanel = new Panel();

        public Label descriptionLabel = new Label();
        public RichTextBox descriptionRichTextBox = new RichTextBox();

        public Label additionalInfoLabel = new Label();
        public RichTextBox additionalInfoRichTextBox = new RichTextBox();

        public Label commentsLabel = new Label();
        public RichTextBox commentsRichTextBox = new RichTextBox();

        public Label lastDemoDateLabel = new Label();
        public DateTimePicker lastDemoDatePicker = new DateTimePicker();

        public Label lastReviewIntLabel = new Label();
        public TextBox lastReviewIntTextBox = new TextBox();

        public Label lastReviewedDateLabel = new Label();
        public DateTimePicker lastReviewedDatePicker = new DateTimePicker();

        int sid = 0;
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
            VendorDataGridView.DataSource=Controller.getDeliverVendor();
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


            SoftCompDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SoftCompDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SoftCompDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            SoftCompDataGridView.Name = "SoftCompDataGridView";
            Controls.Add(SoftCompDataGridView);
            SoftCompDataGridView.ReadOnly = true;



            commentPanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            commentPanel.Name = "CommentsDataGridView";
            Controls.Add(commentPanel);

            commentPanel.Controls.AddRange(new Control[] {
            descriptionLabel,descriptionRichTextBox,
            additionalInfoLabel,additionalInfoRichTextBox,
            commentsLabel,commentsRichTextBox,
            lastDemoDateLabel,lastDemoDatePicker,
            lastReviewIntLabel,lastReviewIntTextBox,
            lastReviewedDateLabel,lastReviewedDatePicker });

            lastDemoDateLabel.Text = "Last Demo Date";
            lastReviewedDateLabel.Text = "Last Reviewed Date";
            lastReviewIntLabel.Text = "Last Reviewed Interval";
            descriptionLabel.Text = "Description";
            additionalInfoLabel.Text = "Additional Info.";
            commentsLabel.Text = "Comments";

            Controls.Add(dataRetPanel);
            //Everything about data retrival added to Data retrival Panel

            InitializeDragDrop();
            this.fileDropPBox.BackColor = System.Drawing.SystemColors.Info;
            this.fileDropPBox.Name = "fileDropPBox";
            this.fileDropPBox.Size = new System.Drawing.Size(461, 314);
            this.fileDropPBox.TabStop = false;
            dataRetPanel.Controls.Add(fileDropPBox);
            // 
            // dragAndDropLabel
            // 
            this.dragAndDropLabel.AutoSize = true;
            
            this.dragAndDropLabel.Name = "dragAndDropLabel";
            this.dragAndDropLabel.Size = new System.Drawing.Size(352, 25);
            this.dragAndDropLabel.Text = "Drag and drop your document here:";
            dataRetPanel.Controls.Add(dragAndDropLabel);
            // 
            // vendorIDLabel
            // 
            this.vendorIDLabel.AutoSize = true;
            this.vendorIDLabel.Size = new System.Drawing.Size(60, 25);
            this.vendorIDLabel.Text = "Vendor ID";
            dataRetPanel.Controls.Add(vendorIDLabel);
            // 
            // vendorIDTxtBox
            // 
            this.vendorIDTxtBox.Size = new System.Drawing.Size(50, 31);
            this.vendorIDTxtBox.TextChanged += new System.EventHandler(this.vendorIDTxtBox_TextChanged);
            dataRetPanel.Controls.Add(vendorIDTxtBox);
            // 
            // removeDocumentBtn
            // 
            this.removeDocumentBtn.Name = "removeDocumentBtn";
            this.removeDocumentBtn.Size = new System.Drawing.Size(110,40);
            this.removeDocumentBtn.Text = "Remove\nDocument";
            this.removeDocumentBtn.UseVisualStyleBackColor = true;
            this.removeDocumentBtn.Click += new System.EventHandler(this.removeDocumentBtn_Click);
            dataRetPanel.Controls.Add(removeDocumentBtn);
            // 
            // downloadDocumentBtn
            // 
            this.downloadDocumentBtn.Size = new System.Drawing.Size(110, 40);
            this.downloadDocumentBtn.Text = "Download Document";
            this.downloadDocumentBtn.UseVisualStyleBackColor = true;
            this.downloadDocumentBtn.Click += new System.EventHandler(this.downloadDocumentBtn_Click);
            dataRetPanel.Controls.Add(downloadDocumentBtn);
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
        private void SoftwareDataGridView_SelectionChanged(object sender, System.EventArgs e)
        {

            if (SoftwareDataGridView.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in SoftwareDataGridView.SelectedCells)
                {
                    SoftwareDataGridView.Rows[cell.RowIndex].Selected = true;
                }
                foreach (DataGridViewRow row in SoftwareDataGridView.SelectedRows)
                {
                    sid = Convert.ToInt32(row.Cells["sid"].Value);
                   Controller.getComments(sid);
                    SoftwareModel model = Controller.softwareModelList.FirstOrDefault(software => software.SoftwareId == sid);
                    
                }
            }

        }

        private void ViewDataByVendor_SizeChanged(object sender, System.EventArgs e)
        {
            VendorDataGridView.Size = new System.Drawing.Size((this.Width * 3 / 10), this.Height);
            fileDropPBox.Location = new System.Drawing.Point(0, 15);
            fileDropPBox.Size = new System.Drawing.Size((this.Width * 3 / 10) + (this.Width * 5 / 10) + 20, dataRetPanel.Height/2);
            dragAndDropLabel.Location = new System.Drawing.Point( 0,0);
            vendorIDLabel.Location = new System.Drawing.Point(0,dataRetPanel.Height/2+20);
            vendorIDTxtBox.Location = new System.Drawing.Point(vendorIDLabel.Width + 10, dataRetPanel.Height / 2 + 17);
            removeDocumentBtn.Location = new System.Drawing.Point(0, vendorIDLabel.Height + vendorIDLabel.Top +10);
            downloadDocumentBtn.Location = new System.Drawing.Point(0, removeDocumentBtn.Height + removeDocumentBtn.Top + 5);
            dataRetPanel.Location = new System.Drawing.Point((this.Width * 3 / 10) + (this.Width * 5 / 10) + 20, 0);
            dataRetPanel.Size = new System.Drawing.Size(this.Width * 2 / 10-12, downloadDocumentBtn.Top + downloadDocumentBtn.Height + 5);
            AddressDataGridView.Location = new System.Drawing.Point((this.Width * 3 / 10) + 10, 0);
            AddressDataGridView.Size = new System.Drawing.Size(this.Width * 5 / 10, dataRetPanel.Height);
            SoftwareDataGridView.Location = new System.Drawing.Point(AddressDataGridView.Left, AddressDataGridView.Height+10);
            SoftwareDataGridView.Size = new System.Drawing.Size(this.Width*3/10 -10, ( this.Height*3/10));
            SoftCompDataGridView.Location = new System.Drawing.Point(SoftwareDataGridView.Width+ SoftwareDataGridView.Left+10,AddressDataGridView.Height+ 10);
            SoftCompDataGridView.Size = new System.Drawing.Size(this.Width * 4 / 10-12, (this.Height * 3 / 10));
            commentPanel.Size = new System.Drawing.Size(this.Width * 7 / 10 -12, this.Width-(SoftCompDataGridView.Height + SoftCompDataGridView.Top + 10)-12 );
            commentPanel.Location = new System.Drawing.Point(VendorDataGridView.Width + 10, SoftCompDataGridView.Height+SoftCompDataGridView.Top + 10);


            lastDemoDateLabel.Location = new System.Drawing.Point(0,0);
            lastDemoDateLabel.Size = new System.Drawing.Size(commentPanel.Width*25/100,15);

            lastDemoDatePicker.Location = new System.Drawing.Point(0,lastDemoDateLabel.Height);
            lastDemoDatePicker.Size = new System.Drawing.Size(commentPanel.Width * 25 / 100, 5);


            lastReviewIntLabel.Location = new System.Drawing.Point(0, lastDemoDatePicker.Top+ lastDemoDatePicker.Height + 10) ;
            lastReviewIntLabel.Size = new System.Drawing.Size(commentPanel.Width * 25 / 100,15);

            lastReviewIntTextBox.Location = new System.Drawing.Point(0,lastReviewIntLabel.Top+lastReviewIntLabel.Height);
            lastReviewIntTextBox.Size = new System.Drawing.Size(commentPanel.Width * 25 / 100,5);


            lastReviewedDateLabel.Location = new System.Drawing.Point(0,lastReviewIntTextBox.Top+lastReviewIntTextBox.Height+10);
            lastReviewedDateLabel.Size = new System.Drawing.Size(commentPanel.Width * 25 / 100,15);

            lastReviewedDatePicker.Location = new System.Drawing.Point(0,lastReviewedDateLabel.Top+lastReviewedDateLabel.Height);
            lastReviewedDatePicker.Size = new System.Drawing.Size(commentPanel.Width * 25 / 100,5);


            commentsLabel.Location = new System.Drawing.Point(lastDemoDateLabel.Width+10,0);
            commentsLabel.Size = new System.Drawing.Size(commentPanel.Width*25/100,15);

            commentsRichTextBox.Location = new System.Drawing.Point(lastDemoDateLabel.Width+10,20);
            commentsRichTextBox.Size = new System.Drawing.Size(commentPanel.Width*25/100,commentPanel.Height-25);


            descriptionLabel.Location = new System.Drawing.Point(commentsLabel.Width+commentsLabel.Left+10,0);
            descriptionLabel.Size = new System.Drawing.Size(commentPanel.Width*25/100,15);

            descriptionRichTextBox.Location = new System.Drawing.Point(commentsLabel.Width+10,20);
            descriptionRichTextBox.Size = new System.Drawing.Size(commentPanel.Width*25/100,commentPanel.Height-25);


            additionalInfoLabel.Location = new System.Drawing.Point(descriptionLabel.Width + 10, 0);
            additionalInfoLabel.Size = new System.Drawing.Size(commentPanel.Width * 25 / 100, 15);

            additionalInfoLabel.Location = new System.Drawing.Point(descriptionLabel.Width + 10, 20);
            additionalInfoLabel.Size = new System.Drawing.Size(commentPanel.Width * 25 / 100, commentPanel.Height - 25);

        }


        //All following made by Ilyas, SID: 2216574. part of code from: ModifyDocumentForm.cs
        private void InitializeDragDrop()
        {
            fileDropPBox.AllowDrop = true;
            fileDropPBox.DragEnter += new DragEventHandler(fileDropPBox_DragEnter);
            fileDropPBox.DragDrop += new DragEventHandler(fileDropPBox_DragDrop);
        }

        // the following two methods are used to enable drag and drop functionality to upload document
        private void fileDropPBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        // adds the dropped file to the database
        private void fileDropPBox_DragDrop(object sender, DragEventArgs e)
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
            // checks if the document already exists
            if (!InputValidation.IsValueNull(DataBaseManager.citiSoftDatabaseConnectionString, "VendorInfo", "docAttach", vendorIDTxtBox.Text))
            {
                MessageBox.Show("This Vendor already has a document attached");
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
                    if (fileName.Length > 255)
                    {
                        MessageBox.Show("Document name is too long");
                        return;
                    }
                    using (SqlConnection connection = new SqlConnection(DataBaseManager.citiSoftDatabaseConnectionString))
                    {
                        string query = "UPDATE VendorInfo SET docAttach = @Data, docName = @FileName WHERE vid = @VendorID";

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
            // checks if the document already exists
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
                    using (SqlCommand command = new SqlCommand("UPDATE VendorInfo SET docAttach = NULL, docName = NULL WHERE vid = @VendorID;", connection, transaction))
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

        // downloads a document into the user's PC
        private void DownloadDocument()
        {
            using (SqlConnection connection = new SqlConnection(DataBaseManager.citiSoftDatabaseConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT docAttach, docName FROM VendorInfo WHERE vid = @VendorID", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@VendorID", vendorIDTxtBox.Text);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                byte[] documentData = (byte[])reader["docAttach"];
                                string fileName = reader["docName"].ToString();

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
