using Microsoft.EntityFrameworkCore;

namespace Test_Api.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions option) : base(option) { }

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(e => e.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<DonHangChiTiet>(e =>
            {
                e.ToTable("DonHangChiTiet");
                e.HasKey(e => new
                {
                    e.MaDh,
                    e.MaHh
                });
                e.HasOne(e => e.DonHang)
                    .WithMany(e => e.DonHangChiTiets)
                    .HasForeignKey(e => e.MaDh)
                    .HasConstraintName("FK_DonHangCT_DonHang");

                e.HasOne(e => e.HangHoa)
                    .WithMany(e => e.DonHangChiTiets)
                    .HasForeignKey(e => e.MaHh)
                    .HasConstraintName("FK_DonHangCT_HangHoa");
            });

            modelBuilder.Entity<Loai>(e =>
            {
                e.ToTable("Loai");
                e.HasKey(e => e.MaLoai);
            });

            modelBuilder.Entity<HangHoa>(e =>
            {
                e.ToTable("HangHoa");

                e.HasKey(e => e.MaHh);

                e.HasOne(e => e.Loai)
                    .WithMany(e => e.HangHoas)
                    .HasPrincipalKey(e=>e.MaLoai)
                    .HasForeignKey(e => e.MaLoai)
                    .HasConstraintName("FK_HangHoa_Loai");
            });

            modelBuilder.Entity<NguoiDung>(e =>
            {
                e.ToTable("NguoiDung");
                e.HasIndex(e => e.UserName).IsUnique();
                e.Property(e => e.HoTen).IsRequired().HasMaxLength(150);
                e.Property(e => e.Email).IsRequired().HasMaxLength(150);
            });
        }
    }

}
