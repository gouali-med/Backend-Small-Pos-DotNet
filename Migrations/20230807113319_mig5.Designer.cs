﻿// <auto-generated />
using System;
using GestionCommercialeServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionCommercialeServices.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230807113319_mig5")]
    partial class mig5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TaxeID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ICE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("Siteweb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RegionID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ICE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Siteweb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.DetailsSale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("Montant")
                        .HasColumnType("real");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<float>("Quantite")
                        .HasColumnType("real");

                    b.Property<int?>("SaleID")
                        .HasColumnType("int");

                    b.Property<int>("VenteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SaleID");

                    b.ToTable("DetailsSales");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.PaymentClient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("DateEcheance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOperation")
                        .HasColumnType("datetime2");

                    b.Property<float>("Payed")
                        .HasColumnType("real");

                    b.Property<int>("TypePaymentID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("VenteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TypePaymentID");

                    b.HasIndex("UserID");

                    b.HasIndex("VenteID");

                    b.ToTable("PaymentClients");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BarCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("PurchasPrice")
                        .HasColumnType("real");

                    b.Property<float?>("StockAlerte")
                        .HasColumnType("real");

                    b.Property<int>("UniteOfSaleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UniteOfSaleID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.Region", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.Sale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOperation")
                        .HasColumnType("datetime2");

                    b.Property<float>("Reste")
                        .HasColumnType("real");

                    b.Property<float>("Solde")
                        .HasColumnType("real");

                    b.Property<float>("TotalHT")
                        .HasColumnType("real");

                    b.Property<float>("TotalTTC")
                        .HasColumnType("real");

                    b.Property<float>("TotalTVA")
                        .HasColumnType("real");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("UserID");

                    b.ToTable("Ventes");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.Taxe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("Valeur")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("Taxes");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.TypePayment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TypePayment");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.UniteOfSale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UniteOfSales");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.Category", b =>
                {
                    b.HasOne("GestionCommercialeServices.Models.Class.Taxe", "Taxe")
                        .WithMany()
                        .HasForeignKey("TaxeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Taxe");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.Client", b =>
                {
                    b.HasOne("GestionCommercialeServices.Models.Class.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.DetailsSale", b =>
                {
                    b.HasOne("GestionCommercialeServices.Models.Class.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCommercialeServices.Models.Class.Sale", "Sale")
                        .WithMany()
                        .HasForeignKey("SaleID");

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.PaymentClient", b =>
                {
                    b.HasOne("GestionCommercialeServices.Models.Class.TypePayment", "TypePayment")
                        .WithMany()
                        .HasForeignKey("TypePaymentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCommercialeServices.Models.Class.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCommercialeServices.Models.Class.Sale", "Vente")
                        .WithMany()
                        .HasForeignKey("VenteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypePayment");

                    b.Navigation("User");

                    b.Navigation("Vente");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.Product", b =>
                {
                    b.HasOne("GestionCommercialeServices.Models.Class.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCommercialeServices.Models.Class.UniteOfSale", "UniteOfSale")
                        .WithMany()
                        .HasForeignKey("UniteOfSaleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("UniteOfSale");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.Sale", b =>
                {
                    b.HasOne("GestionCommercialeServices.Models.Class.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCommercialeServices.Models.Class.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GestionCommercialeServices.Models.Class.User", b =>
                {
                    b.HasOne("GestionCommercialeServices.Models.Class.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}