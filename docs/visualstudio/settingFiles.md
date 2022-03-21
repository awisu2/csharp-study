# setting files

appsettings.json, launchSettings.json について

## [] appsettings.json とは

[既定の builder 設定](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-5.0#default-builder-settings-1)

- Host の[`CreateDefaultBuilder()`](https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.aspnetcore.webhost.createdefaultbuilder?view=aspnetcore-6.0) にて読み込まれる設定ファイル
- 環境別の設定が有効なようで、_appsettings.{Environment}.json_ の読み込みも行われるっぽい
- [] まだ調査が必要だが、Publish 時には全環境用のファイルがコピーされる
- problems
  - Publish したときに appsettings.json が反映されない
  - 解決方法: 実行ファイルと同じディレクトリに cd してから起動
  - article: [c\# \- Self\-Contained ASP\.Net Core Not Reading appsettings\.json file \- Stack Overflow](https://stackoverflow.com/questions/56761561/self-contained-asp-net-core-not-reading-appsettings-json-file)
  - 原因: `CreateDefaultBuilder()`は current directory を基準に appsettings.json を探しているから
- 環境別ファイル名: _appsettings.Production.json_ および _appsettings.Development.json_
  - from official: [IHostingEnvironment\.EnvironmentName](https://docs.microsoft.com/ja-JP/dotnet/api/microsoft.extensions.hosting.ihostingenvironment.environmentname?view=dotnet-plat-ext-6.0) に基づいて読み込まれます。 詳細については、「[ASP\.NET Core で複数の環境を使用する](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/environments?view=aspnetcore-6.0)」を参照してください。
    - [IHostEnvironment の実例](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-6.0#ihostenvironment)
    - we can show it in _StartUp.cs_ > `Configure(IApplicationBuilder app, IWebHostEnvironment env)`
  - publish 時: Configuration の値に関係なく Production
    - [] Configuration から何らかの値を読みに行って変更? Production はデフォルトとの記載はあった

## [] launchSettings.json とは

[開発と launchSettings\.json](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/environments?view=aspnetcore-3.1#development-and-launchsettingsjson-1)

- local 環境のみで有効、publish などの際は持ち越されない
