using HOTENSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOTENSV.Controllers
{
    public class DangNhapController : Controller
    {
        MyData context = new MyData();
        // GET: DangNhap

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var user = collection["MaSV"];
            SinhVien sv = context.SinhViens.FirstOrDefault(p => p.MaSV == user);
            if(sv != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công!";
                Session["SinhVien"] = sv;
                return RedirectToAction("Index","HocPhan");
            }
            else
            {
                ViewBag.ThongBao = "Đăng nhập thất bại!";
                return RedirectToAction("Index");
            }
            
        }
    }
}