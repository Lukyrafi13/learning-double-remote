using MediatR;
using Microsoft.Extensions.Logging;
using NewLMS.Umkm.Helper;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Tests.Commands
{
    public class TestPostDataCommand : IRequest<ServiceResponse<Unit>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class TestPostDataCommandHandler : IRequestHandler<TestPostDataCommand, ServiceResponse<Unit>>
    {
        private readonly ILogger<TestPostDataCommandHandler> _logger;

        public TestPostDataCommandHandler(ILogger<TestPostDataCommandHandler> logger)
        {
            _logger = logger;
        }

        public Task<ServiceResponse<Unit>> Handle(TestPostDataCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Information");
            _logger.LogCritical("Critical");
            _logger.LogDebug("Debug");
            _logger.LogError("Error");
            _logger.LogWarning("Warning");
            _logger.LogTrace("Trace");
            return Task.FromResult(ServiceResponse<Unit>.ReturnSuccess());
        }
    }
}
