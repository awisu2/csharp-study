using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpBlankApp.Pages
{
    public class NewFlyoutPageFlyoutMenuItem
    {
        public NewFlyoutPageFlyoutMenuItem()
        {
            TargetType = typeof(NewFlyoutPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}