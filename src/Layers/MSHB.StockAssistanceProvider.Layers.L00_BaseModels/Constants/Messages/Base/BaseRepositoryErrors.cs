namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class BaseRepositoryErrors
    {
        public static readonly StockAssistanceProviderErrorMessage InternalCommit =
            new StockAssistanceProviderErrorMessage("RBA-1000", "هنگام commit تراکنش داخلی خطایی رخ داده است");
        public static readonly StockAssistanceProviderErrorMessage InternalRollback =
            new StockAssistanceProviderErrorMessage("RBA-1001", "هنگام Rollback تراکنش داخلی خطایی رخ داده است");
    }
}
