using NBA.API.DomainModels.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.API.Services.PlayerServices
{
    public interface IPlayerService
    {
        Player Get(int id);
    }
}
