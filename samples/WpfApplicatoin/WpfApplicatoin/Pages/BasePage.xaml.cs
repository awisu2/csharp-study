using System;
using System.Collections.Generic;
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
using WpfApplicatoin.Windows;

namespace WpfApplicatoin.Pages
{
    /// <summary>
    /// Interaction logic for BasePage.xaml
    /// </summary>
    public partial class BasePage : Page
    {
        public BasePage()
        {
            InitializeComponent();
        }
        void OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SubPage());
        }

        void OnClickShowSubWindow(object sender, RoutedEventArgs e)
        {
            new SubWindow().Show();
        }

        void OnClickGotoSyncValuesPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SyncValuesPage());
        }
    }
}
