using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace FunctionsAppSample.Function.Features.Packages
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Command(string ExId)
            {
                ExId = ExId;
            }

            public string ExId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ExId).NotNull().NotEmpty();
            }
        }

        public class QueryHandler : IRequestHandler<Command>
        {
            public QueryHandler()
            {

            }

            public Task<Unit> Handle(Command message, CancellationToken cancellationToken)
            {
                return Task.FromResult(Unit.Value);
            }
        }
    }
}
