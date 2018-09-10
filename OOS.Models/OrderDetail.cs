using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Models
{
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public Guid? ProductId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid? OrderId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Discount { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }

    public class OrderDetailComplex
    {
        public Guid? ProductId { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public Guid? OrderId { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public int Discount { get; set; }
    }
}
