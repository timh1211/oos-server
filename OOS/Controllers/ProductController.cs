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
    public class ProductController : ApiController
    {
        ProductService productService = new ProductService();

        [HttpGet]
        [Route("api/product/gethighlights")]
        public IHttpActionResult GetHighlights()
        {
            try
            {
                return Ok(productService.GetHighlights());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/product/getproducts")]
        public IHttpActionResult GetProducts(ProductRequest productRequest)
        {
            try
            {
                return Ok(productService.GetProducts(productRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/product/getproductdetail/{id}")]
        public IHttpActionResult GetProductDetail(string id)
        {
            try
            {
                return Ok(productService.GetProductDetail(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/product/save")]
        [AuthorizeFilter]
        public IHttpActionResult Save(ProductDetail entity)
        {
            try
            {
                return Ok(productService.Save(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/product/list")]
        [AuthorizeFilter]
        public IHttpActionResult List(PagedListRequest request)
        {
            try
            {
                return Ok(productService.List(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/product/get")]
        [AuthorizeFilter]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                return Ok(productService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/product/all")]
        public IHttpActionResult All()
        {
            try
            {
                return Ok(productService.All());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/product/enable")]
        [AuthorizeFilter]
        public IHttpActionResult Enable(Guid id)
        {
            try
            {
                return Ok(productService.Enable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/product/disable")]
        [AuthorizeFilter]
        public IHttpActionResult Disable(Guid id)
        {
            try
            {
                return Ok(productService.Disable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/product/delete")]
        [AuthorizeFilter]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                productService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
