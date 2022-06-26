# xaml basics

- top タグで挙動が変わる: Application, Page, TabbedPage, ResourceDictionary, ContentPage, FlyoutPage など
  - 通常は Page か ContentPage かな

## code samples

```xml
<!-- layout -->
<Grid></Grid>
<StackPanel Margin="30 10" Orientation="Vertical"></StackPanel>

<!-- view -->
<TextBlock x:Name="textBlock">UISamplePage</TextBlock>
<Border Background="Black" Padding="1" Margin="0 10 20 50"/>
<Image Source="ms-appx:///Assets/StoreLogo.png" />
<ScrollViewer Height="100" HorizontalScrollMode="Disabled" HorizontalScrollBarVisibility="Disabled" VerticalScrollMode="Auto" VerticalScrollBarVisibility="Auto"></ScrollViewer>

<!-- UI -->
<TextBox Text="form text" Width="100" Margin="10" Padding="10"></TextBox>
<Button Click="OnClickGotoUISample" Content="Go to UISample" />
```

- Margin, Padding: 左 上 右 下 の順で設定される。
  - 設定数により挙動が変わる = 1 つ: 全方向, 2 つ: 左右、上下, ４つ: 各方向
- Image: プロジェクト内の画像であれば簡単に表示できる
- `x:Name`: でプログラムからコンポーネントにアクセスできる

## イベント

### ボタンクリックイベント + 画面移動

```cs
    void OnClick(object sender, RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(OtherPage));
    }
```

```xml
<Button Click="OnClickGotoUISample" Content="Go to UISample" />
```

### テキストボックス

- 変更後の値が取得できる
- text を inspector で見るとエスケープ文字が付与されているが、気にしなくて良い
  - 表示するための便宜上の処理のため実際には付与されていない

```cs
    private void OnTextChanged(object sender, TextChangedEventArgs args)
    {
        var text = (sender as TextBox).Text;
    }
```

```xml
<TextBox Text="form sample" TextChanged="OnTextChanged"></TextBox>
```

## Grid + ScrollViewr

- [Windows アプリのレイアウト パネル \- Windows apps \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/apps/design/layout/layout-panels#grid)

---

- Grid は、Grid.RowDefinitions、Grid.ColumnDefinitions で個別設定をする
  - Height, Width = Auto: 内部コンテンツに合わせる, \*: 残りの幅を埋める
    - `*` は `2*` などと割合を決めることも可能
- `Grid.Row="2" Grid.Column="3"` などを各コンテンツにセットすることで対象場所を指定できる

```xml
   <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
        </Grid.ColumnDefinitions>

        <StackPanel>
            <Button Click="OnClickBack" Content="Back" />
            <StackPanel >
                <TextBox TextChanged="OnTextChanged" />
            </StackPanel>
        </StackPanel>

        <ScrollViewer Grid.Row="2" HorizontalScrollMode="Disabled" HorizontalScrollBarVisibility="Disabled" VerticalScrollMode="Auto" VerticalScrollBarVisibility="Auto" Background="AliceBlue">
            <GridView x:Name="imagesView"
                ItemTemplate="{StaticResource ContactGridViewTemplate}">
            </GridView>
        </ScrollViewer>
    </Grid>
```
