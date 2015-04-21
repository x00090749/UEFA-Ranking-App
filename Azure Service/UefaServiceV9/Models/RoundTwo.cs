using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UefaServiceV9.Models
{
    public class RoundTwo
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        public string CountryCode { get; set; }

        public double Ranking { get; set; }

        //foreign key
        public int TeamRankingId { get; set; }
        //public int TeamRankingRanking { get; set; }
        //public int TeamRankingId { get; set; }
        //public TeamRanking TeamRanking { get; set; }
    }
}