using System;
using System.Threading.Tasks;
using CommonProtos;
using Grpc.Core;
using Grpc.Net.Client;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            
            
            Console.WriteLine("Started.");
            
            do
            {
                Console.WriteLine("Requesting...");
                try
                {
                    var response = await client.SayHelloAsync(
                        new HelloRequest {Name = Guid.NewGuid().ToString()});
                    Console.WriteLine(response.Message);
                }
                catch (RpcException e)
                {
                    Console.WriteLine($"Status = {e.Status}, Message = {e.Message}");
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}