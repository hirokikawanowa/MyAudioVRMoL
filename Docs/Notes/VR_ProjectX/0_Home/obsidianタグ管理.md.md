---
tags: [#ProjectX/タグ管理, #obsidian]
created: 2025-05-15
---

## ✅ ルール・運用の「決まりごと」は `obsidian構成メモ.md` に書く

→「どうするか」を定義するマニュアル的な位置づけ

### 例（obsidian構成メモに記載する内容）：

- フォルダ構成
    
- タグルール
    
- テンプレート一覧
    
- メタデータ（frontmatter）の記載項目
    
- Dataview の基本クエリ例
    


## ✅ 毎回の「作業内容」や「結果一覧」は各用途の専用ノートで管理

→ 自動集計した一覧表示や、現在の状況を確認するためのノートたち

| ノート名                  | 目的      | 中身                    |
| --------------------- | ------- | --------------------- |
| `index.md`（ホーム）       | ダッシュボード | 全体のリンク集・最新更新・未完了タスクなど |
| `進捗_index.md`         | 週報一覧    | Dataview で日付順に自動表示    |
| `experiment_index.md` | 実験ログ一覧  | status・日付などで一覧管理      |
| `literature_index.md` | 関連研究の整理 | 読了状況やキーワード別リストなど      |
## 📊 Dataview & タグ運用のルール

- すべてのノートに必ず `#ProjectX` タグを含める
- 用途別のタグを以下に統一：
  - 設計： `#ProjectX/設計`
  - 実験： `#ProjectX/実験`
  - ...
- Frontmatter に以下を含めること：
```yaml
tags: [#ProjectX/進捗報告]
date: 2025-05-15
status: in-progress
```

### 🔄 Dataview クエリは以下の専用ノートにまとめて表示：

- `index.md`：プロジェクト概要と最新状況
    
- `進捗_index.md`：進捗報告の一覧
    
- `experiment_index.md`：実験ログ一覧
    
- `literature_index.md`：関連研究メモの一覧


---

## 💡イメージとしては：

- `構成メモ` → 「決め事」「やり方のルールブック」
- `indexノートたち` → 「いま何が進んでるかを見る一覧表」

---

