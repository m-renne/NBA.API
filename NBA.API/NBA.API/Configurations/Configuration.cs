using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace NBA.API.Configurations
{
    public class Configuration : IConfiguration
    {
        public string ConnectionString
        {
            get
            {
                return WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            }
        }
    }
}