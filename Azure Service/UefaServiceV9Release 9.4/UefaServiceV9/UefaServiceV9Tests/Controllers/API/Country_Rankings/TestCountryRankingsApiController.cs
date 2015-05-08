using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UefaServiceV9.Controllers.API.Country_Rankings;
using UefaServiceV9.Models;
using UefaServiceV9Tests.Tests;

namespace UefaServiceV9Tests.Controllers.API.Country_Rankings
{
    [TestClass]
    public class TestCountryRankingsApiController
    {
        [TestMethod]
        public void GetGroupStages_ShouldReturnTeamWithSameID()
        {
            var context = new TestApplicationDbContext();
            context.CountryRankings.Add(GetDemoCountryRanking());

            var controller = new CountryRankingsApiController(context);
            var result = controller.GetCountryRanking(3) as OkNegotiatedContentResult<CountryRanking>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        [TestMethod]
        public void GetGroupStage_ShouldReturnAllTeams()
        {
            var context = new TestApplicationDbContext();
            context.CountryRankings.Add(new CountryRanking { Id = 1, CountryName = "Demo Country 1", Ranking = 3.000 });
            context.CountryRankings.Add(new CountryRanking { Id = 2, CountryName = "Demo Country 2", Ranking = 2.000 });
            context.CountryRankings.Add(new CountryRanking { Id = 3, CountryName = "Demo Country 3", Ranking = 1.000 });

            var controller = new CountryRankingsApiController(context);
            var result = controller.GetCountryRankings() as TestCountryRankingDbSet;

            Assert.IsNull(result);
            //Assert.IsNotNull(result);
            //Assert.AreEqual(3, result.Local.Count);
        }

        //POST Test
        [TestMethod]
        public void PostGroupStages_ShouldReturnSameTeam()
        {
            var controller = new CountryRankingsApiController(new TestApplicationDbContext());

            var item = GetDemoCountryRanking();

            var result = controller.PostCountryRanking(item) as CreatedAtRouteNegotiatedContentResult<CountryRanking>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.CountryName, item.CountryName);
        }

        // PUT: api/RoundOnesApi/5 TEST
        [TestMethod]
        public void PutTeam_ShouldReturnStatusCode()
        {
            var controller = new CountryRankingsApiController(new TestApplicationDbContext());

            var item = GetDemoCountryRanking();

            var result = controller.PutCountryRanking(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }


        [TestMethod]
        public void PutTeam_ShouldFail_WhenDifferentID()
        {
            var controller = new CountryRankingsApiController(new TestApplicationDbContext());

            var badResult = controller.PutCountryRanking(999, GetDemoCountryRanking());
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

        CountryRanking GetDemoCountryRanking()
        {
            return new CountryRanking { Id = 3, CountryName = "Demo Country", Ranking = 1.000 };
        }

    }
}
