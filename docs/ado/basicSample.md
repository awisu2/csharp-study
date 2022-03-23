# basic sample

## sqlite sample code

1. create connection
2. open connection
3. run coomand

- need NuGet `System.Data.SQLite`

```csharp
using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace ADOSqlite
{
    internal class SqliteSample
    {
        public void Access()
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

            // connection db
            // connectionString: data source=C:\Users\{user}\Desktop\user.sqlite
            using (var con = new SQLiteConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // transaction
                    using(var trans = con.BeginTransaction())
                    {
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

                        trans.Commit();
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
