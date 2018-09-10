using OOS.Models;
using OOS.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Repositories
{
    public class ImageRepository : BaseRepository<Image>
    {
        public override Image Create(Image entity)
        {
            using (var context = new OOSContext())
            {
                //Guid id = new Guid(context.Products.OrderByDescending(e => e.CreatedDate).FirstOrDefault().Id.ToString());
                Guid id = Guid.NewGuid();
                entity.Id = id;
                entity.CreatedDate = DateTime.Now;
                context.Images.Add(entity);
                context.SaveChanges();
                return context.Images.Find(id);
            }
        }
    }
}
