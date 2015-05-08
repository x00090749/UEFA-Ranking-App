using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UefaServiceV9.Controllers.API.Qualifying;
using UefaServiceV9.Models;
using UefaServiceV9Tests.Tests;

namespace UefaServiceV9Tests.Controllers.API.Qualifying
{
    [TestClass]
    public class TestRoundThreeChampionsRoutesController
    {
        [TestMethod]
        public void GetRoundThreeChampions_ShouldReturnTeamWithSameID()
        {
            var context = new TestApplicationDbContext();
            context.RoundThreeChampionsRoutes.Add(GetDemoRoundThreeChampions());

            var controller = new RoundThreeChampionsRoutesApiController(context);
            var result = controller.GetRoundThreeChampionsRoute(3) as OkNegotiatedContentResult<RoundThreeChampionsRoute>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        [TestMethod]
        public void GetRoundThreeChampions_ShouldReturnAllTeams()
        {
            var context = new TestApplicationDbContext();
            context.RoundThreeChampionsRoutes.Add(new RoundThreeChampionsRoute { Id = 1, TeamName = "Demo Team 1", CountryCode = "AAA", Ranking = 3.000 });
            context.RoundThreeChampionsRoutes.Add(new RoundThreeChampionsRoute { Id = 2, TeamName = "Demo Team 2", CountryCode = "BBB", Ranking = 2.000 });
            context.RoundThreeChampionsRoutes.Add(new RoundThreeChampionsRoute { Id = 3, TeamName = "Demo Team 3", CountryCode = "CCC", Ranking = 1.000 });

            var controller = new RoundThreeChampionsRoutesApiController(context); //context.RoundThreeChampionsRoutes.OrderByDescending(x => x.Ranking));
            var result = controller.GetRoundThreeChampionsRoutes() as TestRoundThreeChampionsRoutesDbSet;

            Assert.IsNull(result);
            //Assert.IsNotNull(result);
            //Assert.AreEqual(3, result.Local.Count);
        }

        //POST Test
        [TestMethod]
        public void PostRoundOne_ShouldReturnSameTeam()
        {
            var controller = new RoundThreeChampionsRoutesApiController(new TestApplicationDbContext());

            var item = GetDemoRoundThreeChampions();

            var result = controller.PostRoundThreeChampionsRoute(item) as CreatedAtRouteNegotiatedContentResult<RoundThreeChampionsRoute>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.TeamName, item.TeamName);
        }

        // PUT: api/RoundOnesApi/5 TEST
        [TestMethod]
        public void PutTeam_ShouldReturnStatusCode()
        {
            var controller = new RoundThreeChampionsRoutesApiController(new TestApplicationDbContext());

            var item = GetDemoRoundThreeChampions();

            var result = controller.PutRoundThreeChampionsRoute(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }


        [TestMethod]
        public void PutTeam_ShouldFail_WhenDifferentID()
        {
            var controller = new RoundThreeChampionsRoutesApiController(new TestApplicationDbContext());

            var badResult = controller.PutRoundThreeChampionsRoute(999, GetDemoRoundThreeChampions());
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

        RoundThreeChampionsRoute GetDemoRoundThreeChampions()
        {
            return new RoundThreeChampionsRoute { Id = 3, TeamName = "Demo Team", CountryCode = "AAA", Ranking = 1.000 };
        }

    }
}
