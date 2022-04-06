# uwp で画像を表示する

- [画像とイメージ ブラシ \- Windows apps \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/apps/design/controls/images-imagebrushes)

## sample: Application 内の画像を表示する

```xml
<Image Source="Assets/logo.png" Height="200">
same
<Image Source="ms-appx:///Assets/StoreLogo.png" />
```

- Application の currentPath が基準となる
- [] Application 外のファイルにはアクセスできない
- `Source="Assets/logo.png"` は `Source="ms-appx:///Assets/StoreLogo.png"` の省略形、Application 内のリソースを指定
  - [uri scheme](../resources/urischeme.md)

## Image で表示可能な形式

- [画像ファイルの形式](https://docs.microsoft.com/ja-jp/windows/apps/design/controls/images-imagebrushes#image-file-formats)

---

- JPEG: Joint Photographic Experts Group
- PNG: ポータブル ネットワーク グラフィックス
- BMP: ビットマップ
- GIF: グラフィックス交換形式
- TIFF: Tagged Image File Format
- JPEG XR
- ICO: アイコン

## 選択した画像を表示する

xaml

```xml
<Image x:Name="Foo" />
```

code

```cs
private async void setPickImage()
{
    // picker settings
    var picker = new FileOpenPicker();
    picker.FileTypeFilter.Add(".jpg");
    picker.FileTypeFilter.Add(".jpeg");
    picker.FileTypeFilter.Add(".png");
    picker.FileTypeFilter.Add(".gif");

    // show picker
    // return Windows.Storage.StorageFile
    var file = await picker.PickSingleFileAsync();
    if (file == null)
        return;

    // create bitmap and xaml
    var bitmap = new BitmapImage();
    using(var s = await file.OpenReadAsync())
    {
        bitmap.SetSource(s);
    }
    Foo.Source = bitmap;
}
```
