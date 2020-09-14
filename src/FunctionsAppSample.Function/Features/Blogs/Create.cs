using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FunctionsAppSample.Blog.Domain;
using MediatR;

namespace FunctionsAppSample.Function.Features.Blogs
{
    public class Create
    {
        public class BlogData
        {
            public string Url { get; set; }
        }

        public class BlogDataValidator : AbstractValidator<BlogData>
        {
            public BlogDataValidator()
            {
                RuleFor(x => x.Url).NotNull().NotEmpty();
            }
        }

        public class Command : IRequest<BlogEnvelope>
        {
            public Command(string url)
            {
                Blog = new BlogData
                {
                    Url = url
                };
            }
            public BlogData Blog { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Blog).NotNull().SetValidator(new BlogDataValidator());
            }
        }

        public class Handler : IRequestHandler<Command, BlogEnvelope>
        {
            private readonly BloggingContext _context;
            public Handler(BloggingContext context)
            {
                _context = context;
            }

            public async Task<BlogEnvelope> Handle(Command message, CancellationToken cancellationToken)
            {
                var blog = new Blog.Domain.Blog
                {
                    Url = message.Blog.Url
                };

                await _context.Blogs.AddAsync(blog, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return new BlogEnvelope(blog);
            }
        }
    }
}
