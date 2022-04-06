# uwp でアクセス可能な範囲

- [ファイル アクセス許可 \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/files/file-access-permissions)

---

- デフォルトのアクセス可能範囲
  - デフォルトではアプリケーション配下及び特定のユーザディレクトリ以外にアクセスでき ない
  - ex: `System.UnauthorizedAccessException: 'Access to the path 'C:\' is denied.'`

## デフォルトでアクセス可能な範囲

- アプリケーションのインストール ディレクトリ
- アプリケーション データの場所へのアクセス
  - アプリケーション用に作られるフォルダ的な場所と思われる
- リムーバブル デバイスへのアクセス
- ユーザーの Downloads フォルダー

## アクセス可能な範囲の拡張

- [その他の場所へのアクセス](https://docs.microsoft.com/ja-jp/windows/uwp/files/file-access-permissions#accessing-additional-locations)
  - [ピッカーでファイルやフォルダーを開く \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/files/quickstart-using-file-and-folder-pickers)
    - ピッカーで選択したフォルダやディレクトリはアクセス可能になる
  - AppExecutionAlias: コンソールウィンドなどで起動したときに、起動フォルダ配下をアクセス可能にする
  - [アプリ機能の宣言 \- UWP applications \| Microsoft Docs](https://docs.microsoft.com/ja-jp/windows/uwp/packaging/app-capability-declarations)
    - インターネットや、システム情報、windows で保護されている情報などへのアクセス権を獲得する
    - android の permission とにている
  - [ファイルとフォルダーへのアクセスの保持](https://docs.microsoft.com/ja-jp/windows/uwp/files/file-access-permissions#retaining-access-to-files-and-folders)
    - 何らかの方法でアクセスを許可した対象の許可状態を永続化する

### 失敗

- `broadFileSystemAccess` を manifest に指定することで、アクセス時のユーザと同等のアクセス権が可能とのこと
  - [windows runtime \- broadFileSystemAccess UWP \- Stack Overflow](https://stackoverflow.com/questions/50559764/broadfilesystemaccess-uwp)
  - [Windows 10 の UWP アプリ、ユーザーの承認なくファイルシステムへのアクセスが許可されるバグ \| スラド セキュリティ](https://security.srad.jp/story/18/11/03/0018224/)

やっってみて、自分で許可を出してみたがうまくいかず。。。
