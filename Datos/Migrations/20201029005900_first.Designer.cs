﻿// <auto-generated />
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(InventarioContext))]
    [Migration("20201029005900_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Asignatura", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Asignaturas");
                });

            modelBuilder.Entity("Entity.Detalle", b =>
                {
                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("CodigoInsumo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolicitudNumero")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Numero");

                    b.HasIndex("CodigoInsumo");

                    b.HasIndex("SolicitudNumero");

                    b.ToTable("Detalle");
                });

            modelBuilder.Entity("Entity.Insumo", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Insumos");
                });

            modelBuilder.Entity("Entity.Solicitud", b =>
                {
                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodigoAsignatura")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Numero");

                    b.HasIndex("CodigoAsignatura");

                    b.ToTable("Solicitudes");
                });

            modelBuilder.Entity("Entity.Detalle", b =>
                {
                    b.HasOne("Entity.Insumo", null)
                        .WithMany()
                        .HasForeignKey("CodigoInsumo");

                    b.HasOne("Entity.Solicitud", null)
                        .WithMany("Detalles")
                        .HasForeignKey("SolicitudNumero");
                });

            modelBuilder.Entity("Entity.Solicitud", b =>
                {
                    b.HasOne("Entity.Asignatura", null)
                        .WithMany()
                        .HasForeignKey("CodigoAsignatura");
                });
#pragma warning restore 612, 618
        }
    }
}
