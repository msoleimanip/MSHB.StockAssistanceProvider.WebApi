using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class ReportServiceErrors
    {
       
        public static readonly StockAssistanceProviderErrorMessage GetReportStructureError =
          new StockAssistanceProviderErrorMessage("GRD-1001", "خطا در دریافت ساختار گزارش");
        public static readonly StockAssistanceProviderErrorMessage ReportStructureNotFoundError =
         new StockAssistanceProviderErrorMessage("GRD-1002", "گزارشی که به دنبال آن هستید در سیستم وجود ندارد");

        public static StockAssistanceProviderErrorMessage UpdateReportStructureError =
         new StockAssistanceProviderErrorMessage("GRD-1003", "خطا در ثبت ساختار گزارشی که به دنبال تغییر آن هستید");

        public static StockAssistanceProviderErrorMessage IssueOfUsersReportError =
         new StockAssistanceProviderErrorMessage("GRD-1004", "خطا در ارائه گزارش مسائل کاربران");

        public static StockAssistanceProviderErrorMessage IssuesOfOrganizationReportError =
         new StockAssistanceProviderErrorMessage("GRD-1005", "خطا در ارائه گزارش مسائل رده های انتخابی");

        public static StockAssistanceProviderErrorMessage TotalIssueReportError =
         new StockAssistanceProviderErrorMessage("GRD-1006", "خطا در دریافت گزارش کل مسائل");

        public static StockAssistanceProviderErrorMessage UserIssuesReportError =
         new StockAssistanceProviderErrorMessage("GRD-1007", "خطا در دریافت گزارش کل مسائل تجهیزهای مورد نظر و کاربران");

        public static StockAssistanceProviderErrorMessage IssueOfUserLikesReportError =
         new StockAssistanceProviderErrorMessage("GRD-1008", "خطا در گزارش میزان محبوبت های درج شده برای کاربران");
    }
}
