using OOS.Models;
using OOS.Models.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Repositories
{
    public class ReviewRepository: BaseRepository<Review>
    {
        public IEnumerable GetByProduct(string productId)
        {
            Guid id = new Guid(productId);
            using (var context = new OOSContext())
            {
                return context.Reviews.Where(e => e.ProductId == id && e.Status == true).OrderByDescending(e => e.Like).Take(8).ToList();
            }
        }
    }
}
