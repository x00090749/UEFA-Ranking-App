using System.Web.Mvc;

namespace UefaServiceV9.Controllers.MVC.Admin_Index
{
    public class HomeController : Controller
    {

        [AllowAnonymous]
        [RequireHttps]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "canEdit")]
        public ActionResult Admin()
        {
            ViewBag.Message = "Select a section of the UEFA Ranking system to administrate";

            return View();
        }
    }
}