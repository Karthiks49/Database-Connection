using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DataAccessManager
    {
        private readonly SqlConnection connection = new SqlConnection("data source=.; database=FresherManagement;" +
                                                                      " integrated security=SSPI");
        private SqlCommand sqlCommand;

        public int GetCommand(string command)
        {
            int affectedRow = 0;
            try
            {
                sqlCommand = new SqlCommand(command, connection);
                connection.Open();
                affectedRow = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return affectedRow;
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
