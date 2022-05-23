using System.Collections.Generic;
using System.Threading.Tasks;
using ZebraPrinters.Entities;

namespace ZebraPrinters.Services.Interfaces
{
    public interface IPrintService
    {
        Task<IEnumerable<Printer>> GetPrinters();
        Task<Printer> GetPrinter(int id);
        Task<Printer> GetPrinterByDepartment(string department);
    }
}
