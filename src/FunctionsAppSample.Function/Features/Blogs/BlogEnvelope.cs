namespace FunctionsAppSample.Function.Features.Blogs
{
    public class BlogEnvelope
    {
        public BlogEnvelope(Blog.Domain.Blog blog)
        {
            Blog = blog;
        }

        public Blog.Domain.Blog Blog { get; }
    }
}
