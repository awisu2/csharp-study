# array

## add item

Array can't add item directory. so we need convert List type.

```cs
// set urls
var urls = new string[] { "http://0.0.0.0:8080", "http://localhost:5003" };
if (!String.IsNullOrEmpty(_args.port))
{
    var _urls = new List<string>(urls);
    _urls.Add("http://0.0.0.0:" + _args.port);
    urls = _urls.ToArray();
}
webBuilder.UseUrls(urls);
```
