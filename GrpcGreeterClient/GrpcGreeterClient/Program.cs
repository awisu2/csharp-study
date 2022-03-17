using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

// 信頼されていないsslを許可
var httpHandler = new HttpClientHandler();
// Return `true` to allow certificates that are untrusted/invalid
httpHandler.ServerCertificateCustomValidationCallback =
    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

// The port number must match the port of the gRPC server.
//var url = "http://localhost:5284";
var url = "http://localhost:5000";

using var channel = GrpcChannel.ForAddress(url, new GrpcChannelOptions { HttpHandler = httpHandler });


var clientUser = new Users.UsersClient(channel);

var createdUser = await clientUser.CreateUsersAsync(new CreateUsersRequest { Name = "new man", Age = 1 });
Console.WriteLine("createdUser1: " + createdUser);

var readUser1 = await clientUser.ReadUsersAsync(new ReadUsersRequest { UserId = 1 });
Console.WriteLine("getUser1: " + readUser1);
var readUser2 = await clientUser.ReadUsersAsync(new ReadUsersRequest { UserId = createdUser.User.Id });
Console.WriteLine("getUser2: " + readUser2);

var readsUsers = await clientUser.ReadsUsersAsync(new ReadsUsersRequest {  });
Console.WriteLine("users: " + readsUsers);

var udpateUser1 = await clientUser.UpdateUsersAsync(new UpdateUsersRequest { UserId = 1, Name = "updated a", Age = readUser1.User.Age + 1 });
Console.WriteLine("createdUser1: " + udpateUser1);
var udpateUser2 = await clientUser.UpdateUsersAsync(new UpdateUsersRequest { UserId = createdUser.User.Id, Name = "updated" + createdUser.User.Name, Age = createdUser.User.Age + 1});
Console.WriteLine("createdUser1: " + udpateUser2);


var deleteUser = await clientUser.DeleteUsersAsync(new DeleteUsersRequest { UserId = createdUser.User.Id});
Console.WriteLine("deleteUser: " + createdUser.User.Id);

var readsUsers2 = await clientUser.ReadsUsersAsync(new ReadsUsersRequest {  });
Console.WriteLine("users after delete: " + readsUsers2);


Console.WriteLine("Press any key to exit...");
Console.ReadKey();
