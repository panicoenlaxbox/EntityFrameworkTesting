using System.Data.Entity;

namespace EntityFrameworkTesting.EntityFrameworkTestingWithYourOwnTestDoubles
{
    /// <summary>
    /// Entity Framework Testing with Your Own Test Doubles (EF6 onwards)
    /// https://msdn.microsoft.com/en-us/data/dn314431(v=vs.113)
    /// </summary>
    public class BloggingContext : DbContext, IBloggingContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
