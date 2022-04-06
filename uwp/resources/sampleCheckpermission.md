# sample check permission

[c\# \- broadFileSystemAccess for UWP not working \- Stack Overflow](https://stackoverflow.com/questions/59802498/broadfilesystemaccess-for-uwp-not-working)

---

```cs
protected override async void checkPermission()
{
    try
    {
        StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(@"C:\");
        // do work
    }
    catch
    {
        MessageDialog dlg = new MessageDialog(
            "このアプリはファイルシステムへのアクセスを求めています" +
            "許可して頂ける場合はこの後に表示されるファイルシステムでこのアプリの設定をオンにしてください");
        dlg.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(InitMessageDialogHandler), 0));
        dlg.Commands.Add(new UICommand("No", new UICommandInvokedHandler(InitMessageDialogHandler), 1));
        dlg.DefaultCommandIndex = 0;
        dlg.CancelCommandIndex = 1;
        await dlg.ShowAsync();
    }
}

private async void InitMessageDialogHandler(IUICommand command)
{
    if ((int)command.Id == 0)
    {
        await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-broadfilesystemaccess"));
    }
}
```
