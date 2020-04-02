namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages
{
    public class StockAssistanceProviderErrorMessage
    {
        public StockAssistanceProviderErrorMessage(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"کد پیام: {Code}\t متن پیام: {Message}";
        }

        public StockAssistanceProviderErrorMessage AddSqlErrorCode(int sqlErrorCode)
        {
            return new StockAssistanceProviderErrorMessage(Code + $" ({sqlErrorCode}) ", Message);
        }
    }
}