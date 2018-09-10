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
    public class CustomerController : ApiController
    {
        CustomerService customerService = new CustomerService();

        [HttpPost]
        [Route("api/customer/login")]
        public IHttpActionResult Login([FromBody]Customer customer)
        {
            try
            {
                string username = customer.Username;
                string password = customer.HashedPassword;
                return Ok(customerService.Login(username, password));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/customer/save")]
        public IHttpActionResult Save(Customer customer)
        {
            try
            {
                return Ok(customerService.Save(customer));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/customer/list")]
        [AuthorizeFilter]
        public IHttpActionResult List(PagedListRequest request)
        {
            try
            {
                return Ok(customerService.List(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/customer/get")]
        //[AuthorizeFilter]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                return Ok(customerService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/customer/all")]
        [AuthorizeFilter]
        public IHttpActionResult All()
        {
            try
            {
                return Ok(customerService.All());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/customer/enable")]
        [AuthorizeFilter]
        public IHttpActionResult Enable(Guid id)
        {
            try
            {
                return Ok(customerService.Enable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/customer/disable")]
        [AuthorizeFilter]
        public IHttpActionResult Disable(Guid id)
        {
            try
            {
                return Ok(customerService.Disable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/customer/delete")]
        [AuthorizeFilter]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                customerService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

