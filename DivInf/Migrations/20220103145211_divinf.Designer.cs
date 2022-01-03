﻿// <auto-generated />
using System;
using DivInf.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DivInf.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220103145211_divinf")]
    partial class divinf
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DivInf.Core.Models.ConsultaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Costo")
                        .HasColumnType("real");

                    b.Property<float>("CostoMaterial")
                        .HasColumnType("real");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("HistoriaClinica")
                        .HasColumnType("int");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("HistoriaClinica");

                    b.HasIndex("Matricula");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("DivInf.Core.Models.MedicoModel", b =>
                {
                    b.Property<int>("Matricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("Matricula");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("DivInf.Core.Models.PacienteModel", b =>
                {
                    b.Property<int>("HistoriaClinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("HistoriaClinica");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("DivInf.Core.Models.ConsultaModel", b =>
                {
                    b.HasOne("DivInf.Core.Models.PacienteModel", "Paciente")
                        .WithMany()
                        .HasForeignKey("HistoriaClinica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DivInf.Core.Models.MedicoModel", "Medico")
                        .WithMany()
                        .HasForeignKey("Matricula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
