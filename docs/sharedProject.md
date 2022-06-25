# 共有プロジェクト

共有されるプロジェクトの作成方法

- その名も共有プロジェクトというものがある
  - 単純なファイル共有用プロジェクト
  - [] ただし、Nugetが導入できなかった
    - 解決方法ありそうだけれどね
- Consoleプロジェクトでシェア
  - プロジェクトファイルから、 `<OutputType>Exe</OutputType>` を削除すると、Mainメソッドを要求しなくなる
  - `dotonet add reference "../Shared"` みたいにreferenceを追加する
  