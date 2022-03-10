using Fresher;
using System.Data;

namespace DataAccess
{
    interface IFresherManagement
    {
        void AddFresher(FresherDetail fresher);

        DataTable GetFreshers();

        void UpdateFresher(FresherDetail fresher);

        void DeleteFresher(int id);
    }
}
