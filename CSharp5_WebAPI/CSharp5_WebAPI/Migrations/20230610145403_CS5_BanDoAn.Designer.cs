﻿// <auto-generated />
using System;
using CSharp5_WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSharp5_WebAPI.Migrations
{
    [DbContext(typeof(CS5_DbContext))]
    [Migration("20230610145403_CS5_BanDoAn")]
    partial class CS5_BanDoAn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CSharp5_Share.Models.Bill", b =>
                {
                    b.Property<Guid>("BillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<int?>("Price")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BillID");

                    b.HasIndex("UserID");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("CSharp5_Share.Models.BillDetail", b =>
                {
                    b.Property<Guid>("BillDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BillID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Price")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid?>("ProductsProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("BillDetailID");

                    b.HasIndex("BillID");

                    b.HasIndex("ProductsProductID");

                    b.ToTable("BillDetails");
                });

            modelBuilder.Entity("CSharp5_Share.Models.Cart", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("CSharp5_Share.Models.CartDetail", b =>
                {
                    b.Property<Guid>("CDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ComboID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Price")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid?>("ProductsProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ToTal")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("CDID");

                    b.HasIndex("CartUserID");

                    b.HasIndex("ComboID");

                    b.HasIndex("ProductsProductID");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("CSharp5_Share.Models.Categories", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Status")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CSharp5_Share.Models.Chef", b =>
                {
                    b.Property<Guid>("ChefID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChefDescription")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ChefName")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("ChefID");

                    b.ToTable("Chefs");
                });

            modelBuilder.Entity("CSharp5_Share.Models.Combo", b =>
                {
                    b.Property<Guid>("ComboID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ComboName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImgCombo")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ComboID");

                    b.ToTable("Combos");
                });

            modelBuilder.Entity("CSharp5_Share.Models.ComboItems", b =>
                {
                    b.Property<Guid>("ComboItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ComboID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Price")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid?>("ProductsProductID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ComboItemID");

                    b.HasIndex("ComboID");

                    b.HasIndex("ProductsProductID");

                    b.ToTable("ComboItems");
                });

            modelBuilder.Entity("CSharp5_Share.Models.National", b =>
                {
                    b.Property<Guid>("NationalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NationalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("NationalID");

                    b.ToTable("Nationals");
                });

            modelBuilder.Entity("CSharp5_Share.Models.Post", b =>
                {
                    b.Property<Guid>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime?>("CreateDate")
                        .IsUnicode(true)
                        .HasColumnType("DateTime");

                    b.Property<string>("ImgPost")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TiTlePost")
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("PostID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CSharp5_Share.Models.Producer", b =>
                {
                    b.Property<Guid>("ProducerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ProducerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("ProducerID");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("CSharp5_Share.Models.Products", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoriesCategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChefID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfManufacture")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("EntryPrice")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Expired")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<DateTime?>("ImPortDate")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<int?>("Price")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid?>("ProducerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid?>("VouchervaVoucherID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoriesCategoryID");

                    b.HasIndex("ChefID");

                    b.HasIndex("ProducerID");

                    b.HasIndex("VouchervaVoucherID");

                    b.ToTable("Productss");
                });

            modelBuilder.Entity("CSharp5_Share.Models.Role", b =>
                {
                    b.Property<Guid>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CSharp5_Share.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<string>("ImgUser")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid?>("NationalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<Guid?>("RoleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Sex")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserID");

                    b.HasIndex("NationalID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CSharp5_Share.Models.Voucher", b =>
                {
                    b.Property<Guid>("VoucherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PercentageDiscount")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("VoucherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("VoucherID");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("CSharp5_Share.Models.Bill", b =>
                {
                    b.HasOne("CSharp5_Share.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CSharp5_Share.Models.BillDetail", b =>
                {
                    b.HasOne("CSharp5_Share.Models.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillID");

                    b.HasOne("CSharp5_Share.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsProductID");

                    b.Navigation("Bill");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("CSharp5_Share.Models.Cart", b =>
                {
                    b.HasOne("CSharp5_Share.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("CSharp5_Share.Models.Cart", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CSharp5_Share.Models.CartDetail", b =>
                {
                    b.HasOne("CSharp5_Share.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartUserID");

                    b.HasOne("CSharp5_Share.Models.Combo", "Combo")
                        .WithMany()
                        .HasForeignKey("ComboID");

                    b.HasOne("CSharp5_Share.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsProductID");

                    b.Navigation("Cart");

                    b.Navigation("Combo");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("CSharp5_Share.Models.ComboItems", b =>
                {
                    b.HasOne("CSharp5_Share.Models.Combo", "Combo")
                        .WithMany()
                        .HasForeignKey("ComboID");

                    b.HasOne("CSharp5_Share.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsProductID");

                    b.Navigation("Combo");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("CSharp5_Share.Models.Products", b =>
                {
                    b.HasOne("CSharp5_Share.Models.Categories", "Categories")
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryID");

                    b.HasOne("CSharp5_Share.Models.Chef", "Chef")
                        .WithMany()
                        .HasForeignKey("ChefID");

                    b.HasOne("CSharp5_Share.Models.Producer", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerID");

                    b.HasOne("CSharp5_Share.Models.Voucher", "Voucherva")
                        .WithMany()
                        .HasForeignKey("VouchervaVoucherID");

                    b.Navigation("Categories");

                    b.Navigation("Chef");

                    b.Navigation("Producer");

                    b.Navigation("Voucherva");
                });

            modelBuilder.Entity("CSharp5_Share.Models.User", b =>
                {
                    b.HasOne("CSharp5_Share.Models.National", "National")
                        .WithMany()
                        .HasForeignKey("NationalID");

                    b.HasOne("CSharp5_Share.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID");

                    b.Navigation("National");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CSharp5_Share.Models.User", b =>
                {
                    b.Navigation("Cart");
                });
#pragma warning restore 612, 618
        }
    }
}
