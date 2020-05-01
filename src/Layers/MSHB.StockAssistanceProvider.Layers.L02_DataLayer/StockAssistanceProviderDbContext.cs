using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;
using System;

namespace MSHB.StockAssistanceProvider.Layers.L02_DataLayer
{
    public class StockAssistanceProviderDbContext : DbContext
    {
        private IConfiguration _configuration;

        public StockAssistanceProviderDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public StockAssistanceProviderDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<GroupAuth> GroupAuths { get; set; }
        public virtual DbSet<GroupAuthRole> GroupAuthRoles { get; set; }
        public virtual DbSet<AppLogItem> Logs { get; set; }
        public virtual DbSet<UserConfiguration> UserConfigurations { get; set; }
        public virtual DbSet<FileAddress> FileAddresses { get; set; }
        public virtual DbSet<ReportStructure> ReportStructures { get; set; }



        public virtual DbSet<Instrument> Instruments { get; set; }
        public virtual DbSet<InstrumentAnalayzeBuy> InstrumentAnalayzeBuys { get; set; }
        public virtual DbSet<InstrumentAnalayzeSell> InstrumentAnalayzeSells { get; set; }
        public virtual DbSet<InstrumentCycle> InstrumentCycles { get; set; }
        public virtual DbSet<InstrumentDescriptionBuy> InstrumentDescriptionBuys { get; set; }
        public virtual DbSet<InstrumentDescriptionSell> InstrumentDescriptionSells { get; set; }
        public virtual DbSet<InstrumentInformation> InstrumentInformations { get; set; }
        public virtual DbSet<MarketValue> MarketValues { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<SubSector> SubSectors { get; set; }
        public virtual DbSet<SpecialInstrumentAnalayzedBuy> SpecialInstrumentAnalayzedBuys { get; set; }
        public virtual DbSet<SpecialInstrumentAnalayzedSell> SpecialInstrumentAnalayzedSells { get; set; }
        public virtual DbSet<UserRankInstrumentBuy> UserRankInstrumentBuys { get; set; }
        public virtual DbSet<UserRankInstrumentSell> UserRankInstrumentSells { get; set; }
        public virtual DbSet<InstrumentUserMapper> InstrumentUserMappers { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServer:ApplicationDbContextConnection"),
               serverDbContextOptionsBuilder =>
               {
                   var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                   serverDbContextOptionsBuilder.CommandTimeout(minutes);
                   serverDbContextOptionsBuilder.EnableRetryOnFailure();
               });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Username).HasMaxLength(450).IsRequired();
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.SerialNumber).HasMaxLength(450);
                entity.HasIndex(b => b.Username);
                entity.HasIndex(b => b.Id);
                entity.HasIndex(b => b.GroupAuthId);

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(450).IsRequired();
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(b => b.Id);

            });


            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.RoleId);
                entity.Property(e => e.UserId);
                entity.Property(e => e.RoleId);
                entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);
                entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);

            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasOne(ut => ut.User)
                      .WithMany(u => u.UserTokens)
                      .HasForeignKey(ut => ut.UserId);
                entity.HasIndex(ut => ut.UserId);
                entity.Property(ut => ut.RefreshTokenIdHash).HasMaxLength(450).IsRequired();
                entity.Property(ut => ut.RefreshTokenIdHashSource).HasMaxLength(450);
            });


            modelBuilder.Entity<User>()
                         .HasOne(d => d.GroupAuth)
                         .WithMany(t => t.Users)
                         .HasForeignKey(d => d.GroupAuthId)
                         .OnDelete(DeleteBehavior.Cascade);

           

            modelBuilder.Entity<User>()
                  .HasMany(d => d.UserConfigurations).WithOne(d => d.User);

            modelBuilder.Entity<User>()
                  .HasMany(d => d.SpecialInstrumentAnalayzedBuys).WithOne(d => d.User);
            modelBuilder.Entity<User>()
                  .HasMany(d => d.SpecialInstrumentAnalayzedSells).WithOne(d => d.User);
            modelBuilder.Entity<User>()
                  .HasMany(d => d.InstrumentUserMappers).WithOne(d => d.User);


            //modelBuilder.Entity<User>()
            //     .HasMany(d => d.UserRankInstrumentBuys).WithOne(d => d.User).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<User>()
            //   .HasMany(d => d.UserRankInstrumentSells).WithOne(d => d.User).OnDelete(DeleteBehavior.Cascade); 



            modelBuilder.Entity<User>()
                 .HasMany(d => d.InstrumentCycles).WithOne(d => d.SenderUser);


            modelBuilder.Entity<GroupAuthRole>()
                     .HasKey(t => new { t.GroupAuthId, t.RoleId });

            modelBuilder.Entity<GroupAuthRole>()
                     .HasOne(pt => pt.GroupAuth)
                     .WithMany(p => p.GroupRoles)
                     .HasForeignKey(pt => pt.GroupAuthId);

            modelBuilder.Entity<GroupAuthRole>()
                    .HasOne(pt => pt.Role)
                    .WithMany()
                    .HasForeignKey(pt => pt.RoleId);


            modelBuilder.Entity<AppLogItem>()
                    .HasKey(t => new { t.Id });

            modelBuilder.Entity<FileAddress>().HasKey(x => x.FileId);
            modelBuilder.Entity<FileAddress>().Property(x => x.FileId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<FileAddress>().HasIndex(x => x.FileId);

            modelBuilder.Entity<ReportStructure>().HasIndex(x => x.ReportId);
            modelBuilder.Entity<ReportStructure>()
                    .Property(c => c.CreationDate).HasDefaultValueSql("getdate()");


            modelBuilder.Entity<Instrument>()
                 .HasMany(d => d.Requests).WithOne(d => d.Instrument).HasForeignKey(d => d.InstrumentId);


            modelBuilder.Entity<Instrument>()
                .HasMany(d => d.InstrumentInformations).WithOne(d => d.Instrument).HasForeignKey(d => d.InstrumentId);

            modelBuilder.Entity<Instrument>()
                   .Property(c => c.CreationDate).HasDefaultValueSql("getdate()");


            modelBuilder.Entity<Instrument>()
                 .HasMany(d => d.InstrumentAnalayzeBuys).WithOne(d => d.Instrument).HasForeignKey(d => d.InstrumentId);

            modelBuilder.Entity<Instrument>()
                 .HasMany(d => d.InstrumentAnalayzeSells).WithOne(d => d.Instrument).HasForeignKey(d => d.InstrumentId);

            modelBuilder.Entity<InstrumentAnalayzeBuy>()
                .HasMany(d => d.InstrumentDescriptionBuys).WithOne(d => d.InstrumentAnalayzeBuy).HasForeignKey(d => d.InstrumentAnalayzeBuyId);

            modelBuilder.Entity<InstrumentAnalayzeBuy>()
                  .Property(c => c.CreationDate).HasDefaultValueSql("getdate()");


            modelBuilder.Entity<InstrumentAnalayzeSell>()
                .HasMany(d => d.InstrumentDescriptionSells).WithOne(d => d.InstrumentAnalayzeSell).HasForeignKey(d => d.InstrumentAnalayzeSellId);

            modelBuilder.Entity<InstrumentAnalayzeSell>()
             .Property(c => c.CreationDate).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<InstrumentAnalayzeBuy>()
                .HasMany(d => d.UserRankInstrumentBuys).WithOne(d => d.InstrumentAnalayzeBuy).HasForeignKey(d => d.InstrumentAnalayzeBuyId);


            modelBuilder.Entity<InstrumentAnalayzeSell>()
                .HasMany(d => d.UserRankInstrumentSells).WithOne(d => d.InstrumentAnalayzeSell).HasForeignKey(d => d.InstrumentAnalayzeSellId);

            modelBuilder.Entity<InstrumentAnalayzeBuy>()
                .HasMany(d => d.SpecialInstrumentAnalayzedBuys).WithOne(d => d.InstrumentAnalayzeBuy).HasForeignKey(d => d.InstrumentAnalayzeBuyId);
            modelBuilder.Entity<InstrumentAnalayzeSell>()
                .HasMany(d => d.SpecialInstrumentAnalayzedSells).WithOne(d => d.InstrumentAnalayzeSell).HasForeignKey(d => d.InstrumentAnalayzeSellId);


            modelBuilder.Entity<InstrumentCycle>()
                .HasOne(d => d.Instrument).WithMany(d=>d.InstrumentCycles).HasForeignKey(d => d.InstrumentId);

            modelBuilder.Entity<InstrumentCycle>().HasIndex(x => x.InstrumentState);
           

            modelBuilder.Entity<InstrumentCycle>()
             .Property(c => c.CreationDate).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<InstrumentCycle>()
               .HasOne(d => d.SenderUser).WithMany(d => d.InstrumentCycles).HasForeignKey(d => d.SenderUserId);


     


            modelBuilder.Entity<Instrument>()
              .HasOne(d => d.Sector).WithMany(d => d.Instruments).HasForeignKey(d => d.CSecVal);
            modelBuilder.Entity<Instrument>()
           .HasOne(d => d.SubSector).WithMany(d => d.Instruments).HasForeignKey(d => d.CSoSecVal);

            modelBuilder.Entity<Instrument>()
      .HasOne(d => d.Board).WithMany(d => d.Instruments).HasForeignKey(d => d.CComVal);


            






        }
    }


}

