using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("InstrumentDescriptionSell_T")]

    public class InstrumentDescriptionSell : BaseEntity
    {

        [Required]
        public long InstrumentAnalayzeSellId { get; set; }

        [ForeignKey("InstrumentAnalayzeSellId")]
        public virtual InstrumentAnalayzeSell InstrumentAnalayzeSell { get; set; }

        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

    }
}
