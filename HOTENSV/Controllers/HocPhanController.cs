using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOTENSV.Models;

namespace HOTENSV.Controllers
{
    public class HocPhanController : Controller
    {
        MyData context = new MyData();       
        // GET: HocPhan
        public ActionResult Index()
        {
            List<HocPhan> hocPhan = context.HocPhans.ToList();
            return View(hocPhan);
        }
    }
}