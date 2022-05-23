﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZebraPrinters.Data;

namespace ZebraPrinters.Migrations
{
    [DbContext(typeof(ZebraPrinterDbContext))]
    partial class ZebraPrinterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("ZebraPrinters.Entities.Printer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .HasColumnType("longtext");

                    b.Property<string>("IpAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("MacAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("Model")
                        .HasColumnType("longtext");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Printers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = "DT",
                            IpAddress = "192.168.2.69",
                            MacAddress = "48:A4:93:8E:7C:9D",
                            Model = "Zebra ZD420",
                            SerialNumber = "D2J21305227"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
