using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Infrastructure.DataAccess
{
    internal class KnowledgeBaseContext : DbContext
    {
        public KnowledgeBaseContext(DbContextOptions<KnowledgeBaseContext> options) : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
    }
}