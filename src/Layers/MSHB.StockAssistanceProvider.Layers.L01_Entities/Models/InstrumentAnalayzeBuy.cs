﻿using MSHB.StockAssistanceProvider.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("InstrumentAnalayzeBuy_T")]

    public class InstrumentAnalayzeBuy : BaseEntity
    {
        public long? Price { get; set; }

       
        public virtual ICollection<InstrumentDescriptionBuy> InstrumentDescriptionBuys { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public AnalyzeType AnalyzeType { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public AnalyzeState AnalyzeState { get; set; }
        public Guid AnalyzerUserId { get; set; }
        public virtual User AnalyzerUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        [Required]
        public long InstrumentId { get; set; }

        [ForeignKey("InstrumentId")]

        public virtual Instrument Instrument { get; set; }

    
        public virtual ICollection<UserRankInstrumentBuy> UserRankInstrumentBuys { get; set; }

      
        public virtual ICollection<SpecialInstrumentAnalayzedBuy> SpecialInstrumentAnalayzedBuys { get; set; }

    }
}
