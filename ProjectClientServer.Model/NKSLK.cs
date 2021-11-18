namespace ProjectClientServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NKSLK")]
    public partial class NKSLK
    {
        [Key]
        [StringLength(20)]
        public string MaNK { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThucHienKhoan { get; set; }

        public TimeSpan? GioBatDau { get; set; }

        public TimeSpan? GioKetThuc { get; set; }

        [StringLength(20)]
        public string MaDanhMucCNTHK { get; set; }

        [StringLength(20)]
        public string MaDanhMucCongViec { get; set; }

        public virtual DanhMucCongNhanThucHienKhoan DanhMucCongNhanThucHienKhoan { get; set; }

        public virtual DanhMucCongViec DanhMucCongViec { get; set; }
    }
}
