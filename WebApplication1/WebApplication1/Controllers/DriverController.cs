using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DriverController : Controller
    {
        LoadDBData load = new LoadDBData();
        // GET: Driver
        public ActionResult Index()
        {
            Session["driver"] = "1";
            short manv = short.Parse(Session["driver"].ToString());
            string query = "select * from nhanvien where manv = " + manv;
            //var thongtincanhan = "";// (from NHANVIEN in db.NHANVIENs where NHANVIEN.MANV == manv select NHANVIEN).ToList();
            //SelectList select = new SelectList(thongtincanhan);
            ViewBag.infor = load.queryTable(query).Rows[0];
            return View();
        }

        public ActionResult Guests(string chuyenDi)
        {
            Session["driver"] = "1";
            // //Lấy mã nv từ session
            short manv = short.Parse(Session["driver"].ToString());
            // //Lấy danh sách các chuyến xe của tài xế đó
            DataTable tableChuyenXe = load.queryTable("select MACHUYEN, TENCHUYEN from NHANVIEN, XE, CHUYENXE where NHANVIEN.MANV = XE.MANV and XE.MAXE = CHUYENXE.MAXE and NHANVIEN.MANV = " + manv); //(from CHUYENXE in db.CHUYENXEs where CHUYENXE.MANV == manv select CHUYENXE).ToList();
            List<CHUYENXE> listChuyenXe = new List<CHUYENXE>();
            for (int i = 0; i < tableChuyenXe.Rows.Count; i++)
            {
                CHUYENXE item = new CHUYENXE();
                item.MACHUYEN = tableChuyenXe.Rows[i][0].ToString();
                item.TENCHUYEN = tableChuyenXe.Rows[i][1].ToString();
                listChuyenXe.Add(item);
            }
            // //đổ dữ liệu vào select với value là MACHUYEN, text là TENCHUYEN
            CHUYENXE init = new CHUYENXE();
            init.MACHUYEN = "0";
            init.TENCHUYEN = "Chọn chuyến xe";
            listChuyenXe.Add(init);
            SelectList select = new SelectList(listChuyenXe, "MACHUYEN", "TENCHUYEN", init);
            // //gắn select vào view
            ViewBag.select = select;
            string queryListVe = "select mave, tenkh, vitrighengoi from VEXE, KHACHHANG where VEXE.MAKH = KHACHHANG.MAKH ";
            if (chuyenDi != null)
            {
                queryListVe += "and MACHUYENXE = " + chuyenDi;
            }
            DataTable tbVe = load.queryTable(queryListVe);
            List<Chuyen> listLinks = new List<Chuyen>();
            for (int i = 0; i < tbVe.Rows.Count; i++)
            {
                Chuyen temp = new Chuyen();
                temp.MAVE = tbVe.Rows[i][0].ToString();
                temp.HOTEN = tbVe.Rows[i][1].ToString();
                temp.SOGHE = int.Parse(tbVe.Rows[i][2].ToString());
                listLinks.Add(temp);
            }
            ViewBag.ls = listLinks;
            return View();
        }
    }
}