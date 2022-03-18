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

        async();
    }

    private static void async()
    {
        // 単純に呼び出すだけで良い
        var task = Sum(1, 2);
        Console.WriteLine("after sum");

        // 終了を待機
        task.Wait();
        Console.WriteLine("waited sum");

        // 終了を待機, かつ返却値あり
        var s = task.Result;
        Console.WriteLine(s);
    }
    private static async Task<string> Sum(int a, int b)
    {
        // 一定時間待機
        await Task.Delay(1000);

        Console.WriteLine("running sum");
        return $"a + b = {a + b}";
    }
}
