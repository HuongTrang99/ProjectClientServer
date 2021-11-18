namespace ProjectClientServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongNhan")]
    public partial class CongNhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongNhan()
        {
            CongNhanThucHienKhoans = new HashSet<CongNhanThucHienKhoan>();
        }

        [Key]
        [StringLength(20)]
        public string MaCongNhan { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThangNamSinh { get; set; }

        [StringLength(50)]
        public string PhongBan { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        [StringLength(50)]
        public string QueQuan { get; set; }

        [StringLength(50)]
        public string LuongHopDong { get; set; }

        [StringLength(50)]
        public string LuongBaoHiem { get; set; }

        public bool? GioiTinh { get; set; }

        [StringLength(30)]
        public string TaiKhoan { get; set; }

        [StringLength(30)]
        public string MatKhau { get; set; }

        public bool? LaAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongNhanThucHienKhoan> CongNhanThucHienKhoans { get; set; }
    }
}
