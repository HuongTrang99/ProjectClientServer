namespace ProjectClientServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongViec")]
    public partial class CongViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongViec()
        {
            DanhMucCongViecs = new HashSet<DanhMucCongViec>();
        }

        [Key]
        [StringLength(20)]
        public string MaCongViec { get; set; }

        [StringLength(50)]
        public string TenCongViec { get; set; }

        public double? DinhMucKhoan { get; set; }

        public double? DonViKhoan { get; set; }

        public double? HeSoKhoan { get; set; }

        public double? DinhMucLaoDong { get; set; }

        public double? DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCongViec> DanhMucCongViecs { get; set; }
    }
}
