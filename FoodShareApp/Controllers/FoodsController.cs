using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodShareApp;
using Microsoft.AspNet.Identity;

namespace FoodShareApp.Views
{
    public class FoodsController : Controller
    {
        private DbFoodShare db = new DbFoodShare();

        // GET: Foods
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var foods = db.Foods.Include(f => f.FoodType).Where(f => f.FoodProviderId == userId);
            //foods = foods.Where(f => f.FoodProviderId.Equals(User.Identity.GetUserId()));
            return View(foods.ToList());
        }

        // GET: Foods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }


        // GET: Foods/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            ViewBag.RightNow = DateTime.Now;
            ViewBag.FoodProviderId = userId;
            ViewBag.FoodTypeId = new SelectList(db.FoodTypes, "FoodTypeId", "FoodType1");
            ViewBag.FoodAmountId = new SelectList(db.FoodAmounts, "FoodAmountId", "FoodAmount1");
            return View();
        }

        // POST: Foods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodId,FoodName,FoodTypeId,FoodAmountId,Urgent,Notes")] Food food)
        {
            var userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                food.FoodProviderId = userId;
                food.DateCreated = DateTime.Now;
                db.Foods.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodProviderId = userId;
            ViewBag.FoodTypeId = new SelectList(db.FoodTypes, "FoodTypeId", "FoodType1", food.FoodTypeId);
            return View(food);
        }

        // GET: Foods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodTypeId = new SelectList(db.FoodTypes, "FoodTypeId", "FoodType1", food.FoodTypeId);
            return View(food);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodId,FoodName,FoodProviderId,FoodTypeId,FoodAmountId,Urgent,Notes,DateCreated")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodTypeId = new SelectList(db.FoodTypes, "FoodTypeId", "FoodType1", food.FoodTypeId);
            return View(food);
        }

        // GET: Foods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
