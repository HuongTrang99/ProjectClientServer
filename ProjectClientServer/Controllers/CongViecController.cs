using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectClientServer.Model;

namespace ProjectClientServer.Controllers
{
    public class CongViecController : Controller
    {
        private ProjectClientServerDbContext db = new ProjectClientServerDbContext();

        // GET: CongViec
        public ActionResult Index()
        {
            return View(db.CongViecs.ToList());
        }

        // GET: CongViec/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongViec congViec = db.CongViecs.Find(id);
            if (congViec == null)
            {
                return HttpNotFound();
            }
            return View(congViec);
        }

        // GET: CongViec/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CongViec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCongViec,TenCongViec,DinhMucKhoan,DonViKhoan,HeSoKhoan,DinhMucLaoDong,DonGia")] CongViec congViec)
        {
            if (ModelState.IsValid)
            {
                db.CongViecs.Add(congViec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(congViec);
        }

        // GET: CongViec/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongViec congViec = db.CongViecs.Find(id);
            if (congViec == null)
            {
                return HttpNotFound();
            }
            return View(congViec);
        }

        // POST: CongViec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCongViec,TenCongViec,DinhMucKhoan,DonViKhoan,HeSoKhoan,DinhMucLaoDong,DonGia")] CongViec congViec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congViec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(congViec);
        }

        // GET: CongViec/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongViec congViec = db.CongViecs.Find(id);
            if (congViec == null)
            {
                return HttpNotFound();
            }
            return View(congViec);
        }

        // POST: CongViec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CongViec congViec = db.CongViecs.Find(id);
            db.CongViecs.Remove(congViec);
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
