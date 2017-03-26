using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NBA.API.Controllers
{
    public class PlayersController : ApiController
    {
        [Route("players")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var players = new { test = 1 };

            return Request.CreateResponse(HttpStatusCode.OK, players);
        }
    }
}
