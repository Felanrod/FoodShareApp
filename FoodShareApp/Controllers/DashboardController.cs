using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using FoodShareApp.Models;

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
            ViewBag.UserId = userId;
            Models.DashboardViewModel myModel = new Models.DashboardViewModel
            {
                foodProvider = db.FoodProviders.ToList(),
                food = db.Foods.ToList().Where(f => f.FoodProviderId == userId),
                events = db.Events.ToList()
            };



            return View(myModel);
        }

        // Post Dashboard 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string UserId, ApplicationDbContext application)
        {
            //_applicationDb = application;
            if (ModelState.IsValid)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(application));
                var user = userManager.FindById(UserId);
                // var user = _applicationDb.Users.Find(UserId);

                var roleId = user.Roles.SingleOrDefault().RoleId;
                var roleName = application.Roles.SingleOrDefault(r => r.Id == roleId).Name;

                userManager.RemoveFromRole(UserId, roleName);
                userManager.AddToRole(UserId, "Admin");

                FoodProvider Provider = db.FoodProviders.FirstOrDefault(f => f.FoodProviderId == UserId);
                Provider.Admin = true;
                db.SaveChanges();

                application.Entry(user).State = System.Data.Entity.EntityState.Modified;

            var userId = User.Identity.GetUserId();
            ViewBag.userId = userId.ToString();
            Models.DashboardViewModel myModel = new Models.DashboardViewModel
            {
                foodProvider = db.FoodProviders.ToList(),
                food = db.Foods.ToList().Where(f => f.FoodProviderId == userId),
                events = db.Events.ToList()
            };
                // return RedirectToAction("../Home");
                return View(myModel);
            }




            return View();

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

        // GET: Dashboard/DeleteEvent
        public ActionResult DeleteFood(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return Redirect("../Events/Delete");
        }

        // GET: Dashboard/CreateFood
        public ActionResult CreateFood()
        {
            return Redirect("../Foods/Create");
        }

    }
}