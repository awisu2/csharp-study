# setting files

appsettings.json, launchSettings.json について

## [] appsettings.json とは

[既定の builder 設定](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-5.0#default-builder-settings-1)

- Host の`CreateDefaultBuilder()` にて読み込まれる設定ファイル
- 環境別の設定が有効なようで、_appsettings.{Environment}.json_ の読み込みも行われるっぽい
- [] まだ調査が必要だが、Publish 時には全環境用のファイルがコピーされる
- problems
  - Publish したときに appsettings.json が反映されない
  - 解決方法: 実行ファイルと同じディレクトリに cd してから起動
  - article: [c\# \- Self\-Contained ASP\.Net Core Not Reading appsettings\.json file \- Stack Overflow](https://stackoverflow.com/questions/56761561/self-contained-asp-net-core-not-reading-appsettings-json-file)
  - 原因: `CreateDefaultBuilder()`は current directory を基準に appsettings.json を探しているから

## [] launchSettings.json とは

[開発と launchSettings\.json](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/environments?view=aspnetcore-3.1#development-and-launchsettingsjson-1)

- local 環境のみで有効、publish などの際は持ち越されない
