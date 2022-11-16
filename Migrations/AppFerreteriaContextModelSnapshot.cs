﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppFerreteria.Migrations
{
    [DbContext(typeof(AppFerreteriaContext))]
    partial class AppFerreteriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppFerreteria.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteID"), 1L, 1);

                    b.Property<string>("ClienteApellido")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ClienteDNI")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("ClienteName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ClientePhone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClienteID");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("AppFerreteria.Models.Motosierra", b =>
                {
                    b.Property<int>("MotosierraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MotosierraID"), 1L, 1);

                    b.Property<string>("CodigoAlfanumericoMotosierra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Codigodefabrica")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<bool>("EstaAlquilada")
                        .HasColumnType("bit");

                    b.Property<byte[]>("MotosierraImg")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PrecioMotosierra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("MotosierraID");

                    b.ToTable("Motosierra");
                });

            modelBuilder.Entity("AppFerreteria.Models.Rental", b =>
                {
                    b.Property<int>("RentalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalID"), 1L, 1);

                    b.Property<string>("ClienteApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<string>("ClienteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoAlfanumericoMotosierra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MotosierraID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RentalID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("MotosierraID");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("AppFerreteria.Models.Return", b =>
                {
                    b.Property<int>("ReturnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReturnID"), 1L, 1);

                    b.Property<string>("ClienteApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<string>("ClienteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoAlfanumericoMotosierra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MotosierraID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ReturnID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("MotosierraID");

                    b.ToTable("Return");
                });

            modelBuilder.Entity("AppFerreteria.Models.Rental", b =>
                {
                    b.HasOne("AppFerreteria.Models.Cliente", "Cliente")
                        .WithMany("Rental")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppFerreteria.Models.Motosierra", "Motosierra")
                        .WithMany()
                        .HasForeignKey("MotosierraID");

                    b.Navigation("Cliente");

                    b.Navigation("Motosierra");
                });

            modelBuilder.Entity("AppFerreteria.Models.Return", b =>
                {
                    b.HasOne("AppFerreteria.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppFerreteria.Models.Motosierra", "Motosierra")
                        .WithMany()
                        .HasForeignKey("MotosierraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Motosierra");
                });

            modelBuilder.Entity("AppFerreteria.Models.Cliente", b =>
                {
                    b.Navigation("Rental");
                });
#pragma warning restore 612, 618
        }
    }
}
