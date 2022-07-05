# xunit

- [Getting started: \.NET Core with command line > xUnit\.net](https://xunit.net/docs/getting-started/netcore/cmdline)

---

- xunit のプロジェクト作って、テストしたいプロジェクトを参照
- `[Fact]` または `[Theory]` が付いた関数がテストとして実行される
  - `[Theory]` はテスト用の値を複数指定できるアノテーション `[InlineData(3)]` こんな感じで指定ができる
- 実行は `dotnet test`, 右クリックからの実行, テストコンソール で実行などが可能
- テストクラスのプロパティにクラスインスタンスを設置して利用することも可能(普通のクラス)
  - テストごとにリセットされているっぽい

## hands up

```bash
mkdir MyFirstUnitTests
cd MyFirstUnitTests
dotnet new xunit

# これでテスト内で利用可能に
dotnet add reference ../MyFirstUnit/MyFirstUnit.csproj
```
