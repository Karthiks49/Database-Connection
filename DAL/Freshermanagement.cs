using System;
using System.Data.SqlClient;
using Fresher;

namespace DAL
{
    public class Freshermanagement : IFresherManagement
    {
        private readonly DatabaseConnection dateBase = new DatabaseConnection();
        
        public void AddFresher(FresherDetail fresher)
        {
            SqlConnection connection = dateBase.Connection();
            try
            {
                SqlCommand command = new SqlCommand($"spCreateFresher '{fresher.name}', '{fresher.dateOfBirth}', {fresher.mobileNumber}, '{fresher.address}', '{fresher.qualification}'", connection);
                connection.Open();
                command.ExecuteNonQuery();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());

            } finally
            {
                connection.Close();
            }
        }

        public void UpdateFresher(FresherDetail fresher)
        {
            SqlConnection connection = dateBase.Connection();
            try
            {
                SqlCommand command = new SqlCommand($"spUpdateFresher {fresher.id}, '{fresher.name}', '{fresher.dateOfBirth}', {fresher.mobileNumber}, '{fresher.address}', '{fresher.qualification}'", connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteFresher(int id)
        {
            SqlConnection connection = dateBase.Connection();
            try
            {
                SqlCommand command = new SqlCommand($"spDeleteFresher {id}", connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            finally
            {
                connection.Close();
            }
        }

        public SqlDataReader GetAllFreshers()
        {
            SqlDataReader reader = null;
            SqlConnection connection = dateBase.Connection();
            try
            {
                SqlCommand command = new SqlCommand($"spGetFreshers", connection);
                reader = command.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            finally
            {
                connection.Close();
            }
            return reader;
        }
    }
}
