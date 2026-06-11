using Microsoft.Data.SqlClient;

namespace LibraryManagementSystem.Repository
{
    public static class DbConnection
    {
        private static readonly string connectionString =
            @"Server=MSP\SQLEXPRESS01;
              Database=LibraryDB;
              Trusted_Connection=True;
              TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}