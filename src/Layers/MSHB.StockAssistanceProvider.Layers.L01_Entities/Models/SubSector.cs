using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("SubSector_T")]

    public class SubSector
    {
        [Key]
        public long? CSecVal { get; set; }
        [ForeignKey("CSecVal")]
        public virtual Sector Sector { get; set; }
        public long? CSoSecVal { get; set; }
        public string LSoSecVal { get; set; }
        public int DEven { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
      
        public virtual ICollection<Instrument> Instruments { get; set; }




    }
}
