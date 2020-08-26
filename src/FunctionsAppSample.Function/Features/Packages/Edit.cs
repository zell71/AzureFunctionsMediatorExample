﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FunctionsAppSample.Function.Domain;
using MediatR;

namespace FunctionsAppSample.Function.Features.Packages
{
    public class Edit
    {
        public class PackageData
        {
            public string Title { get; set; }

            public string Description { get; set; }
        }

        public class Command : IRequest<PackageEnvelope>
        {
            public PackageData Package { get; set; }
            public string ExId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Package).NotNull();
                RuleFor(x => x.ExId).NotNull().NotEmpty();
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
                    ExId = message.ExId,
                    Title = message.Package.Title,
                    Description = message.Package.Description
                };

                return Task.FromResult(new PackageEnvelope(package));
            }
        }
    }
}
