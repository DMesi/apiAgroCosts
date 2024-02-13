﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StorageServiceLibrary.Model;

#nullable disable

namespace StorageServiceLibrary.Migrations
{
    [DbContext(typeof(AppDB))]
    partial class AppDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StorageServiceLibrary.Model.Field", b =>
                {
                    b.Property<int>("Id_Field")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Field"));

                    b.Property<string>("Field_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Ha")
                        .HasColumnType("float");

                    b.Property<double>("J")
                        .HasColumnType("float");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Field");

                    b.ToTable("Fields");

                    b.HasData(
                        new
                        {
                            Id_Field = 1,
                            Field_number = "2494/20",
                            Ha = 2.0,
                            J = 3.5,
                            Link = "",
                            Name = "Kuvajt",
                            Note = ""
                        },
                        new
                        {
                            Id_Field = 2,
                            Field_number = "7739",
                            Ha = 1.5,
                            J = 2.25,
                            Link = "https://a3.geosrbija.rs/share/0dfacc67fca1",
                            Name = "Kanal",
                            Note = ""
                        });
                });

            modelBuilder.Entity("StorageServiceLibrary.Model.Plan", b =>
                {
                    b.Property<int>("Id_plan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_plan"));

                    b.Property<int>("FieldRefId")
                        .HasColumnType("int");

                    b.Property<double>("Ha")
                        .HasColumnType("float");

                    b.Property<double>("J")
                        .HasColumnType("float");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeedRefId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("Id_plan");

                    b.HasIndex("FieldRefId");

                    b.HasIndex("SeedRefId");

                    b.ToTable("Plans");

                    b.HasData(
                        new
                        {
                            Id_plan = 1,
                            FieldRefId = 1,
                            Ha = 1.5,
                            J = 2.25,
                            Note = "",
                            SeedRefId = 2,
                            Year = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id_plan = 2,
                            FieldRefId = 1,
                            Ha = 1.5,
                            J = 2.25,
                            Note = "",
                            SeedRefId = 1,
                            Year = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id_plan = 3,
                            FieldRefId = 2,
                            Ha = 1.5,
                            J = 2.25,
                            Note = "",
                            SeedRefId = 1,
                            Year = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("StorageServiceLibrary.Model.Seed", b =>
                {
                    b.Property<int>("Id_Seed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Seed"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Seed");

                    b.ToTable("Seeds");

                    b.HasData(
                        new
                        {
                            Id_Seed = 1,
                            Name = "Korn",
                            Note = ""
                        },
                        new
                        {
                            Id_Seed = 2,
                            Name = "Soybean",
                            Note = ""
                        },
                        new
                        {
                            Id_Seed = 3,
                            Name = "Wheat",
                            Note = ""
                        });
                });

            modelBuilder.Entity("StorageServiceLibrary.Model.Plan", b =>
                {
                    b.HasOne("StorageServiceLibrary.Model.Field", "Field")
                        .WithMany()
                        .HasForeignKey("FieldRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StorageServiceLibrary.Model.Seed", "Seed")
                        .WithMany()
                        .HasForeignKey("SeedRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("Seed");
                });
#pragma warning restore 612, 618
        }
    }
}
