---
title: VisualVsSpatialAudioImmersion_Potter2022
tags: [文献, VR, spatial_audio, immersion, ProjectX/文献]
date: 2022-09-30
source: [[Attachments/Docs/frsip-02-904866.pdf]]
url: https://doi.org/10.3389/frsip.2022.904866
type: literature
---

# On the Relative Importance of Visual and Spatial Audio Rendering on VR Immersion  
*Thomas Potter, Zoran Cvetković, Enzo De Sena — Frontiers in Signal Processing, 2022*

## 🧠 研究背景と目的
- VR の没入感は高解像度映像・広 FOV・空間音響など複数要因で向上するが、**視覚 vs 空間音響の相対的寄与**は定量化されていない。
- 本研究は **映像解像度 (3 段階) × 空間音響忠実度 (3 段階)** の 3×3 要因で、**没入感と AV 品質**に与える影響を比較した。  

## 🎯 実験デザイン
| 因子 | 水準 |
|------|------|
| **Spatial Audio** | ① Monaural ② Head‑Tracked Binaural (HTB) ③ HTB＋Room Reverb (SDN) |
| **Video Resolution** | 0.5 Mpx (20 %) / 1.5 Mpx (60 %) / 2.5 Mpx (100 %) per eye |
| **Stimuli** | 無響女性スピーチ・クラシックギター (MIT KEMAR) |
| **参加者** | 17 名 (18–25 歳、音響教育訓練済) |
| **評価** | Immersion・Audio‑Visual Quality (ITU 9 点) |

VR 環境：HTC Vive (90 Hz) + ATH‑M50x。各参加者は 18 シーン×2 テスト (Immersion→10 min 休憩→AV 品質)。
## 📈 主な結果
### Immersion
- 両因子とも有意 (**Kruskal–Wallis** Video *H*(2)=34.7, Audio *H*(2)=145.9, *p*<0.001)。  
- **HTB+Reverb / 20 %映像** と **HTBのみ / 100 %映像** の平均スコアほぼ同等 (5.79 vs 5.76, *U*=567, *p*=0.891)。  
- **Reverb 追加**は **映像解像度 5 倍向上**と同程度に没入感を高めた。

### Audio‑Visual Quality
- Video がより大きな影響：100→20 % に劣化すると AV 品質大幅低下。  
- **Reverb なし + HTB** は **Reverb あり + 20 %映像** より高品質 (6.44 vs 4.97, *p*<0.001)。  

## 🔍 考察
1. **高忠実度空間音響 (頭部追従＋残響)** は、低解像度映像を補完して没入感を維持できる。  
2. **AV 品質の主観評価**では映像要因が支配的だが、没入感は音響でも大幅に向上。  
3. モバイル VR 等で GPU 負荷制約がある場合、**real‑time reverberation (SDN)** を優先実装する価値が高い。  

## ⚠ 限界
- 被験者は音響専門学生に偏り。  
- 1 シーン静的環境・着席視聴でタスクなし。  
- 個人化 HRTF 未使用、非個別化誤差の影響は不明。  

## 🚀 応用ポイント
- MoL VR では **室内残響＋頭部追従バイノーラル** を追加することで、順序記憶支援 UI に負荷を掛けず没入感を保てる。  
- リソース制約下の設計ガイド：GPU/映像 <-> CPU/音響のバランス調整でユーザ体験最適化。  

---
