using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarPark.Models;

namespace CarPark.Controllers
{
    public class BookingReservationsController : Controller
    {
        private CarParkDBContext db = new CarParkDBContext();

        // GET: BookingReservations
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
        }

        // GET: BookingReservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingReservation bookingReservation = db.Bookings.Find(id);
            if (bookingReservation == null)
            {
                return HttpNotFound();
            }
            return View(bookingReservation);
        }

        // GET: BookingReservations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingReservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,AreaCode,TimeIn,TimeOut")] BookingReservation bookingReservation)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(bookingReservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookingReservation);
        }

        // GET: BookingReservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingReservation bookingReservation = db.Bookings.Find(id);
            if (bookingReservation == null)
            {
                return HttpNotFound();
            }
            return View(bookingReservation);
        }

        // POST: BookingReservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,AreaCode,TimeIn,TimeOut")] BookingReservation bookingReservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingReservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingReservation);
        }

        // GET: BookingReservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingReservation bookingReservation = db.Bookings.Find(id);
            if (bookingReservation == null)
            {
                return HttpNotFound();
            }
            return View(bookingReservation);
        }

        // POST: BookingReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingReservation bookingReservation = db.Bookings.Find(id);
            db.Bookings.Remove(bookingReservation);
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
