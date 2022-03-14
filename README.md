# csharp-study

- [about .NET](./docs/aboutDotnet.md)

## install and run

- [Visual Studio: ソフトウェア開発者とチーム向けの IDE およびコード エディター](https://visualstudio.microsoft.com/ja/)
  - Different of Community and Professional: [Visual Studio 製品の比較 \| Visual Studio](https://visualstudio.microsoft.com/ja/vs/compare/)
- [Install \.NET on Windows \| Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net60)
  - The latest version of .NET is 6. (2022-03-10)

### windows

- on the windows may be installed "C:\Windows\Microsoft.NET\Framework64\{version}" (version as a "v4.0.30319")
  - When use `csc` command, set PATH of environment or specific directory
- "C:\Users\{user}\AppData\Local\Microsoft\dotnet"

#### dotnet-install command

```ps1
Invoke-WebRequest -Uri https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.ps1 -OutFile dotnet-install.ps1
./dotnet-install.ps1
```

### mac

- `/Library/Frameworks/Mono.framework/Versions/Current/Commands/csc`
