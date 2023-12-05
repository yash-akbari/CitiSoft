using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CitiSoft
{
    // Repository (Model)
    public partial class Repository
    {
        internal DataBaseManager DataBaseManager
        {
            get => default;
            set
            {
            }
        }

        public static List<VendorModel> GetAllVendor()
        {
            List<VendorModel> vendorModelList = new List<VendorModel>();
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            con.Open();
            SqlCommand cmd;
            SqlDataReader dataReader;
            string sql;
            sql = "SELECT * FROM VendorInfo";
            cmd = new SqlCommand(sql, con);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                vendorModelList.Add(new VendorModel
                {
                    Vid = Convert.ToInt32(dataReader.GetValue(0)),
                    CompanyName = Convert.ToString(dataReader.GetValue(1)),
                    CompanyEstablished = Convert.ToInt32(dataReader.GetValue(2)),
                    EmployeesCount = Convert.ToString(dataReader.GetValue(3)),
                    InternalProfessionalServices = (Convert.ToBoolean(dataReader.GetValue(4))),
                });
            }
            dataReader.Close();
            cmd.Dispose();
            con.Close();
            return vendorModelList;
        }

        public static void insertUpdateDeleteVendor(List<VendorModel> vendorModelList)
        {
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            foreach (VendorModel vendorModel in vendorModelList)
            {
                if (vendorModel.Vid < 0)
                {

                    try {
                        con.Open();
                        using (SqlTransaction transaction = con.BeginTransaction())
                        {
                            string sql = @"
                                INSERT INTO [dbo].[VendorInfo] 
                                ([compName], [est], [empCount], [intProfServ]) 
                                VALUES 
                                (@CompanyName, @CompanyEstablished, @EmployeesCount, @InternalProfessionalServices);
                                SELECT SCOPE_IDENTITY();
                            ";

                            using (SqlCommand cmd = new SqlCommand(sql, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@CompanyName", vendorModel.CompanyName);
                                cmd.Parameters.AddWithValue("@CompanyEstablished", vendorModel.CompanyEstablished);
                                cmd.Parameters.AddWithValue("@EmployeesCount", vendorModel.EmployeesCount);
                                cmd.Parameters.AddWithValue("@InternalProfessionalServices", vendorModel.InternalProfessionalServices);

                                try
                                {
                                    object res = (cmd.ExecuteScalar());
                                    transaction.Commit();
                                    cmd.Dispose();
                                    con.Close();
                                    int venId = Convert.ToInt32(res);
                                    //MessageBox.Show(res.ToString());
                                    foreach (AddressModel add in Controller.addressModelList)
                                    {
                                        if (vendorModel.Vid == add.addressId)
                                        {
                                            add.Vid = venId;
                                        }
                                    }
                                    Repository.insertUpdateDeleteAddress(Controller.addressModelList);

                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Error: " + ex.Message);

                                }

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        // Always close the database connection, even if an exception occurs
                        con.Close();
                    }
                }
                else if (vendorModel.CompanyName.Equals(null))
                {
                    string sql = "Delete From VendorInfo WHERE vid = @Vid";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Vid", vendorModel.Vid);
                        try
                        {
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if the update was successful
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record Deleted successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Record not found or update failed.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    string sql = "UPDATE VendorInfo SET compName = @CompanyName, est = @CompanyEstablished, empCount = @EmployeesCount, intProfServ = @InternalProfessionalServices WHERE vid = @Vid";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Vid", vendorModel.Vid);
                        cmd.Parameters.AddWithValue("@CompanyName", vendorModel.CompanyName);
                        cmd.Parameters.AddWithValue("@CompanyEstablished", vendorModel.CompanyEstablished);
                        cmd.Parameters.AddWithValue("@EmployeesCount", vendorModel.EmployeesCount);
                        cmd.Parameters.AddWithValue("@InternalProfessionalServices", vendorModel.InternalProfessionalServices);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
        }
    
     public AddressModel AddressModel
        {
            get => default;
            set
            {
            }
        }

    

        public Controller Controller
        {
            get => default;
            set
            {
            }
        }

        public static List<AddressModel> GetAllAddress()
        {
            List<AddressModel> addressModelList = new List<AddressModel>();
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            con.Open();
            SqlCommand cmd;
            SqlDataReader dataReader;
            string sql;
            sql = "SELECT * FROM Address"; 
            cmd = new SqlCommand(sql, con);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                addressModelList.Add(new AddressModel
                {
                    addressId = Convert.ToInt32(dataReader.GetValue(0)),
                    Vid = Convert.ToInt32(dataReader.GetValue(1)),
                    AddressLine1 = Convert.ToString(dataReader.GetValue(2)),
                    AddressLine2 = Convert.ToString(dataReader.GetValue(3)),
                    City = Convert.ToString(dataReader.GetValue(4)),
                    Country = Convert.ToString(dataReader.GetValue(5)),
                    PostCode = Convert.ToString(dataReader.GetValue(6)),
                    Email = Convert.ToString(dataReader.GetValue(7)),
                    Telephone = Convert.ToString(dataReader.GetValue(8))
                });
            }
            dataReader.Close();
            cmd.Dispose();
            con.Close();
            return addressModelList;
        }

        public static void insertUpdateDeleteAddress(List<AddressModel> addressModelList)
        {
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            foreach (AddressModel addressModel in addressModelList)
            {
                if (addressModel.addressId < 0)
                {
                    string sql = "INSERT INTO Address (vid, addressLine1, addressLine2, city, country, postcode, email, telephone) VALUES (@Vid, @AddressLine1, @AddressLine2, @City, @Country, @PostCode, @Email, @Telephone)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Vid", addressModel.Vid);
                        cmd.Parameters.AddWithValue("@AddressLine1", addressModel.AddressLine1);
                        cmd.Parameters.AddWithValue("@AddressLine2", addressModel.AddressLine2);
                        cmd.Parameters.AddWithValue("@City", addressModel.City);
                        cmd.Parameters.AddWithValue("@Country", addressModel.Country);
                        cmd.Parameters.AddWithValue("@PostCode", addressModel.PostCode);
                        cmd.Parameters.AddWithValue("@Email", addressModel.Email);
                        cmd.Parameters.AddWithValue("@Telephone", addressModel.Telephone);
                        try
                        {
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if the update was successful
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Address updated successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Record not found or update failed.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }

                    }
                }
                else if (addressModel.Vid == 0 && addressModel.addressId != 0)
                {
                    string sql = "Delete From Address WHERE addressId = @addressId";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@addressId", addressModel.addressId);
                        try
                        {
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if the update was successful
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Address updated successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Record not found or update failed.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    string sql = "UPDATE Address SET vid = @Vid, addressLine1 = @AddressLine1, addressLine2 = @AddressLine2, city = @City, country = @Country, postcode = @PostCode, email = @Email, telephone = @Telephone WHERE addressId = @AddressId";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@AddressId", addressModel.addressId);
                        cmd.Parameters.AddWithValue("@Vid", addressModel.Vid);
                        cmd.Parameters.AddWithValue("@AddressLine1", addressModel.AddressLine1);
                        cmd.Parameters.AddWithValue("@AddressLine2", addressModel.AddressLine2);
                        cmd.Parameters.AddWithValue("@City", addressModel.City);
                        cmd.Parameters.AddWithValue("@Country", addressModel.Country);
                        cmd.Parameters.AddWithValue("@PostCode", addressModel.PostCode);
                        cmd.Parameters.AddWithValue("@Email", addressModel.Email);
                        cmd.Parameters.AddWithValue("@Telephone", addressModel.Telephone);
                        try
                        {
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if the update was successful
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Address updated successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Record not found or update failed.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
        }
    
  
        public SoftwareModel SoftwareModel
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

        public BusinessAreasModel BusinessAreasModel
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


      

        public static List<SoftwareModel> GetAllSoftware()
        {
            List<SoftwareModel> softwareModelList = new List<SoftwareModel>();
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            con.Open();
            SqlCommand cmd;
            SqlDataReader dataReader;
            string sql;
            sql = "SELECT * FROM SoftName";
            cmd = new SqlCommand(sql, con);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                softwareModelList.Add(new SoftwareModel
                {
                    Vid = Convert.ToInt32(dataReader.GetValue(0)),
                    SoftwareId = Convert.ToInt32(dataReader.GetValue(1)),
                    SoftwareName = Convert.ToString(dataReader.GetValue(2)),
                    SoftwareWebsite = Convert.ToString(dataReader.GetValue(3)),
                    //Description = Convert.ToString(dataReader.GetValue(4)),
                    Cloud = Convert.ToString(dataReader.GetValue(5)),
                    //AdditionalInfo = Convert.ToString(dataReader.GetValue(6)),
                    //BusinessAreas = JoinProperty(Controller.getBusinessAreasBySid(Convert.ToInt32(dataReader.GetValue(1))), "BusinessAreas"),
                    //Modules = JoinProperty(Controller.getModulesBySid(Convert.ToInt32(dataReader.GetValue(1))), "Modules"),
                    //FinancialServices = JoinProperty(Controller.getFinancialServicesBySid(Convert.ToInt32(dataReader.GetValue(1))), "FinancialService"),
                    //TypeOfSoftware = JoinProperty(Controller.getTypeOfSoftwareBySid(Convert.ToInt32(dataReader.GetValue(1))), "TypeOfSoftware")
                });
            }
            dataReader.Close();
            cmd.Dispose();
            con.Close();
            return softwareModelList;
        }


        static string JoinProperty<T>(List<T> list, string propertyName) //chatgpt
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty(propertyName);

            if (propertyInfo != null)
            {
                IEnumerable<string> values = list.Select(item => propertyInfo.GetValue(item)?.ToString());
                return string.Join(", ", values);
            }

            return string.Empty;
        }

        public static List<ModulesModel> getModules()
        {
            List<ModulesModel> modulesModelList = new List<ModulesModel>();
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            con.Open();
            SqlCommand cmd;
            SqlDataReader dataReader;
            string sql;
            sql = "SELECT * FROM Modules";
            cmd = new SqlCommand(sql, con);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                modulesModelList.Add(new ModulesModel
                {
                    id = Convert.ToInt32(dataReader.GetValue(0)),
                    Sid = Convert.ToInt32(dataReader.GetValue(1)),
                    Modules = Convert.ToString(dataReader.GetValue(2)),
                });
            }
            dataReader.Close();
            cmd.Dispose();
            con.Close();
            return modulesModelList;
        }

        public static List<BusinessAreasModel> getBusinessArea()
        {
            List<BusinessAreasModel> businessAreasModelList = new List<BusinessAreasModel>();
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            con.Open();
            SqlCommand cmd;
            SqlDataReader dataReader;
            string sql;
            sql = "SELECT * FROM Business";
            cmd = new SqlCommand(sql, con);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                businessAreasModelList.Add(new BusinessAreasModel
                {
                    id = Convert.ToInt32(dataReader.GetValue(0)),
                    Sid = Convert.ToInt32(dataReader.GetValue(1)),
                    BusinessAreas = Convert.ToString(dataReader.GetValue(2)),
                });
            }
            dataReader.Close();
            cmd.Dispose();
            con.Close();
            return businessAreasModelList;
        }
        public static List<FinancialServicesModel> getFinancialServices()
        {
            List<FinancialServicesModel> financialServicesModelList = new List<FinancialServicesModel>();
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            con.Open();
            SqlCommand cmd;
            SqlDataReader dataReader;
            string sql;
            sql = "SELECT * FROM ClientTypes";
            cmd = new SqlCommand(sql, con);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                financialServicesModelList.Add(new FinancialServicesModel
                {
                    id = Convert.ToInt32(dataReader.GetValue(0)),
                    Sid = Convert.ToInt32(dataReader.GetValue(1)),
                    FinancialService = Convert.ToString(dataReader.GetValue(2)),
                });
            }
            dataReader.Close();
            cmd.Dispose();
            con.Close();
            return financialServicesModelList;
        }

        public static List<TypeOfSoftwareModel> getTypeOfSoftware()
        {
            List<TypeOfSoftwareModel> typeOfSoftwareModelList = new List<TypeOfSoftwareModel>();
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            con.Open();
            SqlCommand cmd;
            SqlDataReader dataReader;
            string sql;
            sql = "SELECT * FROM SoftTypes";
            cmd = new SqlCommand(sql, con);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                typeOfSoftwareModelList.Add(new TypeOfSoftwareModel
                {
                    id = Convert.ToInt32(dataReader.GetValue(0)),
                    Sid = Convert.ToInt32(dataReader.GetValue(1)),
                    TypeOfSoftware = Convert.ToString(dataReader.GetValue(2)),
                });
            }
            dataReader.Close();
            cmd.Dispose();
            con.Close();
            return typeOfSoftwareModelList;
        }

        public static void insertUpdateDeleteSoftware(List<SoftwareModel> softwareModelList)
        {
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            foreach (SoftwareModel softwareModel in softwareModelList)
            {
                if (softwareModel.SoftwareId < 0)
                {
                    string sql = "INSERT INTO SoftName (vid,softName, softWeb, desc, cloud, addInfo) VALUES (@Vid, @SoftwareName, @SoftwareWebsite, @Description, @Cloud, @AdditionalInfo)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Vid", softwareModel.Vid);
                        cmd.Parameters.AddWithValue("@SoftwareName", softwareModel.SoftwareName);
                        cmd.Parameters.AddWithValue("@softwareWebsite", softwareModel.SoftwareWebsite);
                        cmd.Parameters.AddWithValue("@Description", softwareModel.Description);
                        cmd.Parameters.AddWithValue("@Cloud", softwareModel.Cloud);
                        cmd.Parameters.AddWithValue("@AdditionalInfo", softwareModel.AdditionalInfo);
                        try
                        {
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            cmd.CommandText = "Select SCOPE_INDENTITY();";
                            int sId = Convert.ToInt32(cmd.ExecuteScalar());
                            foreach (BusinessAreasModel business in Controller.businessAreasModelList)
                            {
                                if (softwareModel.SoftwareId == business.id)
                                {
                                    business.Sid = sId;
                                }
                                sql = "INSERT INTO Business(sid,BusinessArea)";

                            }
                            foreach (TypeOfSoftwareModel type in Controller.typeOfSoftwareModelList)
                            {
                                if (softwareModel.SoftwareId == type.id)
                                {
                                    type.Sid = sId;
                                }
                            }
                            foreach (ModulesModel modules in Controller.modulesModelList)
                            {
                                if (softwareModel.SoftwareId == modules.id)
                                {
                                    modules.Sid = sId;
                                }
                            }
                            foreach (FinancialServicesModel fin in Controller.financialServicesModelList)
                            {
                                if (softwareModel.SoftwareId == fin.id)
                                {
                                    fin.Sid = sId;
                                }
                            }

                            // Check if the update was successful
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record updated successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Record not found or update failed.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }

                    }
                }
                else if (softwareModel.SoftwareName.Equals(null))
                {
                    string sql = "Delete From SoftName WHERE sid = @SoftwareId";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@SoftwareId", softwareModel.SoftwareId);
                        try
                        {
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if the update was successful
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record updated successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Record not found or update failed.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    string sql = "UPDATE VendorInfo SET SoftName = @SoftwareName, softWeb = @SoftwareWebsite, desc = @Description, cloud = @Cloud, addInfo = @AdditionalInfo WHERE vid = @Vid";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Vid", softwareModel.Vid);
                        cmd.Parameters.AddWithValue("@SoftwareName", softwareModel.SoftwareName);
                        cmd.Parameters.AddWithValue("@softwareWebsite", softwareModel.SoftwareWebsite);
                        cmd.Parameters.AddWithValue("@Description", softwareModel.Description);
                        cmd.Parameters.AddWithValue("@Cloud", softwareModel.Cloud);
                        cmd.Parameters.AddWithValue("@AdditionalInfo", softwareModel.AdditionalInfo);
                        try
                        {
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if the update was successful
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record updated successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Record not found or update failed.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
        }

    


    
        public static List<CommentsModel> GetAllComments()
        {
            List<CommentsModel> commentsModelList = new List<CommentsModel>();
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            con.Open();
            SqlCommand cmd;
            SqlDataReader dataReader;
            string sql;
            sql = "SELECT * FROM Comments";
            cmd = new SqlCommand(sql, con);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                commentsModelList.Add(new CommentsModel
                {
                    sid = Convert.ToInt32(dataReader.GetValue(0)),
                    commentId = Convert.ToInt32(dataReader.GetValue(1)),
                    Comments = Convert.ToString(dataReader.GetValue(2)),
                    LastDemoDate = Convert.ToDateTime(dataReader.GetValue(3)), 
                    LastReviewedInterval = Convert.ToInt32(dataReader.GetValue(4)),
                    LastReviewedDate = Convert.ToDateTime(dataReader.GetValue(5)),
                });
            }
            dataReader.Close();
            cmd.Dispose();
            con.Close();
            return commentsModelList;
        }

    }

    public class CheckIndent
    {
        /*DECLARE @GapIdentifier INT;

        SELECT TOP 1 @GapIdentifier = tableInstance.id[i] + 1
        FROM tabName[i] tableInstance
        WHERE NOT EXISTS (
            SELECT 1
            FROM tabName[i] t2
            WHERE t2.id[i] = tableInstance.id[i] + 1
        )
        ORDER BY tableInstance.id[i];

        DBCC CHECKIDENT(tabName[i], RESEED, @GapIdentifier);*/
        public CheckIndent()
        {
            String[] tabName = new string[7] { "Address", "Business", "ClientTypes", "Modules", "SoftName", "SoftTypes", "VendorInfo" };
            String[] id = new String[7] { "addressId", "businessId", "clientTypesId", "modulesId", "sid", "softTypesId", "vid" };
            for (int i = 0; i < 7; i++)
            {
                SqlConnection con;
                con = DataBaseManager.GetCitiSoftConnection();

                String sql = "DECLARE @GapIdentifier INT;" +
                             "SELECT TOP 1 @GapIdentifier = tableInstance."+id[i]+" + 1 " +
                             "FROM "+tabName[i]+" tableInstance " +
                             "WHERE NOT EXISTS ( " +
                             "SELECT 1 " +
                             "FROM "+tabName[i]+" t2 " +
                             "WHERE t2."+id[i]+" = tableInstance."+id[i]+" + 1 " +
                             ") " +
                             "ORDER BY tableInstance."+id[i]+"; " +
                             "DECLARE @FirstNUllRow INT = @GapIdentifier - 1; "+
                             "DBCC CHECKIDENT('"+tabName[i]+"', RESEED, @FirstNullRow );";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

        }

        internal DataBaseManager DataBaseManager
        {
            get => default;
            set
            {
            }
        }
    }

}

