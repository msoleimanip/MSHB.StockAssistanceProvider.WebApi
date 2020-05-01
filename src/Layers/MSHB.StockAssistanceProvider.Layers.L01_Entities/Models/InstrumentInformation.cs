using MSHB.StockAssistanceProvider.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("InstrumentInformation_T")]

    public class InstrumentInformation:BaseEntity
    {
        [Required]
        public long InstrumentId { get; set; }

        [ForeignKey("InstrumentId")]

        public virtual Instrument Instrument { get; set; }

        public string Description { get; set; }
        public InstrumentInformationType InstrumentInformationType { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
