using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KrishiJagarnDigitalSystem.Models;

namespace KrishiJagarnDigitalSystem.Controllers
{
    public class FormerDetailsController : Controller
    {
        private KrishiEntities db = new KrishiEntities();

        // GET: FormerDetails
        public ActionResult Index()
        {
            var formerDetails = db.FormerDetails.Include(f => f.CropDetail).Include(f => f.CropePriceDetail);
            return View(formerDetails.ToList());
        }

        // GET: FormerDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormerDetail formerDetail = db.FormerDetails.Find(id);
            if (formerDetail == null)
            {
                return HttpNotFound();
            }
            return View(formerDetail);
        }

        // GET: FormerDetails/Create
        public ActionResult Create()
        {
            ViewBag.Crope_id = new SelectList(db.CropDetails, "id", "CropName");
            ViewBag.Price_id = new SelectList(db.CropePriceDetails, "id", "SellingMandiName");
            return View();
        }

        // POST: FormerDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FirstName,LastName,Address,Crope_id,Price_id,Age")] FormerDetail formerDetail)
        {
            if (ModelState.IsValid)
            {
                db.FormerDetails.Add(formerDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Crope_id = new SelectList(db.CropDetails, "id", "CropName", formerDetail.Crope_id);
            ViewBag.Price_id = new SelectList(db.CropePriceDetails, "id", "SellingMandiName", formerDetail.Price_id);
            return View(formerDetail);
        }

        // GET: FormerDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormerDetail formerDetail = db.FormerDetails.Find(id);
            if (formerDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.Crope_id = new SelectList(db.CropDetails, "id", "CropName", formerDetail.Crope_id);
            ViewBag.Price_id = new SelectList(db.CropePriceDetails, "id", "SellingMandiName", formerDetail.Price_id);
            return View(formerDetail);
        }

        // POST: FormerDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstName,LastName,Address,Crope_id,Price_id,Age")] FormerDetail formerDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formerDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Crope_id = new SelectList(db.CropDetails, "id", "CropName", formerDetail.Crope_id);
            ViewBag.Price_id = new SelectList(db.CropePriceDetails, "id", "SellingMandiName", formerDetail.Price_id);
            return View(formerDetail);
        }

        // GET: FormerDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormerDetail formerDetail = db.FormerDetails.Find(id);
            if (formerDetail == null)
            {
                return HttpNotFound();
            }
            return View(formerDetail);
        }

        // POST: FormerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormerDetail formerDetail = db.FormerDetails.Find(id);
            db.FormerDetails.Remove(formerDetail);
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
