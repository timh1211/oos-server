using OOS.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Models
{
    public class Order : IStatus
    {
        public Guid Id { get; set; }

        public Guid? CustomerId { get; set; }
        
        public DateTime OrderDate { get; set; }

        public DateTime DeliveryTime { get; set; }

        public float Total { get; set; }

        public bool IsPayed { get; set; }

        public bool Status { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        
    }

    public class OrderComplex
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid? EmployeeId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryTime { get; set; }

        public float Total { get; set; }

        public bool IsPayed { get; set; }

        public bool Status { get; set; }

        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeCode { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        //public List<OrderDetailComplex> ProductList { get; set; }
    }
}
