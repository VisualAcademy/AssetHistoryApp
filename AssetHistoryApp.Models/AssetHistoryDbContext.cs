using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace AssetHistoryApp.Models
{
    public class AssetHistoryDbContext : DbContext
    {
        public AssetHistoryDbContext()
        {
            // Empty
        }

        public AssetHistoryDbContext(DbContextOptions<AssetHistoryDbContext> options)
            : base(options)
        {
            // 공식과 같은 코드
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 닷넷 프레임워크 기반에서 호출되는 코드 영역: 
            // App.config 또는 Web.config의 연결 문자열 사용
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetHistory>().Property(m => m.Created).HasDefaultValue("GetDate()");
        }

        public DbSet<AssetHistory> AssetsHistories { get; set; }
    }
}
