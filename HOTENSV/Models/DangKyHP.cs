using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HOTENSV.Models
{
    public class DangKyHP
    {
        MyData context = new MyData();
        [Display(Name = "Mã học phần")] public string MaHP { get; set; }
        [Display(Name = "Tên học phần")] public string TenHP { get; set; }
        [Display(Name = "Số tín chỉ")] public int SoTinChi { get; set; }
        public DangKyHP(string id)
        {
            MaHP = id;
            HocPhan hp = context.HocPhans.Single(n => n.MaHP == MaHP);
            TenHP = hp.TenHP;
            SoTinChi = (int)hp.SoTinChi;
        }
    }
}