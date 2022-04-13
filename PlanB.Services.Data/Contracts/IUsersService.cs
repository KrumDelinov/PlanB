using PlanB.Data.Models;
using PlanB.Web.ViewModels.Administration.Dashboard;

namespace PlanB.Services.Data
{
    public interface IUsersService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllOtherUsers<T>(string id);

        Task<IndexViewModel> GetUsersWithRolesAsync();

        Task<EditUserViewModel> EditUser(string id);

        Task<ApplicationUser> GetCurrentUser();

        T GetT<T>(string userId);

        Task<string> GetUserId(string fullName);

        Task<ApplicationUser> GetUserByUserName(string userName);
    }
}
