using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkTesting.EntityFrameworkTestingWithYourOwnTestDoubles.TestDoubles;
using Xunit;

namespace EntityFrameworkTesting.EntityFrameworkTestingWithYourOwnTestDoubles.Tests
{
    public class NonQueryTests
    {
        [Fact]
        public void CreateBlog_saves_a_blog_via_context()
        {
            var context = new TestContext();

            var service = new BlogService(context);
            service.AddBlog("ADO.NET Blog", "http://blogs.msdn.com/adonet");

            Assert.Equal(1, context.Blogs.Count());
            Assert.Equal("ADO.NET Blog", context.Blogs.Single().Name);
            Assert.Equal("http://blogs.msdn.com/adonet", context.Blogs.Single().Url);
            Assert.Equal(1, context.SaveChangesCount);
        }

        [Fact]
        public void GetAllBlogs_orders_by_name()
        {
            var context = new TestContext();
            context.Blogs.Add(new Blog { Name = "BBB" });
            context.Blogs.Add(new Blog { Name = "ZZZ" });
            context.Blogs.Add(new Blog { Name = "AAA" });

            var service = new BlogService(context);
            var blogs = service.GetAllBlogs();

            Assert.Equal(3, blogs.Count);
            Assert.Equal("AAA", blogs[0].Name);
            Assert.Equal("BBB", blogs[1].Name);
            Assert.Equal("ZZZ", blogs[2].Name);
        }

        [Fact]
        public async Task GetAllBlogsAsync_orders_by_name()
        {
            var context = new TestContext();
            context.Blogs.Add(new Blog { Name = "BBB" });
            context.Blogs.Add(new Blog { Name = "ZZZ" });
            context.Blogs.Add(new Blog { Name = "AAA" });

            var service = new BlogService(context);
            var blogs = await service.GetAllBlogsAsync();

            Assert.Equal(3, blogs.Count);
            Assert.Equal("AAA", blogs[0].Name);
            Assert.Equal("BBB", blogs[1].Name);
            Assert.Equal("ZZZ", blogs[2].Name);
        }
    }
}
