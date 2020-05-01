using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("UserRankInstrumentBuy_T")]

    public class UserRankInstrumentBuy:BaseEntity
    {
        public long InstrumentAnalayzeBuyId { get; set; }
        [ForeignKey("InstrumentAnalayzeBuyId")]

        public virtual  InstrumentAnalayzeBuy InstrumentAnalayzeBuy { get; set; }
       
        public int RankNumber { set; get; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }


    }
}
