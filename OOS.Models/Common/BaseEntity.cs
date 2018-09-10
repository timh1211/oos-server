using SuperDev.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Models
{
    public abstract class BaseEntity: ICreator, IModifier
    {
        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public Nullable<DateTime> ModifiedDate { get; set; }

        public Guid? ModifiedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public Employee Creator { get; set; }

        [ForeignKey("ModifiedBy")]
        public Employee Modifier { get; set; }
    }
}
