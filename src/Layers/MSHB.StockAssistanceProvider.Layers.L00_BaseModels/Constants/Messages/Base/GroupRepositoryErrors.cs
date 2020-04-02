using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class GroupRepositoryErrors
    {
        public static readonly StockAssistanceProviderErrorMessage DbAddGroupError =
          new StockAssistanceProviderErrorMessage("DAGE-1000", "هنگام اضافه کردن Group خطایی رخ داده  است.");
        public static readonly StockAssistanceProviderErrorMessage DbEditGroupError =
          new StockAssistanceProviderErrorMessage("DAGE-1001", "هنگام تغییر دادن Group خطایی رخ داده  است.");
        public static readonly StockAssistanceProviderErrorMessage DbDeleteGroupError =
          new StockAssistanceProviderErrorMessage("DAGE-1002", "هنگام حذف Group خطایی رخ داده  است.");

        public static readonly StockAssistanceProviderErrorMessage DbEditDuplicateGroupError =
          new StockAssistanceProviderErrorMessage("DAGE-1003", "امکان تغییر به Group با نام تکراری مهیا نیست.");
        public static readonly StockAssistanceProviderErrorMessage UserInGroupExistError =
          new StockAssistanceProviderErrorMessage("DAGE-1004", "گروه انتخابی دارای کاربر می باشد ابتدا آن کاربر را به گروه دیگر تخصیص دهید.");
        public static readonly StockAssistanceProviderErrorMessage DeleteGroupNotselectedError =
          new StockAssistanceProviderErrorMessage("DAGE-1005", "درخواست شما منجر به حذف Group می شود که در لیست انتخابی نیست.");      
        public static readonly StockAssistanceProviderErrorMessage DbGetGroupError =
          new StockAssistanceProviderErrorMessage("DAGE-1007", "در گرفتن Group مورد نظر خطایی رخ داده است.");
        public static readonly StockAssistanceProviderErrorMessage DbRoleExistError =
          new StockAssistanceProviderErrorMessage("DAGE-1007", "بخشی یا کل رول ها در لیست انتخابی وجود ندارد");
        public static readonly StockAssistanceProviderErrorMessage DbEditGroupNotExistError =
          new StockAssistanceProviderErrorMessage("DAGE-1006", "گروهی که می خواهید  تغییر دهید وجود ندارد");
        public static readonly StockAssistanceProviderErrorMessage DbGetRolesError =
          new StockAssistanceProviderErrorMessage("DAGE-1008", "در دریافت Role ها خطایی رخ داده است.");




    }
}
