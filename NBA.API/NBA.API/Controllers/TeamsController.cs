using NBA.API.Services.TeamServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
