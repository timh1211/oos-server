using OOS.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Models
{
    public class Employee : IStatus, ICode
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //0: Male, 1: Female, 2: Other
        public int Gender { get; set; }

        public string Avatar { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool Status { get; set; }
    }

    public class EmployeeComplex
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //0: Male, 1: Female, 2: Other
        public int Gender { get; set; }

        public string Avatar { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool Status { get; set; }
    }
}
