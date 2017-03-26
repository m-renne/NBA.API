using NBA.API.DomainModels.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.API.Repositories.PlayerRepository
{
    public interface IPlayerRepository
    {
        Player Get(int id);
        List<Player> Get(PlayerSearchCriteria criteria);
    }
}
