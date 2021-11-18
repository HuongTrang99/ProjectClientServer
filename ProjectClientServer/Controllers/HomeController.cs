using ProjectClientServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectClientServer.Controllers
{
    public class HomeController : Controller
    {
        ProjectClientServerDbContext db = new ProjectClientServerDbContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string taikhoan, string matkhau)
        {
            CongNhan cn = new ProjectClientServerDbContext().CongNhans.SingleOrDefault(x => x.TaiKhoan == taikhoan && x.MatKhau == matkhau);
            if (cn != null)
            {
                Session["MaCongNhan"] = cn.MaCongNhan;
                Session["TaiKhoan"] = cn.TaiKhoan;
                return RedirectToAction("Index");
            }
            ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu!";
            return View();
        }
    }
}