using CDW.Developer.Service.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace CDW.Developer.Service.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RequestLog> Requests { get; set; }
    }
}
