using System;
using System.Windows.Forms;

namespace CitiSoft
{
    internal class ViewDataByVendor : Form
    {
        public DataGridView VendorDataGridView = new DataGridView();
        public DataGridView AddressDataGridView = new DataGridView();
        public DataGridView SoftwareDataGridView = new DataGridView();
        
        public ViewDataByVendor() 
        {
            
            this.InitializeComponent();
            
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
                    int vid = Convert.ToInt32(row.Cells["Vid"].Value);
                    AddressDataGridView.DataSource = Controller.getDeliverAddress(vid);
                    SoftwareDataGridView.DataSource = Controller.getDeliverSoftware(vid);
                }
            }

        }

        private void ViewDataByVendor_SizeChanged(object sender, System.EventArgs e)
        {
            int widthdgv = 0, heightdgv=0;
            widthdgv = (((this.Width) * 5) / 10);
            heightdgv = (((this.Height) * 6) / 10);
            VendorDataGridView.Size = new System.Drawing.Size(widthdgv, heightdgv);
            AddressDataGridView.Location = new System.Drawing.Point(widthdgv + 10, 0);
            AddressDataGridView.Size = new System.Drawing.Size(widthdgv, heightdgv);
            SoftwareDataGridView.Location = new System.Drawing.Point(0, heightdgv+10);
            heightdgv = (((this.Height) * 4) / 10)-10;
            SoftwareDataGridView.Size = new System.Drawing.Size(this.Width, heightdgv);
        }
    }
}
