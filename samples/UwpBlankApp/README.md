# uwp blank app

## 基本挙動

- 最初にNuGet で `Xamarin.forms` を追加する必用があった。毎回かはわからない
- App.xaml が起動対象: タグは Application, プログラム内部では主に、起動、終了などのシステムハンドリングをしている
  - `OnLaunched()` 内で `rootFrame.Navigate(typeof(MainPage), e.Arguments);` としており、初期表示対象となっている。

## inner links

- [xaml basics](./docs/xaml.md): how to use xaml sample.
- [privacy settings](./docs/privacy.md): access file permission etc.
- [image](./docs/image.md): show image

## 新規追加してみた結果

新規追加で文字検索と、メニューのXAMLを選択した場合に結果が違う

- BlankPage: Pageタグを持つ空ページ
- XamlView: プログラム部分のない xamlファイル
