using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Models
{
    public class Image
    {
        public Guid Id { get; set; }

        public string name { get; set; }

        public string originName { get; set; }

        public string path { get; set; }

        public string extension { get; set; }

        public double size { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
