﻿// <auto-generated />
using System;
using AppDevGCD1104.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppDevGCD1104.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240328024937_AddCagoryDb")]
    partial class AddCagoryDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppDevGCD1104.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "vsfsd",
                            CategoryId = 1,
                            Description = "So funny",
                            ImgUrl = "",
                            Price = 0.0,
                            Title = "sdfsf"
                        },
                        new
                        {
                            Id = 2,
                            Author = "sfsv",
                            CategoryId = 2,
                            Description = "So romantic",
                            ImgUrl = "",
                            Price = 0.0,
                            Title = "Rvsvsoman"
                        },
                        new
                        {
                            Id = 3,
                            Author = "vsvsv",
                            CategoryId = 3,
                            Description = "So scary",
                            ImgUrl = "",
                            Price = 0.0,
                            Title = "Horsvsvsror"
                        },
                        new
                        {
                            Id = 4,
                            Author = "vsfsdf",
                            CategoryId = 4,
                            Description = "So Boring",
                            ImgUrl = "",
                            Price = 0.0,
                            Title = "Scivsssence"
                        });
                });

            modelBuilder.Entity("AppDevGCD1104.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "So funny",
                            DisplayOrder = 0,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 2,
                            Description = "So romantic",
                            DisplayOrder = 0,
                            Name = "Roman"
                        },
                        new
                        {
                            Id = 3,
                            Description = "So scary",
                            DisplayOrder = 0,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 4,
                            Description = "So Boring",
                            DisplayOrder = 0,
                            Name = "Science"
                        });
                });

            modelBuilder.Entity("AppDevGCD1104.Models.Book", b =>
                {
                    b.HasOne("AppDevGCD1104.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
