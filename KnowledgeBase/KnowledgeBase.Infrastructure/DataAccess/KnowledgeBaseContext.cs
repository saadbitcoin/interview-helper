using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Infrastructure.DataAccess
{
    internal class KnowledgeBaseContext : DbContext
    {
        public KnowledgeBaseContext(DbContextOptions<KnowledgeBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<LinkedTag> LinkedTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(x => x.HasMany(x => x.LinkedTags));
            modelBuilder.Entity<Tag>(x => x.HasMany<LinkedTag>().WithOne(x => x.Tag));
        }
    }
}