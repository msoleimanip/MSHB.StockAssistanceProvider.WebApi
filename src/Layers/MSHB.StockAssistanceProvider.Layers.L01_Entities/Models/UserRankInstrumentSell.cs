using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("UserRankInstrumentSell_T")]

    public class UserRankInstrumentSell:BaseEntity
    {
        public long InstrumentAnalayzeSellId { get; set; }
        [ForeignKey("InstrumentAnalayzeSellId")]
        public virtual InstrumentAnalayzeSell InstrumentAnalayzeSell { get; set; }
       
        public int RankNumber { set; get; }

        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

     
    }
}
