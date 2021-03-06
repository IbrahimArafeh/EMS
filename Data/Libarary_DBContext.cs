// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EMS.Models;

namespace EMS.Data
{
    public partial class Libarary_DBContext : DbContext
    {
        public Libarary_DBContext()
        {
        }

        public Libarary_DBContext(DbContextOptions<Libarary_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("Category_Name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(512)
                    .HasColumnName("barcode");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.GategoryId).HasColumnName("Gategory_id");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StatusId).HasColumnName("Status_id");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("weight");

                entity.HasOne(d => d.Gategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.GategoryId)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Product_Status");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .HasColumnName("Status_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}