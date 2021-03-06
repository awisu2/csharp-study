# c\# Namespaces

- [\.NET API ブラウザー \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/api/)

---

- バージョンを変更すると含まれているクラスが異なる場合がある
- 基礎となる Namespace は大きく System, Windows, Microsoft に分類される
  - System: 言語の標準機能
  - Windows: Windows OS 関係主に、UI 周りの機能
  - Microsoft: VisualBasic をメインにした、Windows 機能を主に保有。
    - WinUI3 に合わせ Windows \> Microsoft へ Namespace の移行をしようとしているみたい
      - [WinUI 3 and Uno Platform](https://platform.uno/docs/articles/uwp-vs-winui3.html)

## system

- [System](https://docs.microsoft.com/ja-jp/dotnet/api/system?view=dotnet-uwp-10.0)

---

- [System\.Buffers](https://docs.microsoft.com/ja-jp/dotnet/api/system.buffers?view=net-6.0): メモリー バッファーの作成および管理に使用できる、Span\<T\> と Memory\<T\> によって表現される型
- [System\.CodeDom\.Compiler](https://docs.microsoft.com/ja-jp/dotnet/api/system.codedom.compiler?view=net-6.0): サポートされているプログラミング言語でのソース コードの生成とコンパイルを管理するための型
- [System\.Collections](https://docs.microsoft.com/ja-jp/dotnet/api/system.collections?view=net-6.0): リスト、キュー、ビット配列、ハッシュ テーブル、ディクショナリなど、オブジェクトのさまざまなコレクション
- [System\.ComponentModel](https://docs.microsoft.com/ja-jp/dotnet/api/system.componentmodel?view=net-6.0): コンポーネントとコントロールの実行時およびデザイン時の動作を実装するために使用できるクラス
- [System\.Data](https://docs.microsoft.com/ja-jp/dotnet/api/system.data?view=net-6.0): ADO.NET アーキテクチャを表すクラスにアクセス
- [System\.Configuration\.Assemblies](https://docs.microsoft.com/ja-jp/dotnet/api/system.configuration.assemblies?view=net-6.0): アセンブリを構成するために使用されるクラス
- [System\.Diagnostics](https://docs.microsoft.com/ja-jp/dotnet/api/system.diagnostics?view=net-6.0): システム プロセス、イベント ログ、およびパフォーマンス カウンターと対話するためのクラス
- [System\.Drawing](https://docs.microsoft.com/ja-jp/dotnet/api/system.drawing?view=net-6.0): GDI+ の基本的なグラフィックス機能を使用できるようにします
- [System\.Dynamic](https://docs.microsoft.com/ja-jp/dotnet/api/system.dynamic?view=net-6.0): 動的言語ランタイムをサポート
- System.Formats
- [System\.Formats\.Asn1](https://docs.microsoft.com/ja-jp/dotnet/api/system.formats.asn1?view=net-6.0): Abstract Syntax Notation One (ASN.1) データ構造の読み取りと書き込み
- [System\.Formats\.Cbor](https://docs.microsoft.com/ja-jp/dotnet/api/system.formats.cbor?view=dotnet-plat-ext-6.0): Concise Binary Object Representation (CBOR) 形式でデータの読み取りと書き込み
- [System\.Globalization](https://docs.microsoft.com/ja-jp/dotnet/api/system.globalization?view=net-6.0): 言語、国/地域、使用する暦、日付形式、通貨形式、数値形式、文字列並べ替え順序などのカルチャ関連情報を定義するクラス
- [System\.IO](https://docs.microsoft.com/ja-jp/dotnet/api/system.io?view=net-6.0): ファイルとデータ ストリームに対する読み書きを可能にする型、およびファイルとディレクトリに対する基本的なサポートを提供する型
- [System\.Linq](https://docs.microsoft.com/ja-jp/dotnet/api/system.linq?view=net-6.0): 統合言語クエリ (LINQ) を使用するクエリをサポートするクラスとインターフェイス
- [System\.Net](https://docs.microsoft.com/ja-jp/dotnet/api/system.net?view=net-6.0): 最近のネットワークで使用されている多くのプロトコル用の単純なプログラミング インターフェイスを提供
- [System\.Numerics](https://docs.microsoft.com/ja-jp/dotnet/api/system.numerics?view=net-6.0): .NET に定義されているプリミティブ数値型 (Byte、Double、Int32 など) を補足する数値型
- [System\.Reflection](https://docs.microsoft.com/ja-jp/dotnet/api/system.reflection?view=net-6.0): アセンブリ、モジュール、メンバー、パラメーター、およびその他のマネージド コード内のエンティティに関する情報を、そのメタデータを調べることで取得する型
- [System\.Resources](https://docs.microsoft.com/ja-jp/dotnet/api/system.resources?view=net-6.0): アプリケーションで使用されるさまざまなカルチャ固有のリソースを、開発者が作成、格納、および管理するためのクラスとインターフェイス
- [System\.Runtime](https://docs.microsoft.com/ja-jp/dotnet/api/system.runtime?view=net-6.0): System、Runtime、Security の各名前空間など、さまざまな名前空間をサポートする高度な型
- [System\.Security](https://docs.microsoft.com/ja-jp/dotnet/api/system.security?view=net-6.0): アクセス許可の基本クラスなど、共通言語ランタイムのセキュリティ システムの基盤となる構造
- [System\.Text](https://docs.microsoft.com/ja-jp/dotnet/api/system.text?view=net-6.0): ASCII および Unicode 文字エンコーディングを表すクラス
- [System\.Threading](https://docs.microsoft.com/ja-jp/dotnet/api/system.threading?view=net-6.0): マルチスレッド プログラミングを実現するクラスとインターフェイス
- [System\.Timers](https://docs.microsoft.com/ja-jp/dotnet/api/system.timers?view=net-6.0): 指定した間隔でイベントを発生させることができる Timer コンポーネント
- [System\.Transactions](https://docs.microsoft.com/ja-jp/dotnet/api/system.transactions?view=net-6.0): 独自のトランザクション アプリケーションとリソース マネージャーを記述するクラス
- [System\.Web](https://docs.microsoft.com/en-nz/dotnet/api/system.web?view=net-6.0): ブラウザーとサーバー間の通信を可能にするクラスとインターフェイス
- .Net Core と .net 5 以降では、この名前空間には HttpUtility クラスのみが含まれる
- [System\.Windows\.Input](https://docs.microsoft.com/ja-jp/dotnet/api/system.windows.input?view=net-6.0): Windows Presentation Foundation (WPF) 入力システムをサポートする型
- [System\.Xml](https://docs.microsoft.com/ja-jp/dotnet/api/system.xml?view=net-6.0): XML 処理の標準ベースのサポート

## Windows

- [Windows\.UI](https://docs.microsoft.com/ja-jp/dotnet/api/windows.ui?view=dotnet-plat-ext-3.1)
- [Windows\.UI\.Xaml](https://docs.microsoft.com/ja-jp/dotnet/api/windows.ui.xaml?view=dotnet-uwp-10.0)
- [Windows\.Foundation](https://docs.microsoft.com/ja-jp/dotnet/api/windows.foundation?view=dotnet-plat-ext-3.1)
- \+ [Windows UWP Namespaces](https://docs.microsoft.com/en-us/uwp/api/?view=winrt-22000): for uwp namespaces
  - Windows\.AI
    - [Windows\.AI\.MachineLearning](https://docs.microsoft.com/en-us/uwp/api/windows.ai.machinelearning?view=winrt-22000): Enables apps to load machine learning models
  - [Windows\.ApplicationModel](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel?view=winrt-22000)
  - Windows\.Data
    - [Windows\.Data\.Html](https://docs.microsoft.com/en-us/uwp/api/windows.data.html?view=winrt-22000)
    - [Windows\.Data\.Json](https://docs.microsoft.com/en-us/uwp/api/windows.data.json?view=winrt-22000)
    - [Windows\.Data\.Pdf](https://docs.microsoft.com/en-us/uwp/api/windows.data.pdf?view=winrt-22000)
    - [Windows\.Data\.Text](https://docs.microsoft.com/en-us/uwp/api/windows.data.text?view=winrt-22000)
    - [Windows\.Data\.Xml\.Dom](https://docs.microsoft.com/en-us/uwp/api/windows.data.xml.dom?view=winrt-22000)
  - [Windows\.Devices](https://docs.microsoft.com/en-us/uwp/api/windows.devices?view=winrt-22000): access to the low level device providers, including ADC, GPIO, I2 C, PWM and SPI
  - Windows\.Embedded
    - [Windows\.Embedded\.DeviceLockdown](https://docs.microsoft.com/en-us/uwp/api/windows.embedded.devicelockdown?view=winrt-15063)
  - [Windows\.Foundation](https://docs.microsoft.com/en-us/uwp/api/windows.foundation?view=winrt-22000)
  - Windows.Gaming
    - [Windows\.Gaming\.Input](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input?view=winrt-22000)
  - [Windows\.Globalization](https://docs.microsoft.com/en-us/uwp/api/windows.globalization?view=winrt-22000)
  - [Windows\.Graphics](https://docs.microsoft.com/en-us/uwp/api/windows.graphics?view=winrt-22000)
  - [Windows\.Management](https://docs.microsoft.com/en-us/uwp/api/windows.management?view=winrt-22000)
  - [Windows\.Media](https://docs.microsoft.com/en-us/uwp/api/windows.media?view=winrt-22000)
  - [Windows\.Networking](https://docs.microsoft.com/en-us/uwp/api/windows.networking?view=winrt-22000)
  - [Windows\.Perception](https://docs.microsoft.com/en-us/uwp/api/windows.perception?view=winrt-22000)
  - Windows\.Phone
    - [Windows\.Phone\.ApplicationModel](https://docs.microsoft.com/en-us/uwp/api/windows.phone.applicationmodel?view=winrt-15063)
  - Windows\.Security
    - [Windows\.Security\.Authentication\.Identity Namespace](https://docs.microsoft.com/en-us/uwp/api/windows.security.authentication.identity?view=winrt-22000)
  - Windows\.Services
    - [Windows\.Services\.Cortana](https://docs.microsoft.com/en-us/uwp/api/windows.services.cortana?view=winrt-22000)
  - [Windows\.Storage](https://docs.microsoft.com/en-us/uwp/api/windows.storage?view=winrt-22000): Provides classes for managing files, folders, and application settings
  - [Windows\.System](https://docs.microsoft.com/en-us/uwp/api/windows.system?view=winrt-22000): Enables system functionality such as launching apps, obtaining information about a user, and memory profiling.
  - [Windows\.UI](https://docs.microsoft.com/en-us/uwp/api/windows.ui?view=winrt-22000): Provides an app with access to core system functionality and run-time information about its UI
  - [Windows\.Web](https://docs.microsoft.com/en-us/uwp/api/windows.web?view=winrt-22000): Provides information on errors resulting from web service operations.

## Microsoft

- [Microsoft\.VisualBasic](https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.visualbasic?view=dotnet-uwp-10.0): Visual Basic で Visual Basic Runtime をサポートする型
- Win32
  - [Microsoft\.Win32\.SafeHandles](https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.win32.safehandles?view=net-5.0): ファイルとオペレーティング システム ハンドルをサポートする共通機能を提供するセーフ ハンドル クラスの抽象的派生クラス
- [Microsoft\.CSharp\.RuntimeBinder](https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.csharp.runtimebinder?view=net-5.0): 動的言語ランタイムと C# の間の相互運用をサポート
- \+ [Microsoft Windows UI Library namespaces](https://docs.microsoft.com/en-us/windows/winui/api/): for WinUI(2, 3) namespaces
  - [Microsoft\.Foundation](https://docs.microsoft.com/en-us/windows/winui/api/microsoft.foundation?view=winui-3.0): Enables fundamental Windows Runtime functionality
  - [Microsoft\.Graphics\.DirectX](https://docs.microsoft.com/en-us/windows/winui/api/microsoft.graphics.directx?view=winui-3.0): Specifies pixel formats, and other enumerated constants, for use with Windows Runtime Direct3D 11 interop surfaces.
  - [Microsoft\.UI](https://docs.microsoft.com/en-us/windows/winui/api/microsoft.ui?view=winui-3.0): Provides an app with access to core system functionality and run-time information about its UI.

## other

- [Accessibility](https://docs.microsoft.com/ja-jp/dotnet/api/accessibility?view=netframework-4.8): コンポーネント オブジェクト モデル (COM) のアクセシビリティ インターフェイス用のマネージド ラッパー
- [UIAutomationClientsideProviders](https://docs.microsoft.com/ja-jp/dotnet/api/uiautomationclientsideproviders?view=netframework-4.8): クライアント オートメーション プロバイダーを割り当てる単一の型
