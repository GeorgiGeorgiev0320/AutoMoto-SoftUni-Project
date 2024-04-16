﻿// <auto-generated />
using System;
using CarSelling.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarSelling.Data.Migrations
{
    [DbContext(typeof(CarSellingDbContext))]
    [Migration("20240414204846_SeedDb")]
    partial class SeedDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarSelling.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CarSelling.Data.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MakeId");

                    b.HasIndex("SellerId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2e4f8507-3c2d-4e8c-b4f0-e67b8ceb1865"),
                            BuyerId = new Guid("a3116cf0-1ed6-4c4c-2bc8-08dc5cb89100"),
                            CategoryId = 1,
                            Description = "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/df/BMW_5er-E60.jpg",
                            MakeId = 1,
                            Model = "5 series",
                            Price = 13000.00m,
                            SellerId = new Guid("a3573af0-47bd-495e-a90a-b5941782c088")
                        },
                        new
                        {
                            Id = new Guid("c29ea719-f494-4227-97a8-226f88e7604f"),
                            CategoryId = 1,
                            Description = "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!",
                            ImageUrl = "https://autobild.bg/wp-content/uploads/2018/01/Gebrauchte-Edel-Kombis-bis-10-000-Euro-1200x800-91458492c53dfda5.jpg",
                            MakeId = 2,
                            Model = "A6",
                            Price = 27000.00m,
                            SellerId = new Guid("a3573af0-47bd-495e-a90a-b5941782c088")
                        },
                        new
                        {
                            Id = new Guid("87854bda-a6e6-4631-bebe-7ffb138043a2"),
                            CategoryId = 3,
                            Description = "Spacious bus with really comfortable seat, good music and pretty stewardess for your long journeys!",
                            ImageUrl = "https://www.daimlertruck.com/fileadmin/press/6/5/D652811/cms.jpeg",
                            MakeId = 6,
                            Model = "Mercedes-benz bus",
                            Price = 123000.00m,
                            SellerId = new Guid("a3573af0-47bd-495e-a90a-b5941782c088")
                        });
                });

            modelBuilder.Entity("CarSelling.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cars And SUVs"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Motorbikes"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Semi Trucks and Buses"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Boats and Yachts"
                        });
                });

            modelBuilder.Entity("CarSelling.Data.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MakeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Makes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MakeName = "BMW"
                        },
                        new
                        {
                            Id = 2,
                            MakeName = "Audi"
                        },
                        new
                        {
                            Id = 3,
                            MakeName = "Toyota"
                        },
                        new
                        {
                            Id = 4,
                            MakeName = "Honda"
                        },
                        new
                        {
                            Id = 5,
                            MakeName = "Volkswagen"
                        },
                        new
                        {
                            Id = 6,
                            MakeName = "Mercedes-Benz"
                        },
                        new
                        {
                            Id = 7,
                            MakeName = "Nissan"
                        },
                        new
                        {
                            Id = 8,
                            MakeName = "Tesla"
                        },
                        new
                        {
                            Id = 9,
                            MakeName = "Ford"
                        },
                        new
                        {
                            Id = 10,
                            MakeName = "Kia"
                        },
                        new
                        {
                            Id = 11,
                            MakeName = "Hyundai"
                        },
                        new
                        {
                            Id = 12,
                            MakeName = "Subaru"
                        },
                        new
                        {
                            Id = 13,
                            MakeName = "Fiat"
                        },
                        new
                        {
                            Id = 14,
                            MakeName = "Volvo"
                        },
                        new
                        {
                            Id = 15,
                            MakeName = "Porsche"
                        },
                        new
                        {
                            Id = 16,
                            MakeName = "Jaguar"
                        },
                        new
                        {
                            Id = 17,
                            MakeName = "Land Rover"
                        },
                        new
                        {
                            Id = 18,
                            MakeName = "Mazda"
                        },
                        new
                        {
                            Id = 19,
                            MakeName = "Mitsubishi"
                        },
                        new
                        {
                            Id = 20,
                            MakeName = "Rolls-Royce"
                        },
                        new
                        {
                            Id = 21,
                            MakeName = "Bentley"
                        },
                        new
                        {
                            Id = 22,
                            MakeName = "Ferrari"
                        },
                        new
                        {
                            Id = 23,
                            MakeName = "Lamborghini"
                        },
                        new
                        {
                            Id = 24,
                            MakeName = "Koenigsegg"
                        },
                        new
                        {
                            Id = 25,
                            MakeName = "Chevrolet"
                        },
                        new
                        {
                            Id = 26,
                            MakeName = "Dodge"
                        },
                        new
                        {
                            Id = 27,
                            MakeName = "Cadillac"
                        },
                        new
                        {
                            Id = 28,
                            MakeName = "Lada"
                        },
                        new
                        {
                            Id = 29,
                            MakeName = "Mini Cooper"
                        },
                        new
                        {
                            Id = 30,
                            MakeName = "GMC"
                        },
                        new
                        {
                            Id = 31,
                            MakeName = "Bugatti"
                        });
                });

            modelBuilder.Entity("CarSelling.Data.Models.Seller", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarSelling.Data.Models.Car", b =>
                {
                    b.HasOne("CarSelling.Data.Models.ApplicationUser", "Buyer")
                        .WithMany("BoughtCars")
                        .HasForeignKey("BuyerId");

                    b.HasOne("CarSelling.Data.Models.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarSelling.Data.Models.Make", "Make")
                        .WithMany("Cars")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarSelling.Data.Models.Seller", "Seller")
                        .WithMany("CarsForSelling")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Category");

                    b.Navigation("Make");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("CarSelling.Data.Models.Seller", b =>
                {
                    b.HasOne("CarSelling.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CarSelling.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CarSelling.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarSelling.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("CarSelling.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarSelling.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("BoughtCars");
                });

            modelBuilder.Entity("CarSelling.Data.Models.Category", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarSelling.Data.Models.Make", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarSelling.Data.Models.Seller", b =>
                {
                    b.Navigation("CarsForSelling");
                });
#pragma warning restore 612, 618
        }
    }
}
