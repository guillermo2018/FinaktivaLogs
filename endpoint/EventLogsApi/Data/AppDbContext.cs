

using Microsoft.EntityFrameworkCore;

namespace EventLogsApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.EventLogs> EventLogs { get; set; }
    }
}
