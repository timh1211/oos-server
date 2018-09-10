using OOS.Models;
using OOS.Models.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>
    {
        public IEnumerable GetOrderDetail(Guid OrderId)
        {
            using (var context = new OOSContext())
            {
                return context.OrderDetails.Select(e => new
                {
                    OrderId = e.OrderId,
                    ProductId = e.ProductId,
                    PCode = e.Product.Code,
                    PName = e.Product.Name,
                    Quantity = e.Quantity,
                    Price = e.Price,
                    Discount = e.Discount,
                    FileName = e.Product.Image.name,
                    Path = e.Product.Image.path,
                    Extension = e.Product.Image.extension
                }).Where(e => e.OrderId == OrderId).ToList();
            }
        }

        public Order GetOrder(Guid OrderId)
        {
            using (var context = new OOSContext())
            {
                return context.Orders.Include("Customer").SingleOrDefault(e => e.Id == OrderId);
            }
        }

        public IEnumerable Create(OrderDetail entity)
        {
            using (var context = new OOSContext())
            {
                context.OrderDetails.Add(entity);
                context.SaveChanges();
                return context.OrderDetails.Where(e => e.OrderId == entity.OrderId).ToList();
            }
        }

        //public override CartDetail Update(CartDetail entity)
        //{
        //    using (var context = new OOSContext())
        //    {
        //        Guid id = new Guid(entity.GetType().GetProperty("Id").GetValue(entity, null).ToString());
        //        TEntity origin = context.Set<TEntity>().Find(id);
        //        Utility.CloneObject(origin, entity);
        //        context.SaveChanges();
        //        context.Entry(origin).Reload();
        //        return origin;
        //    }
        //}
    }
}
