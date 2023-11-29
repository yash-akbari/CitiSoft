using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CitiSoft
{

    public partial class Controller
    {
        public static List<VendorModel> vendorModelList = new List<VendorModel>(); 
        public static List<AddressModel> addressModelList = new List<AddressModel>();
        public static List<SoftwareModel> softwareModelList = new List<SoftwareModel>();
        public static List<BusinessAreasModel> businessAreasModelList = new List<BusinessAreasModel>();
        public static List<FinancialServicesModel> financialServicesModelList = new List<FinancialServicesModel>();
        public static List<TypeOfSoftwareModel> typeOfSoftwareModelList = new List<TypeOfSoftwareModel>();
        public static List<ModulesModel> modulesModelList = new List<ModulesModel>();
        static ViewDataByVendor vendor = new ViewDataByVendor();
        public static List<VendorModel> getDeliverVendor() 
        {
            vendorModelList = VendorRepository.GetAllVendor();
            return vendorModelList;
        }
        public static void sendVendorUpdate(List<VendorModel> vendorModelList)
        {
            Controller.vendorModelList = vendorModelList;
            VendorRepository.insertUpdateDeleteVendor(vendorModelList);
            vendor.VendorDataGridView.DataSource = Controller.getDeliverVendor();
        }
        public static List<AddressModel> getDeliverAddress(int vid)
        {
            addressModelList = AddressRepository.GetAllAddress();
            List<AddressModel> result= addressModelList.Where(address => address.Vid == vid).ToList();
            return result;
        }

        public static List<BusinessAreasModel> getBusinessAreasBySid(int sid)
        {
            businessAreasModelList = SoftwareRepository.getBusinessArea();
            List<BusinessAreasModel> result = businessAreasModelList.Where(business => business.Sid == sid).ToList();
            return result;
        }
        public static List<FinancialServicesModel> getFinancialServicesBySid(int sid)
        {
            financialServicesModelList = SoftwareRepository.getFinancialServices();
            List<FinancialServicesModel> result = financialServicesModelList.Where(financial => financial.Sid == sid).ToList();
            return result;
        }

        public static List<ModulesModel> getModulesBySid(int sid)
        {
            modulesModelList = SoftwareRepository.getModules();
            List<ModulesModel> result = modulesModelList.Where(modules => modules.Sid == sid).ToList();
            return result;
        }

        public static List<TypeOfSoftwareModel> getTypeOfSoftwareBySid(int sid)
        {
            typeOfSoftwareModelList = SoftwareRepository.getTypeOfSoftware();
            List<TypeOfSoftwareModel> result = typeOfSoftwareModelList.Where(typeOfSoftware => typeOfSoftware.Sid == sid).ToList();
            return result;
        }
        public static void sendAddressUpdate(List<AddressModel> addressModelList)
        {
            Controller.addressModelList = addressModelList;
            AddressRepository.insertUpdateDeleteAddress(addressModelList);
        }

        public static List<SoftwareModel> getDeliverSoftware(int vid)
        {
            softwareModelList = SoftwareRepository.GetAllSoftware();
            List<SoftwareModel> result = softwareModelList.Where(software => software.Vid == vid).ToList();
            return result;
        }

        public static void sendSoftwareUpdate(List<SoftwareModel> softwareModelList)
        {
            Controller.softwareModelList = softwareModelList;
            SoftwareRepository.insertUpdateDeleteSoftware(softwareModelList);
        }

    }

}

