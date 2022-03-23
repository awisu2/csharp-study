# command execute

[コマンドの実行 \- ADO\.NET \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/executing-a-command)

## NOTE

## commands

- ExecuteReader: DataReader オブジェクトを返します。
- ExecuteScalar: 単一のスカラー値を返します。
- ExecuteNonQuery: 行を一切返さないコマンドを実行します。
- ExecuteXMLReader: XmlReader を返します。 SqlCommand オブジェクトでのみ使用できます。

## codes

```cs
using System;
using System.Configuration;
using System.Data.SQLite;

var connectionString = "data source=C:\Users\{user}\Desktop\user.sqlite";
using (var con = new SQLiteConnection(connectionString))
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
```
