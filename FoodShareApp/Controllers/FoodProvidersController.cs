using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodShareApp;

namespace FoodShareApp.Views
{
    public class FoodProvidersController : Controller
    {
        private DbFoodShare db = new DbFoodShare();

        // GET: FoodProviders
        public ActionResult Index()
        {
            return View(db.FoodProviders.ToList());
        }

        // GET: FoodProviders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodProvider foodProvider = db.FoodProviders.Find(id);
            if (foodProvider == null)
            {
                return HttpNotFound();
            }
            return View(foodProvider);
        }

        // GET: FoodProviders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodProviderId,Name,LogoUrl,Street,City,Province,Country,PostalCode,PhoneNumber,Email,Services,Website,Verified,Admin")] FoodProvider foodProvider)
        {
            if (ModelState.IsValid)
            {
                db.FoodProviders.Add(foodProvider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodProvider);
        }

        // GET: FoodProviders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodProvider foodProvider = db.FoodProviders.Find(id);
            if (foodProvider == null)
            {
                return HttpNotFound();
            }
            return View(foodProvider);
        }

        // POST: FoodProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodProviderId,Name,LogoUrl,Street,City,Province,Country,PostalCode,PhoneNumber,Email,Services,Website,Verified,Admin")] FoodProvider foodProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodProvider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodProvider);
        }

        // GET: FoodProviders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodProvider foodProvider = db.FoodProviders.Find(id);
            if (foodProvider == null)
            {
                return HttpNotFound();
            }
            return View(foodProvider);
        }

        // POST: FoodProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FoodProvider foodProvider = db.FoodProviders.Find(id);
            db.FoodProviders.Remove(foodProvider);
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
