using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Transactions;
using MSHB.StockAssistanceProvider.Shared.Common.GuardToolkit;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;
using MSHB.StockAssistanceProvider.Layers.L02_DataLayer;
using MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Enums;

namespace MSHB.StockAssistanceProvider.Layers.L03_Services.Initialization
{
    public interface IDbInitializerService
    {
        /// <summary>
        /// Applies any pending migrations for the context to the database.
        /// Will create the database if it does not already exist.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Adds some default values to the Db
        /// </summary>
        void SeedData();
    }

    public class DbInitializerService : IDbInitializerService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ISecurityService _securityService;
        private readonly StockAssistanceProviderDbContext _context;

        public DbInitializerService(
            IServiceScopeFactory scopeFactory,
            ISecurityService securityService, StockAssistanceProviderDbContext context)
        {
            _scopeFactory = scopeFactory;
            _scopeFactory.CheckArgumentIsNull(nameof(_scopeFactory));

            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));
        }

        public void Initialize()
        {

            _context.Database.Migrate();
        }

        public void SeedData()
        {





            // Add default roles
            var adminRole = CustomRoles.GetInitialRoles();

            if (!_context.Roles.Any())
            {
                _context.AddRange(adminRole);

                _context.SaveChanges();
            }

            // Add Admin user
            if (!_context.Users.Any())
            {
                var groupAuth = new GroupAuth()
                {
                    Name = "Administrator",
                    Description = "Administrator"
                };

               
                var adminUser = new User
                {
                    Username = "admin",
                    FirstName = "مدیر",
                    LastName = "سیستم",
                    IsActive = true,
                    IsPresident = PresidentType.Admin,
                    LastLoggedIn = null,
                    Password = _securityService.GetSha256Hash("1234"),
                    SerialNumber = Guid.NewGuid().ToString("N"),
                    GroupAuth = groupAuth,
                  
                };

                _context.GroupAuths.Add(groupAuth);
                _context.Users.Add(adminUser);
             

                foreach (var role in _context.Roles.ToList())
                {
                    _context.Add(new UserRole { Role = role, User = adminUser });
                    if (groupAuth != null)
                    {
                        _context.GroupAuthRoles.Add(new GroupAuthRole { GroupAuth = groupAuth, Role = role });
                    }
                }

                _context.SaveChanges();



            }

            if (!_context.ReportStructures.Any())
            {
                ReportStructure report_Users = new ReportStructure()
                {
                    ReportId = "Users",
                    Configuration = "{\"ReportVersion\":\"2019.3.2\",\"ReportGuid\":\"655ffc26d15b6d0a0fecf3d36e4598c7\",\"ReportName\":\"Report\",\"ReportAlias\":\"Report\",\"ReportFile\":\"Report.mrt\",\"ReportCreated\":\"/Date(1564426080000+0430)/\",\"ReportChanged\":\"/Date(1564426080000+0430)/\",\"EngineVersion\":\"EngineV2\",\"CalculationMode\":\"Interpretation\",\"ReportUnit\":\"Centimeters\",\"PreviewSettings\":268435455,\"Dictionary\":{\"DataSources\":{\"0\":{\"Ident\":\"StiDataTableSource\",\"Name\":\"root\",\"Alias\":\"root\",\"Columns\":{\"0\":{\"Name\":\"totalIssueCount\",\"Index\":-1,\"NameInSource\":\"totalIssueCount\",\"Alias\":\"totalIssueCount\",\"Type\":\"System.Decimal\"},\"1\":{\"Name\":\"totalIssueUserDetails\",\"Index\":-1,\"NameInSource\":\"totalIssueUserDetails\",\"Alias\":\"totalIssueUserDetails\",\"Type\":\"System.Decimal\"},\"2\":{\"Name\":\"organizationName\",\"Index\":-1,\"NameInSource\":\"organizationName\",\"Alias\":\"organizationName\",\"Type\":\"System.String\"},\"3\":{\"Name\":\"fullName\",\"Index\":-1,\"NameInSource\":\"fullName\",\"Alias\":\"fullName\",\"Type\":\"System.String\"}},\"NameInSource\":\"SimpleDataSet.root\"}}},\"Pages\":{\"0\":{\"Ident\":\"StiPage\",\"Name\":\"Page1\",\"Guid\":\"41c22bda81cfc365f887207215f68280\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Border\":\"All;;2;;;;;solid:0,0,0\",\"Brush\":\"solid:255,255,255\",\"Components\":{\"0\":{\"Ident\":\"StiPageHeaderBand\",\"Name\":\"PageHeaderBand1\",\"ClientRectangle\":\"0,0.4,19.01,3.4\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Border\":\"Bottom;;;;;;;solid:0,0,0\",\"Brush\":\"solid:Transparent\",\"Components\":{\"0\":{\"Ident\":\"StiText\",\"Name\":\"Text1\",\"Guid\":\"a378c20db669984fb6431b4ead097781\",\"ClientRectangle\":\"0,0.4,1.8,0.6\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\"{TotalPageCount}\"},\"HorAlignment\":\"Center\",\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;9;;\",\"Border\":\";;;;;;;solid:Black\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:Black\"},\"1\":{\"Ident\":\"StiText\",\"Name\":\"Text2\",\"Guid\":\"103a1675d0c158cb42f8d54b8a180a35\",\"ClientRectangle\":\"1.8,0.4,2.4,0.6\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\":تعداد کل صفحات\"},\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;9;;\",\"Border\":\";;;;;;;solid:Black\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:Black\",\"Type\":\"Expression\"},\"2\":{\"Ident\":\"StiText\",\"Name\":\"Text3\",\"Guid\":\"719b0313b68957139364aa00f2f06710\",\"ClientRectangle\":\"15.8,0.4,2.6,0.6\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\"طبقه بندی: سری\"},\"HorAlignment\":\"Right\",\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;9;Bold;\",\"Border\":\";;;;;;;solid:Black\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:192,0,0\",\"Type\":\"Expression\"},\"3\":{\"Ident\":\"StiText\",\"Name\":\"Text6\",\"Guid\":\"3f45df356d7dfda09f49e053b4bbb126\",\"ClientRectangle\":\"13.6,1.4,4.8,0.6\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\"گزارش مسائل به تفکیک کاربران\"},\"HorAlignment\":\"Right\",\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;10;;\",\"Border\":\";;;;;;;solid:Black\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:Black\",\"Type\":\"Expression\"},\"4\":{\"Ident\":\"StiText\",\"Name\":\"Text4\",\"Guid\":\"740d6f7ed5377a307d5128905e4fbdf7\",\"ClientRectangle\":\"0,1.2,1.8,0.6\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\"{PageNumber}\"},\"HorAlignment\":\"Center\",\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;9;;\",\"Border\":\";;;;;;;solid:0,0,0\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:0,0,0\"},\"5\":{\"Ident\":\"StiText\",\"Name\":\"Text5\",\"Guid\":\"4575c5b9d56a4dbd8f816aa51e1ecbb8\",\"ClientRectangle\":\"1.8,1.2,2.4,0.6\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\":صفحه شماره\"},\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;9;;\",\"Border\":\";;;;;;;solid:Black\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:Black\",\"Type\":\"Expression\"},\"6\":{\"Ident\":\"StiImage\",\"Name\":\"Image1\",\"Guid\":\"006d1dac9bc7d40b198915cc8af26a03\",\"ClientRectangle\":\"7.91,0.2,3.2,3\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Border\":\";;;;;;;solid:Black\",\"Brush\":\"solid:Transparent\",\"Stretch\":true,\"ImageURL\":{\"Value\":\"favicon.ico\"},\"ImageBytes\":\"\"}}},\"1\":{\"Ident\":\"StiHeaderBand\",\"Name\":\"Headerroot\",\"ClientRectangle\":\"0,4.6,19.01,0.8\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Border\":\";;;;;;;solid:Black\",\"Brush\":\"solid:Transparent\",\"Components\":{\"0\":{\"Ident\":\"StiText\",\"Name\":\"Headerroot_totalIssueCount\",\"Guid\":\"af92bdbdb831fb08803789685a411f67\",\"ClientRectangle\":\"0,0,4.8,0.8\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\"تعداد کل مسائل کاربر\"},\"HorAlignment\":\"Center\",\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;10;Bold;\",\"Border\":\"All;;;;;;;solid:0,0,0\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:Black\",\"TextOptions\":{\"WordWrap\":true},\"Type\":\"Expression\"},\"1\":{\"Ident\":\"StiText\",\"Name\":\"Headerroot_totalIssueUserDetails\",\"Guid\":\"1eb22d01765a134b470a17fd552d4302\",\"ClientRectangle\":\"4.8,0,4.8,0.8\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\"تعداد کل نظرات کاربر\"},\"HorAlignment\":\"Center\",\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;10;Bold;\",\"Border\":\"All;;;;;;;solid:0,0,0\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:Black\",\"TextOptions\":{\"WordWrap\":true},\"Type\":\"Expression\"},\"2\":{\"Ident\":\"StiText\",\"Name\":\"Headerroot_organizationName\",\"Guid\":\"66927b8e993e04c70f43368488e7db79\",\"ClientRectangle\":\"9.6,0,4.8,0.8\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\"نام رده\"},\"HorAlignment\":\"Center\",\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;10;Bold;\",\"Border\":\"All;;;;;;;solid:0,0,0\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:Black\",\"TextOptions\":{\"WordWrap\":true},\"Type\":\"Expression\"},\"3\":{\"Ident\":\"StiText\",\"Name\":\"Headerroot_fullName\",\"Guid\":\"9be6404f51eee9cdd99da276e5904f78\",\"ClientRectangle\":\"14.4,0,4.6,0.8\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\"کاربر\"},\"HorAlignment\":\"Center\",\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;10;Bold;\",\"Border\":\"All;;;;;;;solid:0,0,0\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:Black\",\"TextOptions\":{\"WordWrap\":true},\"Type\":\"Expression\"}}},\"2\":{\"Ident\":\"StiDataBand\",\"Name\":\"Dataroot\",\"ClientRectangle\":\"0,6.2,19.01,0.8\",\"Interaction\":{\"Ident\":\"StiBandInteraction\"},\"Border\":\";;;;;;;solid:Black\",\"Brush\":\"solid:Transparent\",\"Components\":{\"0\":{\"Ident\":\"StiText\",\"Name\":\"Dataroot_totalIssueCount\",\"Guid\":\"1ef96fed6dd4ce2694c0d6bd8f6daf71\",\"CanGrow\":true,\"ClientRectangle\":\"0,0,4.8,0.8\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\"{root.totalIssueCount}\"},\"HorAlignment\":\"Center\",\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;9;;\",\"Border\":\"All;;;;;;;solid:0,0,0\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:Black\",\"TextOptions\":{\"WordWrap\":true}},\"1\":{\"Ident\":\"StiText\",\"Name\":\"Dataroot_totalIssueUserDetails\",\"Guid\":\"fd0df6774a7055e91abbac3dd99a43e6\",\"CanGrow\":true,\"ClientRectangle\":\"4.8,0,4.8,0.8\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\"{root.totalIssueUserDetails}\"},\"HorAlignment\":\"Center\",\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;9;;\",\"Border\":\"All;;;;;;;solid:0,0,0\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:Black\",\"TextOptions\":{\"WordWrap\":true}},\"2\":{\"Ident\":\"StiText\",\"Name\":\"Dataroot_organizationName\",\"Guid\":\"2e8dd58461a737ae8bd77df5781459a3\",\"CanGrow\":true,\"ClientRectangle\":\"9.6,0,4.8,0.8\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\"{root.organizationName}\"},\"HorAlignment\":\"Center\",\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;9;;\",\"Border\":\"All;;;;;;;solid:0,0,0\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:Black\",\"TextOptions\":{\"WordWrap\":true}},\"3\":{\"Ident\":\"StiText\",\"Name\":\"Dataroot_fullName\",\"Guid\":\"3178968f5b1115ee88dca6e7d2a811ba\",\"CanGrow\":true,\"ClientRectangle\":\"14.4,0,4.6,0.8\",\"Interaction\":{\"Ident\":\"StiInteraction\"},\"Text\":{\"Value\":\"{root.fullName}\"},\"HorAlignment\":\"Center\",\"VertAlignment\":\"Center\",\"Font\":\"Tahoma;9;;\",\"Border\":\"All;;;;;;;solid:0,0,0\",\"Brush\":\"solid:Transparent\",\"TextBrush\":\"solid:Black\",\"TextOptions\":{\"WordWrap\":true}}},\"DataSourceName\":\"root\"}},\"PageWidth\":21.01,\"PageHeight\":29.69,\"Watermark\":{\"TextBrush\":\"solid:50,0,0,0\"},\"Margins\":{\"Left\":1,\"Right\":1,\"Top\":1,\"Bottom\":1}}}}",
                    LastUpdatedDateTime = DateTime.Now,
                    CreationDate = DateTime.Now,
                    ProtoType = string.Empty
                };

               


                _context.Add(report_Users);
              
                _context.SaveChanges();
            }

        }
    }
}