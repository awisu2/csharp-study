# NuGet について

.NET のパッケージ管理

## NOTE

- 管理画面の表示
  - solution や project の右クリック \> Manage NuGet Packages (for solution)...
  - Tools \> NuGet Package Manager
    - \> Manage NuGet Packages for solution...: gui
      - 上記と同じく Gui 管理
    - \> Package Manager Console
      - コマンドで NuGet の管理が可能。管理対象がわかっていれば Gui よりも素早く操作が可能
    - \> Package Manager Settings: Settings on Solution
      - ダウンロード元や、不足パッケージのダウンロード許可などの設定が可能。あまりいじることは無さそう

## Package Manager Console

NuGet の管理をコンソール上で行える

例えば、Grpc のクライアント用パッケージは以下のようなコマンドで実行が可能

```bash
Install-Package Grpc.Net.Client
Install-Package Google.Protobuf
Install-Package Grpc.Tools
```
