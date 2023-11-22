using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    internal class viewVendor : Form
    {
        DataGridView venViewData = new DataGridView();
        public viewVendor() 
        {
            InitializeComponent();
        }
        private void InitializeComponent() 
        {
            // 
            // venViewData
            // 
            venViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            venViewData.Dock= DockStyle.Fill;
            venViewData.Name = "venVieData";
            Controls.Add(venViewData);  
        }
    }
}
