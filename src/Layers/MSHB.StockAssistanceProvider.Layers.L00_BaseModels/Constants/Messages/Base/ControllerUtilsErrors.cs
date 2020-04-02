using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class ControllerUtilsErrors
    {
        public static readonly StockAssistanceProviderErrorMessage UserRolesNotFound =
           new StockAssistanceProviderErrorMessage("URN-1000", "Role کاربر یافت نشده است");
        public static readonly StockAssistanceProviderErrorMessage GetUserRoles =
          new StockAssistanceProviderErrorMessage("GUR-1000", "در گرفتن Role کاربر خطایی رخ داده است.");
        public static readonly StockAssistanceProviderErrorMessage GetUserError =
          new StockAssistanceProviderErrorMessage("GUE-1000", "در بدست آوردن کاربر خطایی رخ داده است");
        public static readonly StockAssistanceProviderErrorMessage GetUserPresidentError =
         new StockAssistanceProviderErrorMessage("GUP-1000", "در بدست آوردن سطح کاربر خطایی رخ داده است");
    }
}
