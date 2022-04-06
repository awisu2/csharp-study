# folder picker

- [ピッカーでファイルやフォルダーを開く \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/files/quickstart-using-file-and-folder-pickers)

---

## sample: folder を選択して一つの画像を表示

- [FolderPicker Class \(Windows\.Storage\.Pickers\) \- Windows UWP applications \| Microsoft Docs](https://docs.microsoft.com/en-us/uwp/api/Windows.Storage.Pickers.FolderPicker?view=winrt-22000)

```cs
private async void pickDirectory()
{
    var picker = new FolderPicker();
    picker.FileTypeFilter.Add("*");

    var folder = await picker.PickSingleFolderAsync();
    if (folder == null)
        return;

    var files = await folder.GetFilesAsync();
    if (files.Count <= 0)
        return;

    var file = files[0];

    var bitmap = new BitmapImage();
    using (var s = await file.OpenReadAsync())
    {
        bitmap.SetSource(s);
    }
    Foo.Source = bitmap;
}
```
