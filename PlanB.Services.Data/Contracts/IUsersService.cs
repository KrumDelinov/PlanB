using PlanB.Data.Models;
using PlanB.Web.ViewModels.Administration.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Services.Data
{
    public interface IUsersService
    {
        IEnumerable<T> GetAll<T>();

        Task<IndexViewModel> GetUsersWithRolesAsync();

        Task<EditUserViewModel> EditUser(string id);

        Task<ApplicationUser> GetCurrentUser();
    }
}
