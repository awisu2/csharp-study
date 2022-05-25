# uwp でアクセス可能な範囲

- [ファイル アクセス許可 \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/files/file-access-permissions)

---

- デフォルトのアクセス可能範囲
  - デフォルトではアプリケーション配下及び特定のユーザディレクトリ以外にアクセスでき ない
  - ex: `System.UnauthorizedAccessException: 'Access to the path 'C:\' is denied.'`
- 基本的にカメラや、Downloads ディレクトリなどいわゆるユーザディレクトリと、picker による指定がされたファイル/ディレクトリ以外を許可する方法がない (2022/04 時点)
  - broadFileSystemAccess を利用することで、ユーザアクセス相当になるとのことだがうまくいかない
- Wpf だと問題なく利用可能なので、ローカルファイルを広く利用したい場合はこちらが選択になってくるか。。。

## デフォルトでアクセス可能な範囲

- アプリケーションのインストール ディレクトリ
- アプリケーション データの場所へのアクセス
  - アプリケーション用に作られるフォルダ的な場所と思われる
- リムーバブル デバイスへのアクセス
- ユーザーの Downloads フォルダー

## アクセス可能な範囲の拡張

- [その他の場所へのアクセス](https://docs.microsoft.com/ja-jp/windows/uwp/files/file-access-permissions#accessing-additional-locations)
  - [ピッカーでファイルやフォルダーを開く \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/files/quickstart-using-file-and-folder-pickers)
    - ピッカーで選択したフォルダやディレクトリはアクセス可能になる
  - AppExecutionAlias: コンソールウィンドなどで起動したときに、起動フォルダ配下をアクセス可能にする
  - [アプリ機能の宣言 \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/packaging/app-capability-declarations)
    - インターネットや、システム情報、windows で保護されている情報などへのアクセス権を獲得する
    - android の permission とにている
  - [ファイルとフォルダーへのアクセスの保持](https://docs.microsoft.com/ja-jp/windows/uwp/files/file-access-permissions#retaining-access-to-files-and-folders)
    - 何らかの方法でアクセスを許可した対象の許可状態を永続化する

## manifest 設定によるアクセス可能設定の追加

- 設定可能なアクセス ID: [Capabilities for accessing other locations](https://docs.microsoft.com/en-us/windows/uwp/files/file-access-permissions#capabilities-for-accessing-other-locations)
- [windows runtime \- broadFileSystemAccess UWP \- Stack Overflow](https://stackoverflow.com/questions/50559764/broadfilesystemaccess-uwp)
- [Windows 10 の UWP アプリ、ユーザーの承認なくファイルシステムへのアクセスが許可されるバグ \| スラド セキュリティ](https://security.srad.jp/story/18/11/03/0018224/)

---

- プロジェクトの "Package.appxmanifest" を編集することで設定可能
  - [サンプルコード](https://docs.microsoft.com/en-us/windows/uwp/files/file-access-permissions#example)
    - `xmlns:rescap` の指定も必用なので気をつける
- `broadFileSystemAccess` を manifest に指定することで、アクセス時のユーザと同等のアクセス権が可能とのこと
  - [アクセス権をチェックするサンプル](./sampleCheckpermission.md)
  - 2018 年からデフォルト disable になったとのこと [c\# \- broadFileSystemAccess for UWP not working \- Stack Overflow](https://stackoverflow.com/questions/59802498/broadfilesystemaccess-for-uwp-not-working)
- `picturesLibrary` の動作を確認
  - `broadFileSystemAccess`がなくてもアクセスできた
- 最後に windows 自体の設定でアクセス権を設定する必要あり
  - windows \> 設定 \> プライバシー \> {左カラムの各種対象}

### マイピクチャ(+その以外)へのアクセス権とアクセス例

Package.appxmanifest へ設定を追加

1. `<Package>` に `xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"` を追加
2. `<Package>` の `IgnorableNamespaces` に "rescap" を追加
3. `<Capabilities>` に `<rescap:Capability Name="picturesLibrary" />` の用な感じで必要な設定を追加
   - Name="picturesLibrary" のところを差し替えれば、ほか設定も可能

```xml
<Package
  xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
  xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
  IgnorableNamespaces="uap mp rescap">
  ...
  <Capabilities>
    ...
    <rescap:Capability Name="picturesLibrary" />
  </Capabilities>
  ...
</Package>
```

samplecode

```cs
private async void LoadFromPicture()
{
    var myPictures = await Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Pictures);
    var folder = myPictures.SaveFolder;

    var files = await folder.GetFilesAsync();
    if (files.Count <= 0)
        return;

    var bitmap = new BitmapImage();
    Windows.Storage.StorageFile file = files[0];
    foreach (var _file in files)
    {
        if (_file.Name == "ex.png")
        {
            file = _file;
            break;
        }
    }


    using (var s = await file.OpenReadAsync())
    {
        bitmap.SetSource(s);
    }
    Foo.Source = bitmap;
}
```
