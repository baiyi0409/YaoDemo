using Microsoft.EntityFrameworkCore;

namespace YaoDemoApi.Context
{
    public class YaoDemoContext:DbContext
    {
        public YaoDemoContext(DbContextOptions<YaoDemoContext> options):base(options)
        {
            
        }
        public DbSet<Images> images { get; set; }
    }
}
