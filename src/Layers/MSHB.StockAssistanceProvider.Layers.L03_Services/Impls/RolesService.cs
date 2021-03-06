using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;
using MSHB.StockAssistanceProvider.Layers.L02_DataLayer;
using MSHB.StockAssistanceProvider.Shared.Common.GuardToolkit;
using MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.ViewModels;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.exceptions;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base;

namespace MSHB.StockAssistanceProvider.Layers.L03_Services.Impls
{  
    public class RolesService : IRolesService
    {
        private readonly StockAssistanceProviderDbContext _context;
        public RolesService(StockAssistanceProviderDbContext context)
        {
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));
        }

        public async Task<List<Role>> FindUserRolesAsync(Guid userId)
        {
            try
            {
                var userRolesQuery = from role in _context.Roles
                                     from userRoles in role.UserRoles
                                     where userRoles.UserId == userId
                                     select role;
                return await userRolesQuery.OrderBy(x => x.Name).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new StockAssistanceProviderGlobalException(RolesServiceErrors.FindUserRolesError, ex);
            }
            
           
        }

        public async Task<bool> IsUserInRole(Guid userId, string roleName)
        {
            try
            {
                var userRolesQuery = from role in _context.Roles
                                     where role.Name == roleName
                                     from user in role.UserRoles
                                     where user.UserId == userId
                                     select role;
                var userInRole= await userRolesQuery.FirstOrDefaultAsync();
                return userInRole != null;
            }
            catch (Exception ex)
            {

                throw new StockAssistanceProviderGlobalException(RolesServiceErrors.GetIsUserInRoleError, ex);
            }
            
        }

        public Task<List<User>> FindUsersInRoleAsync(string roleName)
        {
            try
            {
                var roleUserIdsQuery = from role in _context.Roles
                                       where role.Name == roleName
                                       from user in role.UserRoles
                                       select user.UserId;
                return _context.Users.Where(user => roleUserIdsQuery.Contains(user.Id))
                             .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new StockAssistanceProviderGlobalException(RolesServiceErrors.GetFindUsersInRoleError, ex);
            }
            
           
        }
        public async Task<List<RoleViewModel>> GetRolesAsync(User user)
        {
            try
            {
                var roles = await _context.Roles.ToListAsync();
                return roles.Select(x => new RoleViewModel
                {
                    RoleId = x.Id,
                    Name = x.Name,
                    Title = x.Title
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new StockAssistanceProviderGlobalException(RolesServiceErrors.GetRolesError, ex);
            }
        }
    }
}