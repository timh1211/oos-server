using OOS.Models;
using OOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OOS.APIs
{
    public class AccountApiController: ApiController
    {
        [HttpPost]
        [Route("api/getAccounts")]
        public IHttpActionResult GetAccounts()
        {
            var accountService = new AccountService();
            return Ok(accountService.GetList());
        }

        [HttpGet]
        [Route("api/GetAccount/{id}")]
        public IHttpActionResult GetAccount(Guid id)
        {
            var accountService = new AccountService();
            return Ok(accountService.Get(id));
        }

        [HttpPost]
        [Route("api/saveAccount")]
        public IHttpActionResult SaveAccount([FromBody]Account account)
        {
            var accountService = new AccountService();
            return Ok(accountService.Save(account));
        }

        [HttpDelete]
        [Route("api/deleteAccount")]
        public IHttpActionResult DeleteAccount([FromBody]Account account)
        {
            var accountService = new AccountService();
            return Ok(accountService.Delete(account));
        }
    }
}
