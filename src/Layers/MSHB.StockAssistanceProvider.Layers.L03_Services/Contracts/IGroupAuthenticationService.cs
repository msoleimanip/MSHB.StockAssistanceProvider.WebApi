﻿using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.InputForms;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts
{
    public interface IGroupAuthenticationService
    {
        Task<List<GroupAuthenticationViewModel>> GetGroupAuthenticationAsync();
        Task<List<RoleViewModel>> GetGroupRoleAsync(User user, long Id);
        Task<GroupRoleViewModel> GetGroupAuthenticationByIdAsync(long Id);
        Task<long> AddGroupAsync(User user, AddGroupFormModel groupForm);
        Task<bool> EditGroupAsync(User user, EditGroupFormModel groupForm);
        Task<bool> DeleteGroupAsync(User user, List<long> groupIds);
        Task<GroupAuth> GetGroupByIdAsync(User user, long groupAuthId);
    }
}
