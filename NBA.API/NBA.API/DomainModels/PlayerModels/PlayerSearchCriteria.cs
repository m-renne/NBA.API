using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA.API.DomainModels.PlayerModels
{
    public class PlayerSearchCriteria
    {
        public int TeamId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int? JerseyNumber { get; set; }

        public string Position { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? Age { get; set; }

        public string BirthCity { get; set; }

        public string BirthCountry { get; set; }

        public bool? IsRookie { get; set; }
    }
}