# privacy

uwpでは自身が含むコンテンツ以外にアクセスしようとした時各種権限を取得する必要がある。アンドロイドアプリみたいな感じ

## ファイルアクセス

- [ファイル アクセス許可 \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/files/file-access-permissions)

---

## 権限持ちでファイルにアクセスする方法がいくつかある

1. プロジェクト内に含めておく
2. ダイアログでユーザに選択してもらう
3. パーミッション設定
   - 通常は "broadFileSystemAccess" でユーザの権限が及ぶ限りのアクセスで良いと思う
   - 他の設定は

## パーミッション設定

- 設定後手動でONにする必要がある
  - Windows > 設定 > プライバシー > ファイル システム
  - 親切なUIなら、パーミッション確認をして設定画面に飛ばすなどをする
- パーミッションを変更すると、許可状況がリセットされる

### パーミッション設定方法

- **{Project}.appxmanifest** ファイルでパッケージが必用とする権限を設定できる
  - VisualStudio のUIから設定しようと思ったが、broadFileSystemAccess の設定はなかった
- [ファイル アクセス許可 \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/files/file-access-permissions#example)

```xml
<Package
  ...
  xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
  IgnorableNamespaces="uap mp rescap">
...
<Capabilities>
    <rescap:Capability Name="broadFileSystemAccess" />
</Capabilities>
```

- note: *rescap* を追加していること、`<Capabilities>` は複数指定できないのですでにある場合はそちらに含めること
