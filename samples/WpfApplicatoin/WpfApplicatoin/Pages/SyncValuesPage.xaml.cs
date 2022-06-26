using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApplicatoin.Pages
{
    public class MyViewModel : INotifyPropertyChanged
    {
        // notification instance & function
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        // ここまではおまじない ----------

        // We can share Data on multi page with Singleton pattern
        private static MyViewModel _instance = new MyViewModel();
        public static MyViewModel Instance
        {
            get
            {
                return _instance;
            }
        }
        private MyViewModel() { }

        // any properties
        private string _mytext = string.Empty;
        public string MyText
        {
            get { return _mytext; }
            set
            {
                if (value == this._mytext) return;

                this._mytext = value;
                NotifyPropertyChanged();
            }
        }
    }

    public class SampleData
    {
        public string MyText = "mytext sampleData";
    }

    /// <summary>
    /// Interaction logic for SyncValuesPage.xaml
    /// </summary>
    public partial class SyncValuesPage : Page
    {
        private string MyText = "mytext";

        public SyncValuesPage()
        {
            InitializeComponent();
            //DataContext = new { MyText = "mytext w2" };

            //var data = new SampleData();
            //data.MyText = "-------";
            //DataContext = data;

            DataContext = MyViewModel.Instance;
        }

        void OnClickGotoSubPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SyncValuesSubPage());
        }
        void OnClickGotoBasePage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BasePage());
        }
    }
}
