# proto ファイルについて

- [proto ファイル](https://docs.microsoft.com/ja-jp/aspnet/core/grpc/basics?view=aspnetcore-6.0#proto-file)
- [Protocol Buffers  \|  Google Developers](https://developers.google.com/protocol-buffers)

gRpc のプロトコル設定ファイル(**Protobuf**)。これを元に各言語は Inteface や実コードを生成する

## basic

- **Protobuf** と呼ばれる
- [Grpc\.Tools](https://www.nuget.org/packages/Grpc.Tools/) が必要
  - サーバプロジェクトの場合、_Grpc.AspNetCore メタパッケージには、Grpc.Tools への参照が含まれます_ とのことなので、以下の記載をプロジェクトファイルに追加で良いらしい
    - `<PackageReference Include="Grpc.AspNetCore" Version="2.32.0" />`
  - クライアントの場合は、 Grpc.Tool への直接参照が必要
- プロジェクトがビルドされるたびに、必要に応じて生成されます
- プロジェクトに追加されないか、ソース管理にチェックインされません
- obj ディレクトリに格納されるビルド成果物です
  - なので proto を書いたら一回ビルドすると補完が効く
- [visual studio 上でのファイル指定](./gettingStart.md)

## コード生成

[gRPC のサービスとメソッドを作成する \| Microsoft Docs](https://docs.microsoft.com/ja-jp/aspnet/core/grpc/services?view=aspnetcore-6.0)

<details>

<summary>greeter.proto</summary>

```cs
syntax = "proto3";

service Greeter {
  rpc SayHello (HelloRequest) returns (HelloReply);
}

message HelloRequest {
  string name = 1;
}

message HelloReply {
  string message = 1;
}
```

</details>

をビルドすると

<details>

<summary>GreeterBase Class</summary>

```cs
public abstract partial class GreeterBase
{
    public virtual Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
    }
}

public class HelloRequest
{
public string Name { get; set; }
}

public class HelloReply
{
public string Message { get; set; }
}
```

</details>

が生成されるので、以下のように実装する

<details>
<summary>GreeterService.cs</summary>

```cs
public class GreeterService : GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply { Message = $"Hello {request.Name}" });
    }
}
```

</details>

## message

[\.NET アプリの Protobuf メッセージを作成する \| Microsoft Docs](https://docs.microsoft.com/ja-jp/aspnet/core/grpc/protobuf?view=aspnetcore-6.0)

protobuf 上での型定義のようなもの
