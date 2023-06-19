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
    public class CropePriceDetailsController : Controller
    {
        private KrishiEntities db = new KrishiEntities();

        // GET: CropePriceDetails
        public ActionResult Index()
        {
            return View(db.CropePriceDetails.ToList());
        }

        // GET: CropePriceDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropePriceDetail cropePriceDetail = db.CropePriceDetails.Find(id);
            if (cropePriceDetail == null)
            {
                return HttpNotFound();
            }
            return View(cropePriceDetail);
        }

        // GET: CropePriceDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CropePriceDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,SellingMandiName,CropePrice,TotalWeight,Year")] CropePriceDetail cropePriceDetail)
        {
            if (ModelState.IsValid)
            {
                db.CropePriceDetails.Add(cropePriceDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cropePriceDetail);
        }

        // GET: CropePriceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropePriceDetail cropePriceDetail = db.CropePriceDetails.Find(id);
            if (cropePriceDetail == null)
            {
                return HttpNotFound();
            }
            return View(cropePriceDetail);
        }

        // POST: CropePriceDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,SellingMandiName,CropePrice,TotalWeight,Year")] CropePriceDetail cropePriceDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cropePriceDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cropePriceDetail);
        }

        // GET: CropePriceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropePriceDetail cropePriceDetail = db.CropePriceDetails.Find(id);
            if (cropePriceDetail == null)
            {
                return HttpNotFound();
            }
            return View(cropePriceDetail);
        }

        // POST: CropePriceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CropePriceDetail cropePriceDetail = db.CropePriceDetails.Find(id);
            db.CropePriceDetails.Remove(cropePriceDetail);
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
