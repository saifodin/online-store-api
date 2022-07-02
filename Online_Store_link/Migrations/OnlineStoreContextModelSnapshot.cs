﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Online_Store_link.Data.Context;

#nullable disable

namespace Online_Store_link.Migrations
{
    [DbContext(typeof(OnlineStoreContext))]
    partial class OnlineStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Online_Store_link.Models.DBModels.Category", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentCategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryID");

                    b.HasIndex("ParentCategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Online_Store_link.Models.DBModels.Product", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CategoryID")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("VendorID")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("VendorID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Online_Store_link.Models.DBModels.Vendor", b =>
                {
                    b.Property<Guid>("VendorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorID");

                    b.ToTable("Vendors");

                    b.HasData(
                        new
                        {
                            VendorID = new Guid("e6af74a6-ab2f-4ea3-9587-6d79a19d70db"),
                            Address = "Cairo",
                            Email = "saif@saif.com",
                            Name = "Saifuddin Ibrahim"
                        },
                        new
                        {
                            VendorID = new Guid("4e24496a-71ec-4f9c-908c-54efe4861bcb"),
                            Address = "Cairo",
                            Email = "ali@ali.com",
                            Name = "Ali Hamed"
                        },
                        new
                        {
                            VendorID = new Guid("9a1e4c6b-73b7-431e-90b0-d26b4c1a21be"),
                            Address = "Cairo",
                            Email = "islam@islam.com",
                            Name = "Islam Ahmed"
                        },
                        new
                        {
                            VendorID = new Guid("21e7e6d3-fc8d-4b51-8150-66669372f25a"),
                            Address = "Cairo",
                            Email = "khaled@khaled.com",
                            Name = "Khaled Lotfy"
                        });
                });

            modelBuilder.Entity("Online_Store_link.Models.DBModels.Category", b =>
                {
                    b.HasOne("Online_Store_link.Models.DBModels.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryID");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Online_Store_link.Models.DBModels.Product", b =>
                {
                    b.HasOne("Online_Store_link.Models.DBModels.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Store_link.Models.DBModels.Vendor", "Vendor")
                        .WithMany("Products")
                        .HasForeignKey("VendorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Online_Store_link.Models.DBModels.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Online_Store_link.Models.DBModels.Vendor", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
