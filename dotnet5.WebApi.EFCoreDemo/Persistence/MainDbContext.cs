using dotnet5.WebApi.EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet5.WebApi.EFCoreDemo.Persistence
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
