﻿// <auto-generated />
using System;
using Api_Videojuego.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api_Videojuego.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241204024837_ManyToManyAdded")]
    partial class ManyToManyAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api_Videojuego.Data.Modelo.Desarrolladora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Desarrolladoras");
                });

            modelBuilder.Entity("Api_Videojuego.Data.Modelo.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Api_Videojuego.Data.Modelo.Juegos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripción")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaDeLanzamiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Juegos");
                });

            modelBuilder.Entity("Api_Videojuego.Data.Modelo.Juegos_Desarrolladora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDesarrolladora")
                        .HasColumnType("int");

                    b.Property<int>("IdJuegos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDesarrolladora");

                    b.HasIndex("IdJuegos");

                    b.ToTable("Juegos_Desarrolladoras");
                });

            modelBuilder.Entity("Api_Videojuego.Data.Modelo.Juegos", b =>
                {
                    b.HasOne("Api_Videojuego.Data.Modelo.Empresa", "Empresa")
                        .WithMany("Juegos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Api_Videojuego.Data.Modelo.Juegos_Desarrolladora", b =>
                {
                    b.HasOne("Api_Videojuego.Data.Modelo.Desarrolladora", "Desarrolladora")
                        .WithMany("Juegos_Desarrolladora")
                        .HasForeignKey("IdDesarrolladora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_Videojuego.Data.Modelo.Juegos", "Juegos")
                        .WithMany("Juegos_Desarrolladoras")
                        .HasForeignKey("IdJuegos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desarrolladora");

                    b.Navigation("Juegos");
                });

            modelBuilder.Entity("Api_Videojuego.Data.Modelo.Desarrolladora", b =>
                {
                    b.Navigation("Juegos_Desarrolladora");
                });

            modelBuilder.Entity("Api_Videojuego.Data.Modelo.Empresa", b =>
                {
                    b.Navigation("Juegos");
                });

            modelBuilder.Entity("Api_Videojuego.Data.Modelo.Juegos", b =>
                {
                    b.Navigation("Juegos_Desarrolladoras");
                });
#pragma warning restore 612, 618
        }
    }
}