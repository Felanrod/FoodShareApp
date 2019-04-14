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


        // get notifications
        [Authorize(Roles = "Requester")]
        public ActionResult Notifications()
        {
            var RequesterId = User.Identity.GetUserId();


            List<Notification> RequesterNotifications = db.Notifications.Where(m => m.ToId == RequesterId).ToList();

            var Providers = new List<FoodProvider>();

            foreach(var item in RequesterNotifications)
            {
                var providerId = item.FromId;
                FoodProvider Provider = db.FoodProviders.FirstOrDefault(m => m.FoodProviderId == providerId);
                Providers.Add(Provider);
            }
            ViewBag.Providers = Providers;

            return View(RequesterNotifications);
        }

        // post notifications 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Notifications(int id)
        {
            Notification notification = db.Notifications.Find(id);
            db.Notifications.Remove(notification);
            db.SaveChanges();

            return RedirectToAction("Notifications");
        }



    }
}
