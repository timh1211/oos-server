using OOS.Models;
using OOS.Repositories.Common;
using OOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OOS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        OrderService orderService = new OrderService();

        [HttpPost]
        [Route("api/order/save")]
        //[AuthorizeFilterCustomer]
        public IHttpActionResult Save(dynamic entity)
        {
            try
            {
                Order order = new Order();
                order.Id = new Guid(entity.Id.ToString());
                order.CustomerId = new Guid(entity.CustomerId.ToString());
                //order.EmployeeId = new Guid(entity.EmployeeId.ToString());
                order.Total = float.Parse(entity.Total.ToString());
                return Ok(orderService.Save(order, Int32.Parse(entity.highestTime.ToString())));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/order/list")]
        [AuthorizeFilter]
        public IHttpActionResult List(PagedListRequest request)
        {
            try
            {
                return Ok(orderService.List(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/order/getlistproductinfo")]
        [AuthorizeFilter]
        public IHttpActionResult GetListOrderInfo(PagedListRequest request)
        {
            try
            {
                return Ok(orderService.List(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/order/get")]
        [AuthorizeFilter]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                return Ok(orderService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/order/all")]
        [AuthorizeFilter]
        public IHttpActionResult All()
        {
            try
            {
                return Ok(orderService.All());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/order/paid")]
        [AuthorizeFilter]
        public IHttpActionResult Paid(Guid id)
        {
            try
            {
                return Ok(orderService.Paid(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/order/unpaid")]
        [AuthorizeFilter]
        public IHttpActionResult Unpaid(Guid id)
        {
            try
            {
                return Ok(orderService.UnPaid(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/order/enable")]
        [AuthorizeFilter]
        public IHttpActionResult Enable(Guid id)
        {
            try
            {
                return Ok(orderService.Enable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/order/disable")]
        [AuthorizeFilter]
        public IHttpActionResult Disable(Guid id)
        {
            try
            {
                return Ok(orderService.Disable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/order/delete")]
        [AuthorizeFilter]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                orderService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
