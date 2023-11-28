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
            InitializeComponent();
            VendorDataGridView.DataSource = Controller.getDeliverVendor();

        }
        private void InitializeComponent() 
        {
            VendorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            VendorDataGridView.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            VendorDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            
            VendorDataGridView.Name = "VendorDataGridView";
            this.SizeChanged += ViewDataByVendor_SizeChanged;
            Controls.Add(VendorDataGridView);
            VendorDataGridView.ReadOnly = true;
            VendorDataGridView.Columns.Clear();
            VendorDataGridView.SelectionChanged += VendorDataGridView_SelectionChanged;
            
            AddressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AddressDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AddressDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            AddressDataGridView.Name = "AddressDataGridView";
            Controls.Add(AddressDataGridView);
            AddressDataGridView.ReadOnly = true;
            AddressDataGridView.Columns.Clear();


            SoftwareDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SoftwareDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SoftwareDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            SoftwareDataGridView.Name = "AddressDataGridView";
            Controls.Add(SoftwareDataGridView);
            SoftwareDataGridView.ReadOnly = true;
            SoftwareDataGridView.Columns.Clear();
        }

        private void VendorDataGridView_SelectionChanged(object sender, System.EventArgs e)
        {
            if (VendorDataGridView.SelectedCells.Count > 0)
            {
                //int vid = Convert.ToInt32(VendorDataGridView.SelectedCells.);
                //MessageBox.Show(vid.ToString());
                //Controller.requestAddress(vid);
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
