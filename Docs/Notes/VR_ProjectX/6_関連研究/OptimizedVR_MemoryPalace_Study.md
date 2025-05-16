---
title: OptimizedVR_MemoryPalace_Study
tags: [文献, MoL, VR, 記憶術, ProjectX/文献]
date: 2023-03-06
source: [[Attachments/Docs/s10055-022-00700-z.pdf]]
url: https://doi.org/10.1007/s10055-022-00700-z
type: literature
---

# Optimized virtual reality‑based Method of Loci memorization techniques

## 🧠 研究背景と目的
古典的記憶術 Method of Loci（MoL）は熟練と空間想像力を要する。VR によって没入型かつ初心者でも実行可能な MoL 環境を構築できる可能性がある。本研究では「没入感と設計最適化に基づいた VR メモリーパレス」が記憶成績に与える影響を検証した。

## 🎯 研究目標
- Oculus Rift S + KAT Loco による歩行可能なメモリーパレスの構築
- VR MoL 環境と伝統的暗記法の比較による想起効果の定量評価
- 没入感の影響分析

## 🏗 システム設計
- 9 部屋 + バルコニーのアパート型空間
- 自由配置可能な「Placeable」＋3D音＋画像選択による個別最適化
- Unity2019 + XR Plugin。進行・記録を一元管理する ExperimentManager を搭載

## 🧪 実験方法
- 11名を対象に2週構成
- Pre-Test（紙ベース30語）
- VR訓練（探索＋操作習熟）
- VR MoL（30語配置）
- Post-Test（自由再生）
- Lenient/Strictスコアと主観評価、t検定・ANOVAによる分析

## 📈 主な結果
- Lenientスコア：Week1 +20.4%、Week2 +22.2%、いずれも有意 (*p*<0.05)
- Strictスコア：有意な変化なし
- 没入感の高さと記憶成績に正の相関
- 91%が「実生活でも使いたい」と回答

## 🔍 考察
- 自己選択画像と歩行ベースの身体性が短時間訓練でもMoL効果を引き出した
- 順序記憶の不足はガイド表示やUI設計に課題あり
- 音・アニメ・動画などマルチモーダルな強化が今後の鍵

## ⚠ 限界
- 少人数（n=11）、VRを使わないMoLとの比較なし
- 時間制約により語数制限（30語）

## 🔄 今後の課題
1. 大規模統計検証
2. 順序記憶UIとマルチモーダル要素の導入
3. 身体的インタラクションの自然化

## 📂 公開リソース
- ソースコードおよびデモ動画あり（再現性高）

## 📝 所見
短時間・小規模でも高没入型VR MoLは有意な記憶向上を実現しうる。教育・高齢者支援等への応用可能性が高く、今後のUI/UX設計と統計的強化が期待される。
