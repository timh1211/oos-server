using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Repositories.Common
{
    public class PagedListResult
    {
        public int Total { get; set; }

        public IEnumerable Entities { get; set; }

        public PagedListResult(IEnumerable Entities, int Total)
        {
            this.Total = Total;
            this.Entities = Entities;
        }
    }
}
