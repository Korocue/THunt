# THunt（実験用リポジトリ）

このリポジトリは、**THunt-Framework の実験用リポジトリ**です。  
複数のプロンプトを組み合わせた「プロンプト群」を使い、**差分（パッチ）を積み重ねる方式**で大規模なプログラムを作ることを目的にしています。

初期目標は、マインスイーパーのスタイルを模倣した「宝探しゲーム」を作ることです。達成後は、同様の開発方式でゲームやプログラムを製作するフレームワークとして発展させます。

## まず読む（導線）

- フレームワーク概要（理念・目的）: [THunt-Framework/Core/Overview.md](THunt-Framework/Core/Overview.md)
- 運用ルール（回し方・手順）: [THunt-Framework/Core/WorkFlow.md](THunt-Framework/Core/WorkFlow.md)
- 憲法（命名規則・禁止事項など）: [THunt-Framework/Core/Constitution.md](THunt-Framework/Core/Constitution.md)（順次実装予定）
- 会議室（会話ログ・意思決定の記録）: [THunt-Framework/ChatRoom/Chat.md](THunt-Framework/ChatRoom/Chat.md)

## リポジトリ構成（ざっくり）

- `THunt-Framework/`
  - `Core/` : 概要・運用・憲法など、フレームワーク中枢のドキュメント
  - `ChatRoom/` : Chat / Pending / Todo / Log など、議論と実装の導線
- `App/`
  - 実際の生産物（ゲーム・プログラム）側

## 開発の基本方針（要点）

- 0→1の生成は最初の1回だけ行い、以降は**パッチ方式で差分を積み重ねる**
- 議論・方針は `ChatRoom` に残し、実装対象は `Pending` → `Todo` へ移す（詳細は [THunt-Framework/Core/WorkFlow.md](THunt-Framework/Core/WorkFlow.md)）
- Codex 実行時は **1行のコミットメッセージ**を提示する（詳細は [THunt-Framework/Core/Constitution.md](THunt-Framework/Core/Constitution.md)）

## ステータス

- 実験段階のため、ディレクトリ構成や運用ルールは変更される可能性があります
- `Constitution.md` は順次拡張予定です
