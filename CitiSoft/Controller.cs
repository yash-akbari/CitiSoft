using System.Collections.Generic;
using System.Linq;

namespace CitiSoft
{

    public partial class Controller
    {
        public static List<VendorModel> vendorModelList = new List<VendorModel>(); 
        public static List<AddressModel> addressModelList = new List<AddressModel>();
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
        public static List<AddressModel> getDeliverAddress(int vid)
        {
            addressModelList = AddressRepository.GetAllAddress();
            List<AddressModel> result= addressModelList.Where(address => address.Vid == vid).ToList();
            return result;
        }
        public static void requestAddress(int vid) 
        {
            View.addressDelivered(vid);
        }
        public static void sendAddressUpdate(List<AddressModel> addressModelList)
        {
            Controller.addressModelList = addressModelList;
            AddressRepository.insertUpdateDeleteAddress(addressModelList);
        }

    }

}

