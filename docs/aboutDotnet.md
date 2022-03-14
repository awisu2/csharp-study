# about .NET

- [いろいろな種類がある \.NET の違いとは \- Synamon’s Engineer blog](https://synamon.hatenablog.com/entry/2021/10/18/190000)
- [\.NETの派生を理解する](https://www.infoq.com/jp/articles/varieties-dotnet/)

## .NET　分類

- .NET Standard: いわゆる.NET郡すべてのの基幹部分。どの.NETにからも依存されており互換性がある(もちろん基礎実装なため、機能も基礎実装的)
  - ライブラリ向け、基本どの環境でも動く
- .NET Framework, .NET 4 (~4): **.NET Framework** series for windows (application)
  - GUI: WPF
  - ASP.NET: one of the **.Net Framework**  Web Application framework
  - windows用GUI向け
  - Mono: Open source. for **.Net Framework** with  multi platform。割といい感じに動くとのこと
    - Xamarin: for clos platform of mobile with Mono.
    - Xamarin Studio: IDE
- .NET 5 (5~), .NET core (ex: 3.x) : **.Net core** series for multi platform
  - UWP, ASP.Net core
  - クロスプラットフォームで利用する際は、こちらか、.Net Standardを選択すると良い

### 派生系

- Mono: .NET Framework > Mono
- Xamarin: .NET Framework > Mono > Xamarin
