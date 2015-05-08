using System.Data.Entity;
using UefaServiceV9.Models;

namespace UefaServiceV9Tests.Tests
{
    public class TestApplicationDbContext : IApplicationDbContext
    {
        public TestApplicationDbContext()
        {
            RoundOnes = new TestRoundOneDbSet();
            RoundTwoes = new TestRoundTwoDbSet();
            RoundThreeChampionsRoutes = new TestRoundThreeChampionsRoutesDbSet();
            RoundThreeLeagueRoutes = new TestRoundThreeLeagueRoutesDbSet();
            RoundFourLeagueRoutes = new TestRoundFourLeagueRoutesDbSet();

            GroupStages = new TestGroupStagesDbSet();
            TeamRankings = new TestTeamRankingDbSet();
            CountryRankings = new TestCountryRankingDbSet();

        }



        public DbSet<RoundOne> RoundOnes { get; set; }
        public DbSet<RoundTwo> RoundTwoes { get; set; }

        public DbSet<RoundThreeChampionsRoute> RoundThreeChampionsRoutes { get; set; }
        public DbSet<RoundThreeLeagueRoute> RoundThreeLeagueRoutes { get; set; }
        public DbSet<RoundFourLeagueRoute> RoundFourLeagueRoutes { get; set; }
        public DbSet<GroupStage> GroupStages { get; set; }
        public DbSet<TeamRanking> TeamRankings { get; set; }
        public DbSet<CountryRanking> CountryRankings { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(RoundOne item)
        {

        }


        public void MarkAsModified(RoundTwo item)
        {

        }

        public void MarkAsModified(RoundThreeChampionsRoute item)
        {
            
        }

        public void MarkAsModified(RoundThreeLeagueRoute item)
        {
            
        }

        public void MarkAsModified(RoundFourLeagueRoute item)
        {
            
        }

        public void MarkAsModified(GroupStage item)
        {
           
        }

        public void MarkAsModified(TeamRanking item)
        {
            
        }

        public void MarkAsModified(CountryRanking item)
        {
           
        }


        public void Dispose()
        {
            
        }
    }
}
