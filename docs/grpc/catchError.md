# catch error

- [エラー処理 \- WCF 開発者向け gRPC \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/architecture/grpc-for-wcf-developers/error-handling)

## NOTE

- 基本的に `RpcException` の `throw` とその cache で構成

## Server

```cs
using Grpc.Core;
using GrpcSample.Domain;
using GrpcSample.Models;
using GrpcSample.Usecases;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcSample.Services
{
    public class UserService: Users.UsersBase
    {
        public override Task<ReadUsersReply> ReadUsers(ReadUsersRequest request, ServerCallContext context)
        {
            var id = request.UserId;
            var user = usecase.ReadUsers(id);
            if (user == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"user not found. id: {id}"));
            }

            return Task.FromResult(new ReadUsersReply
            {
                User = user
            });
        }
    }
}
```

## Client

```cs
try
{
    var readUser1 = await clientUser.ReadUsersAsync(new ReadUsersRequest { UserId = 1 });
    Console.WriteLine("getUser1: " + readUser1);
}
catch (RpcException ex)
{
    Console.WriteLine(ex.Message);
}
```
