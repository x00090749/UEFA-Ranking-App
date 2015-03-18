using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UEFA_Ranking_V1.Models
{

    public enum TeamDescriptions
    {
        TeamName, CountryName, LeagueName, CoEfficient, RoundToEnter
    }

    public class Team
    {

        public TeamDescriptions TeamDescriptions { get; set; }

        public int Id { get; set; }
        public string Name {  }


    }
}