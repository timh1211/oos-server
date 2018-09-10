using OOS.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Models
{
    public class Review : IStatus, IReview
    {
        public Guid Id { get; set; }

        public Guid? ProductId { get; set; }

        public int Star { get; set; }

        public string Content { get; set; }

        public string CustomerName { get; set; }

        public DateTime ReviewDate { get; set; }

        //0: Male, 1: Female, 2: Other
        public int Gender { get; set; }

        public string Email { get; set; }

        public int Like { get; set; }

        public bool Status { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }

    public class ReviewComplex
    {
        public Guid Id { get; set; }

        public Guid? ProductId { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public int Star { get; set; }

        public string Content { get; set; }

        public string CustomerName { get; set; }

        public DateTime ReviewDate { get; set; }

        //0: Male, 1: Female, 2: Other
        public int Gender { get; set; }

        public string Email { get; set; }

        public int Like { get; set; }

        public bool Status { get; set; }
    }
}
