using OOS.Models;
using OOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OOS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ImageController : ApiController
    {
        [HttpPost]
        [Route("api/image/upload")]
        public HttpResponseMessage Upload()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
                var httpRequest = HttpContext.Current.Request;
                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        int maxContentLength = 1024 * 1024 * 5; //Size = 5 MB
                        var extension = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        if (postedFile.ContentLength > maxContentLength)
                        {
                            var message = string.Format("Please Upload a file upto 5 mb.");
                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {
                            var imageService = new ImageService();
                            var data = new Image
                            {
                                name = Guid.NewGuid().ToString(),
                                originName = postedFile.FileName,
                                path = "/Image/",
                                extension = extension.ToLower(),
                                size = postedFile.ContentLength / 1024
                            };
                            var filePath = HttpContext.Current.Server.MapPath(string.Format("~{0}{1}{2}", data.path, data.name, data.extension));
                            postedFile.SaveAs(filePath);
                            data = imageService.Save(data);
                            return Request.CreateResponse(HttpStatusCode.OK, data);
                        }
                    }
                }
                var res = string.Format("FILE_NOT_FOUND");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format(ex.Message);
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }
    }
}
