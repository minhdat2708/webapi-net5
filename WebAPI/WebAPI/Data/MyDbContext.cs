using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }    

        public DbSet<LoaiHang> LoaiHangs { get; set; }

        #endregion
    }
}
