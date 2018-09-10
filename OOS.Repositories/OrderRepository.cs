using OOS.Models;
using OOS.Models.Common;
using OOS.Repositories.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public Order Create(Order order, int highestTime)
        {
            Guid id = Guid.NewGuid();
            order.Id = id;
            order.OrderDate = DateTime.Now;
            order.DeliveryTime = order.OrderDate.AddDays(highestTime);
            order.IsPayed = false;
            order.Status = true;
            using (var context = new OOSContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return context.Orders.Find(id);
            }
        }

        public override PagedListResult List(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize)
        {
            using (var context = new OOSContext())
            {
                if (orderBy == "CreatedDate") orderBy = "OrderDate";
                var query = context.Orders.Select(e => new OrderComplex
                {
                    Id = e.Id,
                    CustomerName = e.Customer.FirstName + e.Customer.LastName,
                    CustomerCode = e.Customer.Code,
                    Status = e.Status,
                    OrderDate = e.OrderDate,
                    DeliveryTime = e.DeliveryTime,
                    Total = e.Total,
                    IsPayed = e.IsPayed,
                    Address = e.Customer.Address,
                    Phone = e.Customer.Phone,
                    Email = e.Customer.Email
                }).Where(whereClause);
                var entities = query.OrderBy(string.Format("{0} {1}", orderBy.Trim(), orderDirection.Trim()))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
                return new PagedListResult(entities, query.Count());
            }
        }

        public Order UnPaid(Guid id)
        {
            using (var context = new OOSContext())
            {
                Order entity = context.Orders.Find(id);
                entity.IsPayed = false;
                context.SaveChanges();
                context.Entry(entity).Reload();
                return entity;
            }
        }

        public Order Paid(Guid id)
        {
            using (var context = new OOSContext())
            {
                Order entity = context.Orders.Find(id);
                entity.IsPayed = true;
                context.SaveChanges();
                context.Entry(entity).Reload();
                return entity;
            }
        }
    }
}
