﻿// <auto-generated />
using System;
using CRUDOperations_WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUDOperations_WebAPI.Migrations
{
    [DbContext(typeof(ContextClass))]
    [Migration("20230609054514_instial")]
    partial class instial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CRUDOperations_WebAPI.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DateOfAssociation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CRUDOperations_WebAPI.Models.Login", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("CRUDOperations_WebAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasMaxLength(10)
                        .HasColumnType("float");

                    b.Property<DateTime>("OrderedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("customerId")
                        .HasColumnType("int");

                    b.Property<int?>("productId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("customerId");

                    b.HasIndex("productId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CRUDOperations_WebAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Price")
                        .HasMaxLength(10)
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CRUDOperations_WebAPI.Models.Register", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Register");
                });

            modelBuilder.Entity("CRUDOperations_WebAPI.Models.User", b =>
                {
                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CRUDOperations_WebAPI.Models.Order", b =>
                {
                    b.HasOne("CRUDOperations_WebAPI.Models.Customer", "customer")
                        .WithMany("orders")
                        .HasForeignKey("customerId");

                    b.HasOne("CRUDOperations_WebAPI.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("productId");

                    b.Navigation("customer");

                    b.Navigation("product");
                });

            modelBuilder.Entity("CRUDOperations_WebAPI.Models.Customer", b =>
                {
                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
