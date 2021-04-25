using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Infrastructure.DataAccess.Models;

namespace KnowledgeBase.Infrastructure.DataAccess
{
    public class KnowledgeBaseContext : DbContext
    {
        public KnowledgeBaseContext(DbContextOptions<KnowledgeBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TagTableRepresentation> Tags { get; set; }
        public DbSet<LinkedTag> LinkedTags { get; set; }
        public DbSet<QuestionLinkedTag> QuestionLinkedTags { get; set; }
        public DbSet<QuestionTableRepresentation> Questions { get; set; }
    }
}