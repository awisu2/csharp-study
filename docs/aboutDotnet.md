# about .NET

- [いろいろな種類がある \.NET の違いとは \- Synamon’s Engineer blog](https://synamon.hatenablog.com/entry/2021/10/18/190000)
- [\.NET の派生を理解する](https://www.infoq.com/jp/articles/varieties-dotnet/)
- [対応バージョン](./supportVersions.md)

## .NET 分類

- ざっくり 2 種類ある、Windows のみ対応のものと、マルチプラットフォームのもの。
  - マルチプラットフォームの場合だいたい Core がつく、.NET 5 以降は core を付けなくなったが、ASP はまだ ASP core とついているので注意
- ASP は network を担当しており、大抵インタフェースに拡張を施す感じで実装されている。上記 2 種類にそれぞれ存在している
- Mono, Xamarin: は core ができる前に、Windows のみをマルチプラットフォーム対応しようとしたもの(現役)。派生としては Windows のみの方なので注意

### .NET series

- .NET Framework, .NET 4 (~4): **.NET Framework** series for windows (application)
  - GUI: WPF
  - ASP.NET: one of the **.Net Framework** Web Application framework
  - windows 用 GUI 向け
  - Mono: Open source. for **.Net Framework** with multi platform。割といい感じに動くとのこと
    - Xamarin: for clos platform of mobile with Mono.
    - Xamarin Studio: IDE
- .NET 5 (5~), .NET core (ex: 3.x) : **.Net core** series for multi platform
  - GUI: UWP
  - Network: ASP.Net core
  - クロスプラットフォームで利用する際は、こちらか、.Net Standard を選択すると良い
- .NET Standard: いわゆる.NET 郡すべてのの基幹部分。どの.NET にからも依存されており互換性がある(もちろん基礎実装なため、機能も基礎実装的)
  - ライブラリ向け、基本どの環境でも動く

### 派生系

- Mono: .NET Framework > Mono
- Xamarin: .NET Framework > Mono > Xamarin
