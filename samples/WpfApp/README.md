# wpf app

- [配置、余白、パディングの概要 \- WPF \.NET Framework \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/desktop/wpf/advanced/alignment-margins-and-padding-overview?view=netframeworkdesktop-4.8)

---

- uwp との違い
  - Permission制限がない
  　　- ImageのSourceも単にSourceを指定するだけでOK
- デバッグ出力: `DEbug.Print();` Immediate Windows で表示される (`using System.Diagnostics;`)
- xamlのデフォルト位置設定: Top, Center, Stretch っぽい

## xaml

- ボタンをテキストに合わせたサイズにする: "HorizontalAlignment" を指定 (default = Stretch)
  - `<Button Click="OnClickGotoUISample" Content="hoge" HorizontalAlignment="Left" />`
- style: 別途Styleを指定しておき呼び出せる (サンプルは後述)
  - Window.Resources 内で宣言し、TargetTypeを指定
  - x:Key で DynamicRecouce から指定できる


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
