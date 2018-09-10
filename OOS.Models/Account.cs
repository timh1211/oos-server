using OOS.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Models
{
    public class Account : BaseEntity, IStatus
    {
        public Guid Id { get; set; }

        [Index("IX_Username", IsUnique = true)]
        [MaxLength(50)]
        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public Guid? EmployeeID { get; set; }

        public bool Status { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Owner { get; set; }
    }

    public class AccountComplex
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public Guid? EmployeeID { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Guid? ModifiedBy { get; set; }

        public string CreatorName { get; set; }

        public string ModifierName { get; set; }

        public string Owner { get; set; }
    }
}
