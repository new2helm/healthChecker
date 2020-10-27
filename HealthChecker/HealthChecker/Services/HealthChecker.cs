using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Grpc.Health.V1;

namespace HealthChecker
{
    public class HealthChecker : Health.HealthBase
    {
        private readonly ILogger<HealthChecker> _logger;
        public HealthChecker(ILogger<HealthChecker> logger)
        {
            _logger = logger;
        }

        public override async Task<HealthCheckResponse> Check(HealthCheckRequest request, ServerCallContext context)
        {
            return new HealthCheckResponse()
            {
                Status = HealthCheckResponse.Types.ServingStatus.Serving
            };
        }
    }
}