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

     

        

        public AddressModel AddressModel
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

       

        internal ViewDataByVendor ViewDataByVendor
        {
            get => default;
            set
            {
            }
        }

        public Controller()
        {
            vendorModelList = Repository.GetAllVendor();
            addressModelList =Repository.GetAllAddress();
            softwareModelList = Repository.GetAllSoftware();
            businessAreasModelList = Repository.getBusinessArea();
            financialServicesModelList = Repository.getFinancialServices();
            typeOfSoftwareModelList = Repository.getTypeOfSoftware();
            modulesModelList = Repository.getModules(); 
            commentsModelList = Repository.GetAllComments();
        }
    
        
        
        public static List<VendorModel> getDeliverVendor()
        {
            return vendorModelList;
        }
        public static void sendVendorUpdate(List<VendorModel> vendorModelList)
        {
            Controller.vendorModelList = vendorModelList;
            Repository.insertUpdateDeleteVendor(vendorModelList);
        }
        public static List<AddressModel> getDeliverAddress(int vid)
        {
            List<AddressModel> result = addressModelList.Where(address => address.Vid == vid).ToList();
            return result;
        }



        public static List<BusinessAreasModel> getBusinessAreasBySid(int sid)
        {
            List<BusinessAreasModel> result = businessAreasModelList.Where(business => business.Sid == sid).ToList();
            return result;
        }
        public static List<string> getOnlyBusinessBySid(int sid)
        {
            return businessAreasModelList.Where(business => business.Sid == sid).Select(business => business.BusinessAreas).ToList();
        }


        public static List<FinancialServicesModel> getFinancialServicesBySid(int sid)
        {
            
            List<FinancialServicesModel> result = financialServicesModelList.Where(financial => financial.Sid == sid).ToList();
            return result;
        }
        public static List<string> getOnlyFinancialServicesBySid(int sid)
        {
            return financialServicesModelList.Where(finance => finance.Sid == sid).Select(finance => finance.FinancialService).ToList();
        }


        public static List<ModulesModel> getModulesBySid(int sid)
        { 
            List<ModulesModel> result = modulesModelList.Where(modules => modules.Sid == sid).ToList();
            return result;
        }
        public static List<string> getOnlyModulesBySid(int sid)
        {
            return modulesModelList.Where(modules => modules.Sid == sid).Select(modules => modules.Modules).ToList();
        }


        public static List<TypeOfSoftwareModel> getTypeOfSoftwareBySid(int sid)
        {  
            List<TypeOfSoftwareModel> result = typeOfSoftwareModelList.Where(typeOfSoftware => typeOfSoftware.Sid == sid).ToList();
            return result;
        }
        public static List<string> getOnlyTypeOfSoftwareBySid(int sid)
        {
            return typeOfSoftwareModelList.Where(type => type.Sid == sid).Select(type => type.TypeOfSoftware).ToList();
        }


        public static CommentsModel getComments(int sid)
        { 
            commentsModelList=Repository.GetAllComments();
            CommentsModel result = commentsModelList.FirstOrDefault(comments => comments.sid == sid);
            SoftwareModel model = softwareModelList.FirstOrDefault(software => software.SoftwareId == sid);

            return result;
        }
        public static void sendAddressUpdate(List<AddressModel> addressModelList)
        {
            Controller.addressModelList = addressModelList;
            Repository.insertUpdateDeleteAddress(addressModelList);
        }

        public static List<SoftwareModel> getDeliverSoftware(int vid)
        {
            List<SoftwareModel> result = softwareModelList.Where(software => software.Vid == vid).ToList();
            return result;
        }

        public static void sendSoftwareUpdate(List<SoftwareModel> softwareModelList)
        {
            Controller.softwareModelList = softwareModelList;
            Repository.insertUpdateDeleteSoftware(softwareModelList);
            Repository.insertUpdateDelete(Controller.typeOfSoftwareModelList);
            Repository.insertUpdateDelete(Controller.modulesModelList);
            Repository.insertUpdateDelete(Controller.businessAreasModelList);
            Repository.insertUpdateDelete(Controller.financialServicesModelList);
            Repository.insertUpdateDelete(Controller.commentsModelList);
        }

    }

}

