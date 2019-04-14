using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            ViewBag.userId = userId.ToString();
            Models.DashboardViewModel myModel = new Models.DashboardViewModel
            {
                foodProvider = db.FoodProviders.ToList(),
                food = db.Foods.ToList().Where(f => f.FoodProviderId == userId),
                events = db.Events.ToList()
            };
            return View(myModel);
        }

        public ActionResult Notifications(string User)
        {
            ViewBag.UserName = User;
            var foodProviders = db.FoodProviders;
            return View(foodProviders.ToList());
        }

        // GET: Dashboard/CreateEvent
        public ActionResult CreateEvent()
        {
            return Redirect("../Events/Create");
        }

        // GET: Dashboard/EditEvent/5
        public ActionResult EditEvent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Event @event = db.Events.Find(id);
            //if (@event == null)
            //{
            //    return HttpNotFound();
            //}
            return Redirect("../../Events/Edit/"+id);
        }
    }
}