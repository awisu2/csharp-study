# basic things

- namespace: 基本的に書く。 `{Project}[.{directory}][.{directory}]...`という形式
- visual studio
  - check packages have been updates to latest.(need each new solutions)
    - solution(maybe solution Explorer Top) > right click > `Manage NuGet Packages for Solution` > NuGet View > Updates Tab
  - using が不足して赤線が出ている場合: カーソルを合わせていると出るコンテキストか、alt+enter でサポートしてくれる。それでもだめな場合は自力で調査
  - uwp
    - xaml ファイルと、class が連携して画面を構成する: 画面上では xaml の配下に .cs があるように表示されるが、それぞれ同ディレクトリに存在
    - xaml
      - Grid: コンテンツを gurid に並べることが可能で、blank page を作成したときなどは基本タグとして記入される
