using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Models;

namespace Portfolio.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
