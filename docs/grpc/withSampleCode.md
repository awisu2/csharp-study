# csharp での grpc 実装に関する各種事項の調査

- [ASP\.NET Core で \.NET Core gRPC のクライアントとサーバーを作成する \| Microsoft Docs](https://docs.microsoft.com/ja-jp/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-3.0&tabs=visual-studio)

## NOTE

- やっと理解したこととしては、**この一連の話は ASP.NET 上の話**だということ。(.NET はバージョンが多くていつの間にか混ざってるからなー)
- バージョンによってちょいちょい記載が変わっていたり中身がなかったりする
  - [ASP\.NET Core 5.0](https://docs.microsoft.com/ja-jp/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-5.0)
  - [ASP\.NET Core 6.0](https://docs.microsoft.com/ja-jp/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)

## はじめの起動部分

- [IHostBuilder](https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.extensions.hosting.ihostbuilder?view=dotnet-plat-ext-6.0&viewFallbackFrom=net-5.0)を生成して、それを`Build().Run()` する。
- 生成は[Host](https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.extensions.hosting.host?view=dotnet-plat-ext-6.0)により行われており、[`ConfigureWebHostDefaults()`](https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.extensions.hosting.generichostbuilderextensions.configurewebhostdefaults?view=aspnetcore-5.0) にて Web アプリのセットも行っている

NOTE

- about Host: [ASP\.NET Core の \.NET 汎用ホスト \| Microsoft Docs](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-5.0)
- ここで不思議なのが、ConfigureWebHostDefaults がで IHostBuider の標準関数として乗っていないこと。
  - [GenericHostBuilderExtensions](https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.extensions.hosting.generichostbuilderextensions?view=aspnetcore-5.0)を見ると、この関数情報が乗っており ASP.NET Core 5.0 系の時限定の拡張要素と思われる。
    - [] ドキュメントに、Generic の(extension になる) 由来などの情報は無いので別途気にしておく
  - _ドキュメント迷子になりやすいので注意_。(インタフェースである IHostBuilder のドキュメントを見ると、普通に ASP.NET Core のバージョン指定が外れてたりする。)

### ConfigureWebHostDefaults()

[ConfigureWebHostDefaults\(IHostBuilder, Action\<IWebHostBuilder\>\)](https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.extensions.hosting.generichostbuilderextensions.configurewebhostdefaults?view=aspnetcore-5.0)

Web の具体的な挙動設定部分。
デフォルトでは,以下のコードのみだった。`Startup` クラスにて別途 grpc の基本動作を記載

```cs
webBuilder.UseStartup<Startup>();
```

以下の記載を追記することで、_0.0.0.0/80_ で Listen させることができた。

[appsettings.json, launchSettings.json](../visualstudio/settingFiles.md) で指定することも可能

```cs
webBuilder.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 80, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});
```

Note

- webBuilder は: [IWebHostBuilder](https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder?view=aspnetcore-6.0)
- [Kestrel](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-6.0&tabs=windows#kestrel): default HTTP server で、cross-platform 対応
  - [Kestrel over view](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-6.0)
  - [Kestrel vs\. HTTP\.sys](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-6.0&tabs=windows#korh): nginx, abache, IIS などを噛ませた場合との対比
- [] ConfigureWebHostDefaults で可能な他の設定

#### Startuup.cs

- [UseStartup\<TStartup\>\(IWebHostBuilder\)](<https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilderextensions.usestartup?view=aspnetcore-6.0#microsoft-aspnetcore-hosting-webhostbuilderextensions-usestartup-1(microsoft-aspnetcore-hosting-iwebhostbuilder)>)
- [ASP\.NET Core fundamentals overview \| Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-6.0&tabs=windows)

`webBuilder.UseStartup<Startup>();` として呼び出されているクラス 特になんかのインタフェースは持っていない

このメソッドによって、Grpc が設定されている

```cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc();
}
```

こういう感じで service を追加するみたい

```cs
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
```

- `app.UseEndpoints()` によって、Grpc で実際に使う Grpc サービスや、ルート設定が行われている
- app.UseXXX のことを middleware と呼ぶ。各種機能尾を追加
  - [ASP\.NET Core fundamentals overview \| Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-6.0&tabs=windows#middleware)

NOTE

- `app.UseDeveloperExceptionPage();`の詳細: [開発者例外ページ](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/error-handling?view=aspnetcore-3.1#developer-exception-page-2)

#### Startup.cs 詳細

- [Startup クラス](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/startup?view=aspnetcore-5.0)
  - [] ASP.NET Core 6.0 だとドキュメントから消えてベタなメソッド記載になっている。なにか記述方法に変化があった？
- [環境別の起動のクラスとメソッド](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/environments?view=aspnetcore-3.1#environment-based-startup-class-and-methods)
