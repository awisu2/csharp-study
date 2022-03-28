# Blazor

- [Blazor University – Learn the new \.NET SPA framework from Microsoft](https://blazor-university.com/)

## Quick Start

1. (If not yet) Visual Studio Installer \> install ASP.NET
2. Visual Studio \> new Project \> choose Blazor Server App
3. Run(Ctrl + F5)

### 動作

1. 最初に index.html が利用される
2. App.razor が呼ばれ、アセンブリや、Layerout の指定などを行う
3. Pages 以下のファイルに記載されている @page の指定に従い各ページが表示される

### NOTE

- Add @ to indicate it's cSharp
- Folder structure
  - wwwroot: basic html, css, js files.
  - Pages: displays the page files. each files have @page (ex: `@page "/fetchdata"`), it Synchronize with url.
  - Shared
- Razor 構文: html に C#を記述できるように拡張した構文。拡張子 **.razor**
