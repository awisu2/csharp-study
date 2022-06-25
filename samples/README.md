# csharp-samples

- .gitignore: `dotnet new gitignore`
  - github などで 公開されているものだと .vs フォルダなどが残るので、こちらのほうが良さそう。公式だし。
- コマンドライン引数の取得: 単にMain関数が `string[] args` を引数として持っているのでそれを利用する。
  - Debugでコマンドラインを指定する: `launchSettings.json` を編集。(ex: `"commandLineArgs": "p:9999"`)

## smallCodes

- [array](./smallCodes/array.md)
- [parseArgs](./smallCodes/parseArgs.md)
- [file](./docs/file.md)
