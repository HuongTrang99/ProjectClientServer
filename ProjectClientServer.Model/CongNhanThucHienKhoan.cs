namespace ProjectClientServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongNhanThucHienKhoan")]
    public partial class CongNhanThucHienKhoan
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MaDanhMucCNTHK { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaCongNhan { get; set; }

        public TimeSpan? ThoiGianBatDau { get; set; }

        public TimeSpan? ThoiGianKetThuc { get; set; }

        public virtual CongNhan CongNhan { get; set; }

        public virtual DanhMucCongNhanThucHienKhoan DanhMucCongNhanThucHienKhoan { get; set; }
    }
}
