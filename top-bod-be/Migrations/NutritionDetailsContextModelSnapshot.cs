﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using top_bod_be.Models;

#nullable disable

namespace top_bod_be.Migrations
{
    [DbContext(typeof(NutritionDetailsContext))]
    partial class NutritionDetailsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("top_bod_be.Models.NutritionDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Calories")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ServingInGrams")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalCarbsInGrams")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalFatInGrams")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalProteinInGrams")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("NutritionDetails");
                });
#pragma warning restore 612, 618
        }
    }
}