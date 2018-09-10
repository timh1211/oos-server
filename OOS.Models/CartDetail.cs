using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Models
{
    public class CartDetail
    {
        [Key]
        [Column(Order = 1)]
        public Guid? CustomerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid? ProductId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Discount { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
