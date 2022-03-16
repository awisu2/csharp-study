using System;
using System.ComponentModel; // INotifyPropertyChanged
using System.Runtime.CompilerServices; // CallerMemberName

namespace HelloUnoPlatform.Models
{
    public class HelloINotifyPropertyChanged : INotifyPropertyChanged
    {
        // 通知インスタンス
        public event PropertyChangedEventHandler PropertyChanged;

        // 通知関数
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // string hello
        private string hello = string.Empty;
        public string Hello
        {
            get { return hello; }
            set
            {
                if (value != this.hello)
                {
                    this.hello = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
