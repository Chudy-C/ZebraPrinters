using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZebraPrinters.Entities;

namespace ZebraPrinters.Data
{
    public class ZebraPrinterDbContext :DbContext
    {
        public ZebraPrinterDbContext(DbContextOptions<ZebraPrinterDbContext> options) : base(options)
        {

        }

        public DbSet<Printer> Printers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Printer>().HasData(new Printer
            {
                Id = 1,
                Model = "Zebra ZD420",
                IpAddress = "192.168.2.69",
                MacAddress = "48:A4:93:8E:7C:9D",
                SerialNumber = "D2J21305227",
                Department = "DT"
            });
        }
    }
}
