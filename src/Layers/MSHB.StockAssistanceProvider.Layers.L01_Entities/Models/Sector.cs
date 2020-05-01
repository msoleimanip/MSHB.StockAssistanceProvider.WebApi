using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("Sector_T")]

    public class Sector
    {
        [Key]
        public long CSecVal { get; set; }
        public string LSecVal { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public virtual ICollection<Instrument> Instruments { get; set; }
    }
}
