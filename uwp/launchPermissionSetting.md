# lanch permission setting

- [Windows 設定アプリの起動 \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/launch-resume/launch-settings-app)

---

## code

```cs
private async void launchWebCamSetting()
{
    bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-webcam"));
}
```

## xaml link

```xml
<TextBlock x:Name="LocationDisabledMessage" FontStyle="Italic"
        Visibility="Visible" Margin="0,15,0,0" TextWrapping="Wrap" >
    <Run Text="This app is not able to access the microphone. Go to " />
        <Hyperlink NavigateUri="ms-settings:privacy-microphone">
            <Run Text="Settings" />
        </Hyperlink>
    <Run Text=" to check the microphone privacy settings."/>
</TextBlock>
```
