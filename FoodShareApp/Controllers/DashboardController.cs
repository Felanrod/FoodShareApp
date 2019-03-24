using FoodShareApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodShareApp.Controllers
{
    public class DashboardController : Controller
    {
        private AdminDashboardModel adminModel = new AdminDashboardModel();
        // GET: Dashboard
        public ActionResult Index()
        {
            //var adminDashboardModels = new AdminDashboardModel();
            ////adminDashboardModels.AllFoodProviders = List<db.FoodProviders>;
            //var foodProviders = db.FoodProviders;
            //var userId = User.Identity.GetUserId();
            //var foods = db.Foods.Where(f => f.FoodProviderId == userId);

            //var dashModel = new AdminDashboardModel { AllFoodProviders = foodProviders.ToList(), AllFoods = foods.ToList() };
            //return View(dashModel);
            //var foodProviders = db.FoodProviders;
            //var userId = User.Identity.GetUserId();
            //var foods = db.Foods.Where(f => f.FoodProviderId == userId);
            //var dashModel = new 
            //var dashModel = new AdminDashboardModel { foodProviders.ToList(), AllFoods = foods.ToList() };
            //adminModel.AllFoodProviders = GetFoodProviders();
            var dashModel = adminModel;
            return View(adminModel);
        }
        //public ActionResult Details(string id)
        //{
        //    var dashModel = new AdminDashboardModel
        //}
    }
}