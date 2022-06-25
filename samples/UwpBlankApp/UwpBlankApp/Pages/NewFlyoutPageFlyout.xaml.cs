using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UwpBlankApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewFlyoutPageFlyout : ContentPage
    {
        public ListView ListView;

        public NewFlyoutPageFlyout()
        {
            InitializeComponent();

            BindingContext = new NewFlyoutPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class NewFlyoutPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<NewFlyoutPageFlyoutMenuItem> MenuItems { get; set; }

            public NewFlyoutPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<NewFlyoutPageFlyoutMenuItem>(new[]
                {
                    new NewFlyoutPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new NewFlyoutPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new NewFlyoutPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new NewFlyoutPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new NewFlyoutPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}