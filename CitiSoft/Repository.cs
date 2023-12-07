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
                                    MessageBox.Show("Error: " + ex.Message+ "Insert");

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
                            MessageBox.Show("Error: " + ex.Message+ "Update");
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
                    Description = Convert.ToString(dataReader.GetValue(4)),
                    Cloud = Convert.ToString(dataReader.GetValue(5)),
                    AdditionalInfo = Convert.ToString(dataReader.GetValue(6))
                }) ;
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


        public static void insertUpdateDelete(List<TypeOfSoftwareModel> typeOfSoftwareModelList) 
        {
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            foreach (TypeOfSoftwareModel typeOfSoftwareModel in typeOfSoftwareModelList)
            {
                if (typeOfSoftwareModel.id < 0)
                {
                    string sql = "INSERT INTO SoftTypes (sid,softTypes) VALUES (@Sid,@TypeOfSoftware)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Sid", typeOfSoftwareModel.Sid);
                        cmd.Parameters.AddWithValue("@TypeOfSoftware", typeOfSoftwareModel.TypeOfSoftware);
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
                else if (typeOfSoftwareModel.Sid == 0 )
                {
                    string sql = "Delete From SoftTypes WHERE softTypesId = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", typeOfSoftwareModel.id);
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
                else
                {
                    string sql = "UPDATE SoftTypes SET sid = @sid, softTypes = @typeOfSoftware WHERE softTypesId = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id",typeOfSoftwareModel.id);
                        cmd.Parameters.AddWithValue("@sid", typeOfSoftwareModel.Sid);
                        cmd.Parameters.AddWithValue("@typeOfSoftware", typeOfSoftwareModel.TypeOfSoftware);
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
        public static void insertUpdateDelete(List<BusinessAreasModel> businessModelList)
        {
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            foreach (BusinessAreasModel businessAreasModel in businessModelList)
            {
                if (businessAreasModel.id < 0)
                {
                    string sql = "INSERT INTO Business (sid,BusinessArea) VALUES (@Sid,@Business)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Sid", businessAreasModel.Sid);
                        cmd.Parameters.AddWithValue("@Business", businessAreasModel.BusinessAreas);
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
                else if (businessAreasModel.Sid == 0)
                {
                    string sql = "Delete From Business WHERE businessId = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", businessAreasModel.id);
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
                else
                {
                    string sql = "UPDATE Business SET sid = @sid, BusinessArea = @Business WHERE businessId = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", businessAreasModel.id);
                        cmd.Parameters.AddWithValue("@sid", businessAreasModel.Sid);
                        cmd.Parameters.AddWithValue("@Business", businessAreasModel.BusinessAreas);
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

        public static void insertUpdateDelete(List<ModulesModel> modulesModelList)
        {
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            foreach (ModulesModel modulesModel in modulesModelList)
            {
                if (modulesModel.id < 0)
                {
                    string sql = "INSERT INTO Modules (sid,modules) VALUES (@Sid,@Modules)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Sid", modulesModel.Sid);
                        cmd.Parameters.AddWithValue("@Modules", modulesModel.Modules);
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
                else if (modulesModel.Sid == 0 && modulesModel.id != 0)
                {
                    string sql = "Delete From Modules WHERE modulesId = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", modulesModel.id);
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
                else
                {
                    string sql = "UPDATE Modules SET sid = @sid, modules = @modules WHERE modulesId = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", modulesModel.id);
                        cmd.Parameters.AddWithValue("@sid", modulesModel.Sid);
                        cmd.Parameters.AddWithValue("@modules", modulesModel.Modules);
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

        public static void insertUpdateDelete(List<FinancialServicesModel> financialModelList)
        {
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            foreach (FinancialServicesModel financialModel in financialModelList)
            {
                if (financialModel.id < 0)
                {
                    string sql = "INSERT INTO ClientTypes (sid,finSerCliTypes) VALUES (@Sid,@FinancialService)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Sid", financialModel.Sid);
                        cmd.Parameters.AddWithValue("@FinancialService", financialModel.FinancialService);
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
                else if (financialModel.Sid == 0 && financialModel.id != 0)
                {
                    string sql = "Delete From ClientTypes WHERE clientTypesId = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", financialModel.id);
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
                else
                {
                    string sql = "UPDATE ClientTypes SET sid = @sid, finSerCliTypes = @finance WHERE clientTypesId = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", financialModel.id);
                        cmd.Parameters.AddWithValue("@sid", financialModel.Sid);
                        cmd.Parameters.AddWithValue("@finance", financialModel.FinancialService);
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
        public static void insertUpdateDelete(List<CommentsModel> commentsModelList)
        {
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            foreach (CommentsModel commentsModel in commentsModelList)
            {
                if (commentsModel.commentId < 0)
                {
                    string sql = "INSERT INTO Comments (sid,comment,lstDemoDt,lstRevInt,lstRevDt) VALUES (@Sid,@comment,@lstDemoDt,lstRevInt,lstRevDt)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Sid", commentsModel.sid);
                        cmd.Parameters.AddWithValue("@comment", commentsModel.Comments);
                        cmd.Parameters.AddWithValue("@lstDemoDt", commentsModel.LastDemoDate);
                        cmd.Parameters.AddWithValue("@lstRevInt", commentsModel.LastReviewedInterval);
                        cmd.Parameters.AddWithValue("@lstRevDt", commentsModel.LastReviewedDate);
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
                else if (commentsModel.sid == 0 && commentsModel.commentId != 0)
                {
                    string sql = "Delete From Comments WHERE commentId = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", commentsModel.commentId);
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
                else
                {
                    string sql = "UPDATE Comments SET sid = @sid, comment = @comment, lstDemoDt=@lstDemoDt, lstrevInt=@lstrevInt, lstRevDt=@lstRevDt WHERE commentId = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", commentsModel.commentId);
                        cmd.Parameters.AddWithValue("@sid", commentsModel.sid);
                        cmd.Parameters.AddWithValue("@comment", commentsModel.Comments);
                        cmd.Parameters.AddWithValue("@lstDemoDt", commentsModel.LastDemoDate);
                        cmd.Parameters.AddWithValue("@lstRevInt", commentsModel.LastReviewedInterval);
                        cmd.Parameters.AddWithValue("@lstRevDt", commentsModel.LastReviewedDate);
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
        public static void insertUpdateDeleteSoftware(List<SoftwareModel> softwareModelList)
        {
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            foreach (SoftwareModel softwareModel in softwareModelList)
            {
                if (softwareModel.SoftwareId < 0)
                {
                    string sql = "INSERT INTO SoftName (vid,softName, [softWeb], [cloud]) VALUES (@Vid, @SoftwareName, @SoftwareWebsite, @Cloud);SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Vid", softwareModel.Vid);
                        cmd.Parameters.AddWithValue("@SoftwareName", softwareModel.SoftwareName);
                        cmd.Parameters.AddWithValue("@softwareWebsite", softwareModel.SoftwareWebsite);
                        cmd.Parameters.AddWithValue("@Cloud", softwareModel.Cloud);
                        try
                        {
                            con.Open();
                            int sId = Convert.ToInt32(cmd.ExecuteScalar());
                            foreach (BusinessAreasModel business in Controller.businessAreasModelList)
                            {
                                if (softwareModel.SoftwareId == business.id)
                                {
                                    business.Sid = sId;
                                }
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
                else
                {
                    string sql = "UPDATE SoftName SET SoftName = @SoftwareName, [softWeb] = @SoftwareWebsite, [cloud] = @Cloud WHERE vid = @Vid";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Vid", softwareModel.Vid);
                        cmd.Parameters.AddWithValue("@SoftwareName", softwareModel.SoftwareName);
                        cmd.Parameters.AddWithValue("@softwareWebsite", softwareModel.SoftwareWebsite);
                        cmd.Parameters.AddWithValue("@Cloud", softwareModel.Cloud);
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
                             "SET @GapIdentifier = @GapIdentifier - 1;" +               
                             "DBCC CHECKIDENT('" +tabName[i]+ "', RESEED, @GapIdentifier );";

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

