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
            //DataColumn[] keyColumns = new DataColumn[1];
            //keyColumns[0] = tableEmptySeat.Columns[0];
            //tableEmptySeat.PrimaryKey = keyColumns;

            int soGhe = db.SoGhe(maChuyen);
            List<int> listEmptySeat = new List<int>();
            for (int i = 1; i <= soGhe; i++)
            {
                if (booked(tableEmptySeat, i))
                    continue;
                else
                   listEmptySeat.Add(i);
            }
            SelectList select = new SelectList(listEmptySeat);
            return select;
        }

        private bool booked(DataTable tableEmptySeat, int x)
        {
            for (int i = 0; i < tableEmptySeat.Rows.Count; i++)
                if (tableEmptySeat.Rows[i][0].ToString() == x.ToString())
                    return true;
            return false;
        }


        public string BookVe(string GHE, string MACHUYEN)
        {
            if (Session["KH"] == null)
            {
                return "fail";
            }
            string[] arrStr = Session["KH"] as string[];
            string query = "insert into VEXE VALUES(" + arrStr[0] + ", " + MACHUYEN + ", " + GHE + ")";
            DbConnectHelpers db = new DbConnectHelpers();
            db.executeNonQuery(query);
            return "success";
        }


        public ActionResult Search(SearchModels key)
        {

            DataTable rs = db.search(new string[] { key.startPoint == "" ? "Hồ Chí Minh" : key.startPoint, key.endPoint, key.startDate });
            List<SelectList> list = new List<SelectList>();
            for (int i = 0; i < rs.Rows.Count; i++)
            {
                list.Add(EmptySeat(rs.Rows[i][8].ToString()));
            }
            ViewBag.list = list;
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