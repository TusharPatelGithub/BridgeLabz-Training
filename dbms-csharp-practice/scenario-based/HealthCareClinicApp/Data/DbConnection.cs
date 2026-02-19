using Microsoft.Data.SqlClient;
namespace HealthCareClinicApp.Data
{
    public class DbConnection
    {
        private static readonly string connectionString =
            "Server=.\\SQLEXPRESS;Database=HealthCareClinic;Trusted_Connection=True;TrustServerCertificate=True;";
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }
    }
}
