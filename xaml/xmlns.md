# xmlns

[での XAML 名前空間 Xamarin\.Forms \- Xamarin \| Microsoft Docs](https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/xaml/namespaces)

xmal を生成したときに `<Page>` とともに設定されている `xmlns` について

- 連携して動作するクラスの指定: `x:Class`
  - 正しくは、XAML で定義されているクラスの名前空間とクラス名を指定
- 自前のクラスを設定する `xmlns:{name}="using:{namespace}"` or `xmlns:{name}="clr-namespace:{namespace}"` どちらも同じ
  - ex: `xmlns:models="using:Helloworld.Models"` => `models.YourClass` のようにアクセスができるようになる
