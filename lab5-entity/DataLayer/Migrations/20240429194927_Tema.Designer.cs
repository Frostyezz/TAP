﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240429194927_Tema")]
    partial class Tema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Models.Instrument", b =>
                {
                    b.Property<Guid>("InstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InstrumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrumentId");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("DataLayer.Models.Laptop", b =>
                {
                    b.Property<Guid>("LaptopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SpecificationsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LaptopId");

                    b.ToTable("Laptops");
                });

            modelBuilder.Entity("DataLayer.Models.Musician", b =>
                {
                    b.Property<Guid>("MusicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MusicianName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MusicianId");

                    b.ToTable("Musicians");
                });

            modelBuilder.Entity("DataLayer.Models.Passenger", b =>
                {
                    b.Property<Guid>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PassengerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PassengerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("DataLayer.Models.Specifications", b =>
                {
                    b.Property<Guid>("SpecificationsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gpu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LaptopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Memory")
                        .HasColumnType("int");

                    b.HasKey("SpecificationsId");

                    b.HasIndex("LaptopId")
                        .IsUnique();

                    b.ToTable("LaptopSpecifications");
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataLayer.Models.UserType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("DataLayer.Models.Vehicle", b =>
                {
                    b.Property<Guid>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("InstrumentMusician", b =>
                {
                    b.Property<Guid>("InstrumentsInstrumentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MusiciansMusicianId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InstrumentsInstrumentId", "MusiciansMusicianId");

                    b.HasIndex("MusiciansMusicianId");

                    b.ToTable("MusicianInstrument", (string)null);
                });

            modelBuilder.Entity("DataLayer.Models.Passenger", b =>
                {
                    b.HasOne("DataLayer.Models.Vehicle", "Vehicle")
                        .WithMany("Passengers")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DataLayer.Models.Specifications", b =>
                {
                    b.HasOne("DataLayer.Models.Laptop", "Laptop")
                        .WithOne("Specifications")
                        .HasForeignKey("DataLayer.Models.Specifications", "LaptopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop");
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.HasOne("DataLayer.Models.UserType", "Type")
                        .WithMany("Users")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("InstrumentMusician", b =>
                {
                    b.HasOne("DataLayer.Models.Instrument", null)
                        .WithMany()
                        .HasForeignKey("InstrumentsInstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Musician", null)
                        .WithMany()
                        .HasForeignKey("MusiciansMusicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Models.Laptop", b =>
                {
                    b.Navigation("Specifications")
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DataLayer.Models.Vehicle", b =>
                {
                    b.Navigation("Passengers");
                });
#pragma warning restore 612, 618
        }
    }
}
