# ASP.NET Core

- [ASP\.NET Core の概要 \| Microsoft Docs](https://docs.microsoft.com/ja-jp/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)

## about ASP.NET Core

- ASP.NET Core は、インターネットに接続された最新のクラウド対応アプリを構築するための、クロス プラットフォーム
- [vs ASP\.NET and ASP\.NET Core](./vsAspnet.md)
- [推奨のラーニング パス](https://docs.microsoft.com/ja-jp/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0#recommended-learning-path)
- [ASP\.NET Core の基礎の概要](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/?view=aspnetcore-6.0&tabs=windows)
- [Minimal API の概要](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0)

## basic senario

- [ASP\.NET Core のシナリオ](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/choose-aspnet-framework?view=aspnetcore-6.0#aspnet-core-scenarios)

---

- [Web サイト](https://docs.microsoft.com/ja-jp/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-6.0&tabs=visual-studio)
- [API](https://docs.microsoft.com/ja-jp/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio)
- [リアルタイム](https://docs.microsoft.com/ja-jp/aspnet/core/signalr/introduction?view=aspnetcore-6.0): SignalR
- [Azure に ASP.NET Core アプリをデプロイする](https://docs.microsoft.com/ja-jp/azure/app-service/quickstart-dotnetcore?tabs=net60&pivots=development-environment-vs)

## hositing functions

- server
  - [Kestrel](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-6.0): ASP.NET Core のプロジェクト テンプレートに既定で含まれ、有効になっている Web サーバー
  - HTTPS, HTTP/2, Websocket, Nginx (背後にある高パフォーマンスの UNIX ソケット)
  - [IIS](https://docs.microsoft.com/ja-jp/aspnet/core/host-and-deploy/iis/?view=aspnetcore-6.0): Web アプリ (ASP.NET Core を含む) をホストするための、柔軟で安全で管理しやすい Web サーバー
  - [HTTP\.sys](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/servers/httpsys?view=aspnetcore-6.0): Windows 上でのみ動作する ASP.NET Core 用 Web サーバー(Kestrel では提供されていない機能がいくつか用意されています)
  - IIS や IIS Express で使用することはできません
- framework
  - [gRPC](https://docs.microsoft.com/ja-jp/aspnet/core/grpc/?view=aspnetcore-6.0): 高性能なリモート プロシージャ コール (RPC) フレームワーク
- hosiging with other system
  - [Nginx 搭載の Linux で ASP\.NET Core をホストする](https://docs.microsoft.com/ja-jp/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-6.0)
  - [Apache 搭載の Linux で ASP\.NET Core をホストする](https://docs.microsoft.com/ja-jp/aspnet/core/host-and-deploy/linux-apache?view=aspnetcore-6.0)
  - [Docker コンテナーで ASP\.NET Core をホストする](https://docs.microsoft.com/ja-jp/aspnet/core/host-and-deploy/docker/?view=aspnetcore-6.0)
- browser(?) ui
  - [Razor ページ](https://docs.microsoft.com/ja-jp/aspnet/core/razor-pages/?view=aspnetcore-6.0&tabs=visual-studio): ページのコーディングに今まで以上に集中できます
  - [Blazor](https://docs.microsoft.com/ja-jp/aspnet/core/blazor/?view=aspnetcore-6.0): 対話型のクライアント側 Web UI を構築するためのフレームワーク
- codes
  - [dependency injection(依存関係の挿入)](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0)
- management
  - [アプリケーション レベルでの複数の \.NET バージョン](https://docs.microsoft.com/ja-jp/dotnet/standard/choosing-core-framework-server#side-by-side-net-versions-per-application-level): support side by side install
