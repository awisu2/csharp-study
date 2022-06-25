# Just create projects

See the differences between projects.

- ConsoleApp
  - Net5 vs Net6 : "Program.cs" change to sipmly.
    - if check "Do not use top level statemet" go back to the old one.
- AspNetCore: AspNetCore's basicaly setting. 
  - 後述のコードの、app や builder にいろいろ機能をつけていく
  - Empty vs Configure Https: Add https settings to launchSettings.json.
  - Api
    - Empty vs Use Controllers:
    - Empty vs Enable Open Api Support: 
      - Enable support of Swagger Gui
      - Add `<PackageReference Include="Swashbuckle.AspNetCore" Version="6.2.3" />` to Project file
      - Add codes to "Programs.cs"
  - App: Such as a Web page that implemention is razor
- Blazor
  - App vs WebAssembly:
    - Add `<PackageReference Include="Microsoft.AspNetCore.Components.WebAssembly" Version="6.0.5" />` and more to project file
    - コードもいろいろ違う。通常使うならAppのほう

## Code of asp .Net core Empty

```cs
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
```
