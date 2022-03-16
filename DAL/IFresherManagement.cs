using Fresher;
using System.Data;

namespace DataAccess
{
    interface IFresherManagement
    { 

        DataTable GetFreshers();

        int SaveFreshers(FresherDetail fresher);

        void DeleteFresher(int id);
    }
}
