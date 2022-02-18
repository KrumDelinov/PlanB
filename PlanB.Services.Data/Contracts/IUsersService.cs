using PlanB.Data.Models;
using PlanB.Web.ViewModels.Administration.Dashboard;

namespace PlanB.Services.Data
{
    public interface IUsersService
    {
        IEnumerable<T> GetAll<T>();

        Task<IndexViewModel> GetUsersWithRolesAsync();

        Task<EditUserViewModel> EditUser(string id);

        Task<ApplicationUser> GetCurrentUser();

        T GetT<T>(string userId);
    }
}
