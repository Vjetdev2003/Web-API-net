using Microsoft.EntityFrameworkCore;

namespace WebApiNet5.Data
{
    public class MyDBContext : DbContext
    {
        public  MyDBContext(DbContextOptions options) :base(options)
        { }
        #region
        public DbSet<HangHoa>hangHoas { get; set; }
       public DbSet<Loai>Loais { get; set; }
        #endregion
    }
}
