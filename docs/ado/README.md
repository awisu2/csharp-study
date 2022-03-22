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

- sample code. write later
- connection

## sqlite sample code

1. create connection
2. open connection
3. run coomand

- need NuGet `System.Data.SQLite`

```csharp
using System;
using System.Data.SQLite;

namespace ADOSqlite
{
    internal class SqliteSample
    {
        public void AccessSample()
        {
            // builder of string for SQLiteConnection
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();

            // connection setting
            var decktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            builder.DataSource = @$"{decktop}\user.sqlite";

            // connection db
            using (var con = new SQLiteConnection(builder.ConnectionString))
            {
                try
                {
                    con.Open();

                    using (var cmd = con.CreateCommand())
                    {
                        // create
                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS user (id INTEGER PRIMARY KEY, name TEXT);";
                        cmd.ExecuteNonQuery();

                        // insert
                        cmd.CommandText = @"INSERT INTO user(name) values ('jondo')";
                        cmd.ExecuteNonQuery();

                        // select
                        cmd.CommandText = @"select * from user;";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // access column name or index
                                Console.WriteLine($"{reader[0]}: {reader["name"]}");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
```
