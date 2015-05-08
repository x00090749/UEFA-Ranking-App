using System.Linq;
using UefaServiceV9.Models;

namespace UefaServiceV9Tests.Tests
{
  
    class TestRoundOneDbSet : TestDbSet<RoundOne>
    {
        public override RoundOne Find(params object[] keyValues)
        {
            return this.SingleOrDefault(roundOne => roundOne.Id == (int) keyValues.Single());
        }
    }

    class TestRoundTwoDbSet : TestDbSet<RoundTwo>
    {
        public override RoundTwo Find(params object[] keyValues)
        {
            return this.SingleOrDefault(roundTwo => roundTwo.Id == (int) keyValues.Single());
        }
    }

    class TestRoundThreeChampionsRoutesDbSet : TestDbSet<RoundThreeChampionsRoute>
    {
        public override RoundThreeChampionsRoute Find(params object[] keyValues)
        {
            return this.SingleOrDefault(roundThreech => roundThreech.Id == (int)keyValues.Single());
        }
    }

    class TestRoundThreeLeagueRoutesDbSet : TestDbSet<RoundThreeLeagueRoute>
    {
        public override RoundThreeLeagueRoute Find(params object[] keyValues)
        {
            return this.SingleOrDefault(roundThreelr => roundThreelr.Id == (int)keyValues.Single());
        }
    }

    class TestRoundFourLeagueRoutesDbSet : TestDbSet<RoundFourLeagueRoute>
    {
        public override RoundFourLeagueRoute Find(params object[] keyValues)
        {
            return this.SingleOrDefault(roundFourlr => roundFourlr.Id == (int)keyValues.Single());
        }
    }

    class TestGroupStagesDbSet : TestDbSet<GroupStage>
    {
        public override GroupStage Find(params object[] keyValues)
        {
            return this.SingleOrDefault(groupStage => groupStage.Id == (int)keyValues.Single());
        }
    }

    class TestCountryRankingDbSet : TestDbSet<CountryRanking>
    {
        public override CountryRanking Find(params object[] keyValues)
        {
            return this.SingleOrDefault(countryRanking => countryRanking.Id == (int)keyValues.Single());
        }
    }

    class TestTeamRankingDbSet : TestDbSet<TeamRanking>
    {
        public override TeamRanking Find(params object[] keyValues)
        {
            return this.SingleOrDefault(teamRanking => teamRanking.Id == (int)keyValues.Single());
        }
    }


}
