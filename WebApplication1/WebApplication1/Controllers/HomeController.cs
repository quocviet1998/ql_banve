using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
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

        private SelectList EmptySeat(string maChuyen)
        {
            DataTable tableEmptySeat = db.EmptySeat(maChuyen);
            int soGhe = db.SoGhe(maChuyen);
            List<int> listEmptySeat = new List<int>();
            for (int i = 0; i < soGhe; i++)
            {
                if (tableEmptySeat.Rows.Contains(i))
                    break;
                else
                   listEmptySeat.Add(i+1);
            }
            SelectList select = new SelectList(listEmptySeat);
            return select;
        }

        public ActionResult Search(SearchModels key)
        {

            DataTable rs = db.search(new string[] { key.startPoint == "" ? "Hồ Chí Minh" : key.startPoint, key.endPoint, key.startDate });
            for (int i = 0; i < rs.Rows.Count; i++)
            {
                rs.Rows[i][8] = EmptySeat(rs.Rows[i][8].ToString());
            }
            ViewBag.result = rs;
            return View();
        }

        public ActionResult Login(string str)
        {
            ViewBag.str = str;
            return View();
        }

        public ActionResult checkAccount(string user_login, string password)
        {
           
            string str = "";
            var res = db.login(new string[] { user_login, password });
            if (res == 0) {
                str = "Đăng nhập thất bại! Tên đăng nhập hoặc mật khẩu không chính xác";
                TempData["temp"] = str;
            }
            else if(res == 3)
            {
                string[] KH = db.getInfoKH(new string[] { user_login });
                Session["KH"] = KH;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult SignInCustomer(SigninModels val)
        {
            var res = db.signin(new string[] { val.tenKH, val.ngaySinh, val.gioiTinh.ToString(), val.diaChi, val.cmnd, val.dienThoai, val.email, val.username, val.password });
            ViewBag.res = res;
            return RedirectToAction("Login");
        }

    }
}