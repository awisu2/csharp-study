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
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Text;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpBlankApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UISamplePage : Page
    {
        public UISamplePage()
        {
            this.InitializeComponent();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            var text = (sender as TextBox).Text;
            LoadAndSetImage(text);
        }

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
    }
}
