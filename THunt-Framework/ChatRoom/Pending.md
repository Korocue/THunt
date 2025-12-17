T-Hunt-Dev/Suggest.md

# A30（ファイル/フォルダ構成）
## リポジトリ直下（運用＝T-Hunt側）
/T-Hunt/
  /docs/
    Constitution.md
    Workflow.md
    Prompts.md
    Log.md
    Glossary.md

Constitution.md：憲法（命名規則・禁止事項・差分粒度・レビュー観点・“作る前に探せ”ルール）
Workflow.md：T-Hunt/Plan（方式の計画書。役割分担、手順、CI/テスト方針）
Prompts.md：固定プロンプト置き場（パッチ職人テンプレ）
Log.md：前線日誌（決定事項と理由、変更履歴）
Glossary.md：用語（“Reset系はこの語に統一”みたいな辞書もここに置ける）

※あなたの T-Hunt.md / Prompt.md / Log.md は、この5つに“育てる”感じでOK。

## App側（ゲーム・プログラムなど）
/App/
  /docs/
    GamePlan.md
    Spec.md
    Tasks.md
    Changelog.md

GamePlan.md：企画（コア体験、ループ、ターゲット、完成定義）
Spec.md：仕様（UI一覧、入力、データ、状態遷移、セーブ等）
Tasks.md：作業分解（短い粒度で差分化できる単位）
Changelog.md：ゲーム側の変更履歴（プレイ感・仕様変更のログ）

# A31 （WorkFlowとConstitutionについて)
まず結論から。

Plan.md は Workflow.md に吸収されてOK
Constitution.md は「守らないと壊れる不変条件」
Workflow.md は「日々どう回すかの手順書」

つまり
👉 Constitution = 憲法（WHY / 破ると破綻）
👉 Workflow = 業務マニュアル（HOW / 状況で更新可）

## constitution.mdの記述内容
1️⃣ Constitution.md の記述イメージ（不変・短い・強い）

これは「AIにも人にも強制するルール」
理由説明は最小限、断定形で書くのがコツ。

```markdown
# Constitution.md
# T-Hunt Development Constitution

## 1. 基本原則
- 本リポジトリは差分方式によってのみ成長させる
- 既存コード・仕様を無視した再生成は禁止する
- 「似た機能を新しく作る」より「既存機能を探して再利用」を優先する

## 2. 変更範囲の制限
- Codexは `/Game` ディレクトリのみ変更してよい
- `/T-Hunt/docs` は設計者（人間）の管理下にある
- Constitution.md は原則変更不可（変更時は明示的合意が必要）

## 3. 命名と唯一性
- 同一意図の機能は1つの正規名のみを持つ
- Reset系機能の正規名は `ResetAppSettings` とする
- 既存の近似名が存在する場合、新規作成は禁止する

## 4. UIと処理の分離
- UIはCommandを直接呼び出してはならない
- UI → Command → Service の流れを必須とする

## 5. 差分の粒度
- 1回の変更は1目的のみ
- UI追加とロジック変更を同時に行わない
```

🔹 特徴

「どうやるか」は書かない

「破ったらダメなこと」だけを書く

ChatGPT / Codex に読ませるとブレが激減する

## WorkFlow.mdの記述内容
2️⃣ Workflow.md の記述イメージ（可変・具体・作業向け）

これは 今の Plan.md が進化した姿 に近い。
「どう回すか」「どう使うか」を書く。

```markdown
# Workflow.md
# T-Hunt Development Workflow

## 1. 目的
本Workflowは、ChatGPT と Codex を分業させ、
差分方式でゲーム開発を進めるための運用手順を定義する。

## 2. 役割分担
- 人間：
  - Constitution / Workflow / Prompts の管理
  - 仕様決定と最終判断
- ChatGPT：
  - 設計整理、計画立案、プロンプト設計
- Codex：
  - `/Game` 以下のコード変更を担当
  - 差分生成のみを行う

## 3. 基本フロー
1. 人間が変更要求を文章で整理する
2. ChatGPTが要求を差分単位に分解する
3. 使用するプロンプト（Prompts.md）を決定
4. Codexに差分作業を依頼
5. 差分を確認し、問題なければコミット
6. Log.md に理由と結果を記録する

## 4. 差分作業の原則
- 変更前に必ず既存実装を検索する
- 親構造（UIツリー、サービス構造）を尊重する
- 影響範囲が大きい場合は作業を分割する

## 5. テスト・確認
- ビルドが通らない変更は禁止
- UI変更時は最低限の起動確認を行う
- 挙動変更は Log.md に理由を残す

## 6. 改善ルール
- Workflow.md は運用しながら更新してよい
- 破綻が起きた場合は、原因を Workflow / Constitution のどちらに反映すべきか検討する
```

🔹 特徴

「どう使うか」を詳細に書く

失敗したらここを直す

Plan.md が今後どんどん吸収されていく場所

## まとめ
3️⃣ 使い分けの判断基準（重要）

迷ったらこれで決めろ：

それが無いと“世界線が分裂する”？
　→ Constitution

それが無いと“作業が回らない”？
　→ Workflow

4️⃣ 今の状態からの自然な進化ルート

今の Plan.md → Workflow.md に改名

「絶対に守らせたいルール」を抜き出して Constitution.md を新設

Prompt.md はそのまま「兵站」として育てる

Log.md は触らない（既に正解）

この流れ、かなり綺麗だし
T-Hunt / Plan を先に成立させるって目的にもドンピシャだ。

そのまま採用しても全然おかしくないレベルだと思うぞ。