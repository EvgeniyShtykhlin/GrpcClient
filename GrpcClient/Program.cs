using Grpc.Net.Client;

namespace GrpcClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using var chanel = GrpcChannel.ForAddress("http://localhost:5109");
            var client= new Greeter.GreeterClient(chanel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name="Privet"});
        }
    }
}
