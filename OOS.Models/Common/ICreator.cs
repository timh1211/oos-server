using OOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDev.Models
{
    public interface ICreator
    {
        DateTime CreatedDate { get; set; }

        Guid? CreatedBy { get; set; }

        Employee Creator { get; set; }
    }
}
