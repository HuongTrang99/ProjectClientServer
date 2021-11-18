namespace ProjectClientServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucCongNhanThucHienKhoan")]
    public partial class DanhMucCongNhanThucHienKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucCongNhanThucHienKhoan()
        {
            CongNhanThucHienKhoans = new HashSet<CongNhanThucHienKhoan>();
            NKSLKs = new HashSet<NKSLK>();
        }

        [Key]
        [StringLength(20)]
        public string MaDanhMucCNTHK { get; set; }

        public int? SoLuong { get; set; }

        public bool? LaKhoanChung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongNhanThucHienKhoan> CongNhanThucHienKhoans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NKSLK> NKSLKs { get; set; }
    }
}
