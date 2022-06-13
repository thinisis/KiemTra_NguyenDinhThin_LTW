namespace HOTENSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            DangKies = new HashSet<DangKy>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã sinh viên")] public string MaSV { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "H? tên")] public string HoTen { get; set; }

        [StringLength(5)]
        [Display(Name = "Gi?i tính")] public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày sinh")] public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình")] public string Hinh { get; set; }

        [StringLength(4)]
        [Display(Name = "Mã ngành")] public string MaNganh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKy> DangKies { get; set; }

        public virtual NganhHoc NganhHoc { get; set; }
    }
}
