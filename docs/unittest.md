# unittest

[Visual Studio のテスト ツール \- Visual Studio \(Windows\) \| Microsoft Docs](https://docs.microsoft.com/ja-jp/visualstudio/test/?view=vs-2022)

- visual studio のテスト機能
  - テスト エクスプローラー: visual studio の UI 上でテストできるよ
  - enterprise version(有料)
    - Live Unit Testing: バックグラウンドでテスト実行
    - IntelliTest: テストとテストデータの生成
    - コード カバレッジ: テストがどのくらい満たされているかの割合確認
    - Microsoft Fakes: アプリケーションの別の部分をスタブまたは shim で置き換えることにより、テストするコードを分離できます
      - [] よくわらからない。Mock みたいなものだろうか？
      - Microsoft Fakes 分離フレームワークによって、テスト対象コード内の依存関係を作成する実稼働コードおよびシステム .NET コード向けの代替クラスおよび代替メソッドを作成できます。 関数の Fake デリゲートを実装して、依存関係オブジェクトの動作と出力を制御します。
- ソリューションへのプロジェクト追加で選択できるテスト: NUnit, xUnit, MSTest
  - NUnit, xUnit は同率で、MsTest はあんまり人気がないとのこと
  - NUnit はよくある Unittest, xUnit は非常に厳密で拡張性が高い
  - 記法の比較: [Comparing xUnit\.net to other frameworks > xUnit\.net](https://xunit.net/docs/comparisons)
  - links
    - [C\#のテストフレームワークを MSTest から xUnit に乗り換えたい時にその理由を同僚に説明できるようにする \- Qiita](https://qiita.com/kojimadev/items/c451196fb703cbf99e86)
    - [neue cc \- C\#\(\.NET\)のテストフレームワーク 4 種の比較雑感](https://neue.cc/2011/03/03_308.html)

## create unittest by dotnet command(NUnit)

- [NUnit と \.NET Core による単体テスト C\# \- \.NET \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/core/testing/unit-testing-with-nunit)
