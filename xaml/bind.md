# bind

[データ バインディングの概要 \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/data-binding/data-binding-quickstart)

## NOTE

- x:Bind と Binding の違い: ざっくりとだが、xaml 外の値を利用する場合は `x:Bind`、 xmal 内のデータを利用する場合は `Binding` と考えるとわかりやすい
  - Mode の指定ができ、OneWay または TwoWay の場合、値の変更を受け付けるようになる
    - デフォルトは `OneTime` らしく、初回取得でしか走らない
- 値の変更通知: `IFNotifyPropertyChanged`の実装が一番の基礎的な方法みたい
  - `ObservableCollection`を利用した配列(Collection?)の変更通知実装もある
    - [項目のコレクションへのバインド](https://docs.microsoft.com/ja-jp/windows/uwp/data-binding/data-binding-quickstart#binding-to-a-collection-of-items)
- [] `DependencyProperty`: プロパティを色々する？まだ良くわかってない
  - [Create a Single Page App with Uno Platform](https://platform.uno/docs/articles/getting-started-tutorial-2.html)
  - [DependencyProperty クラス \(System\.Windows\) \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/api/system.windows.dependencyproperty?view=windowsdesktop-6.0)

## 変更通知を楽にするライブラリ

- [] どれがいいのか調査
- [mvvm\-helpers](https://github.com/jamesmontemagno/mvvm-helpers)
- [runceel/ReactiveProperty](https://github.com/runceel/ReactiveProperty)

## samples

### direct use

but this usage first time showing only. can't update.

```cs
public sealed partial class MainPage : Page
{
    private string hello = "hello world";
}
```

```xml
<TextBlock Text="{x:Bind hello}" />
```

### with update (IFNotifyPropertyChanged)

[INotifyPropertyChanged インターフェイス \(System\.ComponentModel\) \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-6.0)

- 更新を通知するには基本的に `IFNotifyPropertyChanged` に対応する必要がある
- 具体的には `PropertyChangedEventHandler` のインスタンスを保持し、値の変更時は `Invoke()` をする

```cs
using System;
using System.ComponentModel; // INotifyPropertyChanged
using System.Runtime.CompilerServices; // CallerMemberName

namespace HelloUnoPlatform.Models
{
    public class HelloINotifyPropertyChanged : INotifyPropertyChanged
    {
        // 通知インスタンス
        public event PropertyChangedEventHandler PropertyChanged;

        // 通知関数
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        // ここまではおまじない ----------

        // string hello
        private string hello = string.Empty;
        public string Hello
        {
            get { return hello; }
            set
            {
                if (value != this.hello)
                {
                    this.hello = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
```

```cs
using HelloUnoPlatform.Models;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace HelloUnoPlatform
{
    public sealed partial class MainPage : Page
    {
        public HelloINotifyPropertyChanged hello = new HelloINotifyPropertyChanged();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ChangeHello(object sender, RoutedEventArgs e)
        {
            var next = hello.Hello == "hello world" ? "good night" : "hello world";
            hello.Hello = next;
        }
    }
}
```

```xml
<Page
    x:Class="HelloUnoPlatform.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <StackPanel>
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="{x:Bind hello.Hello, Mode=OneWay}" />
                <Button Content="change" Click="ChangeHello" />
            </StackPanel>
        </StackPanel>
    </Grid>
</Page>
```

## with update (ObservableCollection)

公式サンプル

- [項目のコレクションへのバインド](https://docs.microsoft.com/ja-jp/windows/uwp/data-binding/data-binding-quickstart#binding-to-a-collection-of-items)

```cs
namespace HelloUnoPlatform.Models
{
    public class Recording
    {
        public string Name { get; set; }
        public Recording()
        {
            this.Name = "FizzBuzz";
        }
    }

    // アクセス用の viewmodel クラス。親クラスやアノテーション指定はない
    public class RecordingViewModel
    {
        private Recording defaultRecording = new Recording();
        public Recording DefaultRecording { get { return this.defaultRecording; } }

        // 更新が通達可能な形式で登録
        private ObservableCollection<Recording> recordings = new ObservableCollection<Recording>();
        public ObservableCollection<Recording> Recordings { get { return this.recordings; } }
    }
}
```

```xml
    <Page.Resources>
        <CollectionViewSource x:Name="RecordingsCollection" Source="{x:Bind ViewModel.Recordings}"/>
    </Page.Resources>

    <Grid>
        <ListView ItemsSource="{Binding Source={StaticResource RecordingsCollection}}"/>
    </Grid>
```

### dependency property

- [] mvmHelper
- [] viewmodel

```cs
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloUnoPlatform.Models
{
    public class Counter: ObservableObject
    {
        private int num;
        public int Num
        {
            get => num;
            set => SetProperty(ref num, value);
        }
    }
}
```

```cs
    public static readonly DependencyProperty CounterProperty = DependencyProperty.Register(nameof(MainCounter), typeof(Counter), typeof(MainPage), new PropertyMetadata(default(Counter)));

    public Counter MainCounter
    {
        get => (Counter)GetValue(CounterProperty);
        set => SetValue(CounterProperty, value);
    }
```
