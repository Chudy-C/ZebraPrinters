using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZebraPrinters.Entities
{
    public class Printer
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Model { get; set; }
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }
        public string SerialNumber { get; set; }
        public string Location { get; set; }
    }
}
