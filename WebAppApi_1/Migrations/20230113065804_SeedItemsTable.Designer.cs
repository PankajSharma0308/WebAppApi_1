﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppApi_1.Data;

#nullable disable

namespace WebAppApi1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230113065804_SeedItemsTable")]
    partial class SeedItemsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAppApi_1.Models.ItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "hey this is automatic.",
                            Name = "Pankaj"
                        },
                        new
                        {
                            Id = 2,
                            Description = "hey this is automatic22.",
                            Name = "Sharma"
                        },
                        new
                        {
                            Id = 3,
                            Description = "hey this is automatic333.",
                            Name = "Hey"
                        },
                        new
                        {
                            Id = 4,
                            Description = "hey this is automatic4444.",
                            Name = "This"
                        },
                        new
                        {
                            Id = 5,
                            Description = "hey this is automatic55555.",
                            Name = "Database"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
