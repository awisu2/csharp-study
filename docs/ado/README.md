# ADO.NET

- [ADO\.NET \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/)

## What ADO.NET

- > ActiveX Data Object (ADO)
- > SQL Server や XML などのデータ ソースや、OLE DB や ODBC 経由で公開されるデータ ソースに対する一貫性を持ったアクセス機能を実現
- > 結果は直接処理され、ADO.NET DataSet オブジェクトに格納されます
- > DataSet オブジェクトを .NET Framework データ プロバイダーに関係なく使用した場合でも、... 管理できます。
  - [x] .NET Framework とは切り離して管理できる? \> .NET5 の コンソールアプリで作成することはできた
- > ADO ではなく ADO.NET を使用することをお勧めします。
  - [] この 2 つは異なる?
- > ADO.NET クラスは System.Data.dll にあり、System.Xml.dll に含まれている XML クラスに統合されています

## todos

- [] LINQ
- [DataSet クラス \(System\.Data\) \| Microsoft Docs](https://docs.microsoft.com/ja-JP/dotnet/api/system.data.dataset?view=net-6.0)
- 基になるストレージ モデルではなく概念モデルをアプリケーションで使用できるようにするための高度な抽象化については、「[ADO\.NET Entity Framework](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/ef/)」を参照してください。

## NOTE

- sample code. (write later)
- connection
- [executes](./executes.md): ExecuteReader, ExecuteNonQuery など
- [DataReader](./dataReader.md)

## 順番に理解する

1. [basic sample](./basicSample.md): how to use first ADO
2. [what execute?](./executes.md)
3. [DataReader](./dataReader.md): read datas and scheme
4. [DataAdapter, DataSet](./dataAdapter_DataSet.md): DataAdapter is accsess supporter, DataSet is Adapter's Data instance
   - DB の扱いが少し簡単になり、リレーションなどが可能になる
   - 独特の記述が必要

- [] command builder
