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
    public class NKSLKController : Controller
    {
        private ProjectClientServerDbContext db = new ProjectClientServerDbContext();

        // GET: NKSLK
        public ActionResult Index()
        {
            var nKSLKs = db.NKSLKs.Include(n => n.DanhMucCongNhanThucHienKhoan).Include(n => n.DanhMucCongViec);
            return View(nKSLKs.ToList());
        }

        // GET: NKSLK/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NKSLK nKSLK = db.NKSLKs.Find(id);
            if (nKSLK == null)
            {
                return HttpNotFound();
            }
            return View(nKSLK);
        }

        // GET: NKSLK/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhMucCNTHK = new SelectList(db.DanhMucCongNhanThucHienKhoans, "MaDanhMucCNTHK", "MaDanhMucCNTHK");
            ViewBag.MaDanhMucCongViec = new SelectList(db.DanhMucCongViecs, "MaDanhMucCongViec", "MaCongViec");
            return View();
        }

        // POST: NKSLK/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNK,NgayThucHienKhoan,GioBatDau,GioKetThuc,MaDanhMucCNTHK,MaDanhMucCongViec")] NKSLK nKSLK)
        {
            if (ModelState.IsValid)
            {
                db.NKSLKs.Add(nKSLK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDanhMucCNTHK = new SelectList(db.DanhMucCongNhanThucHienKhoans, "MaDanhMucCNTHK", "MaDanhMucCNTHK", nKSLK.MaDanhMucCNTHK);
            ViewBag.MaDanhMucCongViec = new SelectList(db.DanhMucCongViecs, "MaDanhMucCongViec", "MaCongViec", nKSLK.MaDanhMucCongViec);
            return View(nKSLK);
        }

        // GET: NKSLK/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NKSLK nKSLK = db.NKSLKs.Find(id);
            if (nKSLK == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhMucCNTHK = new SelectList(db.DanhMucCongNhanThucHienKhoans, "MaDanhMucCNTHK", "MaDanhMucCNTHK", nKSLK.MaDanhMucCNTHK);
            ViewBag.MaDanhMucCongViec = new SelectList(db.DanhMucCongViecs, "MaDanhMucCongViec", "MaCongViec", nKSLK.MaDanhMucCongViec);
            return View(nKSLK);
        }

        // POST: NKSLK/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNK,NgayThucHienKhoan,GioBatDau,GioKetThuc,MaDanhMucCNTHK,MaDanhMucCongViec")] NKSLK nKSLK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nKSLK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDanhMucCNTHK = new SelectList(db.DanhMucCongNhanThucHienKhoans, "MaDanhMucCNTHK", "MaDanhMucCNTHK", nKSLK.MaDanhMucCNTHK);
            ViewBag.MaDanhMucCongViec = new SelectList(db.DanhMucCongViecs, "MaDanhMucCongViec", "MaCongViec", nKSLK.MaDanhMucCongViec);
            return View(nKSLK);
        }

        // GET: NKSLK/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NKSLK nKSLK = db.NKSLKs.Find(id);
            if (nKSLK == null)
            {
                return HttpNotFound();
            }
            return View(nKSLK);
        }

        // POST: NKSLK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NKSLK nKSLK = db.NKSLKs.Find(id);
            db.NKSLKs.Remove(nKSLK);
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
