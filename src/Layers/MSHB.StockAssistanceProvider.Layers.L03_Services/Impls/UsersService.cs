﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.exceptions;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;
using MSHB.StockAssistanceProvider.Layers.L02_DataLayer;
using MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.InputForms;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.ViewModels;
using MSHB.StockAssistanceProvider.Shared.Common.GuardToolkit;

namespace MSHB.StockAssistanceProvider.Layers.L03_Services.Impls
{

    public class UsersService : IUsersService
    {
        private readonly ISecurityService _securityService;

        private readonly StockAssistanceProviderDbContext _context;
        public UsersService(ISecurityService securityService, StockAssistanceProviderDbContext context)
        {
            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));
        }

        public async Task<User> FindUserLoginAsync(string username, string password)
        {
            var passwordHash = _securityService.GetSha256Hash(password);
            var resp = await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == passwordHash);
            if (resp == null)
            {
                throw new StockAssistanceProviderGlobalException(UsersServiceErrors.Unauthorized);
            }
            if (!resp.IsActive)
            {
                throw new StockAssistanceProviderGlobalException(UsersServiceErrors.DeActive);
            }

            return resp;
        }
        public async Task<Guid> AddUserAsync(User user, AddUserFormModel userForm)
        {
            try
            {
                if (_context.Users.Any(c => c.Username.ToLower() == userForm.Username.ToLower()))
                {
                    throw new StockAssistanceProviderGlobalException(UsersServiceErrors.UserExistError);
                }
                var groupRole = await _context.GroupAuthRoles.Where(c => c.GroupAuthId == userForm.GroupAuthId).ToListAsync();
                if (groupRole == null)
                {
                    throw new StockAssistanceProviderGlobalException(UsersServiceErrors.GroupNotFoundError);
                }

                var userReg = new User()
                {

                    GroupAuthId = userForm.GroupAuthId,
                    FirstName = userForm.FirstName,
                    Description = userForm.Description,
                    IsActive = userForm.IsActive,
                    UserType = userForm.UserType,
                    LastName = userForm.LastName,
                    AvailableUserType= userForm.AvailableUserType,
                    Password = _securityService.GetSha256Hash(userForm.Password),
                    SerialNumber = Guid.NewGuid().ToString("N"),

                    Location = userForm.Location,
                    PhoneNumber = userForm.PhoneNumber,
                    Username = userForm.Username.ToLower()
                };
                _context.Users.Add(userReg);
                _context.UserRoles.AddRange(groupRole.Select(c => c.RoleId).ToList().Select(roleId =>
                                                      new UserRole
                                                      {
                                                          User = userReg,
                                                          RoleId = roleId
                                                      }));
                _context.SaveChanges();
                return userReg.Id;

            }
            catch (Exception ex)
            {

                throw new StockAssistanceProviderGlobalException(UsersServiceErrors.AddUserError, ex);
            }
        }
        public async Task<bool> EditUserAsync(User user, EditUserFormModel userForm)
        {
            try
            {
                if (_context.Users.Any(c => c.Username.ToLower() == userForm.Username.ToLower() && c.Id != userForm.UserId))
                {
                    throw new StockAssistanceProviderGlobalException(UsersServiceErrors.UserExistError);
                }
                var userEdt = await _context.Users.FirstOrDefaultAsync(c => c.Id == userForm.UserId);
                if (userEdt == null)
                {
                    throw new StockAssistanceProviderGlobalException(UsersServiceErrors.UserNotFoundError);
                }
                var groupRole = await _context.GroupAuthRoles.Where(c => c.GroupAuthId == userForm.GroupAuthId).Include(c => c.Role).ToListAsync();
                if (groupRole == null)
                {
                    throw new StockAssistanceProviderGlobalException(UsersServiceErrors.GroupNotFoundError);
                }


                if (userEdt.GroupAuthId != userForm.GroupAuthId)
                {

                    _context.UserRoles.RemoveRange(_context.UserRoles.Where(c => c.UserId == userForm.UserId).ToList());

                    var newUserRoles = groupRole.Select(c => c.Role).Select(role =>
                                           new UserRole
                                           {
                                               UserId = userForm.UserId,
                                               Role = role
                                           }).ToList();
                    _context.UserRoles.AddRange(newUserRoles);

                }

                userEdt.GroupAuthId = userForm.GroupAuthId;
                userEdt.FirstName = userForm.FirstName;
                userEdt.Description = userForm.Description;
                userEdt.IsActive = userForm.IsActive;
                userEdt.UserType = userForm.UserType;
                userEdt.AvailableUserType = userForm.AvailableUserType;
                userEdt.LastName = userForm.LastName;
                if (!string.IsNullOrEmpty(userForm.Password))
                    userEdt.Password = _securityService.GetSha256Hash(userForm.Password);
                userEdt.SerialNumber = Guid.NewGuid().ToString("N");

                userEdt.Location = userForm.Location;
                userEdt.PhoneNumber = userForm.PhoneNumber;
                _context.Users.Update(userEdt);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw new StockAssistanceProviderGlobalException(UsersServiceErrors.AddUserError, ex);
            }
        }
        public async Task<UserViewModel> GetUserById(User user, Guid id)
        {
            var respUser = await _context.Users.FindAsync(id);
            return new UserViewModel()
            {
                Id = respUser.Id,
                FirstName = respUser.FirstName,
                LastName = respUser.LastName,
                Username = respUser.Username,
                Description = respUser.Description,
                Location = respUser.Location,
                PhoneNumber = respUser.PhoneNumber,
                IsActive = respUser.IsActive,
                UserType = respUser.UserType,
                AvailableUserType = respUser.AvailableUserType,
                GroupAuthId = respUser.GroupAuthId,
                LastLockoutDate = respUser.LastLockoutDate,
                LastPasswordChangedDate = respUser.LastPasswordChangedDate,
                CreationDate = respUser.CreationDate,
                LastVisit = respUser.LastVisit,
                LastLoggedIn = respUser.LastLoggedIn
            };

        }
        public async Task<SearchUserViewModel> GetUsersAsync(SearchUserFormModel searchUserForm)
        {
            var queryable = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(searchUserForm.FirstName))
            {
                queryable = queryable.Where(q => q.FirstName.Contains(searchUserForm.FirstName));
            }

            if (!string.IsNullOrEmpty(searchUserForm.LastName))
            {
                queryable = queryable.Where(q => q.LastName.Contains(searchUserForm.LastName));
            }

            if (!string.IsNullOrEmpty(searchUserForm.Username))
            {
                queryable = queryable.Where(q => q.Username.Contains(searchUserForm.Username));
            }

            if (searchUserForm.IsActive.HasValue)
            {
                queryable = queryable.Where(q => q.IsActive == searchUserForm.IsActive.Value);
            }
            if (searchUserForm.SortModel != null)
                switch (searchUserForm.SortModel.Col + "|" + searchUserForm.SortModel.Sort)
                {
                    case "firstname|asc":
                        queryable = queryable.OrderBy(x => x.FirstName);
                        break;
                    case "firstname|desc":
                        queryable = queryable.OrderByDescending(x => x.FirstName);
                        break;
                    case "lastname|asc":
                        queryable = queryable.OrderBy(x => x.LastName);
                        break;
                    case "lastname|desc":
                        queryable = queryable.OrderByDescending(x => x.LastName);
                        break;
                    case "username|asc":
                        queryable = queryable.OrderBy(x => x.Username);
                        break;
                    case "username|desc":
                        queryable = queryable.OrderByDescending(x => x.Username);
                        break;
                    default:
                        queryable = queryable.OrderBy(x => x.CreationDate);
                        break;
                }
            else
                queryable = queryable.OrderBy(x => x.CreationDate);
            var resp = await queryable.Skip((searchUserForm.PageIndex - 1) * searchUserForm.PageSize).Take(searchUserForm.PageSize).ToListAsync();
            var count = await queryable.CountAsync();
            var searchViewModel = new SearchUserViewModel();
            searchViewModel.searchUserViewModel = resp.Select(respUser => new UserViewModel()
            {
                Id = respUser.Id,
                FirstName = respUser.FirstName,
                LastName = respUser.LastName,
                Username = respUser.Username,
                Description = respUser.Description,
                Location = respUser.Location,
                PhoneNumber = respUser.PhoneNumber,
                IsActive = respUser.IsActive,
                UserType = respUser.UserType,
                AvailableUserType=respUser.AvailableUserType,
                GroupAuthId = respUser.GroupAuthId,
                LastLockoutDate = respUser.LastLockoutDate,
                LastPasswordChangedDate = respUser.LastPasswordChangedDate,
                CreationDate = respUser.CreationDate,
                LastVisit = respUser.LastVisit,
                LastLoggedIn = respUser.LastLoggedIn,

            }).ToList();
            searchViewModel.PageIndex = searchUserForm.PageIndex;
            searchViewModel.PageSize = searchUserForm.PageSize;
            searchViewModel.TotalCount = count;
            return searchViewModel;
        }
        public async Task UpdateUserLastActivityDateAsync(Guid userId)
        {
            var user = await FindUserAsync(userId);
            if (user.LastLoggedIn != null)
            {
                var updateLastActivityDate = TimeSpan.FromMinutes(2);
                var currentUtc = DateTimeOffset.UtcNow;
                var timeElapsed = currentUtc.Subtract(user.LastLoggedIn.Value);
                if (timeElapsed < updateLastActivityDate)
                {
                    return;
                }
            }
            user.LastLoggedIn = DateTimeOffset.UtcNow;
            await _context.SaveChangesAsync();


        }
        public async Task<User> FindUserAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }
       
        public async Task<User> FindUserAsync(string username, string password)
        {
            var passwordHash = _securityService.GetSha256Hash(password);
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == passwordHash);
        }


        public async Task<string> GetSerialNumberAsync(Guid userId)
        {
            var user = await FindUserAsync(userId);
            return user.SerialNumber;
        }

        public async Task<bool> ChangeActivateUserAsync(User user, ChangeActivationFormModel userForm)
        {
            try
            {
                var userEdt = await _context.Users.FindAsync(userForm.UserId);
                if (userEdt == null)
                {
                    throw new StockAssistanceProviderGlobalException(UsersServiceErrors.UserNotFoundError);
                }
                userEdt.IsActive = userForm.IsActive;
                _context.Users.Update(userEdt);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw new StockAssistanceProviderGlobalException(UsersServiceErrors.ChangeStateError, ex);
            }
        }

        public async Task<bool> ChangePasswordAsync(User user, ChangePasswordFormModel userForm)
        {
            try
            {
                var userEdt = await _context.Users.FirstOrDefaultAsync(c => c.Id == userForm.UserId && c.Password == _securityService.GetSha256Hash(userForm.CurrentPassword));
                if (userEdt == null)
                {
                    throw new StockAssistanceProviderGlobalException(UsersServiceErrors.UserNotFoundError);
                }
                userEdt.Password = _securityService.GetSha256Hash(userForm.NewPassword);
                _context.Users.Update(userEdt);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new StockAssistanceProviderGlobalException(UsersServiceErrors.ChangePasswordError, ex);
            }
        }



    }
}
