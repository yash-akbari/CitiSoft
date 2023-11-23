using System;
using System.Data.SqlClient;

namespace CitiSoft
{
    public class VendorDocsManager
    {
        private string _connectionString;

        public VendorDocsManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Method to access vendor docs based on vendor ID
        public string AccessVendorDocs(int vendorId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT document_attached FROM Vendor WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", vendorId);

                    var documentPath = command.ExecuteScalar();
                    if (documentPath != null)
                    {
                        return documentPath.ToString();
                    }
                }
            }
            return null;
        }

        // Method to remove vendor docs based on vendor ID
        public bool RemoveVendorDocs(int vendorId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Vendor SET document_attached = NULL WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", vendorId);
                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows > 0;
                }
            }
        }
    }
}
