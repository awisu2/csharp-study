# dictionary

[Dictionary<TKey,TValue> クラス \(System\.Collections\.Generic\) \| Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0)

```cs
public Dictionary<string, string> DistionaryValue()
{
    var dict = new Dictionary<string, string>();

    dict.Add(".txt", "text file");
    dict.Add(".jpeg", "image, format jpeg");
    dict.Add(".gif", "image, format gaf");

    var s = dict[".jondo"];
    if (s != null)
    {
        dict.Remove(".jondo");
    }

    var values = dict.Values;
    var kesy = dict.Keys;

    foreach(string key in dict.Keys)
    {
        var v = dict[key];
    }

    return dict;
}
```
