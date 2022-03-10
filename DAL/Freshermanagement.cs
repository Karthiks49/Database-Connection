using System;
using System.Data;
using System.Data.SqlClient;
using Fresher;

namespace DataAccess
{
    public class Freshermanagement : IFresherManagement
    {
        DataAccessManager dataManager = new DataAccessManager();
        
        public void AddFresher(FresherDetail fresher)
        {
            string command = $"spCreateFresher '{fresher.name}', '{fresher.dateOfBirth}', " +
                $"{fresher.mobileNumber}, '{fresher.address}', '{fresher.qualification}'";             
            dataManager.GetCommand(command);    
        }

        public DataTable GetFreshers()
        {
            DataTable freshersTable = new DataTable();

            string command = "spGetFreshers";
            SqlDataAdapter dataAdapter = dataManager.GetDatas(command);
            dataAdapter.Fill(freshersTable);

            return freshersTable;
        }

        public void UpdateFresher(FresherDetail fresher)
        {
            string command = $"spUpdateFresher {fresher.id}, '{fresher.name}', '{fresher.dateOfBirth}'," +
                $" {fresher.mobileNumber}, '{fresher.address}', '{fresher.qualification}'";
            dataManager.GetCommand(command);
        }

        public void DeleteFresher(int id)
        {
            string command = $"spDeleteFresher {id}";
            dataManager.GetCommand(command);
        }
    }
}
