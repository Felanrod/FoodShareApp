using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodShareApp.Controllers
{
    public class HomeController : Controller
    {
        private DbFoodShare db = new DbFoodShare();

        public ActionResult Index()
        {
            var foodProviders = db.FoodProviders.OrderBy(f => Guid.NewGuid()).Take(3);
            return View(foodProviders);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Terms()
        {
            ViewBag.Message = "Terms of the Website.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About the FoodShare Map.";

            return View();
        }


        public ActionResult Legal()
        {
            ViewBag.Message = "Legal and Trademark.";

            return View();
        }


        public ActionResult Map()
        {
            ViewBag.Message = "Welcome to Jurassic Park.";

            return View();
        }
    }
}