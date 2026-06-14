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

                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;
                }
            }
            #endregion
            #region Resume

            var currentResume = ChangeTracker.Entries<Resume>()
                .FirstOrDefault(e =>
                    e.Entity.IsSelected &&
                    (e.State == EntityState.Added ||
                     e.State == EntityState.Modified));

            if (currentResume != null)
            {
                var otherResumes = Set<Resume>()
                    .Where(r => r.ID != currentResume.Entity.ID && r.IsSelected)
                    .ToList();

                foreach (var resume in otherResumes)
                {
                    resume.IsSelected = false;
                }
            }

            var deletedResume = ChangeTracker.Entries<Resume>()
                .FirstOrDefault(e =>
                    e.State == EntityState.Deleted &&
                    e.Entity.IsSelected);

            if (deletedResume != null)
            {
                var newestResume = Set<Resume>()
                    .Where(r => r.ID != deletedResume.Entity.ID)
                    .OrderByDescending(r => r.CreatedAt)
                    .FirstOrDefault();

                if (newestResume != null)
                {
                    newestResume.IsSelected = true;
                }
            }

            #endregion
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
