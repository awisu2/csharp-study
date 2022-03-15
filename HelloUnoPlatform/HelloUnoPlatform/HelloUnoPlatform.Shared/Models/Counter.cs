using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloUnoPlatform.Models
{
    public class Counter: ObservableObject
    {
        private int num;
        public int Num
        {
            get => num;
            set => SetProperty(ref num, value);
        }
    }
}
