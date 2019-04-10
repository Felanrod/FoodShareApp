using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodShareApp.Controllers
{
    [Authorize(Roles="SuperAdmin, Admin")]
    public class DashboardController : Controller
    {
        private DbFoodShare db = new DbFoodShare();

        // GET: Dashboard
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            Models.DashboardViewModel myModel = new Models.DashboardViewModel
            {
                foodProvider = db.FoodProviders.ToList(),
                food = db.Foods.ToList().Where(f => f.FoodProviderId == userId)
            };
            return View(myModel);
        }

        public ActionResult Notifications(string User)
        {
            ViewBag.UserName = User;
            var foodProviders = db.FoodProviders;
            return View(foodProviders.ToList());
        }
    }
}