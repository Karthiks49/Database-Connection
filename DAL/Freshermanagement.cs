using System;
using System.Data;
using System.Data.SqlClient;
using Fresher;

namespace DataAccess
{
    public class Freshermanagement : IFresherManagement
    {
        private readonly DataAccessManager dataManager = new DataAccessManager();

        public DataTable GetFreshers()
        {
            DataTable freshersTable = new DataTable();

            string command = "spGetFreshers";
            SqlDataAdapter dataAdapter = dataManager.GetDatas(command);
            dataAdapter.Fill(freshersTable);

            return freshersTable;
        }

        public int SaveFreshers(FresherDetail fresher)
        {
            string command = $"spSaveFreshers {fresher.id}, '{fresher.name}', '{fresher.dateOfBirth}'," +
                $" {fresher.mobileNumber}, '{fresher.address}', '{fresher.qualification}'";
            return dataManager.GetCommand(command);
        }

        public void DeleteFresher(int id)
        {
            string command = $"spDeleteFresher {id}";
            dataManager.GetCommand(command);
        }
    }
}
