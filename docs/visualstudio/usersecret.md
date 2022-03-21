# user secret and environments

[ASP\.NET Core での開発におけるアプリ シークレットの安全な保存](https://docs.microsoft.com/ja-jp/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows)

## NOTE

- 記事では、環境変数と dotnet でサポートする user secret の利用を説明している

## UserSecrets

- Project ディレクトリ配下とは別の箇所に secrets.json が生成され、それを利用できる
  - `%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json`

### setup

```bash
tnet user-secrets init
```

or `Visual Studiio > Project > Manage User Secrets`
