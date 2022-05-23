using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZebraPrinters.Data;
using ZebraPrinters.Entities;

namespace ZebraPrinters.Repositories.Contracts
{
    public interface IPrinterRepository
    {
        Task<IEnumerable<Printer>> GetPrinters();
        Task<Printer> GetPrinter(int id);
        Task<Printer> GetPrinterByDepartment(string department);

    }
}
