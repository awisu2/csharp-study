# connection

- [データ ソースへの接続 \- ADO\.NET \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/connecting-to-a-data-source)
- [接続文字列 \- ADO\.NET \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/connection-strings)

NOTE

- 接続用の文字列を生成する Builder が存在
  - [接続文字列ビルダー \- ADO\.NET \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/connection-string-builders)

## 接続情報を隠す

- [接続文字列と構成ファイル \- ADO\.NET \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/connection-strings-and-configuration-files)
- [接続情報の保護 \- ADO\.NET \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/protecting-connection-information): 何が問題なのかを記載。最終的に構成ファイルの利用をおすすめとなる

NOTE

- コンパイルしていても、[Ildasm\.exe \(IL 逆アセンブラー\)](https://docs.microsoft.com/ja-jp/dotnet/framework/tools/ildasm-exe-il-disassembler)などを利用して、解析できてしまう
- ソースコードとは別のアクセス管理がされたファイルからの読み取りが望ましいが、それには構成ファイルがおすすめ
- 構成ファイルとして web.config(ASP.NET アプリケーションの場合), app.config(Windows アプリケーションの場合) を利用可能
- [] ? providerName は、**machine.config** ファイルに登録された .NET Framework データ プロバイダーの不変名です
  - [app.config を利用した隠蔽](../appConfig.md)
  - 前置きなしの machine.config って何？
