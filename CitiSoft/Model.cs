using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiSoft
{
   
    public class SoftwareModel
    {
        public String SoftwareName { get; set; }
        public String CompanyWebsite { get; set; }
        public List<String> TypeOfSoftware { get; set; }
        public String Description { get; set; }
        public List<String> BuisenessAreas { get; set; }
        public List<String> Modules { get; set; }
        public List<String> FinancialServices { get; set; }
        public String Cloud { get; set; }
        public String AdditionalInfo { get; set; }
    }
    public class VendorModel
    {
        public int Vid { get; set; }
        public String CompanyName { get; set; }
        public int CompanyEstablished { get; set; }
        public String EmployeesCount { get; set; }
        public String InternalProfessionalServices { get; set; }
        public String LastDemoDate { get; set; }
        public String LastReviewedInterval { get; set; }
        public String LastReviewedDate { get; set; }

    }

    public class AddressModels
    {
        public int addressId { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String PostCode { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
    }
}
