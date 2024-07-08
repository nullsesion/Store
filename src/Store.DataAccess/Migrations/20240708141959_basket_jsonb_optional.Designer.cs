﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Store.DataAccess;

#nullable disable

namespace Store.DataAccess.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20240708141959_basket_jsonb_optional")]
    partial class basket_jsonb_optional
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Store.DataAccess.Entities.BasketEntity", b =>
                {
                    b.Property<Guid>("BasketId")
                        .HasColumnType("uuid")
                        .HasColumnName("BasketId");

                    b.Property<string>("JsonProducts")
                        .HasColumnType("jsonb");

                    b.Property<bool>("Sealed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.HasKey("BasketId")
                        .HasName("basket_pk");

                    b.ToTable("Basket", (string)null);
                });

            modelBuilder.Entity("Store.DataAccess.Entities.BasketProductEntity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("ProductId");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uuid")
                        .HasColumnName("BasketId");

                    b.Property<Guid?>("BasketEntityBasketId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BasketEntityBasketId1")
                        .HasColumnType("uuid");

                    b.Property<long>("Count")
                        .HasColumnType("bigint")
                        .HasColumnName("Count");

                    b.HasKey("ProductId", "BasketId");

                    b.HasIndex("BasketEntityBasketId");

                    b.HasIndex("BasketEntityBasketId1");

                    b.HasIndex(new[] { "ProductId" }, "IX_BasketProduct_productid");

                    b.HasIndex(new[] { "BasketId", "ProductId" }, "basketproduct_basketid_idx")
                        .IsUnique();

                    b.ToTable("BasketProduct", (string)null);
                });

            modelBuilder.Entity("Store.DataAccess.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("ProductId");

                    b.Property<Guid?>("BasketEntityBasketId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("Price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Title");

                    b.HasKey("ProductId")
                        .HasName("product_pk");

                    b.HasIndex("BasketEntityBasketId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Store.DataAccess.Entities.BasketProductEntity", b =>
                {
                    b.HasOne("Store.DataAccess.Entities.BasketEntity", null)
                        .WithMany()
                        .HasForeignKey("BasketEntityBasketId");

                    b.HasOne("Store.DataAccess.Entities.BasketEntity", null)
                        .WithMany("BasketProductEntities")
                        .HasForeignKey("BasketEntityBasketId1");

                    b.HasOne("Store.DataAccess.Entities.BasketEntity", "BasketEntity")
                        .WithMany()
                        .HasForeignKey("BasketId")
                        .IsRequired()
                        .HasConstraintName("basketproduct_basket_fk");

                    b.HasOne("Store.DataAccess.Entities.ProductEntity", "ProductEntity")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("basketproduct_product_fk");

                    b.Navigation("BasketEntity");

                    b.Navigation("ProductEntity");
                });

            modelBuilder.Entity("Store.DataAccess.Entities.ProductEntity", b =>
                {
                    b.HasOne("Store.DataAccess.Entities.BasketEntity", null)
                        .WithMany("ProductEntities")
                        .HasForeignKey("BasketEntityBasketId");
                });

            modelBuilder.Entity("Store.DataAccess.Entities.BasketEntity", b =>
                {
                    b.Navigation("BasketProductEntities");

                    b.Navigation("ProductEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
