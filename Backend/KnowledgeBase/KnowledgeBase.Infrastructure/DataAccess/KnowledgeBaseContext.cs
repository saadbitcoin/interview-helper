using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Infrastructure.DataAccess.Models;
using KnowledgeBase.Domain.Entities.Base;

namespace KnowledgeBase.Infrastructure.DataAccess
{
    public class KnowledgeBaseContext : DbContext
    {
        public KnowledgeBaseContext(DbContextOptions<KnowledgeBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<QuestionLinkedTag> QuestionLinkedTags { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}