# 🧩 Git操作メモ - ThesisExperimentVRMoL

## 📂 プロジェクトルートへ移動

```bash
cd C:\Users\kamio\ThesisExperimentVRMoL
```

## ✅ 基本のGit操作手順

```bash
# 変更をステージング
git add .

# コミット（何を変えたかをメモ）
git commit -m "何を変えたかメモ"

# リモートにプッシュ
git push
```

## 🌐 GitHubリポジトリURL

- [https://github.com/hirokikawanowa/MyAudioVRMoL](https://github.com/hirokikawanowa/MyAudioVRMoL)

## 💡 備考

- `.gitignore` には Unity / Obsidian の除外対象をすでに設定済み
- リモートが未設定の場合は以下で設定：
  ```bash
  git remote add origin https://github.com/hirokikawanowa/MyAudioVRMoL
  git push -u origin main
  ```
