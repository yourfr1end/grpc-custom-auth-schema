using System.Threading.Tasks;
using CommonProtos;
using Grpc.Core;

namespace GreeterService.Services
{
    public class GrpcGreeter : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}