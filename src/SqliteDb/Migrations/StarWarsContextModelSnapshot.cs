﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SqliteDb;

#nullable disable

namespace SqliteDb.Migrations
{
    [DbContext(typeof(StarWarsContext))]
    partial class StarWarsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Shared.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BirthYear")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "birth_year");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "created");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "edited");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "eye_color");

                    b.PrimitiveCollection<string>("Films")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "films");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "gender");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "hair_color");

                    b.Property<uint>("Height")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "height");

                    b.Property<string>("Homeworld")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "homeworld");

                    b.Property<uint>("Mass")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "mass");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<string>("SkinColor")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "skin_color");

                    b.PrimitiveCollection<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "species");

                    b.PrimitiveCollection<string>("Starships")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "starships");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "url");

                    b.PrimitiveCollection<string>("Vehicles")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "vehicles");

                    b.HasKey("Id");

                    b.ToTable("People");
                });
#pragma warning restore 612, 618
        }
    }
}
