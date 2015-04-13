using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UefaServiceV4.Models
{
    public class RoundOne
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        public string CountryCode { get; set; }

        public double Ranking { get; set; }

        //foreign key
        public int TeamRankingId { get; set; }

        //public double TeamRankingRanking { get; set; }
        // public string CountryCode { get; set; }
        public TeamRanking TeamRanking { get; set; }
        

    }
}