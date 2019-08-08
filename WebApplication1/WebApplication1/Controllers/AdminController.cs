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
        //QL_BanVeXeEntities db = new QL_BanVeXeEntities();
        LoadDBData load = new LoadDBData();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Xe()
        {
            //var Xe = (from b in db.XEs select b).ToList();
            //DataTable 
            //string ketqua = "";
            //for (int i = 0; i < Xe.Count; i++)
            //{
            //    ketqua += "<tr>";
            //    ketqua += "<td>" + Xe[i].MAXE + "</td>";
            //    ketqua += "<td>" + Xe[i].TENXE + "</td>";
            //    ketqua += "<td>" + Xe[i].BIENSO + "</td>";
            //    ketqua += "<td>" + Xe[i].SOGHE + "</td>";
            //    ketqua += "<td>" + Xe[i].MALOAIXE + "</td>";
            //    ketqua += "</tr>";
            //}
            ViewBag.View = load.loadTable("Xe");
            return View();
        }

        public ActionResult TuyenXe()
        {
            //var TuyenXe = (from b in db.TUYENXEs select b).ToList();
            //string ketqua = "";
            //for (int i = 0; i < TuyenXe.Count; i++)
            //{
            //    ketqua += "<tr>";
            //    ketqua += "<td>" + TuyenXe[i].MATUYEN + "</td>";
            //    ketqua += "<td>" + TuyenXe[i].TENTUYEN + "</td>";
            //    ketqua += "<td>" + TuyenXe[i].DIEMDI + "</td>";
            //    ketqua += "<td>" + TuyenXe[i].DIEMDEN + "</td>";
            //    ketqua += "<td>" + TuyenXe[i].BANGGIA.ToString() + "</td>";
            //    //ketqua += "<td><input type='button' value='Thêm' /><input type='button' value='Xóa' /><input type='button' value='Sửa' /></td>";
            //    ketqua += "</tr>";
            //}
            ViewBag.View = load.loadTable("TuyenXe");
            return View();
        }

        public ActionResult NhanVien()
        {
            //var NhanVien = (from b in db.NHANVIENs select b).ToList();
            //string ketqua = "";
            //for (int i = 0; i < NhanVien.Count; i++)
            //{
            //    ketqua += "<tr>";
            //    //ketqua += "<td>" + NhanVien[i].MANV + "</td>";
            //    ketqua += "<td>" + NhanVien[i].TENDN + "</td>";
            //    //ketqua += "<td>" + NhanVien[i].MATKHAU + "</td>";
            //    ketqua += "<td>" + NhanVien[i].TENNV + "</td>";
            //    ketqua += "<td>" + NhanVien[i].NGAYSINH + "</td>";
            //    ketqua += "<td>" + NhanVien[i].GIOITINH + "</td>";
            //    ketqua += "<td>" + NhanVien[i].DIACHI + "</td>";
            //    ketqua += "<td>" + NhanVien[i].CMND + "</td>";
            //    ketqua += "<td>" + NhanVien[i].DIENTHOAI + "</td>";
            //    ketqua += "<td>" + NhanVien[i].EMAIL + "</td>";
            //    ketqua += "</tr>";
            //}
            ViewBag.View = load.loadTable("NhanVien");
            return View();
        }

        public ActionResult KhachHang()
        {
            //var KhachHang = (from b in db.KHACHHANGs select b).ToList();
            //string ketqua = "";
            //for (int i = 0; i < KhachHang.Count; i++)
            //{
            //    ketqua += "<tr>";
            //    ketqua += "<td>" + KhachHang[i].MAKH + "</td>";
            //    ketqua += "<td>" + KhachHang[i].TENKH + "</td>";
            //    ketqua += "<td>" + KhachHang[i].NGAYSINH + "</td>";
            //    ketqua += "<td>" + KhachHang[i].GIOITINH + "</td>";
            //    ketqua += "<td>" + KhachHang[i].DIACHI + "</td>";
            //    ketqua += "<td>" + KhachHang[i].CMND + "</td>";
            //    ketqua += "<td>" + KhachHang[i].DIENTHOAI + "</td>";
            //    ketqua += "<td>" + KhachHang[i].EMAIL + "</td>";
            //    ketqua += "</tr>";
            //}
            ViewBag.View = load.loadTable("KhachHang");
            return View();
        }

        public ActionResult ChuyenXe()
        {
            //var ChuyenXe = (from b in db.CHUYENXEs select b).ToList();
            //string ketqua = "";
            //for (int i = 0; i < ChuyenXe.Count; i++)
            //{
            //    ketqua += "<tr>";
            //    ketqua += "<td>" + ChuyenXe[i].MACHUYEN + "</td>";
            //    ketqua += "<td>" + ChuyenXe[i].TENCHUYEN + "</td>";
            //    ketqua += "<td>" + ChuyenXe[i].MATUYEN + "</td>";
            //    ketqua += "<td>" + ChuyenXe[i].GIODI + "</td>";
            //    ketqua += "<td>" + ChuyenXe[i].GIODEN + "</td>";
            //    ketqua += "<td>" + ChuyenXe[i].CHOTRONG + "</td>";
            //    ketqua += "<td>" + ChuyenXe[i].MANV + "</td>";
            //    ketqua += "</tr>";
            //}
            ViewBag.View = load.loadTable("ChuyenXe");
            return View();
        }
    }
}


//public DataTable loadTable(string tableName)
//{
//    open();
//    DataTable dt = new DataTable();
//    try
//    {
//        string strCmd = "select* from " + tableName;

//        SqlCommand cmd = new SqlCommand();
//        cmd.Connection = conn;
//        cmd.CommandType = System.Data.CommandType.Text;
//        cmd.CommandText = strCmd;
//        SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);
//        da.Fill(dt);
//        if (dt.Rows.Count > 0)
//            return dt;
//        else return null;
//    }
//    catch
//    {
//        return null;
//    }
//    finally
//    {
//        close();
//    }
//    return null;
//}