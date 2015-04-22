

namespace UefaServiceV9.Models
{
    public class GroupStage
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        public string CountryCode { get; set; }

        public double Ranking { get; set; }

        //foreign key
        public int TeamRankingId { get; set; }

    }
}
    
