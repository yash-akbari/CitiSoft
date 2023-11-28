using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiSoft
{
    public partial class View
    {
        
        public static void vendorDelivered() 
        {
            ViewDataByVendor vendor = new ViewDataByVendor();
            vendor.VendorDataGridView.DataSource = Controller.getDeliverVendor();
        }

        public static void addressDelivered(int vid)
        {
            ViewDataByVendor vendor = new ViewDataByVendor();
           
            vendor.AddressDataGridView.DataSource = Controller.getDeliverAddress(vid); 
        }

    }
}
