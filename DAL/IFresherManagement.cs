using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
