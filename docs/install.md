# install and run

- [Visual Studio: ソフトウェア開発者とチーム向けの IDE およびコード エディター](https://visualstudio.microsoft.com/ja/)
  - Different of Community and Professional: [Visual Studio 製品の比較 \| Visual Studio](https://visualstudio.microsoft.com/ja/vs/compare/)
- [Install \.NET on Windows \| Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net60)
  - The latest version of .NET is 6. (2022-03-10)

## windows

- on the windows may be installed "C:\Windows\Microsoft.NET\Framework64\{version}" (version as a "v4.0.30319")
  - When use `csc` command, set PATH of environment or specific directory
- "C:\Users\{user}\AppData\Local\Microsoft\dotnet"

### dotnet-install command

```ps1
Invoke-WebRequest -Uri https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.ps1 -OutFile dotnet-install.ps1
./dotnet-install.ps1
```

## mac

- `/Library/Frameworks/Mono.framework/Versions/Current/Commands/csc`

## ubuntu に 5.0 6.0 をインストールする

インストール方法はこちら。ただし6.0しか書いてない

- [Install \.NET on Ubuntu \- \.NET \| Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu)

5.0をインストールしたい場合は、20.04 のdepを一回インストールして、`apt update` する

- パッケージリポジトリの削除方法: `sudo apt-get remove packages-microsoft-prod`
- .netのパッケージリポジトリファイルダウロード: `wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb`
  - 22.4: `wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb`
- リポジトリインストール: `sudo dpkg -i packages-microsoft-prod.deb`
  - バージョンが上なら上書き可能っぽい
- リポジトリ更新: `sudo apt update` リポジトリインストールとセットで
- .net インストール `sudo apt-get install -y dotnet-sdk-5.0`, `sudo apt-get install -y dotnet-sdk-6.0`
