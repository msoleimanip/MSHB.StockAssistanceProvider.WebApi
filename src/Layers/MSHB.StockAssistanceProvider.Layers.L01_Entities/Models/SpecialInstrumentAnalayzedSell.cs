using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("SpecialInstrumentAnalayzedSell_T")]

    public class SpecialInstrumentAnalayzedSell:BaseEntity
    {
        public long? InstrumentAnalayzeSellId { get; set; }
        [ForeignKey("InstrumentAnalayzeSellId")]
        public virtual InstrumentAnalayzeSell InstrumentAnalayzeSell { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public string Reason { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
