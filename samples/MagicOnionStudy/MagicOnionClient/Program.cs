using Grpc.Net.Client;
using MagicOnion.Client;
using MyMagicOnionClient.Clients;
using MyMagicOnionShared.Services;

Console.WriteLine("tap any key to continue.(wait a redy to server)");
Console.ReadKey();

// Connect to the server using gRPC channel.
var channel = GrpcChannel.ForAddress("http://localhost:5096");

// NOTE: If your project targets non-.NET Standard 2.1, use `Grpc.Core.Channel` class instead.
// var channel = new Channel("localhost", 5001, new SslCredentials());

// Create a proxy to call the server transparently.
var client = MagicOnionClient.Create<IMyFirstService>(channel);

// Call the server-side method using the proxy.
var result = await client.SumAsync(123, 456);

Console.WriteLine($"Result: {result}");


// streaming hub
var roomName = "r1";
var user1 = "u1";
var user2 = "u2";

var hub1 = new GamingHubClient();
await hub1.ConnectAsync(channel, roomName, user1);

var hub2 = new GamingHubClient();
await hub2.ConnectAsync(channel, roomName, user2);

await hub2.MoveAsync(5);
await hub2.LeaveAsync();



