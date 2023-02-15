﻿// <auto-generated />
using System;
using HardCodeTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HardCodeTest.Migrations
{
    [DbContext(typeof(HardCodeDbContext))]
    [Migration("20230215104358_ChangedSchema")]
    partial class ChangedSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HardCodeData.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("HardCodeData.Models.MiscField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("MiscFields");
                });

            modelBuilder.Entity("HardCodeData.Models.MiscFieldValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FieldValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MiscFieldId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MiscFieldId");

                    b.HasIndex("ProductId");

                    b.ToTable("MiscFieldValue");
                });

            modelBuilder.Entity("HardCodeData.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("HardCodeData.Models.MiscField", b =>
                {
                    b.HasOne("HardCodeData.Models.Category", null)
                        .WithMany("MiscFields")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("HardCodeData.Models.MiscFieldValue", b =>
                {
                    b.HasOne("HardCodeData.Models.MiscField", "MiscField")
                        .WithMany("MiscFieldValues")
                        .HasForeignKey("MiscFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HardCodeData.Models.Product", "Product")
                        .WithMany("MiscFieldValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MiscField");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HardCodeData.Models.Product", b =>
                {
                    b.HasOne("HardCodeData.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HardCodeData.Models.Category", b =>
                {
                    b.Navigation("MiscFields");
                });

            modelBuilder.Entity("HardCodeData.Models.MiscField", b =>
                {
                    b.Navigation("MiscFieldValues");
                });

            modelBuilder.Entity("HardCodeData.Models.Product", b =>
                {
                    b.Navigation("MiscFieldValues");
                });
#pragma warning restore 612, 618
        }
    }
}