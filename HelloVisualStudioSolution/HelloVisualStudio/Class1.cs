using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloVisualStudio
{
    internal class MyClass: MyInterface
    {
        struct Message
        {
            public string text;
        }

        private Message message;

        public MyClass()
        {
            message = new Message
            {
                text = "Hello",
            };
        }

        public void OutputHello(string output)
        {
            // string.Format
            var s = string.Format("{0} {1}", message.text, output);
            Console.WriteLine(s);

            // format $
            s = $"{message.text} {output}";
            Console.WriteLine(s);
        }

        public int Calc(int i)
        {
            return (i + i) * i / i - i;
        }

        public int StoI(string s) 
        {
            int n;
            if(Int32.TryParse(s, out n))  {
                return n;
            }
            return -1;
        }

        public int ArrayLoop(int n)
        {
            var list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(i);
            }

            var arr = list.ToArray();
            var sum = 0;
            foreach(var item in arr)
            {
                sum += item;
            }
            return sum;
        }
    }
}
