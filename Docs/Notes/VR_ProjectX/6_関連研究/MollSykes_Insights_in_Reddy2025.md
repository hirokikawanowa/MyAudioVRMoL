---
title: MollSykes_Insights_in_Reddy2025
tags: [文献, MoL, VR, design_principles, ProjectX/文献]
date: 2025-05-16
source: [[Attachments/Docs/Reddy_Samarth_2025_MDES_DGIF_Thesis.pdf]]
url: https://doi.org/10.1007/s10055-023-xxxxx
related: [[OptimizedVR_MemoryPalace_Study]]
type: literature
---

# Moll & Sykes (2023) が Samarth Reddy (2025) 論文に与えた影響

## 1️⃣ 引用箇所と主張
| 章・ページ | Reddy の位置づけ | Moll & Sykes からの引用要約 | Reddy の示唆 |
|------------|-----------------|-----------------------------|--------------|
| 3.4.3 *VR/AR in Memory Augmentation* p.59 | 文献レビュー | VR‑MoL は従来法より **+20 % 想起**（2週目 +22 %） | 没入×操作性を最重視 |
| 3.3.4 *Technological Enhancements* p.54 | 技術背景 | VR 宮殿効果の代表例として列挙 | 目標 KPI を “+20 % 想起” に設定 |
| 効果比較表 p.54 | 数値比較 | “VR Memory Palaces — up to 20–25 % recall” | AI×XR 案の成績目標とする |
| 設計指針 p.50–51 | 宮殿構築ガイド | 非反復空間・**ユーザ選択画像**UI | Mind Palace XR に同UIを実装 |
| プロトタイプ考察 p.48–49 | 実装課題 | 遅延・順序UI未整備 | レイテンシ最適化＆順序番号UIを優先 |
| 理論比較 p.59 | Presence論と接続 | 高 immersion + MoL が有効 | Presenceとサイバーシックネスのバランス設計 |

## 2️⃣ Moll & Sykes (2023) 実験の要点
- **目的** : 最適化 VR‑MoL デザインの可行性確認  
- **参加者** : 11 名・2 週内的比較  
- **システム** : Oculus Rift S + KAT Loco、10 室アパート型宮殿  
- **結果** : Lenient 想起 **+20.4 %** (週1) / **+22.2 %** (週2) 有意、Strict 順序は非改善  
- **設計要因** : ユーザが画像を選択、3D サウンド付加、歩行＋手操作で Presence 向上  
- **限界** : n 小、対照欠如、語数 30、Strict 改善なし  

## 3️⃣ Reddy での応用ポイント
1. **KPI** : 想起 +20 % を Mind Palace XR の性能目標に。  
2. **UI 継承** : 個別画像選択・順序番号 UI を実装予定。  
3. **課題意識** : 厳密順序スコア向上へ UI/ガイドライン追加。  
4. **研究計画** : 小規模→大規模実験へ拡張し統計的検証。  

## 4️⃣ メモ & 次のアクション
- Moll & Sykes の **順序未改善問題** は XR 宮殿の UI テストで優先的に検証。  
- Presence 向上策（歩行・手操作）と Cybersickness 低減策の両立が必須。  
- 今後、**Strict スコア評価指標**をスプリントテストへ導入する。  

---

> **参照**  
> - [[OptimizedVR_MemoryPalace_Study]] — Moll & Sykes 原論文の詳細ノート  
> - [[PresencePerformance_SpatialVR_Maneuvrier2020]] — Presence とパフォーマンス関係  
