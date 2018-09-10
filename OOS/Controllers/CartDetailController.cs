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
    public class CartDetailController : ApiController
    {
        CartDetailService cartDetailService = new CartDetailService();

        [HttpPost]
        [Route("api/cartDetail/save")]
        //[AuthorizeFilterCustomer]
        public IHttpActionResult Save(CartDetail cartDetail)
        {
            try
            {
                return Ok(cartDetailService.AddProductToCart(cartDetail));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/cartDetail/get")]
        //[AuthorizeFilterCustomer]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                return Ok(cartDetailService.GetCart(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/cartDetail/getTotal")]
        //[AuthorizeFilterCustomer]
        public IHttpActionResult GetTotalQuantity(Guid id)
        {
            try
            {
                return Ok(cartDetailService.GetTotalQuantity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/cartDetail/getTotalPrice")]
        //[AuthorizeFilterCustomer]
        public IHttpActionResult GetTotalPrice(Guid id)
        {
            try
            {
                return Ok(cartDetailService.GetTotalPrice(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/cartDetail/delete")]
        //[AuthorizeFilterCustomer]
        public IHttpActionResult Delete(Guid CId, Guid PId)
        {
            try
            {
                return Ok(cartDetailService.DeleteCart(CId, PId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/cartDetail/deleteAll")]
        //[AuthorizeFilterCustomer]
        public IHttpActionResult DeleteAll(Guid CId)
        {
            try
            {
                return Ok(cartDetailService.DeleteCartAll(CId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/cartDetail/updown")]
        //[AuthorizeFilterCustomer]
        public IHttpActionResult UpDown(dynamic properties)
        {
            try
            {
                return Ok(cartDetailService.UpDownQuantity(properties));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/cartDetail/editqty")]
        //[AuthorizeFilterCustomer]
        public IHttpActionResult EditQuantity(CartDetail properties)
        {
            try
            {
                return Ok(cartDetailService.EditQuantity(properties));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
