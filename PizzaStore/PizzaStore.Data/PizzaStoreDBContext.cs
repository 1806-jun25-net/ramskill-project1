using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

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
        public virtual DbSet<Topping> Topping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }

            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer("Server=tcp:ramskill-1806.database.windows.net,1433;Initial Catalog=PizzaStoreDB;Persist Security Info=False;User ID=nephesh;Password=9D2ziE79;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //            }
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

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Topping10Id).HasColumnName("Topping10ID");

                entity.Property(e => e.Topping1Id).HasColumnName("Topping1ID");

                entity.Property(e => e.Topping2Id).HasColumnName("Topping2ID");

                entity.Property(e => e.Topping3Id).HasColumnName("Topping3ID");

                entity.Property(e => e.Topping4Id).HasColumnName("Topping4ID");

                entity.Property(e => e.Topping5Id).HasColumnName("Topping5ID");

                entity.Property(e => e.Topping6Id).HasColumnName("Topping6ID");

                entity.Property(e => e.Topping7Id).HasColumnName("Topping7ID");

                entity.Property(e => e.Topping8Id).HasColumnName("Topping8ID");

                entity.Property(e => e.Topping9Id).HasColumnName("Topping9ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaOrder");

                entity.HasOne(d => d.Topping10)
                    .WithMany(p => p.PizzaTopping10)
                    .HasForeignKey(d => d.Topping10Id)
                    .HasConstraintName("FK_PizzaTopping10");

                entity.HasOne(d => d.Topping1)
                    .WithMany(p => p.PizzaTopping1)
                    .HasForeignKey(d => d.Topping1Id)
                    .HasConstraintName("FK_PizzaTopping1");

                entity.HasOne(d => d.Topping2)
                    .WithMany(p => p.PizzaTopping2)
                    .HasForeignKey(d => d.Topping2Id)
                    .HasConstraintName("FK_PizzaTopping2");

                entity.HasOne(d => d.Topping3)
                    .WithMany(p => p.PizzaTopping3)
                    .HasForeignKey(d => d.Topping3Id)
                    .HasConstraintName("FK_PizzaTopping3");

                entity.HasOne(d => d.Topping4)
                    .WithMany(p => p.PizzaTopping4)
                    .HasForeignKey(d => d.Topping4Id)
                    .HasConstraintName("FK_PizzaTopping4");

                entity.HasOne(d => d.Topping5)
                    .WithMany(p => p.PizzaTopping5)
                    .HasForeignKey(d => d.Topping5Id)
                    .HasConstraintName("FK_PizzaTopping5");

                entity.HasOne(d => d.Topping6)
                    .WithMany(p => p.PizzaTopping6)
                    .HasForeignKey(d => d.Topping6Id)
                    .HasConstraintName("FK_PizzaTopping6");

                entity.HasOne(d => d.Topping7)
                    .WithMany(p => p.PizzaTopping7)
                    .HasForeignKey(d => d.Topping7Id)
                    .HasConstraintName("FK_PizzaTopping7");

                entity.HasOne(d => d.Topping8)
                    .WithMany(p => p.PizzaTopping8)
                    .HasForeignKey(d => d.Topping8Id)
                    .HasConstraintName("FK_PizzaTopping8");

                entity.HasOne(d => d.Topping9)
                    .WithMany(p => p.PizzaTopping9)
                    .HasForeignKey(d => d.Topping9Id)
                    .HasConstraintName("FK_PizzaTopping9");
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.ToTable("Topping", "StoreOps");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CostLg)
                    .HasColumnName("CostLG")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CostMd)
                    .HasColumnName("CostMD")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CostSm)
                    .HasColumnName("CostSM")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });
        }
    }
}
