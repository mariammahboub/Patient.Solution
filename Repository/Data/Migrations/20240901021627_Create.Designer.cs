﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Data;

#nullable disable

namespace Repository.Data.Migrations
{
    [DbContext(typeof(MySQLDbContext))]
    [Migration("20240901021627_Create")]
    partial class Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MRN")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MotherName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TransferFrom")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Core.Models.PatientReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CheckoutDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("RoomId");

                    b.ToTable("PatientReservations");
                });

            modelBuilder.Entity("Core.Models.PatientTherapy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CompletedSessions")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfSessions")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientTherapies");
                });

            modelBuilder.Entity("Core.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RoomFloor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Core.Models.PatientReservation", b =>
                {
                    b.HasOne("Core.Models.Patient", "Patient")
                        .WithMany("PatientReservations")
                        .HasForeignKey("PatientId");

                    b.HasOne("Core.Models.Room", "Room")
                        .WithMany("PatientReservations")
                        .HasForeignKey("RoomId");

                    b.Navigation("Patient");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Core.Models.PatientTherapy", b =>
                {
                    b.HasOne("Core.Models.Patient", "Patient")
                        .WithMany("PatientTherapies")
                        .HasForeignKey("PatientId");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Models.Patient", b =>
                {
                    b.Navigation("PatientReservations");

                    b.Navigation("PatientTherapies");
                });

            modelBuilder.Entity("Core.Models.Room", b =>
                {
                    b.Navigation("PatientReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
