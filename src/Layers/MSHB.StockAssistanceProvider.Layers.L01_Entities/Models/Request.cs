using MSHB.StockAssistanceProvider.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("Request_T")]
    public class Request:BaseEntity
    {
        [Required]
        public long InstrumentId { get; set; }
        [ForeignKey("InstrumentId")]


        public virtual Instrument Instrument { get; set; }


        [Required]
        public Guid SenderUserId { get; set; }
        [ForeignKey("SenderUserId")]

        public virtual User SenderUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }


    }
}
