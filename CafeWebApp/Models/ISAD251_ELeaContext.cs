using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CafeWebApp.Models
{
    public partial class ISAD251_ELeaContext : DbContext
    {
        public ISAD251_ELeaContext()
        {
        }

        public ISAD251_ELeaContext(DbContextOptions<ISAD251_ELeaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItemOrder> ItemOrder { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemOrder>(entity =>
            {
                entity.Property(e => e.ItemOrderId)
                    .HasColumnName("ItemOrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.OrderMainId).HasColumnName("OrderMainID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemOrder)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("Stock_fk");

                entity.HasOne(d => d.OrderMain)
                    .WithMany(p => p.ItemOrder)
                    .HasForeignKey(d => d.OrderMainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Orders_fk");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderMainId)
                    .HasName("Orders_pk");

                entity.Property(e => e.OrderMainId)
                    .HasColumnName("OrderMainID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderCost).HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("Stock_pk");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.ItemType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
