using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MSProductsBackEnd.Data
{
    public class MSProductsDB : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Product> Products { get; set; }
         
        public DbSet<Review> Reviews { get; set; }

        public DbSet<ResellHistory> ResellHistory { get; set; }

        public DbSet<OrderHistory> OrderHistory { get; set; }

        public MSProductsDB(DbContextOptions<MSProductsDB> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(x =>
            {
                x.Property(c => c.Name).IsRequired();
                x.Property(c => c.Description).IsRequired();
            });

            modelBuilder.Entity<Brand>(x =>
            {
                x.Property(b => b.Name).IsRequired();
            });


            modelBuilder.Entity<Product>(x =>
            {
                x.Property(p => p.Name).IsRequired();
                x.Property(p => p.Description).IsRequired();
                x.Property(p => p.Price).IsRequired();
                x.Property(p => p.StockLevel).IsRequired();
                x.HasOne(p => p.Category).WithMany()
                                         .HasForeignKey(p => p.CategoryId)
                                         .IsRequired();
                x.HasOne(p => p.Brand).WithMany()
                                      .HasForeignKey(p => p.BrandId)
                                      .IsRequired();
            });


            modelBuilder.Entity<Review>(x => {
                x.Property(p => p.ReviewerId).IsRequired();
                x.Property(p => p.ReviewerName).IsRequired();
                x.Property(p => p.Rating).IsRequired();
                x.Property(p => p.Show).IsRequired();
            });

            modelBuilder.Entity<ResellHistory>(x => {
                x.Property(p => p.productId).IsRequired();
                x.Property(p => p.userId).IsRequired();
                x.Property(p => p.oldPrice).IsRequired();
                x.Property(p => p.newPrice).IsRequired();
                x.Property(p => p.created).IsRequired();
            });

            modelBuilder.Entity<OrderHistory>(x => {
                x.Property(p => p.productId).IsRequired();
                x.Property(p => p.userId).IsRequired();
            });

        }
    }
}
