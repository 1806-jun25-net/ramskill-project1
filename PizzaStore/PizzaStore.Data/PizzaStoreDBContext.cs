using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaStore.Data
{
    public partial class PizzaStoreDBContext : DbContext
    {
        public PizzaStoreDBContext()
        {
        }

        public PizzaStoreDBContext(DbContextOptions<PizzaStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<OrderHistory> OrderHistory { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "StoreOps");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FavoriteLocationId).HasColumnName("FavoriteLocationID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastName).HasMaxLength(128);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.FavoriteLocation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.FavoriteLocationId)
                    .HasConstraintName("FK_CustomerLocation");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.LocationId, e.ToppingId });

                entity.ToTable("Inventory", "StoreOps");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryLocation");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "StoreOps");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.ToTable("OrderHistory", "StoreOps");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dt).HasColumnName("DT");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Pizza10Id).HasColumnName("Pizza10ID");

                entity.Property(e => e.Pizza11Id).HasColumnName("Pizza11ID");

                entity.Property(e => e.Pizza12Id).HasColumnName("Pizza12ID");

                entity.Property(e => e.Pizza1Id).HasColumnName("Pizza1ID");

                entity.Property(e => e.Pizza2Id).HasColumnName("Pizza2ID");

                entity.Property(e => e.Pizza3Id).HasColumnName("Pizza3ID");

                entity.Property(e => e.Pizza4Id).HasColumnName("Pizza4ID");

                entity.Property(e => e.Pizza5Id).HasColumnName("Pizza5ID");

                entity.Property(e => e.Pizza6Id).HasColumnName("Pizza6ID");

                entity.Property(e => e.Pizza7Id).HasColumnName("Pizza7ID");

                entity.Property(e => e.Pizza8Id).HasColumnName("Pizza8ID");

                entity.Property(e => e.Pizza9Id).HasColumnName("Pizza9ID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.OrderHistory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderHistoryLocation");

                entity.HasOne(d => d.Pizza10)
                    .WithMany(p => p.OrderHistoryPizza10)
                    .HasForeignKey(d => d.Pizza10Id)
                    .HasConstraintName("FK_OrderHistoryPizza10");

                entity.HasOne(d => d.Pizza11)
                    .WithMany(p => p.OrderHistoryPizza11)
                    .HasForeignKey(d => d.Pizza11Id)
                    .HasConstraintName("FK_OrderHistoryPizza11");

                entity.HasOne(d => d.Pizza12)
                    .WithMany(p => p.OrderHistoryPizza12)
                    .HasForeignKey(d => d.Pizza12Id)
                    .HasConstraintName("FK_OrderHistoryPizza12");

                entity.HasOne(d => d.Pizza1)
                    .WithMany(p => p.OrderHistoryPizza1)
                    .HasForeignKey(d => d.Pizza1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderHistoryPizza");

                entity.HasOne(d => d.Pizza2)
                    .WithMany(p => p.OrderHistoryPizza2)
                    .HasForeignKey(d => d.Pizza2Id)
                    .HasConstraintName("FK_OrderHistoryPizza2");

                entity.HasOne(d => d.Pizza3)
                    .WithMany(p => p.OrderHistoryPizza3)
                    .HasForeignKey(d => d.Pizza3Id)
                    .HasConstraintName("FK_OrderHistoryPizza3");

                entity.HasOne(d => d.Pizza4)
                    .WithMany(p => p.OrderHistoryPizza4)
                    .HasForeignKey(d => d.Pizza4Id)
                    .HasConstraintName("FK_OrderHistoryPizza4");

                entity.HasOne(d => d.Pizza5)
                    .WithMany(p => p.OrderHistoryPizza5)
                    .HasForeignKey(d => d.Pizza5Id)
                    .HasConstraintName("FK_OrderHistoryPizza5");

                entity.HasOne(d => d.Pizza6)
                    .WithMany(p => p.OrderHistoryPizza6)
                    .HasForeignKey(d => d.Pizza6Id)
                    .HasConstraintName("FK_OrderHistoryPizza6");

                entity.HasOne(d => d.Pizza7)
                    .WithMany(p => p.OrderHistoryPizza7)
                    .HasForeignKey(d => d.Pizza7Id)
                    .HasConstraintName("FK_OrderHistoryPizza7");

                entity.HasOne(d => d.Pizza8)
                    .WithMany(p => p.OrderHistoryPizza8)
                    .HasForeignKey(d => d.Pizza8Id)
                    .HasConstraintName("FK_OrderHistoryPizza8");

                entity.HasOne(d => d.Pizza9)
                    .WithMany(p => p.OrderHistoryPizza9)
                    .HasForeignKey(d => d.Pizza9Id)
                    .HasConstraintName("FK_OrderHistoryPizza9");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "StoreOps");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Size).HasMaxLength(128);
            });
        }
    }
}
