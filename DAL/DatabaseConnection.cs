using System.Data.SqlClient;

namespace DAL
{
    public class DatabaseConnection
    {
        public SqlConnection Connection()
        { 
            SqlConnection  con = new SqlConnection("data source=.; database=FresherManagement; integrated security=SSPI");
            return con;
        }
    }
}
