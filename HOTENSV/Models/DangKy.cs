namespace HOTENSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DangKy")]
    public partial class DangKy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DangKy()
        {
            HocPhans = new HashSet<HocPhan>();
        }

        [Key]
        [Display(Name = "M� ??ng k�")] public int MaDK { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ng�y ??ng k�")] public DateTime? NgayDK { get; set; }

        [StringLength(10)]
        [Display(Name = "M� sinh vi�n")] public string MaSV { get; set; }

        public virtual SinhVien SinhVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocPhan> HocPhans { get; set; }


    }
}
