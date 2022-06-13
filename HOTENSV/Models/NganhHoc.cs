namespace HOTENSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NganhHoc")]
    public partial class NganhHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NganhHoc()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        [Key]
        [StringLength(4)]
        [Display(Name = "M� ng�nh")] public string MaNganh { get; set; }

        [StringLength(30)]
        [Display(Name = "T�n ng�nh")] public string TenNganh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
