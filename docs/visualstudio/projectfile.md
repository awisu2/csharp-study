# project file

[プロジェクトファイルについて Microsoft Docs \| Microsoft Docs](https://docs.microsoft.com/ja-jp/aspnet/web-forms/overview/deployment/web-deployment-in-the-enterprise/understanding-the-project-file)

- プロジェクトファイル(.csproj) は Msbuild 用設定ファイルの一つ
- プロジェクトファイルの構造: write later

## .csproj, .dproj, .vbproj などと MsBuild

1. **MsBuild**: Visual Studio は ビルド時に MsBuild を利用して各プロジェクトのビルドをしている
2. **MsBuild プロジェクトファイル**: MsBuild 用のプロジェクトビルド設定ファイル
3. **.csproj** など: MsBuild プロジェクトファイルの派生, .cproj, .dproj, .vbproj など各用途向けの拡張子になっている

## プロジェクトファイルの構造

[プロジェクトファイルの構造](https://docs.microsoft.com/ja-jp/aspnet/web-forms/overview/deployment/web-deployment-in-the-enterprise/understanding-the-project-file#the-anatomy-of-a-project-file)

- `<Project>`: 全てのプロジェクトのルート要素。 XML スキーマの識別や、ビルド時のエントリポイントの指定が可能
- `<PropertyGroup>`: ビルド用の各種パラメータを含むことができる
  - プロパティ値の取得: `$({yourproperty})` という形式。(どこでなのかはわからん)
    - 環境変数、組み込みプロジェクトプロパティの取得も同じ形式
    - 共通値や、マクロ、予約値などの詳細は別記(リンクが多い)
    - [条件式](https://docs.microsoft.com/ja-jp/previous-versions/visualstudio/visual-studio-2015/msbuild/msbuild-conditions?view=vs-2015&redirectedfrom=MSDN)を含めることができる
- `<ItemGroup>`: `<Item>` を保有する事ができる
  - [`<Item>`](https://docs.microsoft.com/ja-jp/previous-versions/visualstudio/visual-studio-2015/msbuild/item-element-msbuild?view=vs-2015&redirectedfrom=MSDN): ビルドプロセスへの入力定義値。実態は `Item` ではなく特定の値を表現する名前になる。大抵は処理/コピーが必要なファイル指定
    - [ItemMetadata](https://docs.microsoft.com/ja-jp/previous-versions/visualstudio/visual-studio-2015/msbuild/itemmetadata-element-msbuild?view=vs-2015&redirectedfrom=MSDN) を含むこともできる
- [`<Target>`](https://docs.microsoft.com/ja-jp/previous-versions/visualstudio/visual-studio-2015/msbuild/msbuild-targets?view=vs-2015&redirectedfrom=MSDN): `<Task>` を保有可能。 _Name_ attribute を持ち識別可能
  - [`<Task>`](https://docs.microsoft.com/ja-jp/previous-versions/visualstudio/visual-studio-2015/msbuild/task-element-msbuild?view=vs-2015&redirectedfrom=MSDN): Target に対し各種タスクを行う
    - 実値は _Task_ ではなく Copy, Message, Csc, Exec などになり、ファイルのコピー、ログへのメッセージ書き込み, C#コンパイラ呼び出し, 何らかの実行 を意味する
- [`<Import>`](https://docs.microsoft.com/ja-jp/previous-versions/visualstudio/visual-studio-2015/msbuild/import-element-msbuild?view=vs-2015&redirectedfrom=MSDN): 外部プロジェクトファイルの import

## プロパティ値の扱い

- [Common macros for MSBuild commands and properties \| Microsoft Docs](https://docs.microsoft.com/en-us/cpp/build/reference/common-macros-for-build-commands-and-properties?redirectedfrom=MSDN&view=msvc-170)
- [Common MSBuild Project Properties \- Visual Studio 2015 \| Microsoft Docs](https://docs.microsoft.com/ja-jp/previous-versions/visualstudio/visual-studio-2015/msbuild/common-msbuild-project-properties?view=vs-2015&redirectedfrom=MSDN)
- [MSBuild Reserved and Well\-Known Properties \- Visual Studio 2015 \| Microsoft Docs](https://docs.microsoft.com/ja-jp/previous-versions/visualstudio/visual-studio-2015/msbuild/msbuild-reserved-and-well-known-properties?view=vs-2015&redirectedfrom=MSDN)
