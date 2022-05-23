using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZebraPrinters.Data;
using ZebraPrinters.Entities;
using ZebraPrinters.Repositories.Contracts;

namespace ZebraPrinters.Repositories
{
    public class PrinterRepository : IPrinterRepository
    {
        private readonly ZebraPrinterDbContext zebraPrinterDbContext;

        public PrinterRepository(ZebraPrinterDbContext zebraPrinterDbContext)
        {
            this.zebraPrinterDbContext = zebraPrinterDbContext;
        }

        public async Task<IEnumerable<Printer>> GetPrinters()
        {
            var printers = await this.zebraPrinterDbContext.Printers.ToListAsync();
            return printers;
        }

        public async Task<Printer> GetPrinter(int id)
        {
            var printer = await this.zebraPrinterDbContext.Printers.SingleOrDefaultAsync(x => x.Id == id);
            return printer;
        }

        public async Task<Printer> GetPrinterByDepartment(string department)
        {
            var printer = await this.zebraPrinterDbContext.Printers.SingleOrDefaultAsync(p => p.Department == department);
            return printer;
        }
    }
}
