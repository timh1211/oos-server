using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Models
{
    public class SupplierDetail
    {
        [Key]
        [Column(Order = 1)]
        public Guid? ProductId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid? SupplierId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
