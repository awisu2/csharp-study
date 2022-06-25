# MagicOnion Study

- [Cysharp/MagicOnion: Unified Realtime/API framework for \.NET platform and Unity\.](https://github.com/Cysharp/MagicOnion)

---

## install etc

- server
  - delete Prots, Services
  - `dotnet add package MagicOnion.Server`
- Shared Project: Interface 部分の共有化
  - SharedプロジェクトはConsoleAppで作って、exeの設定をプロジェクトファイルから消す
  - `dotnet add package MagicOnion.Abstractions`
  - `dotnet add reference ..\MagicOnionShared\` 利用する側のプロジェクトそれぞれで
- client
  - `dotnet add package MagicOnion.Client`

## notes

- インタフェースを利用するとなったら、クラス要件として全メソッドの実装が必要
  - しかし、インタフェース自体を利用しないということは可能(あくまでIServiceを継承したクラスが対象？)

## streaming hub の実装簡易説明

- インタフェースは、Hub と Reseiver で構成される
  - Hub は IStreamingHub を継承し、Reseiverを含む。 gRPc 部分として実装。
  - Reseiver は サーバからクライアントへのコールイベントを宣言
- client side: 
  - Reseiverを継承したクラスで実装
  - `var client = StreamingHubClient.ConnectAsync(gRpcChannel, Reseiver)` で接続
    - clientに対してGrpc接続を行う。Reseiverにはサーバからのコールが帰ってくる
  - サンプルだと、Reseiver自身が connectAsyncの返却を保有して利用している
  - コールバック関数もも自分で呼ぶことが可能: `(this as IGamingHubReceiver).OnJoin(player);` という感じ
    - Broadcast はできないっぽい。関数呼ぶだけ
- server side:
  - `StreamingHubBase<IHub, IReceiver>, IHub` という感じのクラスで実装
  - 通常のgRpcのように利用できる
  - コネクションごとにインスタンスが生成される
  - Broadcast
    - `(room, storage) = await Group.AddAsync(id[, value]);` とすることで 参加させることが可能
      - idの部分は同一にすることで同ルームに接続できる
      - storage は Group ごとに共有される、オンメモリの値の保管庫。 value がセットされるっぽい 
    - `Broadcast(room).OnXxx({any})` とすることでroomに該当するclientにメッセージを送れる
      - ONXxx は Receiver で定義した関数
