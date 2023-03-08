﻿// <auto-generated />
using System;
using MagicVilla_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230308090820_SeedVillaTable_withCreatedDate")]
    partial class SeedVillaTable_withCreatedDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_Api.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbRoom")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Superficie")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 12345,
                            Created_date = new DateTime(2023, 3, 8, 10, 8, 20, 226, DateTimeKind.Local).AddTicks(7402),
                            Description = "Description villa Sousse",
                            ImageUrl = "https://cdn.pixabay.com/photo/2017/09/17/18/15/lost-places-2759275_960_720.jpg",
                            Name = "Villa Sousse",
                            NbRoom = 3,
                            Rate = 5.2999999999999998,
                            Superficie = 300,
                            Updated_date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12344,
                            Created_date = new DateTime(2023, 3, 8, 10, 8, 20, 226, DateTimeKind.Local).AddTicks(7422),
                            Description = "Description villa Tunis",
                            ImageUrl = "https://cdn.pixabay.com/photo/2018/03/18/15/26/villa-3237114_960_720.jpg",
                            Name = "Villa Tunis",
                            NbRoom = 3,
                            Rate = 6.2000000000000002,
                            Superficie = 500,
                            Updated_date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12340,
                            Created_date = new DateTime(2023, 3, 8, 10, 8, 20, 226, DateTimeKind.Local).AddTicks(7425),
                            Description = "Description villa Monastir",
                            ImageUrl = "https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_960_720.jpg",
                            Name = "Villa Monastir",
                            NbRoom = 3,
                            Rate = 10.0,
                            Superficie = 800,
                            Updated_date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}