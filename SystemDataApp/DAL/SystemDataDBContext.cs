using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SystemDataApp.DAL
{
    public partial class SystemDataDBContext : DbContext
    {
        public SystemDataDBContext()
        {
        }

        public SystemDataDBContext(DbContextOptions<SystemDataDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CustomerSupplier> CustomerSupplier { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<UnitName> UnitName { get; set; }
        public virtual DbSet<UnitProduct> UnitProduct { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Sett.cn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.NameAr).HasMaxLength(50);

                entity.Property(e => e.NameEn).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CustomerSupplier>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Tel1).HasMaxLength(50);

                entity.Property(e => e.Tel2).HasMaxLength(50);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderDateAdd).HasColumnType("date");

                entity.HasOne(d => d.BranchCodeNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.BranchCode)
                    .HasConstraintName("FK_Invoice_Branch");

                entity.HasOne(d => d.CustomerSupplierCodeNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.CustomerSupplierCode)
                    .HasConstraintName("FK_Invoice_CustomerSupplier");

                entity.HasOne(d => d.UserCodeNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.UserCode)
                    .HasConstraintName("FK_Invoice_Users");
            });

            modelBuilder.Entity<InvoiceDetails>(entity =>
            {
                entity.HasOne(d => d.InvoiceCodeNavigation)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_InvoiceDetails_Invoice");

                entity.HasOne(d => d.StoreCodeNavigation)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.StoreCode)
                    .HasConstraintName("FK_InvoiceDetails_Store");

                entity.HasOne(d => d.UnitProductCodeNavigation)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.UnitProductCode)
                    .HasConstraintName("FK_InvoiceDetails_UnitProduct");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Img).HasColumnType("image");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.BranchCodeNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.BranchCode)
                    .HasConstraintName("FK_Product_Branch");

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryCode)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.StoreCodeNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.StoreCode)
                    .HasConstraintName("FK_Product_Store");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<UnitName>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<UnitProduct>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.UnitProduct)
                    .HasForeignKey(d => d.ProductCode)
                    .HasConstraintName("FK_UnitProduct_Product");

                entity.HasOne(d => d.UnitNameCodeNavigation)
                    .WithMany(p => p.UnitProduct)
                    .HasForeignKey(d => d.UnitNameCode)
                    .HasConstraintName("FK_UnitProduct_UnitName");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.BranchCodeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BranchCode)
                    .HasConstraintName("FK_Users_Branch");
            });
        }
    }
}
