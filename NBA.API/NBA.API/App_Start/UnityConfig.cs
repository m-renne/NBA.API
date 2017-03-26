using Microsoft.Practices.Unity;
using NBA.API.Configurations;
using NBA.API.Repositories.PlayerRepository;
using NBA.API.Repositories.TeamRepository;
using NBA.API.Services.PlayerServices;
using NBA.API.Services.TeamServices;
using System.Web.Http;
using Unity.WebApi;

namespace NBA.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            #region Repositories

            container.RegisterType<IPlayerRepository, PlayerRepository>();
            container.RegisterType<ITeamRepository, TeamRepository>();

            #endregion

            #region Services

            container.RegisterType<IPlayerService, PlayerService>();
            container.RegisterType<ITeamService, TeamService>();

            #endregion

            container.RegisterType<IConfiguration, Configuration>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}