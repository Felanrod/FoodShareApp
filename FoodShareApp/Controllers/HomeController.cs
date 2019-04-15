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
            List<FoodProvider> foodProviders;
            if (Request.IsAuthenticated)
            {
                // random assortment of providers can be viewed 
                foodProviders = db.FoodProviders.OrderBy(f => Guid.NewGuid()).Take(3).ToList();
            }
            else
            {
                // if not logged in, first three providers only possible to view
                foodProviders = db.FoodProviders.OrderByDescending(f => f.FoodProviderId).Take(3).ToList();
            }
            return View(foodProviders);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us.";

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
    }
}