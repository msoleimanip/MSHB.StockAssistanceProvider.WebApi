﻿using System;
using System.Collections.Generic;
using System.Linq;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Http;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Authority;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.exceptions;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Enums;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;
using SubPro.WebUI.Shared.Common.IdentityToolkit;

namespace MSHB.StockAssistanceProvider.Presentation.WebCore
{
    public static class ControllerUtils
    {
        public static List<string> GetUserRoleNames(this HttpContext context)
        {
            try
            {
                var res = context.User.Identity.GetUserClaimRoles();

                if (res.Count > 0)
                {
                    return (List<string>)res;
                }

                throw new StockAssistanceProviderGlobalException(ControllerUtilsErrors.UserRolesNotFound);
            }
            catch (Exception e)
            {
                throw new StockAssistanceProviderGlobalException(ControllerUtilsErrors.GetUserRoles, e);
            }
        }
        public static User GetUser(this HttpContext context)
        {
            try
            {
                User user = new User
                {
                    Username = context.User.Identity.GetUserName(),
                    FirstName = context.User.Identity.GetUserFirstName(),
                    LastName = context.User.Identity.GetUserLastName(),
                    Id = context.User.Identity.GetUserId<Guid>(),
                    UserType = context.User.Identity.GetUserType<UserType>(),
                    AvailableUserType = context.User.Identity.GetAvailableUserType<AvailableUserType>()

                };

                return user;
            }

            catch (Exception e)
            {
                throw new StockAssistanceProviderGlobalException(ControllerUtilsErrors.GetUserError, e);
            }
        }

        public static UserType GetUserType(this HttpContext context)
        {
            try
            {
                var userType = (UserType)context.User.Identity.GetUserType<UserType>();
                return userType;
            }

            catch (Exception e)
            {
                throw new StockAssistanceProviderGlobalException(ControllerUtilsErrors.GetUserPresidentError, e);
            }
        }

        public static TimeSpan? ConvertTimeStringToMiliseconds(string time)
        {
            if (string.IsNullOrEmpty(time)) return null;
            var parts = time.Split(":").Select(x => int.Parse(x)).ToList();
            var hours = TimeSpan.FromHours(parts[0]).TotalMilliseconds;
            var minutes = TimeSpan.FromMinutes(parts[1]).TotalMilliseconds;
            var seconds = TimeSpan.FromSeconds(parts[2]).TotalMilliseconds;
            var totalMiliseconds = hours + minutes + seconds;
            return TimeSpan.FromMilliseconds(totalMiliseconds);

        }


    }
}