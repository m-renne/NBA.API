using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA.API.DomainModels.PlayerModels
{
    public class Player
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int JerseyNumber { get; set; }
    }
}