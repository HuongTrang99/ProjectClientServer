namespace ProjectClientServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucCongViec")]
    public partial class DanhMucCongViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucCongViec()
        {
            NKSLKs = new HashSet<NKSLK>();
        }

        [Key]
        [StringLength(20)]
        public string MaDanhMucCongViec { get; set; }

        [StringLength(20)]
        public string MaCongViec { get; set; }

        public int? SoLuongDatDuoc { get; set; }

        [StringLength(20)]
        public string SoLoSanPham { get; set; }

        [StringLength(20)]
        public string MaSanPham { get; set; }

        public virtual CongViec CongViec { get; set; }

        public virtual SanPham SanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NKSLK> NKSLKs { get; set; }
    }
}
