﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyNhaHangServer;

namespace QuanLyNhaHangServer.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20190107064111_UpdateOrderWithTables")]
    partial class UpdateOrderWithTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuanLyNhaHangServer.Models.Food", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<long>("FoodCategoryId");

                    b.Property<int?>("ImageId");

                    b.Property<decimal>("Price");

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.HasIndex("FoodCategoryId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.FoodCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FoodCategories");
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.FoodWithOrder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<long>("FoodId");

                    b.Property<long>("OrderId");

                    b.Property<int>("Quantities");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("OrderId");

                    b.ToTable("FoodWithOrders");
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.Image", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Binary");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Name");

                    b.Property<long>("UnitId");

                    b.Property<int?>("imageId");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.IngredientWithFood", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<long>("FoodId");

                    b.Property<long>("IngredientId");

                    b.Property<float>("Quantities");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("IngredientId");

                    b.ToTable("IngredientWithFoods");
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<decimal>("MoneyReceive");

                    b.Property<decimal>("MoneyReturn");

                    b.Property<string>("Note");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.Table", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<long?>("OrderId");

                    b.Property<int>("TableId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.Unit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Password");

                    b.Property<int>("RoleFood");

                    b.Property<int>("RoleIngredient");

                    b.Property<int>("RoleOrder");

                    b.Property<int>("RolePrepareFood");

                    b.Property<int>("RoleTable");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.Food", b =>
                {
                    b.HasOne("QuanLyNhaHangServer.Models.FoodCategory", "FoodCategory")
                        .WithMany()
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.FoodWithOrder", b =>
                {
                    b.HasOne("QuanLyNhaHangServer.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuanLyNhaHangServer.Models.Order", "Order")
                        .WithMany("FoodWithOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.Ingredient", b =>
                {
                    b.HasOne("QuanLyNhaHangServer.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.IngredientWithFood", b =>
                {
                    b.HasOne("QuanLyNhaHangServer.Models.Food", "Food")
                        .WithMany("IngredientWithFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuanLyNhaHangServer.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuanLyNhaHangServer.Models.Table", b =>
                {
                    b.HasOne("QuanLyNhaHangServer.Models.Order")
                        .WithMany("Tables")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
