using Grpc.Core;
using GrpcCounter.Protos;
using System.Threading.Tasks;
using static GrpcCounter.Protos.CounterService;

namespace GrpcCounter.Services
{
    public class CounterService : CounterServiceBase
    {
        public override Task<GetCounterResponse> GetCounterValue(GetCounterRequest request, ServerCallContext context)
        {
            return Task.FromResult(
                new GetCounterResponse
                {
                    Value = 0
                });
        }
    }
}
