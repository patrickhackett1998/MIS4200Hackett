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
    public class LineItemsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: LineItems
        public ActionResult Index()
        {
            var lineItems = db.LineItems.Include(l => l.orders).Include(l => l.Product);
            return View(lineItems.ToList());
        }

        // GET: LineItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineItem lineItem = db.LineItems.Find(id);
            if (lineItem == null)
            {
                return HttpNotFound();
            }
            return View(lineItem);
        }

        // GET: LineItems/Create
        public ActionResult Create()
        {
            ViewBag.orderID = new SelectList(db.orders, "orderID", "description");
            ViewBag.productID = new SelectList(db.Products, "productID", "description");
            return View();
        }

        // POST: LineItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderdetailID,qtyOrdered,price,productID,orderID")] LineItem lineItem)
        {
            if (ModelState.IsValid)
            {
                db.LineItems.Add(lineItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.orderID = new SelectList(db.orders, "orderID", "description", lineItem.orderID);
            ViewBag.productID = new SelectList(db.Products, "productID", "description", lineItem.productID);
            return View(lineItem);
        }

        // GET: LineItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineItem lineItem = db.LineItems.Find(id);
            if (lineItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.orderID = new SelectList(db.orders, "orderID", "description", lineItem.orderID);
            ViewBag.productID = new SelectList(db.Products, "productID", "description", lineItem.productID);
            return View(lineItem);
        }

        // POST: LineItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderdetailID,qtyOrdered,price,productID,orderID")] LineItem lineItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.orderID = new SelectList(db.orders, "orderID", "description", lineItem.orderID);
            ViewBag.productID = new SelectList(db.Products, "productID", "description", lineItem.productID);
            return View(lineItem);
        }

        // GET: LineItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineItem lineItem = db.LineItems.Find(id);
            if (lineItem == null)
            {
                return HttpNotFound();
            }
            return View(lineItem);
        }

        // POST: LineItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LineItem lineItem = db.LineItems.Find(id);
            db.LineItems.Remove(lineItem);
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
