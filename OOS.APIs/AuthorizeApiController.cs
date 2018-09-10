using OOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using OOS.Services;

namespace OOS.APIs
{
    public class AuthorizeApiController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login([FromBody]Account account)
        {
            try
            {
                //var loginResponse = new HttpResponseMessage();
                var accountService = new AccountService();
                var currentUser = accountService.Login(account.Username, account.HashedPassword);
                return Ok(currentUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/authorize")]
        public IHttpActionResult Authorize()
        {
            var response = new HttpResponseMessage();
            var accountService = new AccountService();
            return Ok(accountService.GetCurrentUser());
        }
    }
}
