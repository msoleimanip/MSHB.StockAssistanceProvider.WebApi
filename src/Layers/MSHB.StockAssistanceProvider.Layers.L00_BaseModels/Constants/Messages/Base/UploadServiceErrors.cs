using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class UploadServiceErrors
    {
        public static readonly StockAssistanceProviderErrorMessage UploadFileError =
        new StockAssistanceProviderErrorMessage("UFE-1000", "هنگام آپلود فایل خطایی رخ داده است.");
        public static readonly StockAssistanceProviderErrorMessage UploadFileValidError =
          new StockAssistanceProviderErrorMessage("UFE-1001", "فایل ارسالی بایستی معتبر باشد.");

        public static StockAssistanceProviderErrorMessage FileNotFoundError =
              new StockAssistanceProviderErrorMessage("UFE-1002", "فایل وجود ندارد.");
        public static StockAssistanceProviderErrorMessage FileIdNotFoundError =
             new StockAssistanceProviderErrorMessage("UFE-1003", "شناسه فایل وجود ندارد.");
        public static StockAssistanceProviderErrorMessage FileDownloadError =
             new StockAssistanceProviderErrorMessage("UFE-1004", "خطا در دانلود فایل.");

    }
}
