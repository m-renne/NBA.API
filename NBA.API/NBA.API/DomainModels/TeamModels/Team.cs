using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA.API.DomainModels.TeamModels
{
    public class Team
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Name { get; set; }

        public string Abbrev { get; set; }

        public string Image
        {
            get
            {
                return $"{HttpContext.Current.Request.Url.Authority}/images/teams/{Abbrev.ToLower()}.png";
            }
        }
    }
}