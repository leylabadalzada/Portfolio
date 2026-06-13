using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Constants;
using Portfolio.Core.Models;
using Portfolio.Core.Models.BaseModels;
using Portfolio.Data.Seeders;

namespace Portfolio.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedAuthor();
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            #region TimeConfiguring
            var changedEntries = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            var now = TimeConstants.AzerbaijaniTime;
            foreach (var entry in changedEntries)
            {

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                }

                else if (entry.State == EntityState.Modified && entry.Entity.isDeleted)
                {
                    entry.Entity.DeletedAt = now;
                }

                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;
                }
            }
            #endregion
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
