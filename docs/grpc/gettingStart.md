# getting start grpc

- [ASP\.NET Core で \.NET Core gRPC のクライアントとサーバーを作成する \| Microsoft Docs](https://docs.microsoft.com/ja-jp/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-6.0&tabs=visual-studio)
- [about .proto(protobuf) file](./proto.md)

## NOTE

1. サーバとクライアントで実装が違う(サンプルでは)
   - サーバ: ASP.NET Core gRPC Service
     - NuGet: `Grpc.AspNetCore`
       - `Google.Protobuf` への参照を持っており proto からのコードビルドもこれで OK
   - クライアント: プロジェクトに NuGet を追加
     - NuGet: `Grpc.Net.Client`, `Google.Protobuf`, `Grpc.Tools`
2. (共通) protobuf ファイルの追加、更新 (両方とも同じもの)
3. (共通) visual studio 上での protobuf への参照をチェック: プロジェクトファイルにて、対象となる Protobuf を指定している。details later
4. (共通) ビルドして Interface、抽象クラスを生成
   - サーバで生成されるコードは[こちら](./proto.md)
5. (クライアント): 各 proto 毎にクライアントを生成しチャンネルに追加する。 details later

## サーバ

- visual studio > create a new project > **ASP.NET Core gRPC Service**
  - NuGet に `Grpc.AspNetCore` と greet という簡易なコードが設定されている

## クライアント

### NuGet

```bash
Install-Package Grpc.Net.Client
Install-Package Google.Protobuf
Install-Package Grpc.Tools
```

### Code

- how to [allow no trust ssl on client](./allowNoTrustSslOnClient.md)

```cs
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7042");

// 各proto毎に必要
var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
```

## protos の設定

- official: [C\# アプリに \.proto ファイルを追加する](https://docs.microsoft.com/ja-jp/aspnet/core/grpc/basics?view=aspnetcore-6.0#add-a-proto-file-to-a-c-app)
- メタ指定(複数指定可)と、個別指定があり、衝突するとうまく動かないことがある
- GrpcServices: 対象サービス, Both, Server, Client, None が指定可能
- [ItemGroup が何かはこちら](../visualstudio/projectfile.md)

### メタ指定

```xml
<ItemGroup>
  <Protobuf Include="Protos\*" GrpcServices="Server" />
</ItemGroup>
```

### 個別指定

```xml
<ItemGroup>
  <Protobuf Include="Protos\greet.proto" GrpcServices="Server" />
  <Protobuf Include="Protos\hello.proto" GrpcServices="Server" />
</ItemGroup>
```
