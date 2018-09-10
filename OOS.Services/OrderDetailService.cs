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
    public class OrderDetailService : BaseService<OrderDetail, OrderDetailRepository>
    {
        OrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        public IEnumerable GetOrderDetail(Guid OrderId)
        {
            return orderDetailRepository.GetOrderDetail(OrderId);
        }

        public IEnumerable Create(OrderDetail entity)
        {
            return orderDetailRepository.Create(entity);
        }

        public dynamic GetOrder(Guid OrderId)
        {
            var order = orderDetailRepository.GetOrder(OrderId);
            return new
            {
                OrderId = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                DeliveryTime = order.DeliveryTime,
                Total = order.Total,
                IsPayed = order.IsPayed,
                Status = order.Status,
                CFullName = order.Customer.LastName + " " + order.Customer.FirstName,
                CPhone = order.Customer.Phone,
                CEmail = order.Customer.Email,
                CAddress = order.Customer.Address
            };
        }
    }
}
