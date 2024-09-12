using Grpc.Net.Client;
using GrpcService;

namespace GrpcClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            var nameForGreeting = Console.ReadLine();

            using var chanel = GrpcChannel.ForAddress("http://localhost:5109");
            var client = new Greeter.GreeterClient(chanel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = nameForGreeting });


            Console.WriteLine("---Day Time---");
            var reply2 = await client.DayTimeAsync(new DayTimeRequest());
            Console.WriteLine($"Reply from daytime(): {reply2.Message}");
        }
    }
}
