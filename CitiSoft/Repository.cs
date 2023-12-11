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
                    Operation = 'N'
                });
            }
            dataReader.Close();
            cmd.Dispose();
            con.Close();
            return vendorModelList;
        }

        public static void insertUpdateDelete(List<VendorModel> vendorModelList)
        {
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            foreach (VendorModel vendorModel in vendorModelList)
            {
                if (vendorModel.Operation.Equals('I'))
                {

                    try
                    {
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
                                        if (vendorModel.Vid == add.AddressId)
                                        {
                                            add.Vid = venId;
                                        }
                                    }
                                    Repository.insertUpdateDelete(Controller.addressModelList);

                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Error: " + ex.Message + "Insert");

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
                else if (vendorModel.Operation.Equals('D'))
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
                else if (vendorModel.Operation.Equals('U'))
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
                            MessageBox.Show("Error: " + ex.Message + "Update");
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
                    AddressId = Convert.ToInt32(dataReader.GetValue(0)),
                    Vid = Convert.ToInt32(dataReader.GetValue(1)),
                    AddressLine1 = Convert.ToString(dataReader.GetValue(2)),
                    AddressLine2 = Convert.ToString(dataReader.GetValue(3)),
                    City = Convert.ToString(dataReader.GetValue(4)),
                    Country = Convert.ToString(dataReader.GetValue(5)),
                    PostCode = Convert.ToString(dataReader.GetValue(6)),
                    Email = Convert.ToString(dataReader.GetValue(7)),
                    Telephone = Convert.ToString(dataReader.GetValue(8)),
                    Operation = 'N'
                });
            }
            dataReader.Close();
            cmd.Dispose();
            con.Close();
            return addressModelList;
        }

        public static void insertUpdateDelete(List<AddressModel> addressModelList)
        {
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            foreach (AddressModel addressModel in addressModelList)
            {
                if (addressModel.Operation.Equals('I'))
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
                else if (addressModel.Operation.Equals('D'))
                {
                    string sql = "Delete From Address WHERE addressId = @addressId";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@addressId", addressModel.AddressId);
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
                else if (addressModel.Operation.Equals('U'))
                {
                    string sql = "UPDATE Address SET vid = @Vid, addressLine1 = @AddressLine1, addressLine2 = @AddressLine2, city = @City, country = @Country, postcode = @PostCode, email = @Email, telephone = @Telephone WHERE addressId = @AddressId";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@AddressId", addressModel.AddressId);
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
                    AdditionalInfo = Convert.ToString(dataReader.GetValue(6)),
                    Operation = 'N'
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
                    Id = Convert.ToInt32(dataReader.GetValue(0)),
                    Sid = Convert.ToInt32(dataReader.GetValue(1)),
                    Modules = Convert.ToString(dataReader.GetValue(2)),
                    Operation = 'N'
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
                    Id = Convert.ToInt32(dataReader.GetValue(0)),
                    Sid = Convert.ToInt32(dataReader.GetValue(1)),
                    BusinessAreas = Convert.ToString(dataReader.GetValue(2)),
                    Operation = 'N'
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
                    Id = Convert.ToInt32(dataReader.GetValue(0)),
                    Sid = Convert.ToInt32(dataReader.GetValue(1)),
                    FinancialService = Convert.ToString(dataReader.GetValue(2)),
                    Operation = 'N'
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
                    Id = Convert.ToInt32(dataReader.GetValue(0)),
                    Sid = Convert.ToInt32(dataReader.GetValue(1)),
                    TypeOfSoftware = Convert.ToString(dataReader.GetValue(2)),
                    Operation = 'N'
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
                if (typeOfSoftwareModel.Operation.Equals('I'))
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
                else if (typeOfSoftwareModel.Operation.Equals('D'))
                {
                    string sql = "Delete From SoftTypes WHERE softTypesId = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", typeOfSoftwareModel.Id);
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
                else if (typeOfSoftwareModel.Operation.Equals('U'))
                {
                    string sql = "UPDATE SoftTypes SET sid = @sid, softTypes = @typeOfSoftware WHERE softTypesId = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", typeOfSoftwareModel.Id);
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
                if (businessAreasModel.Operation.Equals('I'))
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
                else if (businessAreasModel.Operation.Equals('D'))
                {
                    string sql = "Delete From Business WHERE businessId = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", businessAreasModel.Id);
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
                else if (businessAreasModel.Operation.Equals('U'))
                {
                    string sql = "UPDATE Business SET sid = @sid, BusinessArea = @Business WHERE businessId = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", businessAreasModel.Id);
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
                if (modulesModel.Operation.Equals('I'))
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
                else if (modulesModel.Operation.Equals('D'))
                {
                    string sql = "Delete From Modules WHERE modulesId = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", modulesModel.Id);
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
                else if (modulesModel.Operation.Equals('U'))
                {
                    string sql = "UPDATE Modules SET sid = @sid, modules = @modules WHERE modulesId = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", modulesModel.Id);
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
                if (financialModel.Operation.Equals('I'))
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
                else if (financialModel.Operation.Equals('D'))
                {
                    string sql = "Delete From ClientTypes WHERE clientTypesId = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", financialModel.Id);
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
                else if (financialModel.Operation.Equals('U'))
                {
                    string sql = "UPDATE ClientTypes SET sid = @sid, finSerCliTypes = @finance WHERE clientTypesId = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", financialModel.Id);
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
                if (commentsModel.Operation.Equals('I'))
                {
                    string sql = "INSERT INTO Comments (sid,comment,lstDemoDt,lstRevInt,lstRevDt) VALUES (@Sid,@comment,@lstDemoDt,lstRevInt,lstRevDt)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Sid", commentsModel.Sid);
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
                else if (commentsModel.Operation.Equals('D'))

                {
                    string sql = "Delete From Comments WHERE commentId = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", commentsModel.CommentId);
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
                else if (commentsModel.Operation.Equals('U'))
                {
                    string sql = "UPDATE Comments SET sid = @sid, comment = @comment, lstDemoDt=@lstDemoDt, lstrevInt=@lstrevInt, lstRevDt=@lstRevDt WHERE commentId = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", commentsModel.CommentId);
                        cmd.Parameters.AddWithValue("@sid", commentsModel.Sid);
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
        public static void insertUpdateDelete(List<SoftwareModel> softwareModelList)
        {
            SqlConnection con;
            con = DataBaseManager.GetCitiSoftConnection();
            foreach (SoftwareModel softwareModel in softwareModelList)
            {
                if (softwareModel.Operation.Equals('I'))
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
                                if (softwareModel.SoftwareId == business.Id)
                                {
                                    business.Sid = sId;
                                }
                            }
                            foreach (TypeOfSoftwareModel type in Controller.typeOfSoftwareModelList)
                            {
                                if (softwareModel.SoftwareId == type.Id)
                                {
                                    type.Sid = sId;
                                }
                            }
                            foreach (ModulesModel modules in Controller.modulesModelList)
                            {
                                if (softwareModel.SoftwareId == modules.Id)
                                {
                                    modules.Sid = sId;
                                }
                            }
                            foreach (FinancialServicesModel fin in Controller.financialServicesModelList)
                            {
                                if (softwareModel.SoftwareId == fin.Id)
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
                else if (softwareModel.Operation.Equals('D'))
                {
                    string sql = "Delete From SoftName WHERE sid = @SoftwareId";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@SoftwareId", softwareModel.SoftwareId);
                        try
                        {
                            con.Open();
                            MessageBox.Show(cmd.ExecuteNonQuery().ToString());


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
                else if (softwareModel.Operation.Equals('U'))
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
                    Sid = Convert.ToInt32(dataReader.GetValue(0)),
                    CommentId = Convert.ToInt32(dataReader.GetValue(1)),
                    Comments = Convert.ToString(dataReader.GetValue(2)),
                    LastDemoDate = Convert.ToDateTime(dataReader.GetValue(3)),
                    LastReviewedInterval = Convert.ToInt32(dataReader.GetValue(4)),
                    LastReviewedDate = Convert.ToDateTime(dataReader.GetValue(5)),
                    Operation = 'N'
                });
            }
            dataReader.Close();
            cmd.Dispose();
            con.Close();
            return commentsModelList;
        }

        public AddressModel AddressModel1
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

