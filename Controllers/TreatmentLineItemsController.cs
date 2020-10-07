using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200Hackett.DAL;
using MIS4200Hackett.Models;

namespace MIS4200Hackett.Controllers
{
    public class TreatmentLineItemsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: TreatmentLineItems
        public ActionResult Index()
        {
            var treatmentLineItems = db.TreatmentLineItems.Include(t => t.Patient).Include(t => t.Treatment);
            return View(treatmentLineItems.ToList());
        }

        // GET: TreatmentLineItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentLineItem treatmentLineItem = db.TreatmentLineItems.Find(id);
            if (treatmentLineItem == null)
            {
                return HttpNotFound();
            }
            return View(treatmentLineItem);
        }

        // GET: TreatmentLineItems/Create
        public ActionResult Create()
        {
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "description");
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "description");
            return View();
        }

        // POST: TreatmentLineItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderdetailID,qtyOrdered,price,TreatmentID,PatientID")] TreatmentLineItem treatmentLineItem)
        {
            if (ModelState.IsValid)
            {
                db.TreatmentLineItems.Add(treatmentLineItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "description", treatmentLineItem.PatientID);
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "description", treatmentLineItem.TreatmentID);
            return View(treatmentLineItem);
        }

        // GET: TreatmentLineItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentLineItem treatmentLineItem = db.TreatmentLineItems.Find(id);
            if (treatmentLineItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "description", treatmentLineItem.PatientID);
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "description", treatmentLineItem.TreatmentID);
            return View(treatmentLineItem);
        }

        // POST: TreatmentLineItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderdetailID,qtyOrdered,price,TreatmentID,PatientID")] TreatmentLineItem treatmentLineItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatmentLineItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "description", treatmentLineItem.PatientID);
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "description", treatmentLineItem.TreatmentID);
            return View(treatmentLineItem);
        }

        // GET: TreatmentLineItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentLineItem treatmentLineItem = db.TreatmentLineItems.Find(id);
            if (treatmentLineItem == null)
            {
                return HttpNotFound();
            }
            return View(treatmentLineItem);
        }

        // POST: TreatmentLineItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TreatmentLineItem treatmentLineItem = db.TreatmentLineItems.Find(id);
            db.TreatmentLineItems.Remove(treatmentLineItem);
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
