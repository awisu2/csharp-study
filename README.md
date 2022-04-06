# csharp-study

## basic

- [about C\#](./docs/aboutCsharp.md)
- [about .NET](./docs/aboutDotnet.md): about .NET. .NET has a lot of kind.
  - [suport versions](./docs/supportVersions.md): .NET and C# versions
- [basic things](./docs/basicthings.md): So i am beginner
- [basic codes](./HelloVisualStudioSolution/README.md)
- [visualstudio](./docs/visualstudio/README.md): visual studio
- [NuGet](./docs/visualstudio/nuget.md): .Net's package (manager)

## docs

- [install & run](./docs/install.md)
- [dotnet command](./docs/dotnet.md): can controll .NET project on CLI
- [about visual studio](./docs/supportVersions.md): about visual studio and shortcuts ...etc
- [Mono](https://www.mono-project.com/docs/)
- [about xxx.config](./docs/appConfig.md): App.config など アプリケーション設定と呼ばれる アプリ設定について
  - [] 他にも usesetting.json, web.config などがある

### ASP.NET

- [about ASP\.NET Core](https://docs.microsoft.com/ja-jp/aspnet/core/ntroduction-to-aspnet-core?view=aspnetcore-6.0)
- [Kestrel](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-6.0): ASP.NET Core's web server
  - [AspNetCore\.Docs/kestrel\.md at main · dotnet/AspNetCore\.Docs](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/fundamentals/servers/kestrel.md): Kestrel についての説明ではあるが、Microsoft サイト では記載のない appsettings.json での設定項目が載っている(まとまっていないので要調査)

## codes

- [async await task](./codes/asyncAwaitTask.md)
- [commandline arguments](./docs/getCommandlineArgs.md)
- [dictionary](./codes/dictionary.md): type of the dictionay
- [grpc](./docs/grpc/README.md): network access protocol like REST
- [unittest](./docs/unittest.md)

## files

- [files](./files/README.md): ファイルへのアクセスとその制限

## xaml

- [images](./images/README.md): uwp で画像を表示する

### db

- [ADO, ADO.NET, LINQ](./docs/ado/README.md)

## gui

- [uno platform](./docs/unoPlatform.md): multiplatform
- [xaml](./xaml/README.md): xaml with uwp and c#

## webassembly

- [uno platform](./docs/unoPlatform.md): multiplatform
- [blazor](./brazor/README.md)

## Words

- VisualStudio Installer: manageent multi version VisualStudios, and modify tools, SDK, libraries ...etc in each VisualStudios.
- VisualStudio
  - solution: muli project management system. like vscode workspace
    - has a config file named _{solution name}.sln_ for management
    - directories
      - .vs: ? (any binaly)
  - project
    - has a xml file named _{project name}.csproj_
    - directories
      - bin: build file directory. set builded file when build
      - obj: temporary files for run visual studio
