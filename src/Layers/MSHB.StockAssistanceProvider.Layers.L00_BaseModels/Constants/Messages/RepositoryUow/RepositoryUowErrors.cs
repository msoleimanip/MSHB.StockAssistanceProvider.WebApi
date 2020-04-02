namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.RepositoryUow
{
    public class RepositoryUowErrors
    {
        public static readonly StockAssistanceProviderErrorMessage Commit =
            new StockAssistanceProviderErrorMessage("RUOW-1000", "هنگام commit تراکنش خطایی رخ داده است");
        public static readonly StockAssistanceProviderErrorMessage Rollback =
            new StockAssistanceProviderErrorMessage("RUOW-1001", "هنگام Rollback تراکنش خطایی رخ داده است");
        public static readonly StockAssistanceProviderErrorMessage Dispose =
            new StockAssistanceProviderErrorMessage("RUOW-1002", "هنگام dispose کردن UOW خطایی رخ داده است");
    }
}
