﻿using System;
using System.Collections.Generic;
using System.Linq;

using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;

namespace MSHB.StockAssistanceProvider.Layers.L03_Services.Initialization
{ 
    public static class CustomRoles
    {
        public static List<Role> GetInitialRoles()
        {
            var initRoles = new List<Role>();
            initRoles.AddRange(DefineInitRole());


            return initRoles;
        }

        private static List<Role> DefineInitRole()
        {
            var initRoles = new List<Role>
            {
                DefineIntRole("File", "File"),
                DefineIntRole("File-UploadFile", "File-UploadFile"),
                DefineIntRole("File-DownloadFile", "File-DownloadFile"),           

                DefineIntRole("GroupAuthentication", "GroupAuthentication"),
                DefineIntRole("GroupAuthentication-GetGroupAuthentication", "GroupAuthentication-GetGroupAuthentication"),
                DefineIntRole("GroupAuthentication-GetGroupRole", "GroupAuthentication-GetGroupRole"),
                DefineIntRole("GroupAuthentication-AddGroup", "GroupAuthentication-AddGroup"),
                DefineIntRole("GroupAuthentication-EditGroup", "GroupAuthentication-EditGroup"),
                DefineIntRole("GroupAuthentication-DeleteGroup", "GroupAuthentication-DeleteGroup"),
                DefineIntRole("GroupAuthentication-GetRoles", "GroupAuthentication-GetRoles"),
                DefineIntRole("GroupAuthentication-GetGroupAuthenticationById", "GroupAuthentication-GetGroupAuthenticationById"),

             
                DefineIntRole("Account", "Account"),
                DefineIntRole("Account-RefreshToken", "Account-RefreshToken"),
                DefineIntRole("Account-AddUser", "Account-AddUser"),
                DefineIntRole("Account-EditUser", "Account-EditUser"),
                DefineIntRole("Account-ChangeActivateUser", "Account-ChangeActivateUser"),
                DefineIntRole("Account-ChangePassword", "Account-ChangePassword"),
                DefineIntRole("Account-GetUsers", "Account-GetUsers"),
                DefineIntRole("Account-UserCityAssign", "Account-UserCityAssign"),
                DefineIntRole("Account-GetUserById", "Account-GetUserById"),
         
                
                


                DefineIntRole("Report", "Report"),
                DefineIntRole("Report-GetReportStructure", "Report-GetReportStructure"),
                DefineIntRole("Report-AddOrUpdateReportStructure", "Report-AddOrUpdateReportStructure"),
                          

                DefineIntRole("Dashboard", "Dashboard"),
                

            };

            return initRoles;

        }
        private static Role DefineIntRole(string name, string title)
        {
            var role = new Role()
            {
                Name = name,
                Title = title,
                Discriminator = "Role"
            };

            return role;

        }
    }
}
