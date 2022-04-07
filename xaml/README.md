# xmal

- [Windows アプリのレイアウト パネル \- Windows apps \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/apps/design/layout/layout-panels)

## important

- xaml の調べ方
  - まとまった資料が(まだ)見つからない。_[デザイン概要](https://docs.microsoft.com/ja-jp/windows/apps/design/)_ ページにぶら下がる形で分散して状況別の解説がある
  - こちらの Github( [microsoft/Xaml\-Controls\-Gallery at winui3](https://github.com/microsoft/Xaml-Controls-Gallery/tree/winui3) )で、一通りの動作を動かしつつ見ることが可能

## NOTE

- [xmlns](./xmlns.md)
- [bind](./bind.md)
- viewmodel について: 単なる class での実装を散見する
  - xaml への通知が可能な形式で構成する必要はあるが、これは mvvm としての必要要件とは別
- official docs
  - [デザイン](https://docs.microsoft.com/ja-jp/windows/apps/design/)
  - [レイアウト](https://docs.microsoft.com/ja-jp/windows/apps/design/layout/layouts-with-xaml)
  - [コントロール](https://docs.microsoft.com/ja-jp/windows/apps/design/controls/)
  - [スタイル](https://docs.microsoft.com/ja-jp/windows/apps/design/style/): 色、文字、アイコン、サウンド
  - [モーション](https://docs.microsoft.com/ja-jp/windows/apps/design/motion/)

## Functions

- move page: `Frame.Navigate(typeof(SubPage));`

## mvvm helps

- ReactiveProperty
- MVVMHelpers
- Prism
- MvvmCross
- ReactiveUI
- MVVMLite

## view samples

### ListView
