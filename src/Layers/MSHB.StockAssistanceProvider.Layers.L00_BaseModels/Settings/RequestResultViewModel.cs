using System.Collections.Generic;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages;


namespace StockAssistanceProvider.WebUI.Layers.L00_BaseModels.Settings
{
    public class RequestResultViewModel
    {
        public object Data { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<StockAssistanceProviderErrorMessage> DetailErrorList { get; set; }=new List<StockAssistanceProviderErrorMessage>();
        public Dictionary<string, string> ValidationMessages { get; set; }

    }
}
