using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class UsersServiceErrors
    {
        public static readonly StockAssistanceProviderErrorMessage AddUserError =
           new StockAssistanceProviderErrorMessage("AUE-1000", "خطا در افزودن کاربر اتفاق افتاده است");
        public static readonly StockAssistanceProviderErrorMessage GroupNotFoundError =
           new StockAssistanceProviderErrorMessage("AUE-1001", "گروه ای که انتخاب کرده اید وجود ندارد ");
        public static readonly StockAssistanceProviderErrorMessage OrganizationNotFoundError =
           new StockAssistanceProviderErrorMessage("AUE-1002", "رده ای که انتخاب کرده اید وجود ندارد ");
        public static readonly StockAssistanceProviderErrorMessage UserExistError =
           new StockAssistanceProviderErrorMessage("AUE-1003", "کاربری با این نام در سیستم وجود دارد امکان اضافه کردن وجود ندارد.");
        public static readonly StockAssistanceProviderErrorMessage UserNotFoundError =
           new StockAssistanceProviderErrorMessage("AUE-1004", "کاربری با این مشخصات در سیستم وجود ندارد.");
        public static readonly StockAssistanceProviderErrorMessage AssignmentError =
           new StockAssistanceProviderErrorMessage("AUE-1005", "تخصیص به درستی صورت نپذیرفت.");
        public static readonly StockAssistanceProviderErrorMessage OrgNotFoundError =
           new StockAssistanceProviderErrorMessage("AUE-1006", "ارگان انتخابی پیدا نشد.");
        public static readonly StockAssistanceProviderErrorMessage EquipmentNotFoundError =
           new StockAssistanceProviderErrorMessage("AUE-1006", "در تجهیزات انتخابی موردی است که یافت نشد.");
        public static readonly StockAssistanceProviderErrorMessage ChangeStateError =
           new StockAssistanceProviderErrorMessage("AUE-1007", "خطا در تغییر وضعیت کاربر");
        public static readonly StockAssistanceProviderErrorMessage ChangePasswordError =
           new StockAssistanceProviderErrorMessage("AUE-1008", "در تغییر پسورد خطایی رخ داده است.");
        public static StockAssistanceProviderErrorMessage Unauthorized =
             new StockAssistanceProviderErrorMessage("AUE-1010", "نام کاربری و شناسه کاربری درست نمی باشد.");
        public static StockAssistanceProviderErrorMessage RefreshToken =
            new StockAssistanceProviderErrorMessage("AUE-1011", "مشکل در کد دریافت دوباره سطح دسترسی.");
        public static StockAssistanceProviderErrorMessage DeActive =
            new StockAssistanceProviderErrorMessage("AUE-1012", "کاربری شما توسط ادمین سیستم غیرفعال شده است");

        public static StockAssistanceProviderErrorMessage GetOrganizationUsers =
            new StockAssistanceProviderErrorMessage("AUE-1013", "در دریافت اطلاعات کاربران رده مشکل رخ داده است.");
    }

}
