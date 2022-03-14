namespace HelloVisualStudio;

class Program
{
    static void Main(string[] args)
    {
        MyInterface myClass = new MyClass();

        myClass.OutputHello("world");

        int n;
        n = myClass.StoI("123");
        Console.WriteLine(n);

        n = myClass.Calc(4);
        Console.WriteLine(n);

        n = myClass.ArrayLoop(10);
        Console.WriteLine(n);
    }
}
