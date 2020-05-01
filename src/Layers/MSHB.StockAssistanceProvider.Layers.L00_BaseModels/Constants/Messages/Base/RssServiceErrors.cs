using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class RssServiceErrors
    {
        public static readonly StockAssistanceProviderErrorMessage ConnectionError =
         new StockAssistanceProviderErrorMessage("REC-100", "ارتباط با سرور برقرار نشد");
    }
}
