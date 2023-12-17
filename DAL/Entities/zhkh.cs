using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Net.Sockets;

namespace DAL.Entities
{
    public partial class zhkh : DbContext
    {
        //public zhkh()
        //    : base("name=zhkh")
        //{
        //}

        public zhkh(DbContextOptions<zhkh> options) : base(options)
        { }
        public zhkh()
        { }

        public virtual DbSet<ADDRESS> ADDRESS { get; set; }
        public virtual DbSet<METER> METER { get; set; }
        public virtual DbSet<METER_CATEGORY> METER_CATEGORY { get; set; }
        public virtual DbSet<SERVICE> SERVICE { get; set; }
        public virtual DbSet<SERVICE_CATEGORY> SERVICE_CATEGORY { get; set; }
        public virtual DbSet<USER> USER { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADDRESS>(entity =>
            {
                entity.Property(e => e.city)
                .IsUnicode(false);

                entity.Property(e => e.street)
                .IsUnicode(false);

                entity.Property(e => e.house)
                .IsUnicode(false);

                entity.Property(e => e.flat)
                .IsUnicode(false);

                entity.Property<int>("id_user");

                entity.HasOne(a => a.USER)
                    .WithMany(b => b.ADDRESS)
                    .HasForeignKey("id_user");
            });

            modelBuilder.Entity<METER>(entity =>
            {
                entity.Property(e => e.number)
                .IsUnicode(false);

                entity.Property<int>("id_address");

                entity.HasOne(a => a.ADDRESS)
                    .WithMany(b => b.METER)
                    .HasForeignKey("id_address");

                entity.Property<int>("id_category");

                entity.HasOne(a => a.METER_CATEGORY)
                    .WithMany(b => b.METER)
                    .HasForeignKey("id_category");
            });

            modelBuilder.Entity<METER_CATEGORY>(entity =>
            {
                entity.Property(e => e.name)
                .IsUnicode(false);

                entity.Property(e => e.unit)
                .IsUnicode(false);
            });

            modelBuilder.Entity<SERVICE>(entity =>
            {
                entity.Property(e => e.company)
                .IsUnicode(false);

                entity.Property(e => e.month)
                .IsUnicode(false);

                entity.Property(e => e.account)
                .IsUnicode(false);

                entity.HasOne(a => a.ADDRESS)
                    .WithMany(b => b.SERVICE)
                    .HasForeignKey("id_address");

                entity.Property<int>("id_category");

                entity.HasOne(a => a.SERVICE_CATEGORY)
                    .WithMany(b => b.SERVICE)
                    .HasForeignKey("id_category");
            });

            modelBuilder.Entity<SERVICE_CATEGORY>(entity =>
            {
                entity.Property(e => e.name)
                .IsUnicode(false);
            });

            modelBuilder.Entity<USER>(entity =>
            {
                entity.Property(e => e.phone)
                .IsUnicode(false);

                entity.Property(e => e.password)
                .IsUnicode(false);
            });
        }
    }
}
