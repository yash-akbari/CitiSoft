using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiSoft
{
    public class SoftwareModel
    {
        public int SoftwareId { get; set; }
        public int Vid { get; set; }
        public String SoftwareName { get; set; }
        public String SoftwareWebsite { get; set; }
        public String Description { get; set; }
        public String Cloud { get; set; }
        public String AdditionalInfo { get; set; }
        public char Operation { get; set; }
    }
    public class TypeOfSoftwareModel
    {
        public int Id { get; set; }
        public int Sid { get; set; }
        public string TypeOfSoftware { get; set; }
        public char Operation { get; set; }
    }
    public class BusinessAreasModel
    {
        public int Id { get; set; }
        public int Sid { get; set; }
        public string BusinessAreas { get; set; }
        public char Operation { get; set; }
    }
    public class ModulesModel
    {
        public int Id { get; set; }
        public int Sid { get; set; }
        public string Modules { get; set; }
        public char Operation { get; set; }
    }
    public class FinancialServicesModel      
    {
        public int Id { get; set; }
        public int Sid { get; set; }
        public string FinancialService { get; set; }
        public char Operation { get; set; }
    }
    public class VendorModel
    {
        public int Vid { get; set; }
        public String CompanyName { get; set; }
        public int CompanyEstablished { get; set; }
        public String EmployeesCount { get; set; }
        public Boolean InternalProfessionalServices { get; set; }
        public char Operation { get; set; }
    }

    public class AddressModel 
    {
        public int AddressId { get; set; }
        public int Vid { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String PostCode { get; set; }
        public String Email { get; set; }
        public String Telephone { get; set; }
        public char Operation { get; set; }
    }
    public class CommentsModel 
    {
        public int Sid { get; set; }
        public int CommentId { get; set; }
        public string Comments { get; set; }
        public int LastReviewedInterval { get; set; }
        public DateTime LastReviewedDate { get; set; }
        public DateTime LastDemoDate { get; set; }
        public char Operation { get; set; }
    }
}
