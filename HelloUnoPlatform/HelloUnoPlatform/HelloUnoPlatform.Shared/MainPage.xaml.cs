using HelloUnoPlatform.Models;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloUnoPlatform
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public HelloINotifyPropertyChanged hello = new HelloINotifyPropertyChanged();

        public RecordingViewModel ViewModel { get; set; }

        public static readonly DependencyProperty CounterProperty =
    DependencyProperty.Register(nameof(MainCounter), typeof(Counter), typeof(MainPage), new PropertyMetadata(default(Counter)));

        public Counter MainCounter
        {
            get => (Counter)GetValue(CounterProperty);
            set => SetValue(CounterProperty, value);
        }


        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new RecordingViewModel();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            MainCounter.Num = 123;
            this.ViewModel.Recordings.Add(new Recording()
            {
                ArtistName = "Johann Sebastian Bach",
                CompositionName = "Mass in B minor",
                ReleaseDateTime = new DateTime(1748, 7, 8)
            });
        }

        private void ChangeHello(object sender, RoutedEventArgs e)
        {
            var next = hello.Hello == "hello world" ? "good night" : "hello world";
            hello.Hello = next;
        }

        private void GotoSub(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SubPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            MainCounter = new Counter
            {
                Num = 999,
            };
        }

    }
}
