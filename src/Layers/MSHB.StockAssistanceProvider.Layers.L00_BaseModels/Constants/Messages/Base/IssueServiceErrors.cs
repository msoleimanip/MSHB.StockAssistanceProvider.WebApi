using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class IssueServiceErrors
    {
        public static readonly StockAssistanceProviderErrorMessage UploadFileError =
          new StockAssistanceProviderErrorMessage("UFE-1000", "هنگام آپلود فایل خطایی رخ داده است.");
        public static readonly StockAssistanceProviderErrorMessage UploadFileValidError =
          new StockAssistanceProviderErrorMessage("UFE-1001", "فایل ارسالی بایستی معتبر باشد.");
        public static readonly StockAssistanceProviderErrorMessage AddIssueError =
          new StockAssistanceProviderErrorMessage("UFE-1002", "هنگام ذخیره مسئله خطایی رخ داده است.");
        public static readonly StockAssistanceProviderErrorMessage NotExistFileAddressError =
          new StockAssistanceProviderErrorMessage("UFE-1003", "فایل  با این مقدار وجود ندارد.");
        public static readonly StockAssistanceProviderErrorMessage ChangeToThumbnailError =
          new StockAssistanceProviderErrorMessage("UFE-1004", "خطا در تغییر سایز تصویر");
        public static readonly StockAssistanceProviderErrorMessage AddIssueDetailError =
          new StockAssistanceProviderErrorMessage("UFE-1005", "خطایی در درج جزییات مسئله رخ داده است.");
        public static readonly StockAssistanceProviderErrorMessage IssueNotFoundError =
          new StockAssistanceProviderErrorMessage("UFE-1006", "مسئله مورد نظر یافت نشد.");
        public static StockAssistanceProviderErrorMessage ChangeStateIssueError =
          new StockAssistanceProviderErrorMessage("UFE-1007", "در تغییر وضعیت مسئله خطایی رخ داده است.");
        public static StockAssistanceProviderErrorMessage EditIssueError =
          new StockAssistanceProviderErrorMessage("UFE-1008", "در تغییر دادن مسئله خطایی رخ داده است.");
          public static StockAssistanceProviderErrorMessage IssueDetailNotFoundError =
          new StockAssistanceProviderErrorMessage("UFE-1009", "جزییات مورد نظر در مسئله یافت نشد.");
          public static StockAssistanceProviderErrorMessage EditIssueDetailError =
          new StockAssistanceProviderErrorMessage("UFE-1010", "خطا در تغییر جزییات در مسئله رخ داده است.");
        public static readonly StockAssistanceProviderErrorMessage FileNotFoundError =
        new StockAssistanceProviderErrorMessage("UFE-1011", "فایل یافت نشد.");

        public static StockAssistanceProviderErrorMessage IssueDetailAttachmentNotFoundError =
          new StockAssistanceProviderErrorMessage("UFE-1011", "ضمیمه مورد نظر یافت نشده است");

        public static StockAssistanceProviderErrorMessage DeleteIssueDetailAttachmentsError =
          new StockAssistanceProviderErrorMessage("UFE-1012", "در حذف ضمیمه مورد نظر خطایی رخ داده است.");
        public static StockAssistanceProviderErrorMessage NotExistEquipmentsListError =
          new StockAssistanceProviderErrorMessage("UFE-1013", "برخی از تجهیزات انتخابی وجود ندارد.");

        public static StockAssistanceProviderErrorMessage AddIssueDetailCommentError =
          new StockAssistanceProviderErrorMessage("UFE-1014", "در اضافه کردن پیام به جزییات خاص خطایی رخ داده است.");
        public static StockAssistanceProviderErrorMessage GetIssuesError =
          new StockAssistanceProviderErrorMessage("UFE-1015", "خطا در دریافت مسئله های کاربر.");
        public static StockAssistanceProviderErrorMessage GetIssueDetailsError =
          new StockAssistanceProviderErrorMessage("UFE-1016", "خطا در دریافت جزییات مسئله.");
        public static StockAssistanceProviderErrorMessage SearchIssuesError =
          new StockAssistanceProviderErrorMessage("UFE-1017", "خطا در دریافت مسئله ها.");

        public static StockAssistanceProviderErrorMessage ChangeLikeIssueError =
          new StockAssistanceProviderErrorMessage("UFE-1018", "موقع تغییر میزان محبوبیت خطایی رخ داده است.");

        public static StockAssistanceProviderErrorMessage ChangeAnswerIssueError =
          new StockAssistanceProviderErrorMessage("UFE-1019", "موقع تغییر وضعیت کیفیت پاسخ خطایی رخ داده است.");

        public static StockAssistanceProviderErrorMessage UserChangeAnswerIssueError =
          new StockAssistanceProviderErrorMessage("UFE-1020", "کاربر مورد نظر امکان تایید یا رد پاسخ را ندارد تنها طراح مسئله می تواند.");

        public static StockAssistanceProviderErrorMessage IssueDetailsCountError =
          new StockAssistanceProviderErrorMessage("UFE-1021", "امکان ویرایش دیگر وجود ندارد زیرا که نظری برای این مسئله ثبت شده است.");

        public static StockAssistanceProviderErrorMessage DeleteIssueError { get; set; }
        public static StockAssistanceProviderErrorMessage NotAccessError { get; set; }
    }
}
