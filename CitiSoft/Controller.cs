using System.Collections.Generic;

namespace CitiSoft
{

    public partial class Controller
    {
        public static List<VendorModel> vendorModelList = new List<VendorModel>(); 
        public static List<VendorModel> getDeliverVendor() 
        {
            vendorModelList = VendorRepository.GetAllVendor();
            return vendorModelList;
        }
        public static void sendVendorUpdate(List<VendorModel> vendorModelList)
        {
            Controller.vendorModelList = vendorModelList;
            VendorRepository.insertUpdateDeleteVendor(vendorModelList);
            View.vendorDelivered();
        }
    }

}

