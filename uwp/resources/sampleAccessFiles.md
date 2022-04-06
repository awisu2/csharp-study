# sample basice access files/folders

- アクセス許可設定に注意
- `StorageFolder`, `StorageFile` を基本にアクセスすること
  - CSharp 標準の Directory や File を利用しても Access denied と言われれてしまう

## folder

```cs
using Windows.Storage;

var folder = await StorageFolder.GetFolderFromPathAsync(@"C:\");
var files = await folder.GetFilesAsync();
if (files.Count <= 0)
    return;
```

## file

```cs
using Windows.Storage;

var file = await StorageFile.GetFileFromPathAsync(path);
using (var source = await file.OpenReadAsync())
{
    // anything
}
```
