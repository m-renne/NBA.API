using NBA.API.Services.TeamServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Hosting;
using System.Web.Http;

namespace NBA.API.Controllers
{
    public class ImageController : ApiController
    {
        ITeamService TeamService { get; set; }

        public ImageController(ITeamService teamService)
        {
            TeamService = teamService;
        }

        [Route("teams/{id}/image")]
        [HttpGet]
        public HttpResponseMessage GetImage(int id)
        {
            var team = TeamService.Get(id);

            if(team == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
            string filePath = HostingEnvironment.MapPath(team.Image);
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            Image image = Image.FromStream(fileStream);
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(memoryStream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            return result;
        }
    }
}
