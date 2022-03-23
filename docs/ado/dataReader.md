# DataReader and adapter

- [DataReader によるデータの取得 \- ADO\.NET \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/retrieving-data-using-a-datareader)

## NOTE

- [basicSample](./basicSample.md)

## usage

1. DataReader can get from `cmd.ExecuteReader()`
2. DataReader must Call `Close()` before end
   - easy way is use `using`
3. DataReader can read datas by `Read()`
4. DataReader.`schemaTable` has schemes infomation
   - Columns: schemes name
   - Rows: schemes Value

## codes

- before ran `CREATE TABLE IF NOT EXISTS user (id INTEGER PRIMARY KEY, name TEXT);` and insert datas.

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
            // builder of string for SQLiteConnection
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();

            // connection setting (coding)
            var decktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            builder.DataSource = @$"{decktop}\user.sqlite";
            var connectionString = builder.ConnectionString;

            //// connection setting (from config file)
            //ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            //var connectionString = settings["Sqlite"].ConnectionString;

            // connectionString: data source=C:\Users\{user}\Desktop\user.sqlite
            return new SQLiteConnection(connectionString);
        }

        public void WithReader()
        {
            // connection db
            using (var con = this.connnection())
            {
                try
                {
                    con.Open();

                    using (var cmd = con.CreateCommand())
                    {
                        // select
                        cmd.CommandText = @"select * from user;";

                        // Reader must call `Close()` or with `using`
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // access column name or index
                                Console.WriteLine($"{reader[0]}: {reader["name"]}");
                            }

                            // schemeTable >>>>>
                            var schemaTable = reader.GetSchemaTable();
                            var columnOne = schemaTable.Columns[0];
                            foreach (DataRow row in schemaTable.Rows)
                            {
                                foreach (DataColumn column in schemaTable.Columns)
                                {
                                    Console.WriteLine($"{column}: {row[column]}");
                                }
                                break;
                            }
                            // ColumnName: id
                            // ColumnOrdinal: 0
                            // ColumnSize: 8
                            // NumericPrecision: 19
                            // NumericScale: 0
                            // IsUnique: True
                            // IsKey: True
                            // BaseServerName:
                            // BaseCatalogName: main
                            // BaseColumnName: id
                            // BaseSchemaName: sqlite_default_schema
                            // BaseTableName: user
                            // DataType: System.Int64
                            // AllowDBNull: False
                            // ProviderType: 12
                            // IsAliased: False
                            // IsExpression: False
                            // IsAutoIncrement: False
                            // IsRowVersion: False
                            // IsHidden: False
                            // IsLong: False
                            // IsReadOnly: False
                            // ProviderSpecificDataType:
                            // DefaultValue:
                            //    DataTypeName: INTEGER
                            //    CollationType: BINARY

                            // schemeTable <<<<<
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
