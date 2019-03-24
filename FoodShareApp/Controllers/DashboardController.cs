using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodShareApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private DbFoodShare db = new DbFoodShare();

        // GET: TestDash
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
    }
}