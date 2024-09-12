using Grpc.Net.Client;
using GrpcService;

namespace GrpcClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            using var chanel = GrpcChannel.ForAddress("http://localhost:5109");

            //Console.WriteLine("Enter your name:");
            //var nameForGreeting = Console.ReadLine();

            //var client = new Greeter.GreeterClient(chanel);
            //var reply = await client.SayHelloAsync(new HelloRequest { Name = nameForGreeting });


            //Console.WriteLine("---Day Time---");
            //var reply2 = await client.DayTimeAsync(new DayTimeRequest());
            //Console.WriteLine($"Reply from daytime(): {reply2.Message}");
            //Console.ReadKey();


            Console.WriteLine("WITH USERS METHODS");
            Console.WriteLine("enter some key to start...");
            Console.ReadKey();
            Console.WriteLine("------------------");

            var clientForUsersMethods = new User.UserClient(chanel);

            Console.WriteLine("getUser()");
            var userInfo = await clientForUsersMethods.GetUserInfoAsync(new UserRequest { UserId = 1 });
            Console.WriteLine($"Name: {userInfo.Name}");
            Console.WriteLine($"Age: {userInfo.Age}");
            Console.WriteLine($"Roles: {string.Join(", ", userInfo.Roles)}");
            Console.WriteLine($"Adress: {userInfo.Address.Street}, {userInfo.Address.City}, {userInfo.Address.Country}");
            Console.WriteLine($"Coordinates: {userInfo.Coordinates.Latitude}, {userInfo.Coordinates.Longitude}");


            Console.WriteLine("createUser()");
            var createUserReply = await clientForUsersMethods.CreateUserAsync(new CreateUserRequest
            {
                Name = "Alice",
                Age = 25,
                Roles = { "user" },
                Address = new Address
                {
                    Street = "456 Another St",
                    City = "Los Angeles",
                    Country = "USA"
                },
                Coordinates = new Coordinates
                {
                    Latitude = 34.052235,
                    Longitude = -118.243683
                }
            });

            Console.WriteLine($"User created: {createUserReply.Message}");
        }
    }
}
