# dotnet commands

.NET をインストールすると同時に利用できるようになる

.NET プロジェクト関係の処理をコマンドラインから実行可能

## help

<details>
<summary>dotnet -h</summary>

```txt
.NET SDK (6.0.201)
使用法: dotnet [runtime-options] [path-to-application] [arguments]

.NET アプリケーションを実行します。

runtime-options:
  --additionalprobingpath <path>   調査ポリシーと調査対象アセンブリを含むパス。
  --additional-deps <path>         追加の deps.json ファイルへのパス。
  --depsfile                       <application>.deps.json ファイルへのパス。
  --fx-version <version>           アプリケーションを実行するために使用するインストール済み Shared Framework のバージョン。
  --roll-forward <setting>         フレームワーク バージョン (LatestPatch、Minor、LatestMinor、Major、LatestMajor、Disable) にロールフォワードします。
  --runtimeconfig                  <application>.runtimeconfig.json ファイルへのパス。

path-to-application:
  実行するアプリケーション .dll ファイルへのパス。

使用法: dotnet [sdk-options] [command] [command-options] [arguments]

.NET SDK コマンドを実行します。

sdk-options:
  -d|--diagnostics  診断出力を有効にします。
  -h|--help         コマンド ラインのヘルプを表示します。
  --info            .NET 情報を表示します。
  --list-runtimes   インストール済みランタイムを表示します。
  --list-sdks       インストール済み SDK を表示します。
  --version         使用中の .NET SDK バージョンを表示します。

SDK コマンド:
  add               .NET プロジェクトにパッケージまたは参照を追加します。
  build             .NET プロジェクトをビルドします。
  build-server      ビルドによって開始されたサーバーとやり取りします。
  clean             .NET プロジェクトのビルド出力をクリーンします。
  format            プロジェクトやソリューションにスタイルのユーザー設定を適用します。
  help              コマンド ラインのヘルプを表示します。
  list              .NET プロジェクトのプロジェクト参照を一覧表示します。
  msbuild           Microsoft Build Engine (MSBuild) コマンドを実行します。
  new               新しい .NET プロジェクトまたはファイルを作成します。
  nuget             追加の NuGet コマンドを提供します。
  pack              NuGet パッケージを作成します。
  publish           .NET プロジェクトを配置のために公開します。
  remove            .NET プロジェクトからパッケージまたは参照を削除します。
  restore           .NET プロジェクトに指定されている依存関係を復元します。
  run               .NET プロジェクトの出力をビルドして実行します。
  sdk               .NET SDK のインストールを管理します。
  sln               Visual Studio ソリューション ファイルを変更します。
  store             指定されたアセンブリをランタイム パッケージ ストアに格納します。
  test              .NET プロジェクトに指定されているテスト ランナーを使用して、単体テストを実行します。
  tool              .NET のエクスペリエンスを向上するツールをインストールまたは管理します。
  vstest            Microsoft Test Engine (VSTest) コマンドを実行します。
  workload          オプションのワークロードを管理します。

バンドルされたツールからの追加コマンド:
  dev-certs         開発証明書を作成し、管理します。
  fsi               F# Interactive を開始するか、F# スクリプトを実行します。
  sql-cache         SQL Server キャッシュ コマンドライン ツール。
  user-secrets      開発ユーザーのシークレットを管理します。
  watch             ファイルが変更されたときにコマンドを実行するファイル ウォッチャーを起動します。

コマンドに関する詳細情報については、'dotnet [command] --help' を実行します。

```

</details>

## commands

ヘルプを並び替えただけ

- control
  - new 新しい .NET プロジェクトまたはファイルを作成します。
  - add .NET プロジェクトにパッケージまたは参照を追加します。
  - list .NET プロジェクトのプロジェクト参照を一覧表示します。
  - remove .NET プロジェクトからパッケージまたは参照を削除します。
  - restore .NET プロジェクトに指定されている依存関係を復元します。
  - sln Visual Studio ソリューション ファイルを変更します。
- nuget
  - nuget 追加の NuGet コマンドを提供します。
  - pack NuGet パッケージを作成します。
- sdk, tool
  - sdk .NET SDK のインストールを管理します。
  - tool .NET のエクスペリエンスを向上するツールをインストールまたは管理します。
- build, test
  - build .NET プロジェクトをビルドします。
  - msbuild Microsoft Build Engine (MSBuild) コマンドを実行します。
  - run .NET プロジェクトの出力をビルドして実行します。
  - build-server ビルドによって開始されたサーバーとやり取りします。
  - clean .NET プロジェクトのビルド出力をクリーンします。
  - test .NET プロジェクトに指定されているテスト ランナーを使用して、単体テストを実行します。
  - vstest Microsoft Test Engine (VSTest) コマンドを実行します。
- publish
  - publish .NET プロジェクトを配置のために公開します。
  - store 指定されたアセンブリをランタイム パッケージ ストアに格納します。
- other, ?
  - help コマンド ラインのヘルプを表示します。
  - format プロジェクトやソリューションにスタイルのユーザー設定を適用します。
  - workload オプションのワークロードを管理します。
