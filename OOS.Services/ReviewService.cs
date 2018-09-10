using OOS.Models;
using OOS.Repositories;
using OOS.Services.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Services
{
    public class ReviewService: BaseService<Review, ReviewRepository>
    {
        ReviewRepository reviewRepository = new ReviewRepository();
        public IEnumerable GetByProduct(string productId)
        {
            return reviewRepository.GetByProduct(productId);
        }
    }
}
