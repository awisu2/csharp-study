# get commandline arguments

- [Environment\.GetCommandLineArgs メソッド \(System\) \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/api/system.environment.getcommandlineargs?view=net-6.0)

```cs
using System;

string[] _args;
try
{
    _args = Environment.GetCommandLineArgs();
} catch (NotSupportedException e) {
    Console.WriteLine(e.Message);
}
```

## NOTE

- set args on debug: Project > {Project} Properties > Debug > General > Open debug launch profiles UI > Command line arguments
  - separate by space
