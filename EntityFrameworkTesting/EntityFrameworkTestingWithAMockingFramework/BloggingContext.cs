using System;
using System.Data.Entity;
using System.Text;

namespace EntityFrameworkTesting.EntityFrameworkTestingWithAMockingFramework
{
    public class BloggingContext : DbContext
    {
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
    }
}
