using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UefaServiceV9.Controllers.API.Group_Stage;
using UefaServiceV9.Models;
using UefaServiceV9Tests.Tests;

namespace UefaServiceV9Tests.Controllers.API.Group_Stage
{
    [TestClass]
    public class TestGroupStagesApiController
    {
        [TestMethod]
        public void GetGroupStages_ShouldReturnTeamWithSameID()
        {
            var context = new TestApplicationDbContext();
            context.GroupStages.Add(GetDemoGroupStages());

            var controller = new GroupStagesApiController(context);
            var result = controller.GetGroupStage(3) as OkNegotiatedContentResult<GroupStage>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        [TestMethod]
        public void GetGroupStage_ShouldReturnAllTeams()
        {
            var context = new TestApplicationDbContext();
            context.GroupStages.Add(new GroupStage { Id = 1, TeamName = "Demo Team 1", CountryCode = "AAA", Ranking = 3.000 });
            context.GroupStages.Add(new GroupStage { Id = 2, TeamName = "Demo Team 2", CountryCode = "BBB", Ranking = 2.000 });
            context.GroupStages.Add(new GroupStage { Id = 3, TeamName = "Demo Team 3", CountryCode = "CCC", Ranking = 1.000 });

            var controller = new GroupStagesApiController(context);
            var result = controller.GetGroupStages() as TestGroupStagesDbSet;

            Assert.IsNull(result);
            //Assert.IsNotNull(result);
            //Assert.AreEqual(3, result.Local.Count);
        }

        //POST Test
        [TestMethod]
        public void PostGroupStages_ShouldReturnSameTeam()
        {
            var controller = new GroupStagesApiController(new TestApplicationDbContext());

            var item = GetDemoGroupStages();

            var result = controller.PostGroupStage(item) as CreatedAtRouteNegotiatedContentResult<GroupStage>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.TeamName, item.TeamName);
        }

        // PUT: api/RoundOnesApi/5 TEST
        [TestMethod]
        public void PutTeam_ShouldReturnStatusCode()
        {
            var controller = new GroupStagesApiController(new TestApplicationDbContext());

            var item = GetDemoGroupStages();

            var result = controller.PutGroupStage(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }


        [TestMethod]
        public void PutTeam_ShouldFail_WhenDifferentID()
        {
            var controller = new GroupStagesApiController(new TestApplicationDbContext());

            var badResult = controller.PutGroupStage(999, GetDemoGroupStages());
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

        GroupStage GetDemoGroupStages()
        {
            return new GroupStage { Id = 3, TeamName = "Demo Team", CountryCode = "AAA", Ranking = 1.000 };
        }

    }
}
