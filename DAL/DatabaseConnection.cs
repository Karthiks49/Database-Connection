using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DatabaseConnection
    {
        public SqlConnection Connection()
        { 
            SqlConnection  con = new SqlConnection("data source=.; database=FresherManagement; integrated security=SSPI");
            return con;
        }
    }
}
