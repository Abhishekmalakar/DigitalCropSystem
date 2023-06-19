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
    public class CropDetailsController : Controller
    {
        private KrishiEntities db = new KrishiEntities();

        // GET: CropDetails
        public ActionResult Index()
        {
            return View(db.CropDetails.ToList());
        }

        // GET: CropDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropDetail cropDetail = db.CropDetails.Find(id);
            if (cropDetail == null)
            {
                return HttpNotFound();
            }
            return View(cropDetail);
        }

        // GET: CropDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CropDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CropName,CropVariety,CropSeasion")] CropDetail cropDetail)
        {
            if (ModelState.IsValid)
            {
                db.CropDetails.Add(cropDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cropDetail);
        }

        // GET: CropDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropDetail cropDetail = db.CropDetails.Find(id);
            if (cropDetail == null)
            {
                return HttpNotFound();
            }
            return View(cropDetail);
        }

        // POST: CropDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CropName,CropVariety,CropSeasion")] CropDetail cropDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cropDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cropDetail);
        }

        // GET: CropDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropDetail cropDetail = db.CropDetails.Find(id);
            if (cropDetail == null)
            {
                return HttpNotFound();
            }
            return View(cropDetail);
        }

        // POST: CropDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CropDetail cropDetail = db.CropDetails.Find(id);
            db.CropDetails.Remove(cropDetail);
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
