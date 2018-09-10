using Newtonsoft.Json.Linq;
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
    public class AccountApiController : ApiController
    {
        AccountService accountService = new AccountService();

        [HttpPost]
        [Route("api/account/login")]
        public IHttpActionResult Login([FromBody]Account account)
        {
            try
            {
                string username = account.Username;
                string password = account.HashedPassword;
                return Ok(accountService.Login(username, password));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/account/save")]
        [AuthorizeFilter]
        public IHttpActionResult Save(Account account)
        {
            try
            {
                return Ok(accountService.Save(account));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/account/list")]
        [AuthorizeFilter]
        public IHttpActionResult List(PagedListRequest request)
        {
            try
            {
                return Ok(accountService.List(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/account/get/{id}")]
        [AuthorizeFilter]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                return Ok(accountService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/account/all")]
        [AuthorizeFilter]
        public IHttpActionResult All()
        {
            try
            {
                return Ok(accountService.All());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/account/enable")]
        [AuthorizeFilter]
        public IHttpActionResult Enable(Guid id)
        {
            try
            {
                return Ok(accountService.Enable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/account/disable")]
        [AuthorizeFilter]
        public IHttpActionResult Disable(Guid id)
        {
            try
            {
                return Ok(accountService.Disable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/account/delete")]
        [AuthorizeFilter]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                return Ok(accountService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
