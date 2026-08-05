using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Service
{
    public static class DBConnectionUtillity
    {
        private static readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=HealthClinicDB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}