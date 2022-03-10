using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DataAccessManager
    {
        private readonly SqlConnection connection = new SqlConnection("data source=.; database=FresherManagement;" +
                                                                      " integrated security=SSPI");
        private SqlCommand sqlCommand;

        public void GetCommand(string command)
        {
            try
            {
                sqlCommand = new SqlCommand(command, connection);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public SqlDataAdapter GetDatas(string command)
        {
            SqlDataAdapter dataAdapter = null;

            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter(command, connection);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return dataAdapter;
        }
    }
}
