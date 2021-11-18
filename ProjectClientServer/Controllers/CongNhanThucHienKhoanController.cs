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
    public class CongNhanThucHienKhoanController : Controller
    {
        private ProjectClientServerDbContext db = new ProjectClientServerDbContext();

        // GET: CongNhanThucHienKhoan
        public ActionResult Index()
        {
            var congNhanThucHienKhoans = db.CongNhanThucHienKhoans.Include(c => c.CongNhan).Include(c => c.DanhMucCongNhanThucHienKhoan);
            return View(congNhanThucHienKhoans.ToList());
        }

        // GET: CongNhanThucHienKhoan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongNhanThucHienKhoan congNhanThucHienKhoan = db.CongNhanThucHienKhoans.Find(id);
            if (congNhanThucHienKhoan == null)
            {
                return HttpNotFound();
            }
            return View(congNhanThucHienKhoan);
        }

        // GET: CongNhanThucHienKhoan/Create
        public ActionResult Create()
        {
            ViewBag.MaCongNhan = new SelectList(db.CongNhans, "MaCongNhan", "HoTen");
            ViewBag.MaDanhMucCNTHK = new SelectList(db.DanhMucCongNhanThucHienKhoans, "MaDanhMucCNTHK", "MaDanhMucCNTHK");
            return View();
        }

        // POST: CongNhanThucHienKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDanhMucCNTHK,MaCongNhan,ThoiGianBatDau,ThoiGianKetThuc")] CongNhanThucHienKhoan congNhanThucHienKhoan)
        {
            if (ModelState.IsValid)
            {
                db.CongNhanThucHienKhoans.Add(congNhanThucHienKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCongNhan = new SelectList(db.CongNhans, "MaCongNhan", "HoTen", congNhanThucHienKhoan.MaCongNhan);
            ViewBag.MaDanhMucCNTHK = new SelectList(db.DanhMucCongNhanThucHienKhoans, "MaDanhMucCNTHK", "MaDanhMucCNTHK", congNhanThucHienKhoan.MaDanhMucCNTHK);
            return View(congNhanThucHienKhoan);
        }

        // GET: CongNhanThucHienKhoan/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongNhanThucHienKhoan congNhanThucHienKhoan = db.CongNhanThucHienKhoans.Find(id);
            if (congNhanThucHienKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCongNhan = new SelectList(db.CongNhans, "MaCongNhan", "HoTen", congNhanThucHienKhoan.MaCongNhan);
            ViewBag.MaDanhMucCNTHK = new SelectList(db.DanhMucCongNhanThucHienKhoans, "MaDanhMucCNTHK", "MaDanhMucCNTHK", congNhanThucHienKhoan.MaDanhMucCNTHK);
            return View(congNhanThucHienKhoan);
        }

        // POST: CongNhanThucHienKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDanhMucCNTHK,MaCongNhan,ThoiGianBatDau,ThoiGianKetThuc")] CongNhanThucHienKhoan congNhanThucHienKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congNhanThucHienKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCongNhan = new SelectList(db.CongNhans, "MaCongNhan", "HoTen", congNhanThucHienKhoan.MaCongNhan);
            ViewBag.MaDanhMucCNTHK = new SelectList(db.DanhMucCongNhanThucHienKhoans, "MaDanhMucCNTHK", "MaDanhMucCNTHK", congNhanThucHienKhoan.MaDanhMucCNTHK);
            return View(congNhanThucHienKhoan);
        }

        // GET: CongNhanThucHienKhoan/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongNhanThucHienKhoan congNhanThucHienKhoan = db.CongNhanThucHienKhoans.Find(id);
            if (congNhanThucHienKhoan == null)
            {
                return HttpNotFound();
            }
            return View(congNhanThucHienKhoan);
        }

        // POST: CongNhanThucHienKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CongNhanThucHienKhoan congNhanThucHienKhoan = db.CongNhanThucHienKhoans.Find(id);
            db.CongNhanThucHienKhoans.Remove(congNhanThucHienKhoan);
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
