using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        LoadDBData load = new LoadDBData();
        public ActionResult Index()
        {
            //Session["Admin"] = null;
            if (Session["Admin"] == null)
                return RedirectToAction("Login", "Admin");
            return View();
        }

        public ActionResult Xe()
        {
            ViewBag.result = load.loadTable("Xe");
            return View();
        }

        public ActionResult TuyenXe()
        {
            ViewBag.result = load.loadTable("TuyenXe");
            return View();
        }

        public ActionResult NhanVien()
        {
            ViewBag.result = load.loadTable("NhanVien");
            return View();
        }

        public ActionResult KhachHang()
        {
            ViewBag.result = load.loadTable("KhachHang");
            return View();
        }

        public ActionResult ChuyenXe()
        {
            ViewBag.result = load.loadTable("ChuyenXe");
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult checkAccount(string user_login, string password)
        {
            string str = "";
            var res = load.login(new string[] { user_login, password });
            if (res == 0)
            {
                str = "Đăng nhập thất bại! Tên đăng nhập hoặc mật khẩu không chính xác";
                TempData["temp"] = str;
            }
            else if (res == 2)
            {
                //string[] KH = load.getInfoKH(new string[] { user_login });
                Session["Admin"] = res.ToString();
                return RedirectToAction("Index","Admin");
            }
            return RedirectToAction("Login","Admin");
        }
    }
}