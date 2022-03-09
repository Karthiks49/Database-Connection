using Fresher;
using System.Data.SqlClient;

namespace DAL
{
    interface IFresherManagement
    {
        void AddFresher(FresherDetail fresher);

        SqlDataReader GetAllFreshers();

        void UpdateFresher(FresherDetail fresher);

        void DeleteFresher(int id);
    }
}
