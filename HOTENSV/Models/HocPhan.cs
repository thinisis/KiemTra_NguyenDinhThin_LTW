namespace HOTENSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocPhan")]
    public partial class HocPhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocPhan()
        {
            DangKies = new HashSet<DangKy>();
        }

        [Key]
        [StringLength(6)]
        [Display(Name = "Mã h?c ph?n")] public string MaHP { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Tên h?c ph?n")] public string TenHP { get; set; }

        [Display(Name = "??a ch?")] public int? SoTinChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKy> DangKies { get; set; }

        
    }
}
