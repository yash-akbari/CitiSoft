using System;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class VendorDocsUI : Form
    {
        private VendorDocsManager _manager;

        public VendorDocsUI()
        {

        }

        public VendorDocsUI(string connectionString)
        {
            InitializeComponent();

            _manager = new VendorDocsManager(connectionString);

            _accessButton.Click += AccessButton_Click;
            _removeButton.Click += RemoveButton_Click;
        }

        private void AccessButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(_vendorDocsGridView.Text, out int vendorId))
            {
                var docPath = _manager.AccessVendorDocs(vendorId);
                if (docPath != null)
                {
                    _statusLabel.Text = $"Document Path: {docPath}";
                }
                else
                {
                    _statusLabel.Text = "Document not found!";
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Vendor ID!");
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(_vendorDocsGridView.Text, out int vendorId))
            {
                if (_manager.RemoveVendorDocs(vendorId))
                {
                    _statusLabel.Text = "Document removed successfully!";
                }
                else
                {
                    _statusLabel.Text = "Failed to remove document!";
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Vendor ID!");
            }
        }

        private void _statusLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
