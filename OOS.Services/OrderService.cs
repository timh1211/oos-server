using OOS.Models;
using OOS.Repositories;
using OOS.Repositories.Common;
using OOS.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Services
{
    public class OrderService : BaseService<Order, OrderRepository>
    {
        OrderRepository orderRepository = new OrderRepository();
        public Order Save(Order entity, int highestTime)
        {
            Guid id = new Guid(entity.Id.ToString());
            if (id == Guid.Empty)
            {
                return orderRepository.Create(entity, highestTime);
            }
            else
            {
                return repository.Update(entity);
            }
        }

        public override PagedListResult List(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize)
        {
            return orderRepository.List(whereClause, orderBy, orderDirection, pageNumber, pageSize);
        }

        public override PagedListResult List(PagedListRequest request)
        {
            return this.List(request.whereClause, request.orderBy, request.orderDirection, request.pageNumber, request.pageSize);
        }

        public Order UnPaid(Guid id)
        {
            return orderRepository.UnPaid(id);
        }

        public Order Paid(Guid id)
        {
            return orderRepository.Paid(id);
        }
    }
}
