using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace HelloUnoPlatform.Skia.Tizen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new HelloUnoPlatform.App(), args);
            host.Run();
        }
    }
}
