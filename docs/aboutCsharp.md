# about C\#

- [C Sharp \- Wikipedia](https://ja.wikipedia.org/wiki/C_Sharp)

## NOTE

- [.NET](./aboutDotnet.md) に依存しており, csc.exe や dotnet コマンドでコンパイルする。
  - 通常は visual studio 上からのコンパイル及び実行
  - csc.exe, `dotnet build` について: [\.NET Framework projects](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/#net-framework-projects)
    - > .NET Framework projects use csc.exe instead of dotnet build to build projects.
    - > The word for some compiler options changed from csc.exe and .NET Framework projects to the new MSBuild system.
  - unity や mac でも .sln, .csproj によって管理している
    - .NET 5~をインストールすることで `dotnet`コマンドが利用可能なはず
- CLI と呼ばれる中間言語を生成し実行を行う.
  - コンパイラの仕様上生成対象の指定は特にないが事実上 CLI を生成するのが基本となっている
