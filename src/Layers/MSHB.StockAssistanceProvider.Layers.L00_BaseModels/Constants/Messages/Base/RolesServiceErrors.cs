using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class RolesServiceErrors
    {
        public static readonly StockAssistanceProviderErrorMessage GetRolesError =
           new StockAssistanceProviderErrorMessage("GRE-1000", "خطا در دریافت Role");
        public static readonly StockAssistanceProviderErrorMessage FindUserRolesError =
          new StockAssistanceProviderErrorMessage("GRE-1001", "خطا در پیدا کردن Role");
        public static readonly StockAssistanceProviderErrorMessage GetIsUserInRoleError =
          new StockAssistanceProviderErrorMessage("GRE-1002", "خطا در تشخیص رول مشخصی از کاربر");
        public static readonly StockAssistanceProviderErrorMessage GetFindUsersInRoleError =
          new StockAssistanceProviderErrorMessage("GRE-1003", "خطا در پیدا کردن کاربران رول مشخص");

        
            
            

    }
    
}
