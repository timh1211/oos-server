using OOS.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Models
{
    public class Product : BaseEntity, IStatus, ICode
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Discount { get; set; }

        public int DeliveryTime { get; set; } //Days default = 3

        public bool isLatest { get; set; }

        public int View { get; set; }

        public string Special { get; set; } //Discount, Limitted.

        public Guid? ManufacturerID { get; set; }

        public Guid? CategoryID { get; set; }

        public bool Status { get; set; }

        [ForeignKey("ManufacturerID")]
        public Manufacturer Manufacturer { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        [ForeignKey("Id")]
        public Image Image { get; set; }

        [ForeignKey("Id")]
        public DigitalInformation DigitalInformation { get; set; }
    }

    public class ProductComplex
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Discount { get; set; }

        public int DeliveryTime { get; set; }

        public bool isLatest { get; set; }

        public int View { get; set; }

        public string Special { get; set; }

        public Guid? ManufacturerID { get; set; }

        public Guid? CategoryID { get; set; }

        public bool Status { get; set; }

        public string ManufacturerCode { get; set; }

        public string ManufacturerName { get; set; }

        public string CategoryCode { get; set; }

        public string CategoryName { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Guid? ModifiedBy { get; set; }

        public string CreatorName { get; set; }

        public string ModifierName { get; set; }
    }

    public class ProductDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Discount { get; set; }

        public int DeliveryTime { get; set; }

        public bool isLatest { get; set; }

        public string Special { get; set; }

        public Guid? ManufacturerID { get; set; }

        public Guid? CategoryID { get; set; }

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
}
