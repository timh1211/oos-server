using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Repositories.Common
{
    public class ProductRequest
    {
        public string whereClause { get; set; }

        public int quantity { get; set; }

        public string orderBy { get; set; }

        public string orderDirection { get; set; }

        public ProductRequest()
        {
            whereClause = "1>0";
            quantity = 4;
            orderBy = "Name";
            orderDirection = "DESC";
        }
    }
}
