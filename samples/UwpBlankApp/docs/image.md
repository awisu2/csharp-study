# image

- アプリ外の画像を表示する場合は権限対応が必用。 ([privacy](./privacy.md))

## 特定のパスの画像を表示

- StorageFile, StorageDirectory を利用する
  - 通常のFile関数だとエラーになる。uwp特有の制限なのかは謎(パーミッション設定をしてもだめ)。
- 事前のファイル存在チェックも(今のところ)不可能なため、エラーキャッチで判定をする

```cs
    private async void LoadAndSetImage(string path)
    {
        try
        {
            var file = await StorageFile.GetFileFromPathAsync(path);
            if (file == null) return;

            var bitmap = new BitmapImage();
            bitmap.SetSource(await file.OpenReadAsync());
            this.image.Source = bitmap;

        }
        catch (Exception ex)
        {
            if (ex.GetType() == typeof(System.IO.FileNotFoundException))
            {
                Console.WriteLine("file not found");
                this.image.Source = null;
            }
        }
    }
```
