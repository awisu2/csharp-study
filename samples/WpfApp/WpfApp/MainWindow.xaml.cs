using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    public class File
    {
        public string Path = "";
    }

    public class ImageFile : File
    {
    }
    public class HogeData : INotifyPropertyChanged
    {
        private string _text = "Default";
        public string HogeText
        {
            get => _text;
            set
            {
                if (_text == value) return;
                _text = value;
                // データを更新したことを通知する
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HogeText)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string DirPath = @"D:\tmps\goHentai\hitomi\南の島でママ達と…。";
        private const string FilePath = @"0003_hitomi_2246703.webp";

        public ObservableCollection<ImageFile> ImageFiles { get; } = new ObservableCollection<ImageFile>();
        public ObservableCollection<string> JapaneseCalendar { get; private set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();

            JapaneseCalendar.Add("明治");
            JapaneseCalendar.Add("大正");
            JapaneseCalendar.Add("昭和");
            JapaneseCalendar.Add("平成");
            JapaneseCalendar.Add("令和");
        }

        void OnClickGotoUISample(object sender, RoutedEventArgs e)
        {
            Listing();
        }

        private void Listing()
        {
            var files = Directory.GetFiles(DirPath);
            if (files == null) return;
            foreach (var file in files)
            {
                Debug.Print(file);
                ImageFiles.Add(new ImageFile()
                {
                    Path = file
                });
            }
        }

    }
}
