﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetsFederes.Models;
using ProjetsFederes.Persistence;

#nullable disable

namespace ProjetsFederes.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240503181108_ParaMigration")]
    partial class ParaMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetsFederes.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategorieId"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategorieId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProjetsFederes.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TypePeau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ProjetsFederes.Models.Commande", b =>
                {
                    b.Property<int>("CommandeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommandeId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCommande")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CommandeId");

                    b.HasIndex("ClientId");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("ProjetsFederes.Models.DetailCommande", b =>
                {
                    b.Property<int>("DetailCommandeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailCommandeId"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("CommandeId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProduitId")
                        .HasColumnType("int");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.HasKey("DetailCommandeId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CommandeId");

                    b.HasIndex("ProduitId");

                    b.ToTable("DetailCommandes");
                });

            modelBuilder.Entity("ProjetsFederes.Models.Fournisseur", b =>
                {
                    b.Property<int>("FournisseurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FournisseurId"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("FournisseurId");

                    b.ToTable("Fournisseurs");
                });

            modelBuilder.Entity("ProjetsFederes.Models.Produit", b =>
                {
                    b.Property<int>("ProduitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduitId"));

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FournisseurId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantiteEnStock")
                        .HasColumnType("int");

                    b.Property<string>("TypePeauRecommande")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProduitId");

                    b.HasIndex("CategorieId");

                    b.HasIndex("FournisseurId");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("ProjetsFederes.Models.Commande", b =>
                {
                    b.HasOne("ProjetsFederes.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ProjetsFederes.Models.DetailCommande", b =>
                {
                    b.HasOne("ProjetsFederes.Models.Client", null)
                        .WithMany("Achats")
                        .HasForeignKey("ClientId");

                    b.HasOne("ProjetsFederes.Models.Commande", "Commande")
                        .WithMany()
                        .HasForeignKey("CommandeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetsFederes.Models.Produit", "Produit")
                        .WithMany()
                        .HasForeignKey("ProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commande");

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("ProjetsFederes.Models.Produit", b =>
                {
                    b.HasOne("ProjetsFederes.Models.Categorie", "Categorie")
                        .WithMany("Produits")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetsFederes.Models.Fournisseur", "Fournisseur")
                        .WithMany()
                        .HasForeignKey("FournisseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Fournisseur");
                });

            modelBuilder.Entity("ProjetsFederes.Models.Categorie", b =>
                {
                    b.Navigation("Produits");
                });

            modelBuilder.Entity("ProjetsFederes.Models.Client", b =>
                {
                    b.Navigation("Achats");
                });
#pragma warning restore 612, 618
        }
    }
}
