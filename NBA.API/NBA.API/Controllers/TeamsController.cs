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
    public class TeamsController : ApiController
    {
        ITeamService TeamService { get; set; }

        public TeamsController(ITeamService teamService)
        {
            TeamService = teamService;
        }

        [Route("teams/{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var team = TeamService.Get(id);

            return Request.CreateResponse(HttpStatusCode.OK, team);
        }

        [Route("teams")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var teams = TeamService.Get();

            return Request.CreateResponse(HttpStatusCode.OK, teams);
        }

        [Route("teams/{id}/image")]
        [HttpGet]
        public HttpResponseMessage GetImage(int id)
        {
            var team = TeamService.Get(id);

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            String filePath = HostingEnvironment.MapPath($"~/Resources/Images/teams/{team.Abbrev.ToLower()}.png");
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            Image image = Image.FromStream(fileStream);
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            result.Content = new ByteArrayContent(memoryStream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            //HttpResponseMessage response = new HttpResponseMessage();
            //response.Content = new StreamContent(new FileStream(HostingEnvironment.MapPath($"~/Resources/Images/teams/{team.Abbrev.ToLower()}.png"), FileMode.Open)); // this file stream will be closed by lower layers of web api for you once the response is completed.
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            //return response;

            return result;
        }
    }
}
