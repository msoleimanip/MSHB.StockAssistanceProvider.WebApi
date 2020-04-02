using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages;


namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.exceptions
{
    public class StockAssistanceProviderGlobalException : Exception
    {
        public StockAssistanceProviderGlobalException(StockAssistanceProviderErrorMessage error)
        {
            UserMessage = error.Message;
            ErrorCode = error.Code;
            ExceptionList = null;
        }

        public StockAssistanceProviderGlobalException(StockAssistanceProviderErrorMessage error, Exception e)
        {
            UserMessage = error.Message;
            ErrorCode = error.Code;
            ExceptionList = new List<Exception>{e};
        }
        public StockAssistanceProviderGlobalException(StockAssistanceProviderErrorMessage error, params Exception[] exceptions)
        {
            UserMessage = error.Message;
            ErrorCode = error.Code;
            ExceptionList = new List<Exception>();
            ExceptionList.AddRange(exceptions);
        }

    

        public string UserMessage { get; set; }
        public string ErrorCode { get; set; }
        public List<Exception> ExceptionList { get; set; }
    }
}