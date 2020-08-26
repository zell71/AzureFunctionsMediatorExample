using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FunctionsAppSample.Function.Features.Packages
{
    public class AddPackageFunction
    {
        private readonly IMediator _mediator;
        private readonly IHttpFunctionExecutor _httpFunctionExecutor;

        public AddPackageFunction(IMediator mediator, IHttpFunctionExecutor httpFunctionExecutor)
        {
            _mediator = mediator;
            _httpFunctionExecutor = httpFunctionExecutor;
        }

        [FunctionName("AddPackageFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            Create.Command command,
            ILogger log)
        {
            log.LogInformation("AddPackage function processed a request.");
            return await _httpFunctionExecutor.ExecuteAsync(async () =>
            {
                var users = await _mediator.Send(command);
                return new OkObjectResult(users);
            });
        }
    }
}
