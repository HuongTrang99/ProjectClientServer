namespace ProjectClientServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            DanhMucCongViecs = new HashSet<DanhMucCongViec>();
        }

        [Key]
        [StringLength(20)]
        public string MaSanPham { get; set; }

        [StringLength(50)]
        public string TenSanPham { get; set; }

        public int? SoDangKy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanSuDung { get; set; }

        [StringLength(50)]
        public string QuyCach { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCongViec> DanhMucCongViecs { get; set; }
    }
}
