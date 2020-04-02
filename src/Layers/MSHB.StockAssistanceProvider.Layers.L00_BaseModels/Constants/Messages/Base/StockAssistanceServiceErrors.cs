using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class EquipmentServiceErrors
    {
        public static readonly StockAssistanceProviderErrorMessage AddEquipmentError =
          new StockAssistanceProviderErrorMessage("AEE-1000", "هنگام اضافه کردن تجهیزات خطایی رخ داده  است.");
        public static readonly StockAssistanceProviderErrorMessage EditEquipmentError =
          new StockAssistanceProviderErrorMessage("AEE-1001", "هنگام تغییر دادن تجهیزات خطایی رخ داده  است.");
        public static readonly StockAssistanceProviderErrorMessage DeleteEquipmentError =
          new StockAssistanceProviderErrorMessage("AEE-1002", "هنگام حذف تجهیزات خطایی رخ داده  است.");
        public static readonly StockAssistanceProviderErrorMessage EquipmentNotFoundError =
          new StockAssistanceProviderErrorMessage("AEE-1003", "تجهیزات مورد نظر یافت نشده است");       
        public static readonly StockAssistanceProviderErrorMessage EditDuplicateEquipmentError =
          new StockAssistanceProviderErrorMessage("AEE-1004", "امکان تغییر به تجهیزات با نام تکراری مهیا نیست.");
        public static readonly StockAssistanceProviderErrorMessage UserInEquipmentExistError =
          new StockAssistanceProviderErrorMessage("AEE-1005", "کاربری در رده انتخابی برای پاک کردن وجود دارد ابتدا تجهیزات آن تغییر کند.");
        public static readonly StockAssistanceProviderErrorMessage DeleteEquipmentNotselectedError =
          new StockAssistanceProviderErrorMessage("AEE-1006", "درخواست شما منجر به حذف تجهیزات  می شود که در لیست انتخابی نیست.");
        public static readonly StockAssistanceProviderErrorMessage EditEquipmentNotExistError =
          new StockAssistanceProviderErrorMessage("AEE-1007", "تجهیزات مورد نظر وجود ندارد.");
        public static readonly StockAssistanceProviderErrorMessage GetEquipmentError =
         new StockAssistanceProviderErrorMessage("AEE-1008", "در گرفتن تجهیز مورد نظر خطایی رخ داده است.");
        public static readonly StockAssistanceProviderErrorMessage AddDuplicateEquipmentError =
          new StockAssistanceProviderErrorMessage("AEE-1009", "امکان اضافه کردن تجهیزات با نام تکراری مهیا نیست.");

        public static StockAssistanceProviderErrorMessage AddDuplicateEquipmentAttachmentError =
          new StockAssistanceProviderErrorMessage("AEE-1010", "امکان اضافه کردن افزونه تجهیزات با نام تکراری مهیا نیست.");
        public static StockAssistanceProviderErrorMessage AddEquipmentAttachmentError =
          new StockAssistanceProviderErrorMessage("AEE-1011", "هنگام اضافه کردن افزونه تجهیزات خطایی رخ داده است.");

        public static StockAssistanceProviderErrorMessage EditEquipmentAttachmentNotFoundError =
          new StockAssistanceProviderErrorMessage("AEE-1012", "افزونه مورد نظر یافت نشد.");

        public static StockAssistanceProviderErrorMessage GetEquipmentAttachmentByEquipmentIdError =
          new StockAssistanceProviderErrorMessage("AEE-1013", "موقع دریافت افزونه های تجهیز مورد نظر خطایی رخ داده است.");

        public static StockAssistanceProviderErrorMessage GetEquipmentAttachmentForUserError =
          new StockAssistanceProviderErrorMessage("AEE-1014", "موقع دریافت افزونه تجهیزات ارسالی خطایی رخ داده است..");
    }
}
