using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Enums
{
    public enum InstrumentState
    {
        SendToCheck=1,
        Accepted,
        Rejected,
        InAnalyze,
        ReadyToWork,
        Closed

    }
}
