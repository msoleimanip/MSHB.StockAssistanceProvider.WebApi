using MSHB.StockAssistanceProvider.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("User_T")]

    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UserTokens = new HashSet<UserToken>();
            SpecialInstrumentAnalayzedBuys = new HashSet<SpecialInstrumentAnalayzedBuy>();
            SpecialInstrumentAnalayzedSells = new HashSet<SpecialInstrumentAnalayzedSell>();
            InstrumentCycles = new HashSet<InstrumentCycle>();
            UserRankInstrumentBuys = new HashSet<UserRankInstrumentBuy>();
            UserRankInstrumentSells = new HashSet<UserRankInstrumentSell>();
            InstrumentUserMappers = new HashSet<InstrumentUserMapper>();





        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(500)]
        public string Username { get; set; }

        public string Password { get; set; }

        [MaxLength(500)]
        public string FirstName { get; set; }
        [MaxLength(500)]
        public string LastName { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        public string SerialNumber { get; set; }

        public DateTime? LastLockoutDate { get; set; }

        public DateTime? LastPasswordChangedDate { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? LastVisit { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset? LastLoggedIn { get; set; }

        public UserType UserType { get; set; }
        public AvailableUserType? AvailableUserType { get; set; }


       
        public long? GroupAuthId { get; set; }

        [ForeignKey("GroupAuthId")]
        public virtual GroupAuth GroupAuth { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<UserToken> UserTokens { get; set; }

        

        public virtual ICollection<UserConfiguration> UserConfigurations { get; set; }




        public virtual ICollection<SpecialInstrumentAnalayzedBuy> SpecialInstrumentAnalayzedBuys { get; set; }




        public virtual ICollection<SpecialInstrumentAnalayzedSell> SpecialInstrumentAnalayzedSells { get; set; }



        public virtual ICollection<InstrumentCycle> InstrumentCycles { get; set; }




        public virtual ICollection<UserRankInstrumentBuy> UserRankInstrumentBuys { get; set; }




        public virtual ICollection<UserRankInstrumentSell> UserRankInstrumentSells { get; set; }


        public virtual ICollection<InstrumentUserMapper> InstrumentUserMappers { get; set; }

        








    }
}
