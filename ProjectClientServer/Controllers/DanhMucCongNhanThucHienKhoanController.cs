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
    public class DanhMucCongNhanThucHienKhoanController : Controller
    {
        private ProjectClientServerDbContext db = new ProjectClientServerDbContext();

        // GET: DanhMucCongNhanThucHienKhoan
        public ActionResult Index()
        {
            return View(db.DanhMucCongNhanThucHienKhoans.ToList());
        }

        // GET: DanhMucCongNhanThucHienKhoan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucCongNhanThucHienKhoan danhMucCongNhanThucHienKhoan = db.DanhMucCongNhanThucHienKhoans.Find(id);
            if (danhMucCongNhanThucHienKhoan == null)
            {
                return HttpNotFound();
            }
            return View(danhMucCongNhanThucHienKhoan);
        }

        // GET: DanhMucCongNhanThucHienKhoan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMucCongNhanThucHienKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDanhMucCNTHK,SoLuong,LaKhoanChung")] DanhMucCongNhanThucHienKhoan danhMucCongNhanThucHienKhoan)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucCongNhanThucHienKhoans.Add(danhMucCongNhanThucHienKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhMucCongNhanThucHienKhoan);
        }

        // GET: DanhMucCongNhanThucHienKhoan/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucCongNhanThucHienKhoan danhMucCongNhanThucHienKhoan = db.DanhMucCongNhanThucHienKhoans.Find(id);
            if (danhMucCongNhanThucHienKhoan == null)
            {
                return HttpNotFound();
            }
            return View(danhMucCongNhanThucHienKhoan);
        }

        // POST: DanhMucCongNhanThucHienKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDanhMucCNTHK,SoLuong,LaKhoanChung")] DanhMucCongNhanThucHienKhoan danhMucCongNhanThucHienKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMucCongNhanThucHienKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMucCongNhanThucHienKhoan);
        }

        // GET: DanhMucCongNhanThucHienKhoan/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucCongNhanThucHienKhoan danhMucCongNhanThucHienKhoan = db.DanhMucCongNhanThucHienKhoans.Find(id);
            if (danhMucCongNhanThucHienKhoan == null)
            {
                return HttpNotFound();
            }
            return View(danhMucCongNhanThucHienKhoan);
        }

        // POST: DanhMucCongNhanThucHienKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DanhMucCongNhanThucHienKhoan danhMucCongNhanThucHienKhoan = db.DanhMucCongNhanThucHienKhoans.Find(id);
            db.DanhMucCongNhanThucHienKhoans.Remove(danhMucCongNhanThucHienKhoan);
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
