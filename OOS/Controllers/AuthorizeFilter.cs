using OOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using OOS.Services;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net;
using System.Web.Http.Cors;

namespace OOS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthorizeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                var accountService = new AccountService();
                var result = accountService.IsValidToken();
                if (result) base.OnActionExecuting(actionContext);
                else throw new Exception("TOKEN_INVALID");
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
        }
    }
}
