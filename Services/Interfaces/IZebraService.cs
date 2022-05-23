using Zebra.Sdk.Printer;

namespace ZebraPrinters.Services.Interfaces
{
    public interface IZebraService
    {
        public byte[] GetLabelBytes(PrinterLanguage printerLanguage, string labelString);
        public string CreateDemoFile(PrinterLanguage printerLanguage, string labelString);
    }
}
