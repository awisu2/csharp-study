using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UwpBlankApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewViewCell : ViewCell
    {
        public NewViewCell()
        {
            InitializeComponent();
        }
    }
}