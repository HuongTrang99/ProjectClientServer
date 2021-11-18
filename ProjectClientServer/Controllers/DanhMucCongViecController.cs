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
    public class DanhMucCongViecController : Controller
    {
        private ProjectClientServerDbContext db = new ProjectClientServerDbContext();

        // GET: DanhMucCongViec
        public ActionResult Index()
        {
            var danhMucCongViecs = db.DanhMucCongViecs.Include(d => d.CongViec).Include(d => d.SanPham);
            return View(danhMucCongViecs.ToList());
        }

        // GET: DanhMucCongViec/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucCongViec danhMucCongViec = db.DanhMucCongViecs.Find(id);
            if (danhMucCongViec == null)
            {
                return HttpNotFound();
            }
            return View(danhMucCongViec);
        }

        // GET: DanhMucCongViec/Create
        public ActionResult Create()
        {
            ViewBag.MaCongViec = new SelectList(db.CongViecs, "MaCongViec", "TenCongViec");
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: DanhMucCongViec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDanhMucCongViec,MaCongViec,SoLuongDatDuoc,SoLoSanPham,MaSanPham")] DanhMucCongViec danhMucCongViec)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucCongViecs.Add(danhMucCongViec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCongViec = new SelectList(db.CongViecs, "MaCongViec", "TenCongViec", danhMucCongViec.MaCongViec);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", danhMucCongViec.MaSanPham);
            return View(danhMucCongViec);
        }

        // GET: DanhMucCongViec/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucCongViec danhMucCongViec = db.DanhMucCongViecs.Find(id);
            if (danhMucCongViec == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCongViec = new SelectList(db.CongViecs, "MaCongViec", "TenCongViec", danhMucCongViec.MaCongViec);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", danhMucCongViec.MaSanPham);
            return View(danhMucCongViec);
        }

        // POST: DanhMucCongViec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDanhMucCongViec,MaCongViec,SoLuongDatDuoc,SoLoSanPham,MaSanPham")] DanhMucCongViec danhMucCongViec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMucCongViec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCongViec = new SelectList(db.CongViecs, "MaCongViec", "TenCongViec", danhMucCongViec.MaCongViec);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", danhMucCongViec.MaSanPham);
            return View(danhMucCongViec);
        }

        // GET: DanhMucCongViec/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucCongViec danhMucCongViec = db.DanhMucCongViecs.Find(id);
            if (danhMucCongViec == null)
            {
                return HttpNotFound();
            }
            return View(danhMucCongViec);
        }

        // POST: DanhMucCongViec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DanhMucCongViec danhMucCongViec = db.DanhMucCongViecs.Find(id);
            db.DanhMucCongViecs.Remove(danhMucCongViec);
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
