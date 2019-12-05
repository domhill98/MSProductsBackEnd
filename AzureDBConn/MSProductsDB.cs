﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MSProductsBackEnd.Data
{
    public class MSProductsDB : DbContext
    {
         public DbSet<Product> Products { get; set; }
         public DbSet<Brand> Brands { get; set; }
         public DbSet<Category> Category { get; set; }

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
                x.Property(c => c.Id).IsRequired();
                x.Property(c => c.Name).IsRequired();
                x.Property(c => c.Description).IsRequired();
            });

            modelBuilder.Entity<Brand>(x =>
            {
                x.Property(b => b.Id).IsRequired();
                x.Property(b => b.Name).IsRequired();
            });


            modelBuilder.Entity<Product>(x =>
            {
                x.Property(p => p.Id).IsRequired();
                x.Property(p => p.CategoryId).IsRequired();
                x.Property(p => p.BrandId).IsRequired();
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

        }
    }
}