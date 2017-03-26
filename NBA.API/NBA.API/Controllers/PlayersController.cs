using NBA.API.DomainModels.PlayerModels;
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

        [Route("players/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var player = PlayerService.Get(id);

            return Request.CreateResponse(HttpStatusCode.OK, player);
        }

        [Route("players")]
        [HttpGet]
        public HttpResponseMessage Get([FromUri]PlayerSearchCriteria criteria)
        {
            var players = PlayerService.Get(criteria);

            return Request.CreateResponse(HttpStatusCode.OK, players);
        }
    }
}
