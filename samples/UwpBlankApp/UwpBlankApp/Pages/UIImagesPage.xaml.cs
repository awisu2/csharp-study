using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpBlankApp.Pages
{
    public class ImageItem
    {
        public BitmapImage Source { get; set; }
        public string Name { get; set; }

        public ImageItem(BitmapImage Source, string Name)
        {
            this.Source = Source;
            this.Name = Name;
        }
    }

    public class DirectoryItem
    {
        public string path { get; set; }
        public string name { get; set; }

        public DirectoryItem(string path)
        {
            var info = new DirectoryInfo(path);

            this.path = path;
            this.name = info.Name;
        }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UIImagesPage : Page
    {
        private static string[] ImageExtentions = { ".jpg", ".jpeg", ".png", ".gif" };

        private string[] drives;

        private string currentFolder;

        public UIImagesPage()
        {
            this.InitializeComponent();

            var drivers = GetDriveNames();
            foreach (var driver in drivers)
            {
                var item = new DirectoryItem(driver);
                this.explorerView.Items.Add(item);
            }
        }

        void OnClickBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        void OnClickDirectory(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            var text = (sender as TextBox).Text;
            LoadAndShowPictures(text);
        }

        private async void LoadAndShowPictures(string path)
        {
            try
            {
                imagesView.Items.Clear();

                var folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync(path);

                var files = await folder.GetFilesAsync();
                if (files.Count <= 0)
                    return;

                imagesView.Items.Clear();
                foreach (var file in files)
                {
                    try
                    {
                        var info = new FileInfo(file.Name);
                        if (0 > Array.IndexOf(ImageExtentions, info.Extension)) continue;

                        var bitmap = new BitmapImage();
                        using (var s = await file.OpenReadAsync())
                        {
                            bitmap.SetSource(s);
                        }

                        var image = new ImageItem(bitmap, file.Name);
                        imagesView.Items.Add(image);
                    } catch(Exception _) {}
                }
            } catch(Exception ex)
            {
                if (ex.GetType() == typeof(DirectoryNotFoundException))
                {
                    Console.WriteLine("Directory NotFoundException");
                }
            }
        }

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

        private void OnTappedDirectory(object sender, TappedRoutedEventArgs e)
        {
            var dir = (sender as TextBlock)?.Text;
            this.targetPathView.Text = dir;
        }
    }
}
