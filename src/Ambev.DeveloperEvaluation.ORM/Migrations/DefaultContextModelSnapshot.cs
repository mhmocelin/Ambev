﻿// <auto-generated />
using System;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    [DbContext(typeof(DefaultContext))]
    partial class DefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence<int>("SaleSequence");

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.CartProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("cartproduct", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Rate")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("rating", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("SaleCancelled")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("SaleCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("SaleModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SaleNumber")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalSaleAmount")
                        .HasColumnType("numeric");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("sale", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.SaleProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<decimal>("Discounts")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("SaleId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("saleproduct", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Cart", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.CartProduct", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Cart", "Cart")
                        .WithMany("Products")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Rating", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Product", "Product")
                        .WithOne("Rating")
                        .HasForeignKey("Ambev.DeveloperEvaluation.Domain.Entities.Rating", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.SaleProduct", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Sale", "Sale")
                        .WithMany("SaleProducts")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Cart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Product", b =>
                {
                    b.Navigation("Rating");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Sale", b =>
                {
                    b.Navigation("SaleProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
