# csharp-study

## basic

- [about .NET](./docs/aboutDotnet.md): about .NET. .NET has a lot of kind.
- [basic things](./docs/basicthings.md): So i am beginner
- [basic codes](./HelloVisualStudioSolution/README.md)
- [visualstudio](./docs/visualstudio/README.md): visual studio
- [NuGet](./docs/visualstudio/nuget.md): .Net's package (manager)

## docs

- [install & run](./docs/install.md)
- [suport versions](./docs/supportVersions.md): .NET and C# versions
- [about visual studio](./docs/supportVersions.md): about visual studio and shortcuts ...etc
- [grpc](./docs/grpc/README.md): network access protocol like REST
- [dotnet command](./docs/dotnet.md): can controll .NET project on CLI
- [unittest](./docs/unittest.md)

### ASP.NET

- [about ASP\.NET Core](https://docs.microsoft.com/ja-jp/aspnet/core/ntroduction-to-aspnet-core?view=aspnetcore-6.0)
- [Kestrel](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-6.0): ASP.NET Core's web server
  - [AspNetCore\.Docs/kestrel\.md at main · dotnet/AspNetCore\.Docs](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/fundamentals/servers/kestrel.md): Kestrel についての説明ではあるが、Microsoft サイト では記載のない appsettings.json での設定項目が載っている(まとまっていないので要調査)

## codes

- [async await task](./codes/asyncAwaitTask.md)
- [dictionary](./codes/dictionary.md)

## gui

- [uno platform](./docs/unoPlatform.md)
- [xaml](./docs/xaml/xaml.md): xaml with uwp and c#

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
