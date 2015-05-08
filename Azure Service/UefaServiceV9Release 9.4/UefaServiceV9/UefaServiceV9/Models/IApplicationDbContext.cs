using System;
using System.Data.Entity;

namespace UefaServiceV9.Models
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<RoundOne> RoundOnes { get;}
        DbSet<RoundTwo> RoundTwoes { get;}
        DbSet<RoundThreeChampionsRoute> RoundThreeChampionsRoutes { get; }
        DbSet<RoundThreeLeagueRoute> RoundThreeLeagueRoutes { get; }
        DbSet<RoundFourLeagueRoute> RoundFourLeagueRoutes { get; }
        DbSet<GroupStage> GroupStages { get; }
        DbSet<TeamRanking> TeamRankings { get; }
        DbSet<CountryRanking> CountryRankings { get; }
        int SaveChanges();

        void MarkAsModified(RoundOne item);
        void MarkAsModified(RoundTwo item);
        void MarkAsModified(RoundThreeChampionsRoute item);
        void MarkAsModified(RoundThreeLeagueRoute item);
        void MarkAsModified(RoundFourLeagueRoute item);
        void MarkAsModified(GroupStage item);
        void MarkAsModified(TeamRanking item);
        void MarkAsModified(CountryRanking item);



    }
}
