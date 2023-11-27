using System.Windows.Forms;

namespace CitiSoft
{
    internal class ViewDataByVendor : Form
    {
        public DataGridView venViewData = new DataGridView();
        public ViewDataByVendor() 
        {
            InitializeComponent();
            venViewData.DataSource = Controller.getDeliverVendor();

        }
        private void InitializeComponent() 
        {
            venViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            venViewData.Dock= DockStyle.Fill;
            venViewData.Name = "venViewData";
            Controls.Add(venViewData);
            venViewData.ReadOnly = true;
            venViewData.Columns.Clear();
        }
    }
}
