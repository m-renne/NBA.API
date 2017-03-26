using Microsoft.Practices.Unity;
using NBA.API.Configurations;
using NBA.API.Repositories.PlayerRepository;
using NBA.API.Services.PlayerServices;
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

            #endregion

            #region Services

            container.RegisterType<IPlayerService, PlayerService>();
            
            #endregion

            container.RegisterType<IConfiguration, Configuration>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}