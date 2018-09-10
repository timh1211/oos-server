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
    public class OrderDetailController : ApiController
    {
        OrderDetailService orderDetailService = new OrderDetailService();

        [HttpPost]
        [Route("api/orderDetail/create")]
        //[AuthorizeFilterCustomer]
        public IHttpActionResult Create(OrderDetail orderDetail)
        {
            try
            {
                return Ok(orderDetailService.Create(orderDetail));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/orderDetail/list")]
        [AuthorizeFilter]
        public IHttpActionResult List(PagedListRequest request)
        {
            try
            {
                return Ok(orderDetailService.List(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/orderDetail/get")]
        [AuthorizeFilter]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                return Ok(orderDetailService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/orderDetail/getOrderDetail")]
        //[AuthorizeFilterCustomer]
        public IHttpActionResult GetOrderDetail(Guid id)
        {
            try
            {
                return Ok(orderDetailService.GetOrderDetail(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/orderDetail/getOrder")]
        //[AuthorizeFilterCustomer]
        public IHttpActionResult GetOrder(Guid id)
        {
            try
            {
                return Ok(orderDetailService.GetOrder(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/orderDetail/all")]
        [AuthorizeFilter]
        public IHttpActionResult All()
        {
            try
            {
                return Ok(orderDetailService.All());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/orderDetail/delete")]
        [AuthorizeFilter]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                orderDetailService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
