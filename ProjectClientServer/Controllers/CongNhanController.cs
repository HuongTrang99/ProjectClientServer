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
    public class CongNhanController : Controller
    {
        private ProjectClientServerDbContext db = new ProjectClientServerDbContext();

        // GET: CongNhan
        public ActionResult Index()
        {
            return View(db.CongNhans.ToList());
        }

        // GET: CongNhan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongNhan congNhan = db.CongNhans.Find(id);
            if (congNhan == null)
            {
                return HttpNotFound();
            }
            return View(congNhan);
        }

        // GET: CongNhan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CongNhan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCongNhan,HoTen,NgayThangNamSinh,PhongBan,ChucVu,QueQuan,LuongHopDong,LuongBaoHiem,GioiTinh,TaiKhoan,MatKhau,LaAdmin")] CongNhan congNhan)
        {
            if (ModelState.IsValid)
            {
                db.CongNhans.Add(congNhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(congNhan);
        }

        // GET: CongNhan/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongNhan congNhan = db.CongNhans.Find(id);
            if (congNhan == null)
            {
                return HttpNotFound();
            }
            return View(congNhan);
        }

        // POST: CongNhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCongNhan,HoTen,NgayThangNamSinh,PhongBan,ChucVu,QueQuan,LuongHopDong,LuongBaoHiem,GioiTinh,TaiKhoan,MatKhau,LaAdmin")] CongNhan congNhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congNhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(congNhan);
        }

        // GET: CongNhan/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongNhan congNhan = db.CongNhans.Find(id);
            if (congNhan == null)
            {
                return HttpNotFound();
            }
            return View(congNhan);
        }

        // POST: CongNhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CongNhan congNhan = db.CongNhans.Find(id);
            db.CongNhans.Remove(congNhan);
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
