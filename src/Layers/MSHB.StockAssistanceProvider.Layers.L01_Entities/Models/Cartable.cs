using MSHB.StockAssistanceProvider.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    public class Cartable:BaseEntity
    {
        [Required]
        public long InstrumentUserMapperId { get; set; }

        public virtual InstrumentUserMapper InstrumentUserMapper { get; set; }

        public UserType UserType { get; set; }
        public AvailableUserType? AvailableUserType { get; set; }
        [Required]
        public Guid SenderUserId { get; set; }

        public virtual User SenderUser { get; set; }


    }
}
