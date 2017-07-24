using System.Data.Entity;

namespace EntityFrameworkTesting.EntityFrameworkTestingWithYourOwnTestDoubles
{
    public interface IBloggingContext
    {
        DbSet<Blog> Blogs { get; }
        DbSet<Post> Posts { get; }
        int SaveChanges();
    }
}