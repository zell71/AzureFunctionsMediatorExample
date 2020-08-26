using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FunctionsAppSample.Function.Domain;
using MediatR;

namespace FunctionsAppSample.Function.Features.Packages
{
    public class Create
    {
        public class PackageData
        {
            public string ExId { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }
        }

        public class PackageDataValidator : AbstractValidator<PackageData>
        {
            public PackageDataValidator()
            {
                RuleFor(x => x.ExId).NotNull().NotEmpty();
                RuleFor(x => x.Title).NotNull().NotEmpty();
                RuleFor(x => x.Description).NotNull().NotEmpty();
            }
        }

        public class Command : IRequest<PackageEnvelope>
        {
            public Command(string title, string description)
            {
                Package = new PackageData
                {
                    Title = title,
                    Description = description
                };
            }
            public PackageData Package { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Package).NotNull().SetValidator(new PackageDataValidator());
            }
        }

        public class Handler : IRequestHandler<Command, PackageEnvelope>
        {
            public Handler()
            {
            }

            public Task<PackageEnvelope> Handle(Command message, CancellationToken cancellationToken)
            {
                var package = new Package
                {
                    Title = message.Package.Title,
                    Description = message.Package.Description
                };

                return Task.FromResult(new PackageEnvelope(package));
            }
        }
    }
}
