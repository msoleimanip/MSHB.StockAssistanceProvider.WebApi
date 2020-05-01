using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("InstrumentDescriptionBuy_T")]

    public class InstrumentDescriptionBuy:BaseEntity
    {

        [Required]
        public long InstrumentAnalayzeBuyId { get; set; }

        [ForeignKey("InstrumentAnalayzeBuyId")]
        public virtual InstrumentAnalayzeBuy InstrumentAnalayzeBuy { get; set; }

        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

    }
}
