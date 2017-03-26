using NBA.API.Services.PlayerServices;
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
        public IPlayerService PlayerService { get; set; }

        public PlayersController(IPlayerService playerService)
        {
            PlayerService = playerService;
        }

        [Route("players")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var players = new { test = 7};

            var player = PlayerService.Get(1);

            return Request.CreateResponse(HttpStatusCode.OK, player);
        }
    }
}
