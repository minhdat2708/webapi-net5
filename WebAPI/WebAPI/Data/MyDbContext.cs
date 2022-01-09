using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }    

        public DbSet<LoaiHang> LoaiHangs { get; set; }

        public DbSet<DonHang> DonHangs { get; set;}
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("GETDATE()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<ChiTietDonHang>(e => {
                e.ToTable("ChiTietDonHang");
                e.HasKey(e => new { e.MaDh, e.MaHh });

                e.HasOne(e => e.DonHang)
                    .WithMany(e => e.ChiTietDonHangs)
                    .HasForeignKey(e => e.MaDh)
                    .HasConstraintName("FK_CTDonHang_DonHang");

                e.HasOne(e => e.HangHoa)
                    .WithMany(e => e.ChiTietDonHangs)
                    .HasForeignKey(e => e.MaHh)
                    .HasConstraintName("FK_CTDonHang_HangHoa");
            });
        }


    }
}
