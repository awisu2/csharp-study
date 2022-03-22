# app.config アプリ構成ファイルについて

- [構成ファイルからのカスタム情報の保存 \| Microsoft Docs](https://docs.microsoft.com/ja-jp/troubleshoot/developer/visualstudio/csharp/general/store-custom-information-config-file)
- [構成ファイルを使用してアプリを構成する方法 \- \.NET Framework \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/framework/configure-apps/)
- [アプリケーション設定のスキーマ](https://docs.microsoft.com/ja-jp/dotnet/framework/configure-apps/file-schema/application-settings-schema)
- [How to add an app\.config file to a project \- Visual Studio \(Windows\) \| Microsoft Docs](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-add-app-config-file?view=vs-2022)

## TODO

- [] スキーマは見たが、ADO の場合記載のないスキーマを利用していた。多分拡張だけれどわからない
  - [接続文字列と構成ファイル \- ADO\.NET \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/connection-strings-and-configuration-files#the-connectionstrings-section)
- [] プロジェクトファイルに特に記載が追加されないが、ADO のために git 管理からは外したい可能であるか？
  - xml の記載によって判定しているから関係ないのかな

## NOTE

- NuGet: `System.Configuration.ConfigurationManager`
- how to add app.config: `Project \> new Item \> Application Configuration File`
- \> 構成ファイルは、関連付けられたアプリケーションと同じフォルダーに保存する必要があります。
- \> 構成ファイル名には、次の構文を使用する必要があります。`<ApplicationName>.<ApplicationType>.config`
  - \>アプリケーション `<ApplicationName>` の名前はここで指定します。 `<ApplicationType>` は、アプリケーションの種類です。.exe 。 必須 .config の接尾辞です。
  - [トラブルシューティング](https://docs.microsoft.com/ja-jp/troubleshoot/developer/visualstudio/csharp/general/store-custom-information-config-file)
  - 細かくはよくわからないが、動作上 `App.config` は OK `App1.config` は NG だった

## sample code

### simple

[How to: Read application settings](https://docs.microsoft.com/ja-jp/dotnet/framework/configure-apps/read-app-settings)

_App.config_

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<appSettings>
		<add key="occupation" value="dentist"/>
	</appSettings>
</configuration>
```

```cs
using System.Configuration;

string occupation = ConfigurationManager.AppSettings["occupation"];
Console.WriteLine(occupation);
```

### ConfigSections

- [] what mean: `ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);`
- sectionGroup, section の name はフリー: 対応するタグが存在していれば OK
- sectionGroup is optional

App.config

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
        <sectionGroup name="userSettings" type="System.Configuration.UserSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
            <section name="ADOSqlite.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" allowExeDefinition="MachineToLocalUser" requirePermission="false" />
        </sectionGroup>
    </configSections>
    <userSettings>
        <ADOSqlite.Settings>
            <setting name="Foo" serializeAs="String">
                <value>Bar</value>
            </setting>
        </ADOSqlite.Settings>
    </userSettings>
</configuration>
```

```cs
var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
ConfigurationSectionGroup userSettings = config.SectionGroups["userSettings"];
var settingsSection = userSettings.Sections["ADOSqlite.Settings"] as ClientSettingsSection;
string v = settingsSection.Settings.Get("Foo").Value.ValueXml.InnerText;

Console.WriteLine($"value: {v}");
```

### ConnectionStrings (from ADO(ActiveX Data Object))

[例:すべての接続文字列を一覧表示する](https://docs.microsoft.com/ja-jp/dotnet/framework/data/adonet/connection-strings-and-configuration-files#example-listing-all-connection-strings)

- このファイルは本番などでは隠蔽する必要があるので、.gitignore に乗せるなどの工夫が必要
- 実際利用する場合は `connectionString` に完全なアクセス文字列をセットしておき `cs.ConnectionString` で Connection 時に値を渡すのが妥当か
  - ここで利用する文字列は `XXXStringBuilideer` を利用して生成すると良い

_App.config_

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<connectionStrings>
		<add name="key1"
		 providerName="System.Data.ProviderName"
		 connectionString="Valid Connection String;" />
	</connectionStrings>
</configuration>
```

```cs
using System.Configuration;

// get one of setting
ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
var cs = settings["key1"];
Console.WriteLine(cs.Name);
Console.WriteLine(cs.ProviderName);
Console.WriteLine(cs.ConnectionString);

// write all value
ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
if (settings != null)
{
    foreach (ConnectionStringSettings cs in settings)
    {
        Console.WriteLine(cs.Name);
        Console.WriteLine(cs.ProviderName);
        Console.WriteLine(cs.ConnectionString);
    }
}
```
