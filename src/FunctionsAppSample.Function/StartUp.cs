using FunctionsAppSample.Function;
using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using FunctionsAppSample.Function.Domain;
using FunctionsAppSample.Function.Features.Packages;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace FunctionsAppSample.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            builder.Services.AddSingleton<IValidator<Create.Command>, Create.CommandValidator>();
            builder.Services.AddSingleton<IHttpFunctionExecutor, HttpFunctionExecutor>();
        }
    }
}
