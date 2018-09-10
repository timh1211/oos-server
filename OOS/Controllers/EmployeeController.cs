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
using System.Web;

namespace OOS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        EmployeeService employeeService = new EmployeeService();
        AccountService accountService = new AccountService();

        [HttpPost]
        [Route("api/image/save")]
        [AuthorizeFilter]
        public IHttpActionResult SaveImage(dynamic file)
        {
            try
            {
                return Ok(Utilities.Utility.SaveImage(file));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/employee/save")]
        [AuthorizeFilter]
        public IHttpActionResult Save(Employee employee)
        {
            try
            {  
                return Ok(employeeService.Save(employee));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/employee/list")]
        [AuthorizeFilter]
        public IHttpActionResult List(PagedListRequest request)
        {
            try
            {
                return Ok(employeeService.List(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/employee/get")]
        [AuthorizeFilter]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                return Ok(employeeService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Id = EmployeeID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/employee/getAccount")]
        [AuthorizeFilter]
        public IHttpActionResult GetAccount(Guid id)
        {
            try
            {
                return Ok(accountService.GetAccountOfEmployee(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/employee/all")]
        [AuthorizeFilter]
        public IHttpActionResult All()
        {
            try
            {
                return Ok(employeeService.All());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/employee/enable")]
        [AuthorizeFilter]
        public IHttpActionResult Enable(Guid id)
        {
            try
            {
                return Ok(employeeService.Enable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/employee/disable")]
        [AuthorizeFilter]
        public IHttpActionResult Disable(Guid id)
        {
            try
            {
                return Ok(employeeService.Disable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/employee/delete")]
        [AuthorizeFilter]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                employeeService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
    //{
    //    [HttpGet]
    //    [Route("api/getEmployees")]
    //    public IHttpActionResult GetEmployees()
    //    {
    //        try
    //        {
    //            var employeeService = new EmployeeService();
    //            if (employeeService.GetCurrentUser() != null) return Ok(employeeService.GetList());
    //            return BadRequest();
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }

    //    [HttpGet]
    //    [Route("api/getEmployees")]
    //    public IHttpActionResult GetEmployees
    //        (string orderBy, string orderDirection, int page, int pageSize, string whereClause = "1>0")
    //    {
    //        try
    //        {
    //            var employeeService = new EmployeeService();
    //            if (employeeService.GetCurrentUser() != null)
    //                return Ok(employeeService.GetList(orderBy, orderDirection, page, pageSize, whereClause));
    //            return BadRequest();
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }

    //    [HttpGet]
    //    [Route("api/getEmployee/{id}")]
    //    public IHttpActionResult GetEmployee(Guid id)
    //    {
    //        try
    //        {
    //            var employeeService = new EmployeeService();
    //            if (employeeService.GetCurrentUser() != null) return Ok(employeeService.Get(id));
    //            return BadRequest();
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }

    //    [HttpPost]
    //    [Route("api/saveEmployee")]
    //    public IHttpActionResult SaveEmployee([FromBody]Employee employee)
    //    {
    //        try
    //        {
    //            var employeeService = new EmployeeService();
    //            if (employeeService.GetCurrentUser() != null) return Ok(employeeService.Save(employee));
    //            return BadRequest();
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }

    //    [HttpPost]
    //    [Route("api/deleteEmployee")]
    //    public IHttpActionResult DeleteEmployee([FromBody]Employee employee)
    //    {
    //        try
    //        {
    //            var employeeService = new EmployeeService();
    //            if (employeeService.GetCurrentUser() != null) return Ok(employeeService.Delete(employee.Id));
    //            return BadRequest();
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }
}
