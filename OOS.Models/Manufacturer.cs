using OOS.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Models
{
    public class Manufacturer: ICode
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }

    public class ManufacturerComplex
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
