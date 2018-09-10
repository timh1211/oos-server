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
    public class Customer : IStatus, ICode
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        [Index("CUS_Username", IsUnique = true)]
        [MaxLength(50)]
        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public string Address { get; set; }

        public bool Status { get; set; }
    }

    public class CustomerComplex
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //0: Male, 1: Female, 2: Other
        public int Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool Status { get; set; }
    }
}
