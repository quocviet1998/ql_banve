using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        LoadDBData db = new LoadDBData();
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Search(SearchModels key)
        //{

        //    ViewBag.result = db.search(new string[] { key.startPoint == "" ? "Hồ Chí Minh" : key.startPoint, key.endPoint, key.startDate });
        //    return View();
        //}

        public ActionResult Login()
        {

            return View();
        }

        public ActionResult checkAccount(string user_login, string password)
        {
            var res = db.login(new string[] { user_login, password });
            if (res == "3")
            {
                return View();//chuyen toi trang thong tin ve cua khach hang
            }
            else
               return RedirectToAction("Login","Home");
        }

        public ActionResult SignIn(SigninModels val)
        {
            //var res = db.signin(new string[] { val.tenKH, val.ngaySinh, val.gioiTinh.ToString(), val.diaChi, val.cmnd, val.dienThoai, val.email, val.username, val.password });
            //ViewBag.res = res;
            return View();
        }


    }
}