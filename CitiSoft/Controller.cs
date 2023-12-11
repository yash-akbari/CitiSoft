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
            return vendorModelList.Where(vendor => vendor.Operation!= 'D').ToList();
        }
        public static void sendVendorUpdate(List<VendorModel> vendorModelList)
        {
            Controller.vendorModelList = vendorModelList;
            Repository.insertUpdateDelete(vendorModelList);
        }
        public static List<AddressModel> getDeliverAddress(int vid)
        {
            return addressModelList.Where(address => address.Vid == vid && address.Operation != 'D').ToList();
        }



        public static List<BusinessAreasModel> getBusinessAreasBySid(int sid)
        {
            return businessAreasModelList.Where(business => business.Sid == sid && business.Operation != 'D').ToList();
        }
        public static List<string> getOnlyBusinessBySid(int sid)
        {
            return businessAreasModelList.Where(business => business.Sid == sid && business.Operation != 'D').Select(business => business.BusinessAreas).ToList();
        }


        public static List<FinancialServicesModel> getFinancialServicesBySid(int sid)
        {
            
            return financialServicesModelList.Where(financial => financial.Sid == sid && financial.Operation != 'D').ToList();
        }
        public static List<string> getOnlyFinancialServicesBySid(int sid)
        {
            return financialServicesModelList.Where(finance => finance.Sid == sid && finance.Operation != 'D').Select(finance => finance.FinancialService).ToList();
        }


        public static List<ModulesModel> getModulesBySid(int sid)
        { 
            return modulesModelList.Where(modules => modules.Sid == sid && modules.Operation != 'D').ToList();
        }
        public static List<string> getOnlyModulesBySid(int sid)
        {
            return modulesModelList.Where(modules => modules.Sid == sid && modules.Operation != 'D').Select(modules => modules.Modules).ToList();
        }


        public static List<TypeOfSoftwareModel> getTypeOfSoftwareBySid(int sid)
        {  
            return typeOfSoftwareModelList.Where(typeOfSoftware => typeOfSoftware.Sid == sid && typeOfSoftware.Operation != 'D').ToList();
        }
        public static List<string> getOnlyTypeOfSoftwareBySid(int sid)
        {
            return typeOfSoftwareModelList.Where(type => type.Sid == sid && type.Operation != 'D').Select(type => type.TypeOfSoftware).ToList();
        }


        public static CommentsModel getComments(int sid)
        { 
            commentsModelList=Repository.GetAllComments();
            return commentsModelList.FirstOrDefault(comments => comments.Sid == sid && comments.Operation != 'D');
        }
        public static void sendAddressUpdate(List<AddressModel> addressModelList)
        {
            Controller.addressModelList = addressModelList;
            Repository.insertUpdateDelete(addressModelList);
        }

        public static List<SoftwareModel> getDeliverSoftware(int vid)
        {
           return softwareModelList.Where(software => software.Vid == vid && software.Operation != 'D').ToList();
        }

        public static void sendSoftwareUpdate(List<SoftwareModel> softwareModelList)
        {
            Controller.softwareModelList = softwareModelList;
            Repository.insertUpdateDelete(softwareModelList);
            Repository.insertUpdateDelete(Controller.typeOfSoftwareModelList);
            Repository.insertUpdateDelete(Controller.modulesModelList);
            Repository.insertUpdateDelete(Controller.businessAreasModelList);
            Repository.insertUpdateDelete(Controller.financialServicesModelList);
            Repository.insertUpdateDelete(Controller.commentsModelList);
        }

    }

}

