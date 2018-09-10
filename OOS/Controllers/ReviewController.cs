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
    public class ReviewController : ApiController
    {
        ReviewService reviewService = new ReviewService();

        [HttpPost]
        [Route("api/review/save")]
        [AuthorizeFilter]
        public IHttpActionResult Save(Review review)
        {
            try
            {
                return Ok(reviewService.Save(review));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/review/list")]
        [AuthorizeFilter]
        public IHttpActionResult List(PagedListRequest request)
        {
            try
            {
                return Ok(reviewService.List(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/review/getbyproduct")]
        public IHttpActionResult GetByProduct(string id)
        {
            try
            {
                return Ok(reviewService.GetByProduct(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/review/get")]
        //[AuthorizeFilter]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                return Ok(reviewService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/review/all")]
        [AuthorizeFilter]
        public IHttpActionResult All()
        {
            try
            {
                return Ok(reviewService.All());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/review/enable")]
        [AuthorizeFilter]
        public IHttpActionResult Enable(Guid id)
        {
            try
            {
                return Ok(reviewService.Enable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/review/disable")]
        [AuthorizeFilter]
        public IHttpActionResult Disable(Guid id)
        {
            try
            {
                return Ok(reviewService.Disable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/review/delete")]
        [AuthorizeFilter]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                reviewService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
