using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DriverController : Controller
    {
        QL_BanVeXeEntities db = new QL_BanVeXeEntities();
        // GET: Driver
        public ActionResult Index()
        {
            Session["driver"] = "1";
            short manv = short.Parse(Session["driver"].ToString());
            var thongtincanhan = (from NHANVIEN in db.NHANVIENs where NHANVIEN.MANV == manv select NHANVIEN).ToList();
            //SelectList select = new SelectList(thongtincanhan);
            ViewBag.infor = thongtincanhan[0];
            return View();
        }

        public ActionResult Guests(string chuyenDi)
        {
            Session["driver"] = "1";
            //Lấy mã nv từ session
            short manv = short.Parse(Session["driver"].ToString());
            //Lấy danh sách các chuyến xe của tài xế đó
            var listChuyenXe = (from CHUYENXE in db.CHUYENXEs where CHUYENXE.MANV == manv select CHUYENXE).ToList();
            //đổ dữ liệu vào select với value là MACHUYEN, text là TENCHUYEN
            CHUYENXE init = new CHUYENXE();
            init.MACHUYEN = "0";
            init.TENCHUYEN = "Chọn chuyến xe";
            listChuyenXe.Add(init);
            SelectList select = new SelectList(listChuyenXe, "MACHUYEN", "TENCHUYEN", init);
            //gắn select vào view
            ViewBag.select = select;
            //lấy danh sách vé của chuyến xe 'chuyenDi'
            var listVeXe = (from VEXE in db.VEXEs join KHACHHANG in db.KHACHHANGs 
                            on VEXE.MAKH equals KHACHHANG.MAKH 
                            join CHUYENXE in db.CHUYENXEs on VEXE.MACHUYENXE equals CHUYENXE.MACHUYEN select new { VEXE.MAVE, KHACHHANG.TENKH, VEXE.VITRIGHENGOI, VEXE.MACHUYENXE });
            if (chuyenDi != "")
            {
                listVeXe = listVeXe.Where(x => x.MACHUYENXE == chuyenDi);
            }
           List<Chuyen> listLinks = new List<Chuyen>();
           foreach (var item in listVeXe)
           {
               Chuyen temp = new Chuyen();
               temp.MAVE= item.MAVE;
               temp.HOTEN = item.TENKH;
               temp.SOGHE = (int)item.VITRIGHENGOI;
               listLinks.Add(temp);
           }
           ViewBag.ls = listLinks;
           return View();
        }
    }
}
//<form action="~/Driver/Guests">

//<select name="chuyenDi" class="form-control" id="timeStart" style="display:inline; width:20%; margin-bottom:10px">
//    @Html.Raw(ViewBag.View)
//</select>
//<input id="xem" type="button" value="Xem" />
//</form>
//</div>

//<table style="width: 100%;border:1px solid black; text-align:center">
//    <tr>
//        <td>Mã vé</td>
//        <td>Họ tên</td>
//        <td>Số ghế</td>
//    </tr>
//    @Html.Raw(ViewBag.Ve)
//</table>