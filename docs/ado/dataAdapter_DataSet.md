# DataAdapter and DataSet

- [DataAdapter からの DataSet の読み込み \- ADO\.NET \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/populating-a-dataset-from-a-dataadapter)
- [DataAdapter パラメーター \- ADO\.NET \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/dataadapter-parameters)

## NOTE

- DataAdapter は select の結果を保持して DateSet に登録することが可能(`adapter.Fill(dataset, srcTable)`)
- 1 つの DataSet に複数の DataAdapter が `Fill()`することが可能
- adapter.Fill()
  - 自動で必要なときに `connection.Open()`, `connection.Close()`を行う
    - もともと開いていた場合は何もしない
  - 識別子(テーブル名)を指定してセットすることが可能
- DataSet は
  - Fill されたレコードにアクセスが可能
  - 複数のテーブル間のリレーションを構築することが可能
    - [] [例](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/populating-a-dataset-from-a-dataadapter#example-1)

## codes

```cs
using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace ADOSqlite
{
    internal class SqliteSample
    {
        private SQLiteConnection connnection()
        {
            return new SQLiteConnection("data source=C:\Users\{user}\Desktop\user.sqlite");
        }

        public void WithAdapter()
        {
            // connection db
            using (var con = this.connnection())
            {
                try
                {
                    // adapter not need Open()
                    // automatycaly Open() and Close() by Fill()
                    // con.Open()

                    // create adapter
                    var sql = @"select * from user limit 5;";
                    var adapter = new SQLiteDataAdapter(sql, con);

                    // set to DataSet from DataAdapter
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    adapter.Fill(dataset, "Users"); // with tablename

                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                        Console.WriteLine($"{row["id"]}: {row["name"]}");
                    }

                    foreach (DataRow row in dataset.Tables["Users"].Rows)
                    {
                        Console.WriteLine($"{row["id"]}: {row["name"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // generate adapter
        private SQLiteDataAdapter GenerateAdapter(SQLiteConnection con)
        {
            var adapter = new SQLiteDataAdapter();

            // set select
            adapter.SelectCommand = new SQLiteCommand(@"select id, name as change_name from user order by id desc limit 5;", con);
            adapter.InsertCommand = new SQLiteCommand(@"INSERT INTO user ([name]) VALUES (@Name);", con);
            adapter.DeleteCommand = new SQLiteCommand(@"Delete From user WHERE id = @id", con);

            // @Name と change_name を結びつける
            // InstertCommandの扱いがよくわからないが, selectCommandのカラム名と対応させる
            adapter.InsertCommand.Parameters.Add("@Name", DbType.String, 255, "change_name");

            adapter.DeleteCommand.Parameters.Add("@id", DbType.Int32, 255, "id");

            return adapter;
        }

        // insert delete with generate adapter
        public void WithAdapter2()
        {
            // connection db
            using (var con = this.connnection())
            {
                try
                {
                    // create adapter
                    var adapter = GenerateAdapter(con);

                    var dataset = new DataSet();
                    adapter.Fill(dataset, "Users");

                    var users = dataset.Tables["Users"];
                    Console.WriteLine($"{users.Rows[0]["id"]}: {users.Rows[0]["change_name"]}");

                    // delete
                    users.Rows[users.Rows.Count - 1].Delete();
                    var deletedRows = users.Select(null, null, DataViewRowState.Deleted);
                    adapter.Update(deletedRows);

                    // add new record
                    var row = users.NewRow();
                    row["change_name"] = "new jondo";
                    users.Rows.Add(row);

                    var row2 = users.NewRow();
                    row2["change_name"] = "new jondo2";
                    users.Rows.Add(row2);

                    // update
                    var addedRows = users.Select(null, null, DataViewRowState.Added);
                    adapter.Update(addedRows);

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
