using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("SpecialInstrumentAnalayzedBuy_T")]

    public class SpecialInstrumentAnalayzedBuy: BaseEntity
    {

        public long? InstrumentAnalayzeBuyId { get; set; }
        [ForeignKey("InstrumentAnalayzeBuyId")]

        public virtual InstrumentAnalayzeBuy InstrumentAnalayzeBuy { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string Reason { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
