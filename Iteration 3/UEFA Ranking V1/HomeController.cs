using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UEFA_Ranking_V1.Models;

namespace UEFA_Ranking_V1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        [HttpGet]
        public ActionResult Calculate()
        {
            ViewBag.CountrySelect = new SelectList(Enum.GetValues(typeof(TeamDescriptions)).Cast<TeamDescriptions>());
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(Team service)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", service);
            }
            else
            {
                ViewBag.CountrySelect = new SelectList(Enum.GetValues(typeof(TeamDescriptions)).Cast<TeamDescriptions>());
                return View(service);
            }
        }

        // show confirmation
        public ActionResult Confirm(Team service)
        {
            return View(service);
        }



    }
}
