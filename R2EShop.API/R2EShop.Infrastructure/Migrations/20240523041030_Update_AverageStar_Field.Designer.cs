﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using R2EShop.Infrastructure.Data;

#nullable disable

namespace R2EShop.Infrastructure.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240523041030_Update_AverageStar_Field")]
    partial class Update_AverageStar_Field
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryPhoneCase", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryPhoneCase");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.CaseColor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CaseColorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CaseColor");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.CaseType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AverageStar")
                        .HasColumnType("float");

                    b.Property<string>("CaseTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Protection")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CaseType");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ParentDeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParentDeviceId");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PhoneCaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhoneCaseId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ItemPrice")
                        .HasColumnType("real");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PhoneCaseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PhoneCaseId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.PhoneCase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CaseColorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CaseTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfBuyers")
                        .HasColumnType("int");

                    b.Property<string>("PhoneCaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PhoneCasePrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CaseColorId");

                    b.HasIndex("CaseTypeId");

                    b.HasIndex("DeviceId");

                    b.ToTable("PhoneCase");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CaseTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("OrderVerified")
                        .HasColumnType("bit");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CaseTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CategoryPhoneCase", b =>
                {
                    b.HasOne("R2EShop.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("R2EShop.Domain.Entities.PhoneCase", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Category", b =>
                {
                    b.HasOne("R2EShop.Domain.Entities.Category", null)
                        .WithMany("Categories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Device", b =>
                {
                    b.HasOne("R2EShop.Domain.Entities.Device", null)
                        .WithMany("Devices")
                        .HasForeignKey("ParentDeviceId");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Image", b =>
                {
                    b.HasOne("R2EShop.Domain.Entities.PhoneCase", null)
                        .WithMany("Images")
                        .HasForeignKey("PhoneCaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Order", b =>
                {
                    b.HasOne("R2EShop.Domain.Entities.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("R2EShop.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.HasOne("R2EShop.Domain.Entities.PhoneCase", "PhoneCase")
                        .WithMany()
                        .HasForeignKey("PhoneCaseId");

                    b.Navigation("Order");

                    b.Navigation("PhoneCase");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.PhoneCase", b =>
                {
                    b.HasOne("R2EShop.Domain.Entities.CaseColor", "CaseColor")
                        .WithMany()
                        .HasForeignKey("CaseColorId");

                    b.HasOne("R2EShop.Domain.Entities.CaseType", "CaseType")
                        .WithMany("PhoneCases")
                        .HasForeignKey("CaseTypeId");

                    b.HasOne("R2EShop.Domain.Entities.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId");

                    b.Navigation("CaseColor");

                    b.Navigation("CaseType");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Rating", b =>
                {
                    b.HasOne("R2EShop.Domain.Entities.CaseType", "CaseType")
                        .WithMany("Ratings")
                        .HasForeignKey("CaseTypeId");

                    b.HasOne("R2EShop.Domain.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId");

                    b.Navigation("CaseType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.User", b =>
                {
                    b.OwnsOne("R2EShop.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("AddressCity");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("AddressState");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("AddressStreet");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.CaseType", b =>
                {
                    b.Navigation("PhoneCases");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Category", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Device", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.PhoneCase", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("R2EShop.Domain.Entities.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
