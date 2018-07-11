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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:ramskill-1806.database.windows.net,1433;Initial Catalog=PizzaStoreDB;Persist Security Info=False;User ID=nephesh;Password=9D2ziE79;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

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

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderHistory)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderCustomerID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.OrderHistory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderHistoryLocation");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Size });

                entity.ToTable("Pizza", "StoreOps");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Size).HasMaxLength(2);

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });
        }
    }
}
