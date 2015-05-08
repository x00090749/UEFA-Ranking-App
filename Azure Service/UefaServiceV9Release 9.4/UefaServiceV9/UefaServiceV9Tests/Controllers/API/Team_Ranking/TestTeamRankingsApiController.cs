using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UefaServiceV9.Controllers.API.Team_Ranking;
using UefaServiceV9.Models;
using UefaServiceV9Tests.Tests;

namespace UefaServiceV9Tests.Controllers.API.Team_Ranking
{
    [TestClass]
    public class TestTeamRankingsApiController
    {
        [TestMethod]
        public void GetTeamRankings_ShouldReturnTeamWithSameID()
        {
            var context = new TestApplicationDbContext();
            context.TeamRankings.Add(GetDemoTeamRankings());

            var controller = new TeamRankingsApiController(context);
            var result = controller.GetTeamRanking(3) as OkNegotiatedContentResult<TeamRanking>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        [TestMethod]
        public void GetTeamRankings_ShouldReturnAllTeams()
        {
            var context = new TestApplicationDbContext();
            context.TeamRankings.Add(new TeamRanking { Id = 1, TeamName = "Demo Team 1", CountryCode = "AAA", Ranking = 3.000 });
            context.TeamRankings.Add(new TeamRanking { Id = 2, TeamName = "Demo Team 2", CountryCode = "BBB", Ranking = 2.000 });
            context.TeamRankings.Add(new TeamRanking { Id = 3, TeamName = "Demo Team 3", CountryCode = "CCC", Ranking = 1.000 });

            var controller = new TeamRankingsApiController(context); //(context.TeamRankings.OrderByDescending(x => x.Ranking));
            var result = controller.GetTeamRankings() as TestGroupStagesDbSet;

            Assert.IsNull(result);
            //Assert.IsNotNull(result);
            //Assert.AreEqual(3, result.Local.Count);
        }

        //POST Test
        [TestMethod]
        public void PostGroupStages_ShouldReturnSameTeam()
        {
            var controller = new TeamRankingsApiController(new TestApplicationDbContext());

            var item = GetDemoTeamRankings();

            var result = controller.PostTeamRanking(item) as CreatedAtRouteNegotiatedContentResult<TeamRanking>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.TeamName, item.TeamName);
        }

        // PUT: api/RoundOnesApi/5 TEST
        [TestMethod]
        public void PutTeam_ShouldReturnStatusCode()
        {
            var controller = new TeamRankingsApiController(new TestApplicationDbContext());

            var item = GetDemoTeamRankings();

            var result = controller.PutTeamRanking(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }


        [TestMethod]
        public void PutTeam_ShouldFail_WhenDifferentID()
        {
            var controller = new TeamRankingsApiController(new TestApplicationDbContext());

            var badResult = controller.PutTeamRanking(999, GetDemoTeamRankings());
            Assert.IsInstanceOfType(badResult, typeof(BadRequestResult));
        }

        /*    [TestMethod]
             public void DeleteTeam_ShouldReturnOK()
            {
                var context = new TestApplicationDbContext();
                var item = GetDemoRoundOne();
                context.RoundOnes.Add(item);

                var controller = new RoundOnesApiController(context);
                var result = controller.DeleteRoundOne(3) as OkNegotiatedContentResult<RoundOne>;

                //Assert.IsNull(result);
                Assert.IsNotNull(result);
                Assert.AreEqual(item.Id, result.Content.Id);
            }*/

        TeamRanking GetDemoTeamRankings()
        {
            return new TeamRanking { Id = 3, TeamName = "Demo Team", CountryCode = "AAA", Ranking = 1.000 };
        }

    }
}
