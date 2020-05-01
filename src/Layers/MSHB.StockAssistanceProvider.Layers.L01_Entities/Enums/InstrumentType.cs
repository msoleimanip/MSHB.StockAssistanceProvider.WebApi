using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Enums
{
    public enum InstrumentType
    {
        CommonStockExchangeMetaExchange=1,
        StockExchange,
        MetaExchange,
        Future,
        MetaExchangeBase,
        MetaExchangeBaseNotpublished,
        EnergyExchange,
        CommodityExchange
    }
}
