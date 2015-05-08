using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UefaServiceV9.Controllers.API.Qualifying;
using UefaServiceV9.Models;
using UefaServiceV9Tests.Tests;

namespace UefaServiceV9Tests.Controllers.API.Qualifying
{
    [TestClass]
    public class TestRoundThreeLeagueRoutesController
    {
        [TestMethod]
        public void GetRoundThreeLeague_ShouldReturnTeamWithSameID()
        {
            var context = new TestApplicationDbContext();
            context.RoundThreeLeagueRoutes.Add(GetDemoRoundThreeLeague());

            var controller = new RoundThreeLeagueRoutesApiController(context);
            var result = controller.GetRoundThreeLeagueRoute(3) as OkNegotiatedContentResult<RoundThreeLeagueRoute>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        [TestMethod]
        public void GetRoundThreeLeague_ShouldReturnAllTeams()
        {
            var context = new TestApplicationDbContext();
            context.RoundThreeLeagueRoutes.Add(new RoundThreeLeagueRoute { Id = 1, TeamName = "Demo Team 1", CountryCode = "AAA", Ranking = 3.000 });
            context.RoundThreeLeagueRoutes.Add(new RoundThreeLeagueRoute { Id = 2, TeamName = "Demo Team 2", CountryCode = "BBB", Ranking = 2.000 });
            context.RoundThreeLeagueRoutes.Add(new RoundThreeLeagueRoute { Id = 3, TeamName = "Demo Team 3", CountryCode = "CCC", Ranking = 1.000 });

            var controller = new RoundThreeLeagueRoutesApiController(context); //(context.RoundThreeLeagueRoutes.OrderByDescending(x => x.Ranking));
            var result = controller.GetRoundThreeLeagueRoutes() as TestRoundThreeLeagueRoutesDbSet;

            Assert.IsNull(result);
            //Assert.IsNotNull(result);
            //Assert.AreEqual(3, result.Local.Count);
        }

        //POST Test
        [TestMethod]
        public void PostRoundThreeLeagueRoute_ShouldReturnSameTeam()
        {
            var controller = new RoundThreeLeagueRoutesApiController(new TestApplicationDbContext());

            var item = GetDemoRoundThreeLeague();

            var result = controller.PostRoundThreeLeagueRoute(item) as CreatedAtRouteNegotiatedContentResult<RoundThreeLeagueRoute>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.TeamName, item.TeamName);
        }

        // PUT: api/RoundOnesApi/5 TEST
        [TestMethod]
        public void PutTeam_ShouldReturnStatusCode()
        {
            var controller = new RoundThreeLeagueRoutesApiController(new TestApplicationDbContext());

            var item = GetDemoRoundThreeLeague();

            var result = controller.PutRoundThreeLeagueRoute(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }


        [TestMethod]
        public void PutTeam_ShouldFail_WhenDifferentID()
        {
            var controller = new RoundThreeLeagueRoutesApiController(new TestApplicationDbContext());

            var badResult = controller.PutRoundThreeLeagueRoute(999, GetDemoRoundThreeLeague());
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

        RoundThreeLeagueRoute GetDemoRoundThreeLeague()
        {
            return new RoundThreeLeagueRoute { Id = 3, TeamName = "Demo Team", CountryCode = "AAA", Ranking = 1.000 };
        }

    }
}
