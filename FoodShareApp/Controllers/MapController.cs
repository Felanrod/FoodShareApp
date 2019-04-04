using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodShareApp.Controllers
{
    public class MapController : Controller
    {
        private DbFoodShare db = new DbFoodShare();
        // GET: Map
        public ActionResult Index()
        {
            Models.DashboardViewModel mapModel = new Models.DashboardViewModel
            {
                foodProvider = db.FoodProviders.ToList(),
                food = db.Foods.ToList()
            };
            return View(mapModel);
        }
    }
}