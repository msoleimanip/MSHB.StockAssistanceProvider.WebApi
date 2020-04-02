using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class OrganizationServiceErrors
    {
        public static readonly StockAssistanceProviderErrorMessage AddOrganizationError =
          new StockAssistanceProviderErrorMessage("AOE-1000", "هنگام اضافه کردن رده خطایی رخ داده  است.");
        public static readonly StockAssistanceProviderErrorMessage EditOrganizationError =
          new StockAssistanceProviderErrorMessage("AOE-1001", "هنگام تغییر دادن رده خطایی رخ داده  است.");
        public static readonly StockAssistanceProviderErrorMessage DeleteOrganizationError =
          new StockAssistanceProviderErrorMessage("DEO-1002", "هنگام حذف رده خطایی رخ داده  است.");
        public static readonly StockAssistanceProviderErrorMessage OrganizationNotFoundError =
          new StockAssistanceProviderErrorMessage("ONE-1003", "رده مورد نظر یافت نشده است");
        public static readonly StockAssistanceProviderErrorMessage AddDuplicateOrganizationError =
          new StockAssistanceProviderErrorMessage("ONE-1004", "اضافه کردن رده تکراری ممکن نیست");
        public static readonly StockAssistanceProviderErrorMessage EditDuplicateOrganizationError =
          new StockAssistanceProviderErrorMessage("ONE-1005", "تغییر در رده منجر به رده تکراری می شود");
        public static readonly StockAssistanceProviderErrorMessage EditOrganizationNotExistError =
          new StockAssistanceProviderErrorMessage("ONE-1006", "رده ای که به دنبال تغییر هستید وجود ندارد");
        public static readonly StockAssistanceProviderErrorMessage UserInOrganizationExistError =
          new StockAssistanceProviderErrorMessage("ONE-1007", "در رده و سلسله مراتب آن کاربر وجود دارد");
        public static readonly StockAssistanceProviderErrorMessage DeleteOrgNotselectedError =
          new StockAssistanceProviderErrorMessage("ONE-1008", "رده که برای حذف انتخاب شده منجر به حذف رده های انتخاب نشده می شود لطفا همه موارد انتخاب شود.");
        public static readonly StockAssistanceProviderErrorMessage GetOrganizationError =
          new StockAssistanceProviderErrorMessage("ONE-1009", "در دریافت اطلاعات رده خطا رخ داده است");


    }
}
