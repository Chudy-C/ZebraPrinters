using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZebraPrinters.Entities;
using ZebraPrinters.Repositories.Contracts;

namespace ZebraPrinters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrinterController : ControllerBase
    {
        private readonly IPrinterRepository printerRepository;

        public PrinterController(IPrinterRepository printerRepository)
        {
            this.printerRepository = printerRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Printer>>> GetPrinters()
        {
            try
            {
                var printers = await printerRepository.GetPrinters();
                if (printers == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(printers);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{department}")]
        public async Task<ActionResult<Printer>> GetPrinter(string department)
        {
            try
            {
                var printer = await printerRepository.GetPrinterByDepartment(department);
                if (printer == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(printer);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Printer>> GetPrinter(int id)
        {
            try
            {
                var printer = await printerRepository.GetPrinter(id);
                if (printer == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(printer);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
