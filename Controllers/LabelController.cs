using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;
using ZebraPrinters.Dtos;
using ZebraPrinters.Entities;
using ZebraPrinters.Services.Interfaces;

namespace ZebraPrinters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly IZebraService zebraService;
        private readonly IPrintService printService;

        public LabelController(IZebraService zebraService, IPrintService printService)
        {
            this.zebraService = zebraService;
            this.printService = printService;
        }

        [HttpPost]
        public async Task<ActionResult> PrintLabel(string weight, string product)
        {
            LabelZebraDto labelZebra = new LabelZebraDto();
            labelZebra.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            labelZebra.LabelString = $@"^XA
                                    ^CFA,50
                                    ^FO80,200^FD Waga PZ:^FS
                                    ^CFA,40
                                    ^FO80,300^FD {weight} ^FS
                                    ^CFA,50
                                    ^FO80,400^FD Data:^FS
                                    ^CFA,40
                                    ^FO80,500^FD {labelZebra.Timestamp}^FS
                                    ^CFA,50
                                    ^FO80,600^FD Produkt:^FS
                                    ^CFA,40
                                    ^FO80,700^FD {product} ^FS
                                    ^XZ";

            string filePath = null;
            Connection connection = null;

            try
            {
                Printer printer = new Printer();
                printer = await printService.GetPrinterByDepartment("DT");

                TcpConnection tcpCon = new TcpConnection(printer.IpAddress, 9100);
                connection = tcpCon;
                connection.Open();

                ZebraPrinter zebraPrinter = ZebraPrinterFactory.GetInstance(connection);

                filePath = zebraService.CreateDemoFile(zebraPrinter.PrinterControlLanguage, labelZebra.LabelString);
                zebraPrinter.SendFileContents(filePath);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                try
                {

                }
                catch (ConnectionException) { }

                if (filePath != null)
                {
                    try
                    {
                        new FileInfo(filePath).Delete();
                    }
                    catch (Exception) { }
                }
            }
        }
    }
}
