# visual studio

- [project file](./projectfile.md)(.csproj) は Msbuild 用設定ファイルの一つ
- [shortcut](./shortcut.md)
- [NuGet](./nuget.md)

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
