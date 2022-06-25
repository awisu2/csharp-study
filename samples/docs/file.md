# file

- uwp だとpermissionつけても動作しない。StorageFile など Storage 系のライブラリ経由が必要
- file list in directory: `string[]? files = Directory.GetFiles(DirPath);`

## read file

- ファイルをバイトで読み込む。ただ、uwpだと動作しない?

```cs
private byte[] ReadFile(string path)
{
    var info = new FileInfo(path);
    byte[] data = new byte[info.Length];
    using (var fs = info.OpenRead())
    {
        fs.Read(data, 0, data.Length);
    }
    info.Delete();

    return data;
}
```

## drive list

```cs
private string[] GetDriveNames()
{
    var drives = new List<string>();

    var driveinfos = DriveInfo.GetDrives();
    foreach(var driveinfo in driveinfos)
    {
        drives.Add(driveinfo.Name);
    }

    return drives.ToArray();
}
```

