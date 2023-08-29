using MediatR;
using Microsoft.Extensions.Logging;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.Tests;
using NewLMS.UMKM.Helper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Tests.Queries
{
    public class TestQuery : RequestParameter, IRequest<ServiceResponse<IEnumerable<TestResponse>>>
    {
        public class TestQueryHandler : IRequestHandler<TestQuery, ServiceResponse<IEnumerable<TestResponse>>>
        {
            private readonly ILogger<TestQueryHandler> _logger;

            public TestQueryHandler(ILogger<TestQueryHandler> logger)
            {
                _logger = logger;
            }

            public Task<ServiceResponse<IEnumerable<TestResponse>>> Handle(TestQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Who are u dude");
                throw new NotImplementedException();
            }
        }
    }
}
