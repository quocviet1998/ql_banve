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
    }
}