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
        public ActionResult Create(FormCollection collection,HttpPostedFileBase uploadHinh)
        {
            SinhVien sv = new SinhVien();
            sv.MaSV = collection["MaSV"];
            sv.HoTen = collection["HoTen"];
            sv.NgaySinh = DateTime.Parse(collection["NgaySinh"]);
            sv.GioiTinh = collection["GioiTinh"];
            sv.MaNganh = collection["MaNganh"];
            context.SinhViens.Add(sv);
            context.SaveChanges();
            if (uploadHinh != null && uploadHinh.ContentLength > 0)
            {
                string id = context.SinhViens.ToList().Last().MaSV.ToString();

                string _FileName = "";
                int index = uploadHinh.FileName.IndexOf('.');
                _FileName = "sv" + id.ToString();
                string _path = Path.Combine(Server.MapPath("~/Content/images"), _FileName);
                uploadHinh.SaveAs(_path);

                SinhVien svx = context.SinhViens.FirstOrDefault(x => x.MaSV == id);
                svx.Hinh = _FileName;
                context.SaveChanges();
            }
            
            return RedirectToAction("Index","SinhVien");
        }

        public string ProcessUpload(HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                return "";
            }
            string path = Server.MapPath("~/Content/images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName = Path.GetFileName(fileUpload.FileName);
            string fullPath = Path.Combine(path, fileName);
            fileUpload.SaveAs(fullPath);
            return fullPath;
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