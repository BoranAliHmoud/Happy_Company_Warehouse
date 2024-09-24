using Happy_Company_Warehouse.DataAccess.DTO;
using Happy_Company_Warehouse.DataAccess.Settings.Models;
using Happy_Company_Warehouse.Model;
using System.Threading.Tasks;
 

namespace Happy_Company_Warehouse.DataAccess.Services
{
    public interface IAuthService
    {
        Task<AuthModel> AddUserAsync(UserModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<List<ApplicationUser>> GetAllUsers(FilterActivities filter);
     }
}