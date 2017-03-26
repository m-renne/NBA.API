using AutoMapper;
using NBA.API.Repositories.PlayerRepository;
using NBA.API.DomainModels.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA.API.Services.PlayerServices
{
    public class PlayerService : IPlayerService
    {
        IPlayerRepository Repo { get; set; }

        public PlayerService(IPlayerRepository repo)
        {
            Repo = repo;
        }

        public Player Get(int id)
        {
            return Repo.Get(id);
        }

        public List<Player> Get(PlayerSearchCriteria criteria)
        {
            return Repo.Get(criteria);
        }
    }
}