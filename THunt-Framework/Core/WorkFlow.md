T-Hunt-Dev/WorkFlow.md

# T-hunt開発方式

複数のプロンプトを組み合わせたプロンプト群を利用して
大規模なプログラムを作る方式

プロンプトを利用して0からプログラムを作るのではなく
パッチ方式で差分を積み重ねていく差分方式
（最初の1回はプロンプトを使って生成をする）

目標はマインスイーパーのスタイルを模倣した
「宝探しゲーム」を作ること

それが達成され次第、同様の開発方式で
ゲームやプログラムを製作するフレームワークとする

## フォルダ/ファイル構成

### リポジトリ直下（運用＝T-Hunt側）
- /THunt-Framework/
  - /Core/
    - Overview.md
    - Constitution.md
    - Workflow.md
  - /ChatRoom/
    - Chat.md
    - Pending.md
    - Todo.md
    - Log.md
    - /images/
      - (スクリーンショット)

Overview.md: 概要・実装理念
Constitution.md: 憲法（命名規則・禁止事項・差分粒度・レビュー観点・“作る前に探せ”ルール）
Workflow.md: T-Hunt/Plan（方式の計画書。役割分担、手順、CI/テスト方針）

### 生産物側（ゲーム・プログラムなど）
- /App/
  - AppPlan.md
  - (各種プロンプト)

AppPlan.md：企画（コア体験、ループ、ターゲット、完成定義）

## Chat.md / Pending.md / Todo.mdについて
Chat.mdを通じて会話することで
ChatGPT内での誤爆も防げる上に、推敲しながら文章を書く狙い。
また、今後の進行状況で回答が変化する可能性もあるので
同じQに関して、後々質問し直して、複数のAを保持することも考慮する。

Chat.mdから有用な内容をPending.mdに隔離。
そこから本格的に実行する内容を、Todo.mdに移行して実装。

もしかしたら、Todoに移行する前にそのまま実装するかも知れないので
PendingがそのままTodo扱いになるかも知れない。

Chat層が蓄積した場合に逐次Log化する。
命名規則にChat.md内での質問番号を記載する形式にする。（無印の場合は0から）

Stage1:　Chat層
Stage2:　Pending層
Stage3:  Todo層

### Chat.md内の記述ルール
Q : ChatGPTへの質問
A : ChatGPTからの返答
CQ : Codexへの命令案
CQR : CQに対する、ChatGPTのレビュー
M : メモ（場合によってはChatGPTやCodexに投げる）

### スクリーンショットについて
会話用に一時的にimagesに格納
基本的に削除し、リポジトリには転送しない
