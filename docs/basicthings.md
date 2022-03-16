# basic things

- namespace: 基本的に書く。 `{Project}[.{directory}][.{directory}]...`という形式
- visual studio
  - check packages have been updates to latest.(need each new solutions)
    - solution(maybe solution Explorer Top) > right click > `Manage NuGet Packages for Solution` > NuGet View > Updates Tab
  - using が不足して赤線が出ている場合: カーソルを合わせていると出るコンテキストか、alt+enter でサポートしてくれる。それでもだめな場合は自力で調査
  - uwp
    - xaml ファイルと、class が連携して画面を構成する: 画面上では xaml の配下に .cs があるように表示されるが、それぞれ同ディレクトリに存在
    - xaml
      - Grid: コンテンツを gurid に並べることが可能で、blank page を作成したときなどは基本タグとして記入される

## 突然出てきてわからなかったやつ

- OnNavigatedTo(NavigationEventArgs e): Page のファンクションの一つ、遷移時に実行される
  - [Page\.OnNavigatedTo\(NavigationEventArgs\) Method \(Windows\.UI\.Xaml\.Controls\) \- Windows UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/uwp/api/windows.ui.xaml.controls.page.onnavigatedto?view=winrt-22000)
- DependencyProperty
  - [DependencyProperty クラス \(System\.Windows\) \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/api/system.windows.dependencyproperty?view=windowsdesktop-6.0)
- DependencyProperty と{x:Bind Any, Mode=OneWay}を活用することで、リアルタイム更新ができるようになった
  - DependencyProperty: 特定のプロパティにいろいろな機能を付け加える。今回の場合はデータバインディング
  - x:Bind の OneWay: 「モードが OneWay/TwoWay の場合は、変更検出が実行されて、オブジェクトが変化するとバインディングが再評価されます」とのこと
    - [x:Bind の関数 \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/data-binding/function-bindings)
    - [{x:Bind} で設定できるプロパティ](https://docs.microsoft.com/ja-jp/windows/uwp/xaml-platform/x-bind-markup-extension#properties-that-you-can-set-with-xbind)
- データバインディングについて
  - [データ バインディングの詳細 \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/data-binding/data-binding-in-depth)
