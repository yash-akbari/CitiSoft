using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    internal class vendorView : Form
    {
        DataGridView venViewData = new DataGridView();
        public vendorView() 
        {
            InitializeComponent();
        }
        private void InitializeComponent() 
        {
            // 
            // venViewData
            // 
            venViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            venViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            venViewData.Location = new System.Drawing.Point(3, 3);
            venViewData.Name = "venVieData";
            venViewData.Size = new System.Drawing.Size(604, 660);
        }
    }
}
