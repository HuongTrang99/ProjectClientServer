namespace ProjectClientServer.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectClientServerDbContext : DbContext
    {
        public ProjectClientServerDbContext()
            : base("name=ProjectClientServerDbContext")
        {
        }

        public virtual DbSet<CongNhan> CongNhans { get; set; }
        public virtual DbSet<CongViec> CongViecs { get; set; }
        public virtual DbSet<DanhMucCongNhanThucHienKhoan> DanhMucCongNhanThucHienKhoans { get; set; }
        public virtual DbSet<DanhMucCongViec> DanhMucCongViecs { get; set; }
        public virtual DbSet<NKSLK> NKSLKs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<CongNhanThucHienKhoan> CongNhanThucHienKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CongNhan>()
                .Property(e => e.MaCongNhan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongNhan>()
                .Property(e => e.TaiKhoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongNhan>()
                .Property(e => e.MatKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongNhan>()
                .HasMany(e => e.CongNhanThucHienKhoans)
                .WithRequired(e => e.CongNhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CongViec>()
                .Property(e => e.MaCongViec)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucCongNhanThucHienKhoan>()
                .Property(e => e.MaDanhMucCNTHK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucCongNhanThucHienKhoan>()
                .HasMany(e => e.CongNhanThucHienKhoans)
                .WithRequired(e => e.DanhMucCongNhanThucHienKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMucCongViec>()
                .Property(e => e.MaDanhMucCongViec)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucCongViec>()
                .Property(e => e.MaCongViec)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucCongViec>()
                .Property(e => e.SoLoSanPham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucCongViec>()
                .Property(e => e.MaSanPham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NKSLK>()
                .Property(e => e.MaNK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NKSLK>()
                .Property(e => e.MaDanhMucCNTHK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NKSLK>()
                .Property(e => e.MaDanhMucCongViec)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSanPham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.TenSanPham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongNhanThucHienKhoan>()
                .Property(e => e.MaDanhMucCNTHK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongNhanThucHienKhoan>()
                .Property(e => e.MaCongNhan)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
