using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOTENSV.Models;

namespace HOTENSV.Controllers
{
    public class SinhVienController : Controller
    {
        MyData context = new MyData();
        // GET: SinhVien
        public ActionResult Index()
        {
            List<SinhVien> sv = context.SinhViens.ToList();
            return View(sv);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase file)
        {
            SinhVien sv = new SinhVien();
            sv.MaSV = collection["MaSV"];
            sv.HoTen = collection["HoTen"];
            sv.NgaySinh = DateTime.Parse(collection["NgaySinh"]);
            sv.GioiTinh = collection["GioiTinh"];
            string path = Server.MapPath("~/Content/images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName = Path.GetFileName(file.FileName);
            string fullPath = Path.Combine(path, fileName);
            file.SaveAs(fullPath);
            sv.Hinh = "/Content/images" + fullPath;
            sv.MaNganh = collection["MaNganh"];
            context.SinhViens.Add(sv);
            context.SaveChanges();
            return RedirectToAction("Index","SinhVien");
        }

        public ActionResult Details(string id)
        {
            SinhVien sinhVien = context.SinhViens.FirstOrDefault(p => p.MaSV == id);
            return View(sinhVien);
        }

        public ActionResult Edit(string id)
        {
            SinhVien sinhVien = context.SinhViens.FirstOrDefault(p => p.MaSV == id);
            return View(sinhVien);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection, string id)
        {
            SinhVien sv = context.SinhViens.FirstOrDefault(p => p.MaSV == id);
            sv.HoTen = collection["HoTen"];
            sv.NgaySinh = DateTime.Parse(collection["NgaySinh"]);
            sv.GioiTinh = collection["GioiTinh"];
            string path = Server.MapPath("~/Content/images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            sv.Hinh = collection["Hinh"];
            sv.MaNganh = collection["MaNganh"];
            context.SaveChanges();
            return RedirectToAction("Index", "SinhVien");
        }

        public ActionResult Delete(string id)
        {
            SinhVien sinhVien = context.SinhViens.FirstOrDefault(p => p.MaSV == id);
            return View(sinhVien);
        }

        [HttpPost]
        
        public ActionResult Delete(FormCollection collection, string id) 
        {
            SinhVien sinhVien = context.SinhViens.FirstOrDefault(p => p.MaSV == id);
            context.SinhViens.Remove(sinhVien);
            context.SaveChanges();
            return RedirectToAction("Index", "SinhVien");
        }

    }

}