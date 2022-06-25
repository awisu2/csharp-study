# async await task

[async および await を使用したタスク非同期プログラミング \(TAP\) モデル \(C\#\) \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/concepts/async/task-asynchronous-programming-model)

## NOTE

## code

コマンドラインなどで、非同期を呼び出しつつ待機する方法

```cs
using System;
using System.Threading.Tasks;

namespace HelloVisualStudio;

class Program
{
    static void Main(string[] args)
    {
        async();
    }

    private static void async()
    {
        // 単純に呼び出すだけで良い
        var task = Sum(1, 2);
        Console.WriteLine("write before Sum()'s WriteLine");

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
```
