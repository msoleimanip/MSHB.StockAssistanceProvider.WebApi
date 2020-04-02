using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class GroupServiceErrors
    {
        public static readonly StockAssistanceProviderErrorMessage GetRolesError =
           new StockAssistanceProviderErrorMessage("GRE-1000", "خطا در دریافت Role");
        public static readonly StockAssistanceProviderErrorMessage AddGroupError =
           new StockAssistanceProviderErrorMessage("GRE-1001", "مشکل در ساخت گروه جدید");
        public static readonly StockAssistanceProviderErrorMessage SameGroupExistError =
          new StockAssistanceProviderErrorMessage("GRE-1002", "گروه با نام مشابه وجود دارد");
        public static readonly StockAssistanceProviderErrorMessage DeleteGroupError =
          new StockAssistanceProviderErrorMessage("GRE-1003", "خطا در حذف گروه درخواست شده");
        public static readonly StockAssistanceProviderErrorMessage EditGroupError =
          new StockAssistanceProviderErrorMessage("GRE-1004", "خطا در ویرایش گروه درخواست شده");
        public static readonly StockAssistanceProviderErrorMessage EditDuplicateGroupError =
          new StockAssistanceProviderErrorMessage("GRE-1005", "امکان تغییر به Group با نام تکراری مهیا نیست.");
        public static readonly StockAssistanceProviderErrorMessage UserInGroupExistError =
          new StockAssistanceProviderErrorMessage("GRE-1006", "گروه انتخابی دارای کاربر می باشد ابتدا آن کاربر را به گروه دیگر تخصیص دهید.");
        public static readonly StockAssistanceProviderErrorMessage DeleteGroupNotselectedError =
          new StockAssistanceProviderErrorMessage("GRE-1007", "درخواست شما منجر به حذف Group می شود که در لیست انتخابی نیست.");
        public static readonly StockAssistanceProviderErrorMessage GetGroupError =
          new StockAssistanceProviderErrorMessage("GRE-1008", "در گرفتن Group مورد نظر خطایی رخ داده است.");
        public static readonly StockAssistanceProviderErrorMessage RoleExistError =
          new StockAssistanceProviderErrorMessage("GRE-1009", "بخشی یا کل رول ها در لیست انتخابی وجود ندارد");
        public static readonly StockAssistanceProviderErrorMessage EditGroupNotExistError =
          new StockAssistanceProviderErrorMessage("GRE-1010", "گروهی که می خواهید  تغییر دهید وجود ندارد");
        public static readonly StockAssistanceProviderErrorMessage GetGroupAuthenticationByIdError =
          new StockAssistanceProviderErrorMessage("GRE-1011", "گروه مربوط به شناسه ارسالی در سامانه وجود ندارد");


    }
    
}
