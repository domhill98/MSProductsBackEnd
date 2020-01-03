using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSProductsBackEnd.Data.Migrations
{
    [DbContext(typeof(MSProductsDB))]
    partial class MSProductsDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MSProductsBackEnd.Data.Brand", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<bool>("Active");

                b.Property<string>("Name")
                    .IsRequired();

                b.HasKey("Id");

                b.ToTable("Brands");
            });

            modelBuilder.Entity("MSProductsBackEnd.Data.Category", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<bool>("Active");

                b.Property<string>("Description")
                    .IsRequired();

                b.Property<string>("Name")
                    .IsRequired();

                b.HasKey("Id");

                b.ToTable("Categories");
            });

            modelBuilder.Entity("MSProductsBackEnd.Data.Product", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<bool>("Active");

                b.Property<int>("BrandId");

                b.Property<int>("CategoryId");

                b.Property<string>("Description")
                    .IsRequired();

                b.Property<string>("Name")
                    .IsRequired();

                b.Property<double>("Price");

                b.Property<int>("StockLevel");

                b.HasKey("Id");

                b.HasIndex("BrandId");

                b.HasIndex("CategoryId");

                b.ToTable("Products");
            });

            modelBuilder.Entity("MSProductsBackEnd.Data.Product", b =>
            {
                b.HasOne("MSProductsBackEnd.Data.Brand", "Brand")
                    .WithMany()
                    .HasForeignKey("BrandId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("MSProductsBackEnd.Data.Category", "Category")
                    .WithMany()
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
#pragma warning restore 612, 618
        }
    }
}
