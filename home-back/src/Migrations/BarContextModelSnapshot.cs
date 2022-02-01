﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using src;

#nullable disable

namespace src.Migrations
{
    [DbContext(typeof(BarContext))]
    partial class BarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("src.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BrandId"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("src.Models.Cocktail", b =>
                {
                    b.Property<int>("CocktailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CocktailId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Strength")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CocktailId");

                    b.ToTable("Cocktails");
                });

            modelBuilder.Entity("src.Models.Glass", b =>
                {
                    b.Property<int>("GlassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GlassId"));

                    b.HasKey("GlassId");

                    b.ToTable("Glasses");
                });

            modelBuilder.Entity("src.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IngredientId"));

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IngredientId");

                    b.HasIndex("BrandId");

                    b.ToTable("Ingredients");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Ingredient");
                });

            modelBuilder.Entity("src.Models.Instruction", b =>
                {
                    b.Property<int>("InstructionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InstructionId"));

                    b.Property<int?>("CocktailId")
                        .HasColumnType("integer");

                    b.HasKey("InstructionId");

                    b.HasIndex("CocktailId");

                    b.ToTable("Instructions");
                });

            modelBuilder.Entity("src.Models.InstructionStep", b =>
                {
                    b.Property<int>("InstructionStepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InstructionStepId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("InstructionId")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("InstructionStepId");

                    b.HasIndex("InstructionId");

                    b.ToTable("InstructionSteps");
                });

            modelBuilder.Entity("src.Models.Measurement", b =>
                {
                    b.Property<int>("MeasurementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MeasurementId"));

                    b.Property<int>("TypeMeasurementTypeId")
                        .HasColumnType("integer");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("MeasurementId");

                    b.HasIndex("TypeMeasurementTypeId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("src.Models.MeasurementType", b =>
                {
                    b.Property<int>("MeasurementTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MeasurementTypeId"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MeasurementTypeId");

                    b.ToTable("MeasurementTypes");
                });

            modelBuilder.Entity("src.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeIngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RecipeIngredientId"));

                    b.Property<int?>("CocktailId")
                        .HasColumnType("integer");

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<int>("MeasurementId")
                        .HasColumnType("integer");

                    b.HasKey("RecipeIngredientId");

                    b.HasIndex("CocktailId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("MeasurementId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("src.Models.Fruit", b =>
                {
                    b.HasBaseType("src.Models.Ingredient");

                    b.HasDiscriminator().HasValue("Fruit");
                });

            modelBuilder.Entity("src.Models.Garnish", b =>
                {
                    b.HasBaseType("src.Models.Ingredient");

                    b.HasDiscriminator().HasValue("Garnish");
                });

            modelBuilder.Entity("src.Models.Liqueur", b =>
                {
                    b.HasBaseType("src.Models.Ingredient");

                    b.Property<double>("Percentage")
                        .HasColumnType("double precision");

                    b.HasDiscriminator().HasValue("Liqueur");
                });

            modelBuilder.Entity("src.Models.Liquor", b =>
                {
                    b.HasBaseType("src.Models.Ingredient");

                    b.Property<double>("Percentage")
                        .HasColumnType("double precision")
                        .HasColumnName("Liquor_Percentage");

                    b.HasDiscriminator().HasValue("Liquor");
                });

            modelBuilder.Entity("src.Models.Mixer", b =>
                {
                    b.HasBaseType("src.Models.Ingredient");

                    b.HasDiscriminator().HasValue("Mixer");
                });

            modelBuilder.Entity("src.Models.Ingredient", b =>
                {
                    b.HasOne("src.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("src.Models.Instruction", b =>
                {
                    b.HasOne("src.Models.Cocktail", null)
                        .WithMany("Instructions")
                        .HasForeignKey("CocktailId");
                });

            modelBuilder.Entity("src.Models.InstructionStep", b =>
                {
                    b.HasOne("src.Models.Instruction", null)
                        .WithMany("steps")
                        .HasForeignKey("InstructionId");
                });

            modelBuilder.Entity("src.Models.Measurement", b =>
                {
                    b.HasOne("src.Models.MeasurementType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeMeasurementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("src.Models.RecipeIngredient", b =>
                {
                    b.HasOne("src.Models.Cocktail", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("CocktailId");

                    b.HasOne("src.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("src.Models.Measurement", "Measurement")
                        .WithMany()
                        .HasForeignKey("MeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Measurement");
                });

            modelBuilder.Entity("src.Models.Cocktail", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Instructions");
                });

            modelBuilder.Entity("src.Models.Instruction", b =>
                {
                    b.Navigation("steps");
                });
#pragma warning restore 612, 618
        }
    }
}
