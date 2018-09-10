using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Models
{
    public class DigitalInformation
    {
        public Guid Id { get; set; }

        public string Monitor { get; set; }

        public string OperatingSystem { get; set; }

        public string CPU { get; set; }

        //Unit: GB
        public int RAM { get; set; }

        //Unit: GB
        public int InternalMemory { get; set; }

        public string HardDrive { get; set; }

        public string GraphicCard { get; set; }

        public string BehindCamera { get; set; }

        public string FrontCamera { get; set; }

        public string NetworkConnection { get; set; }

        public string Connector { get; set; }

        public string Weight { get; set; }

        public string Design { get; set; }

        public string Size { get; set; }

        public string MemoryCard { get; set; }

        public string SIMCard { get; set; }

        public string Conversation { get; set; }

        public string BatteryCapacity { get; set; }
    }

    public class DigitalInformationComplex
    {
        public Guid? ProductId { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string Monitor { get; set; }

        public string OperatingSystem { get; set; }

        public string CPU { get; set; }

        //Unit: GB
        public int RAM { get; set; }

        //Unit: GB
        public int InternalMemory { get; set; }

        public string HardDrive { get; set; }

        public string GraphicCard { get; set; }

        public string BehindCamera { get; set; }

        public string FrontCamera { get; set; }

        public string NetworkConnection { get; set; }

        public string Connector { get; set; }

        public string Weight { get; set; }

        public string Special { get; set; }

        public string Design { get; set; }

        public string Size { get; set; }

        public string MemoryCard { get; set; }

        public string SIMCard { get; set; }

        public string Conversation { get; set; }

        public string BatteryCapacity { get; set; }
    }
}
