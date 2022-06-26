# wpf app

- [配置、余白、パディングの概要 \- WPF \.NET Framework \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/desktop/wpf/advanced/alignment-margins-and-padding-overview?view=netframeworkdesktop-4.8)

---

- uwp との違い
  - Permission 制限がない
    　　- Image の Source も単に Source を指定するだけで OK
  - x:Bind がない
- デバッグ出力: `DEbug.Print();` Immediate Windows で表示される (`using System.Diagnostics;`)
- xaml のデフォルト位置設定: Top, Center, Stretch っぽい
- binding:
  - links
    - [第 5 回　 WPF の「データ・バインディング」を理解する：連載：WPF 入門（1/3 ページ） \- ＠IT](https://atmarkit.itmedia.co.jp/ait/articles/1010/08/news123.html)
    - [方法: TextBox テキストでソースを更新するタイミングを制御する \- WPF \.NET Framework \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/desktop/wpf/data/how-to-control-when-the-textbox-text-updates-the-source?view=netframeworkdesktop-4.8)
  - samplecode
    - [WPF\-Samples/Sample Applications/DataBindingDemo at master · microsoft/WPF\-Samples](https://github.com/microsoft/WPF-Samples/tree/master/Sample%20Applications/DataBindingDemo)
  - 成功例:
    1. `INotifyPropertyChanged` で通知可能なインスタンスを生成
    2. Page 内で `DataContext` に インスタンスをセット
    3. xaml 内で `{Binding {property}}` でアクセスできる
    4. 更新を反映させるには `Mode=TwoWay, UpdateSourceTrigger=PropertyChanged` を指定する必要がある
       - 受信側(TextBlock など) の Mode を指定する必要はない

## xaml

- ボタンをテキストに合わせたサイズにする: "HorizontalAlignment" を指定 (default = Stretch)
  - `<Button Click="OnClickGotoUISample" Content="hoge" HorizontalAlignment="Left" />`
- style: 別途 Style を指定しておき呼び出せる (サンプルは後述)
  - Window.Resources 内で宣言し、TargetType を指定
  - x:Key で DynamicRecouce から指定できる
- window, Page, UserControl = window: 独立して表示可能, Page: Window 内での遷移先, UserControl: カスタム UI(Window 内に設置)
  - [C\# WPF Window,Page,UserControl の違い \- Qiita](https://qiita.com/nie/items/3e2f6f37b3425585952b)
- 画面遷移:
  - [WPF と Visual Studio で画面遷移を実装する方法 \| \.NET コラム](https://www.fenet.jp/dotnet/column/environment/4951/)
  - まず Frame を設定して、その中でページを表示/遷移するのが基本
  - page 遷移: `NavigationService.Navigate(new SubPage());`
  - window 遷移: `new SubWindow().Show();`

## samples

### style

```xml
    <Window.Resources>
        <Style x:Key="ButtonStyle" TargetType="{x:Type Button}">
            <Setter Property="HorizontalAlignment" Value="Center" />
        </Style>
    </Window.Resources>
    <Grid>
        <StackPanel>
            <Button Click="OnClickGotoUISample" Content="hoge" Style="{DynamicResource ButtonStyle}" />
        </StackPanel>
    </Grid>
```

## binding のイマイチよくわからない挙動

- DataContext に無名クラスをセットすると表示されるが、単純なクラスの場合 public でも反映されない
  - ok: `DataContext = new { MyText = "mytext" };`
  - ng: `DataContext = new SampleData();`
  - ok: INotifyPropertyChanged を継承したクラス
