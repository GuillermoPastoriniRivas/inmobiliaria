﻿// <auto-generated />
using System;
using Inmobiliaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inmobiliaria.Migrations
{
    [DbContext(typeof(InmobiliariaContext))]
    [Migration("20190808192911_Operacion")]
    partial class Operacion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inmobiliaria.Models.Inmueble", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Baths");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaDePublicación");

                    b.Property<string>("Operacion");

                    b.Property<decimal>("Precio");

                    b.Property<int>("Rooms");

                    b.Property<int>("Superficie");

                    b.Property<string>("Ubicación");

                    b.HasKey("Id");

                    b.ToTable("Inmueble");
                });
#pragma warning restore 612, 618
        }
    }
}
