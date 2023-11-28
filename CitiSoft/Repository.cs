using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace CitiSoft
{
    // Repository (Model)
    public partial class VendorRepository
    {
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
                    InternalProfessionalServices = Convert.ToString(dataReader.GetValue(4)),
                    LastDemoDate = Convert.ToString(dataReader.GetValue(5)),
                    LastReviewedDate = Convert.ToString(dataReader.GetValue(6)),
                    LastReviewedInterval = Convert.ToString(dataReader.GetValue(7)),
                }) ;
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
                if (vendorModel.Vid == -1)
                {
                    string sql = "INSERT INTO VendorInfo (compName, est, empCount, intProfServ, lstDemoDt, lstRevInt, lstRevDt) VALUES (@CompanyName, @CompanyEstablished, @Employees, @InternalServices, @LastDemoDate, @LastReviewInt, @LastReviewedDate)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@compName", vendorModel.CompanyName);
                        cmd.Parameters.AddWithValue("@est", vendorModel.CompanyEstablished);
                        cmd.Parameters.AddWithValue("@empCount", vendorModel.EmployeesCount);
                        cmd.Parameters.AddWithValue("@intProfServ", vendorModel.InternalProfessionalServices);
                        cmd.Parameters.AddWithValue("@lstDemoDt", vendorModel.LastDemoDate);
                        cmd.Parameters.AddWithValue("@lstRevInt", vendorModel.LastReviewedInterval);
                        cmd.Parameters.AddWithValue("@lstRevDt", vendorModel.LastReviewedDate);
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
                else if (vendorModel.CompanyName.Equals(null)) 
                {
                    string sql = "Delete From VendorInfo WHERE vid = @vid";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@vid", vendorModel.Vid);
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
                    string sql = "UPDATE VendorInfo SET compName = @compName, est = @est, empCount = @empCount, intProfServ = @intProfServ, lstDemoDt = @lstDemoDt, lstRevInt = @lstRevInt, lstRevDt = @lstRevDt WHERE vid = @vid";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@vid", vendorModel.Vid);
                        cmd.Parameters.AddWithValue("@compName", vendorModel.CompanyName);
                        cmd.Parameters.AddWithValue("@est", vendorModel.CompanyEstablished);
                        cmd.Parameters.AddWithValue("@empCount", vendorModel.EmployeesCount);
                        cmd.Parameters.AddWithValue("@intProfServ", vendorModel.InternalProfessionalServices);
                        cmd.Parameters.AddWithValue("@lstDemoDt", vendorModel.LastDemoDate);
                        cmd.Parameters.AddWithValue("@lstRevInt", vendorModel.LastReviewedInterval);
                        cmd.Parameters.AddWithValue("@lstRevDt", vendorModel.LastReviewedDate);
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
    }
    public partial class AddressRepository 
    {
        public static List<AddressModel> GetAllAddress()
        {
            List<AddressModel> addressModelList = new List<AddressModel>();
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
                addressModelList.Add(new AddressModel
                {
                    Vid = Convert.ToInt32(dataReader.GetValue(0)),
                    AddressLine1= Convert.ToString(dataReader.GetValue(1)),
                    AddressLine2 = Convert.ToString(dataReader.GetValue(2)),
                    City = Convert.ToString(dataReader.GetValue(3)),
                    Country = Convert.ToString(dataReader.GetValue(4)),
                    PostCode = Convert.ToString(dataReader.GetValue(5)),
                    Email = Convert.ToString(dataReader.GetValue(6)),
                    Telephone = Convert.ToString(dataReader.GetValue(7))
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
                if (addressModel.addressId == -1)
                {
                    string sql = "INSERT INTO Address (vid, addressLine1, addressLine2, city, country, postcode, email, telephone) VALUES (@vid, @addressLine1, @addressLine2, @city, @country, @postcode, @email, @telephone)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@vid", addressModel.Vid);
                        cmd.Parameters.AddWithValue("@addressLine1", addressModel.AddressLine1);
                        cmd.Parameters.AddWithValue("@addressLine2",addressModel.AddressLine2);
                        cmd.Parameters.AddWithValue("@city", addressModel.City);
                        cmd.Parameters.AddWithValue("@country", addressModel.Country);
                        cmd.Parameters.AddWithValue("@postcode", addressModel.PostCode);
                        cmd.Parameters.AddWithValue("@email", addressModel.Email);
                        cmd.Parameters.AddWithValue("@telephone", addressModel.Telephone);
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
                else if (addressModel.Vid == 0 && addressModel.addressId != 0 )
                {
                    string sql = "Delete From Address WHERE addressId = @addressId";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@vid", addressModel.addressId);
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
                    string sql = "INSERT INTO Address (vid, addressLine1, addressLine2, city, country, postcode, email, telephone) VALUES (@vid, @addressLine1, @addressLine2, @city, @country, @postcode, @email, @telephone)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@vid", addressModel.Vid);
                        cmd.Parameters.AddWithValue("@addressLine1", addressModel.AddressLine1);
                        cmd.Parameters.AddWithValue("@addressLine2", addressModel.AddressLine2);
                        cmd.Parameters.AddWithValue("@city", addressModel.City);
                        cmd.Parameters.AddWithValue("@country", addressModel.Country);
                        cmd.Parameters.AddWithValue("@postcode", addressModel.PostCode);
                        cmd.Parameters.AddWithValue("@email", addressModel.Email);
                        cmd.Parameters.AddWithValue("@telephone", addressModel.Telephone);
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
    }
}

