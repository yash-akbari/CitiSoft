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
        public static List<CommentsModel> commentsModelList = new List<CommentsModel>();
        public static ViewDataByVendor vendor = new ViewDataByVendor();

        public searchVendor searchVendor
        {
            get => default;
            set
            {
            }
        }

        public AddressRepository AddressRepository
        {
            get => default;
            set
            {
            }
        }

        public AddressModel AddressModel
        {
            get => default;
            set
            {
            }
        }

        public SoftwareRepository SoftwareRepository
        {
            get => default;
            set
            {
            }
        }

        public VendorRepository VendorRepository
        {
            get => default;
            set
            {
            }
        }

        public VendorModel VendorModel
        {
            get => default;
            set
            {
            }
        }

        public SoftwareModel SoftwareModel
        {
            get => default;
            set
            {
            }
        }

        public ModulesModel ModulesModel
        {
            get => default;
            set
            {
            }
        }

        public FinancialServicesModel FinancialServicesModel
        {
            get => default;
            set
            {
            }
        }

        public BusinessAreasModel BusinessAreasModel
        {
            get => default;
            set
            {
            }
        }

        public TypeOfSoftwareModel TypeOfSoftwareModel
        {
            get => default;
            set
            {
            }
        }

        public VendorRepository VendorRepository1
        {
            get => default;
            set
            {
            }
        }

        public AddressRepository AddressRepository1
        {
            get => default;
            set
            {
            }
        }

        public SoftwareRepository SoftwareRepository1
        {
            get => default;
            set
            {
            }
        }

        internal ViewDataByVendor ViewDataByVendor
        {
            get => default;
            set
            {
            }
        }

        public SearchByVendor SearchByVendor
        {
            get => default;
            set
            {
            }
        }

        public searchVendor searchVendor1
        {
            get => default;
            set
            {
            }
        }

        public static List<VendorModel> getDeliverVendor()
        {
            vendorModelList = VendorRepository.GetAllVendor();
            return vendorModelList;
        }
        public static void sendVendorUpdate(List<VendorModel> vendorModelList)
        {
            Controller.vendorModelList = vendorModelList;
            VendorRepository.insertUpdateDeleteVendor(vendorModelList);
        }
        public static List<AddressModel> getDeliverAddress(int vid)
        {
            addressModelList = AddressRepository.GetAllAddress();
            List<AddressModel> result = addressModelList.Where(address => address.Vid == vid).ToList();
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
        public static CommentsModel getComments(int sid)
        { 
            commentsModelList=CommentsRepository.GetAllComments();
            CommentsModel result = commentsModelList.FirstOrDefault(comments => comments.sid == sid);
            SoftwareModel model = softwareModelList.FirstOrDefault(software => software.SoftwareId == sid);

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

