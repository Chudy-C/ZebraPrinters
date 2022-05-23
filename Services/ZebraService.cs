using System.IO;
using System.Text;
using Zebra.Sdk.Printer;
using ZebraPrinters.Services.Interfaces;

namespace ZebraPrinters.Services
{
    public class ZebraService : IZebraService
    {
        public byte[] GetLabelBytes(PrinterLanguage printerLanguage, string labelString)
        {
            if (printerLanguage == PrinterLanguage.ZPL)
            {
                return Encoding.UTF8.GetBytes(labelString);
            }
            else
            {
                throw new ZebraPrinterLanguageUnknownException();
            }
        }

        public string CreateDemoFile(PrinterLanguage printerLanguage, string labelString)
        {
            string tempFilePath = Path.Combine(Path.GetTempPath(), "TEST_ZEBRA.LBL");

            using (FileStream tempFileStream = new FileStream(tempFilePath, FileMode.Create))
            {
                byte[] labelBytes = GetLabelBytes(printerLanguage, labelString);
                tempFileStream.Write(labelBytes, 0, labelBytes.Length);
                tempFileStream.Flush();
            }

            return new FileInfo(tempFilePath).FullName;
        }
    }
}
