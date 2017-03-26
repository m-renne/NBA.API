using NBA.API.DomainModels.TeamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.API.Repositories.TeamRepository
{
    public interface ITeamRepository
    {
        Team Get(int id);
        List<Team> Get();
    }
}
