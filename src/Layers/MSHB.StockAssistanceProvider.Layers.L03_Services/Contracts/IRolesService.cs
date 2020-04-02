using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.InputForms;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts
{
    public interface IRolesService
    {
        Task<List<Role>> FindUserRolesAsync(Guid userId);
        Task<bool> IsUserInRole(Guid userId, string roleName);
        Task<List<User>> FindUsersInRoleAsync(string roleName);
        Task<List<RoleViewModel>> GetRolesAsync(User user);
    }
}
