﻿// <auto-generated />
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JohandriPena.Migrations
{
    [DbContext(typeof(DeportistaDbContext))]
    [Migration("20231127212543_Deportista")]
    partial class Deportista
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entitys.Deportista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Deportistas");
                });

            modelBuilder.Entity("Domain.Entitys.PesoDeportista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<int>("DeportistaId")
                        .HasColumnType("int");

                    b.Property<short>("Intentos")
                        .HasColumnType("smallint");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeportistaId");

                    b.ToTable("PesoDeportistas");
                });

            modelBuilder.Entity("Domain.Entitys.PesoDeportista", b =>
                {
                    b.HasOne("Domain.Entitys.Deportista", "Deportista")
                        .WithMany("Pesos")
                        .HasForeignKey("DeportistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deportista");
                });

            modelBuilder.Entity("Domain.Entitys.Deportista", b =>
                {
                    b.Navigation("Pesos");
                });
#pragma warning restore 612, 618
        }
    }
}
