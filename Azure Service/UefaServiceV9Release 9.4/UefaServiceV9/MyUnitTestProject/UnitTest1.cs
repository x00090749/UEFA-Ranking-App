using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UefaServiceV9.Controllers.API.Qualifying;
using UefaServiceV9.Models;

namespace MyUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            RoundOnesApiController rc = new RoundOnesApiController();

            RoundOnesApiController rc2 = new RoundOnesApiController();

            //IHttpActionResult actionResult = rc.GetRoundOne(1);

            IHttpActionResult roundOne = rc.GetRoundOne(1);

            //IHttpActionResult result = await rc.Get();

            //arrange

            var controller = new RoundOnesApiController();

            //act

            var actionResult = controller.GetRoundOne(1); //1

            //var actionResult2 = db.RoundOnes.Find(1);

            //assert

            //Assert.IsInstanceOfType(actionResult2, typeof(NotFoundResult));

            //var response = actionResult as OkNegotiatedContentResult<RoundOne>;

            //Assert.IsNotNull(response);

            //Assert.AreEqual(1, response.Content.Id);


            /*
                 // GET api/books
   2: public IHttpActionResult Get()
   3: {
   4:     return Ok(_repo.GetBooks().AsEnumerable());
   5: }
   6:  
   7: // GET api/books/5
   8: public IHttpActionResult Get(int id)
   9: {
  10:     var book = _repo.GetBook(id);
  11:  
  12:     if (book == null)
  13:     {
  14:         return NotFound();
  15:     }
  16:  
  17:     return Ok(book);
  18: }
                 * */

            //bool expected = true;
            //bool actual = cpd.Equals(roundOne);

            //Assert.IsInstanceOfType(actionResult, typeof(OkResult));

            //RoundOne roundOne = db.RoundOnes.Find(id);

            //roundOne.Id = 1;

            //Assert.AreEqual(expected, actual);

            //Assert.AreEqual(roundOne, cpd);

        }
    }
}
