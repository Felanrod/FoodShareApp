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


namespace FoodShareApp.Controllers
{
    public class RequestersController : Controller
    {
        private DbFoodShare db = new DbFoodShare();

        // GET: Requesters
        public ActionResult Index()
        {
            return View(db.Requesters.ToList());
        }

        // GET: Requesters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requester requester = db.Requesters.Find(id);
            if (requester == null)
            {
                return HttpNotFound();
            }
            return View(requester);
        }

        // GET: Requesters/Create
        [Authorize(Roles = "Requester")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Requesters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Requester")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Email,Phone,Street,PostalCode,City,Province,Country")] Requester requester)
        {
            var id = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                requester.RequesterId = id;

                db.Requesters.Add(requester);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requester);
        }

        // GET: Requesters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requester requester = db.Requesters.Find(id);
            if (requester == null)
            {
                return HttpNotFound();
            }
            return View(requester);
        }

        // POST: Requesters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequesterId,Name,Email,Phone,Street,PostalCode,City,Province,Country")] Requester requester)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requester);
        }

        // GET: Requesters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requester requester = db.Requesters.Find(id);
            if (requester == null)
            {
                return HttpNotFound();
            }
            return View(requester);
        }

        // POST: Requesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requester requester = db.Requesters.Find(id);
            db.Requesters.Remove(requester);
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
        // GET: Requesters/Register
        //[Authorize(Roles = "Requester")]
        //public ActionResult Register()
        //{
        //    return View();
        //}

        //// POST: Requesters/Register
        //[Authorize(Roles = "Requester")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(FormCollection values)
        //{
        //    var requester = new Requester();
        //    TryUpdateModel(requester);

        //    string id = User.Identity.GetUserId();
        //    //requester.RequesterId = id;

        //    db.Requesters.Add(requester);
        //    db.SaveChanges();

        //    return RedirectToAction("Index", "Requesters");
        //}

    }
}
