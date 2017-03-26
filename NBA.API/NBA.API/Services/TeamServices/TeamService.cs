using NBA.API.DomainModels.TeamModels;
using NBA.API.Repositories.TeamRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA.API.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        public ITeamRepository Repo { get; set; }

        public TeamService(ITeamRepository repo)
        {
            Repo = repo;
        }

        public Team Get(int id)
        {
            return Repo.Get(id);
        }

        public List<Team> Get()
        {
            return Repo.Get();
        }
    }
}