# uri scheme

- [URI スキーム \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/app-resources/uri-schemes#ms-appx-and-ms-appx-web)

---

こんな感じで利用し、対象の範囲を規定する

```xml
<Image Source="ms-appx:///Assets/StoreLogo.png" />
```

---

- `ms-appx`, `ms-appx-web`: アプリのパッケージに含まれるファイルを参照
- `ms-appdata`: アプリのローカル フォルダー、ローミング フォルダー、一時データ フォルダーのアプリ ファイルを参照
- `ms-resource`: アプリのリソース ファイル (.resw) から読み込まれた文字列を参照
