using HOTENSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOTENSV.Controllers
{
    public class DangKyController : Controller
    {
        MyData context = new MyData();
        // GET: DangKy
        public ActionResult Index()
        {
            return View();
        }

        public List<DangKyHP> GetDangKy()
        {
            List<DangKyHP> lstDangKy = Session["DangKy"] as List<DangKyHP>;
            if (lstDangKy == null)
            {
                lstDangKy = new List<DangKyHP>(); 
                Session["DangKy"] = lstDangKy;
            }
            return lstDangKy;
        }
        public ActionResult ThemDangKy(string id, string strURL)
        {
            List<DangKyHP> lstDangKy = GetDangKy();
            DangKyHP dangKy = lstDangKy.Find(n => n.MaHP == id); 
            if (dangKy == null)
            {
                dangKy = new DangKyHP(id);
                lstDangKy.Add(dangKy); 
                return Redirect(strURL);
            }
            else
            {
                return Redirect(strURL);
            }
        }
        private int TongSoTC()
        {
            int tsl = 0;
            List<DangKyHP> lstDangKy = Session["DangKy"] as List<DangKyHP>; 
            if (lstDangKy != null)
            {
                tsl = lstDangKy.Sum(n => n.SoTinChi);
            }
            return tsl;
        }
        private int TongSoLuongHP()
        {
            int tsl = 0;
            List<DangKyHP> lstDangKy = Session["DangKy"] as List<DangKyHP>; 
            if (lstDangKy != null)
            {
                tsl = lstDangKy.Count;
            }
            return tsl;
        }
        public ActionResult DangKy()
        {
            List<DangKyHP> lstDangKy = GetDangKy();
            ViewBag.TongSoTC = TongSoTC();
            ViewBag.TongSoHP = TongSoLuongHP();
            return View(lstDangKy);
        }
        public ActionResult View()
        {
            ViewBag.TongSoTC = TongSoTC();
            ViewBag.TongSoHP = TongSoLuongHP(); 
            return PartialView();
        }
        public ActionResult XoaDangKy(string id)
        {
            List<DangKyHP> lstDangKy = GetDangKy(); 
            DangKyHP hp = lstDangKy.SingleOrDefault(n => n.MaHP == id); 
            if (hp != null)
            {
                lstDangKy.RemoveAll(n => n.MaHP == id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult CapNhatDangKy(string id, FormCollection collection)
        {
            List<DangKyHP> lstDangKy = GetDangKy();
            DangKyHP hp = lstDangKy.SingleOrDefault(n => n.MaHP == id);
            return RedirectToAction("Index");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<DangKyHP> lstDangKy = GetDangKy();
            lstDangKy.Clear(); 
            return RedirectToAction("Index");
        }
        public ActionResult DangKyHP()
        {
            try
            {
                //DangKy dky = new DangKy();
                //List<DangKyHP> lstDangKy = GetDangKy();
                //dky.NgayDK = DateTime.UtcNow("yyyy-mm-dd");
                //dky.MaSV = 
                //data.DonHangs.InsertOnSubmit(donhang);
                //data.SubmitChanges();
                //for (int i = 0; i < lstGiohang.Count; i++)
                //{
                //    ChiTietDH ctdh = new ChiTietDH();
                //    ctdh.MaDon = donhang.MaDon;
                //    ctdh.masach = lstGiohang[i].masach;
                //    ctdh.soluong = lstGiohang[i].iSoluong;
                //    ctdh.dongia = (decimal?)lstGiohang[i].giaban;
                //    data.ChiTietDHs.InsertOnSubmit(ctdh);
                //}
                //data.SubmitChanges();
                XoaTatCaGioHang();
               
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}