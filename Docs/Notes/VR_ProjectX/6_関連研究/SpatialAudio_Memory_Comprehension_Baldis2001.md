---
title: SpatialAudio_Memory_Comprehension_Baldis2001
tags: [文献, spatial_audio, desktop_conference, CHI2001, ProjectX/文献]
date: 2001-03-31
source: [[Attachments/Docs/365024.365092.pdf]]
url: https://doi.org/10.1145/365024.365092
type: literature
---

# Effects of Spatial Audio on Memory, Comprehension, and Preference during Desktop Conferences  
*Jessica J. Baldis, CHI 2001*

## 🧠 研究背景と目的
- デスクトップ会議では複数話者の音が同一スピーカから出るため**話者識別が困難**になり、記憶・理解を阻害する。  
- **Spatial audio** により話者位置を提示すれば、視聴覚ワーキングメモリを分散でき、認知負荷を低減できると仮定。  
- 本研究は**記憶・焦点保証 (focal assurance)・主観的理解・ユーザ嗜好**に対する空間音響の効果を検証する。  

## 🎯 実験設計
| 項目 | 内容 |
|------|------|
| 参加者 | 19 名（男性 11・女性 8、21–48 歳） |
| デザイン | 2 (画像: 有/無) × 3 (音: non‑spatial / co‑located / scaled 60°) **完全内的要因** |
| 刺激 | 6 本 × 6 分の録画済み 4 人会議（論争的トピック） |
| 評価指標 | Speaker ID 正答/信頼度、Focal assurance、主観理解 (Likert 7)、好み順位 |

### オーディオ条件
1. **Non‑spatial**: 全話者 0° 正面  
2. **Co‑located spatial**: 話者ごとに 15°, 5°, −5°, −15°  
3. **Scaled spatial**: 60°, 20°, −20°, −60°（被験者事前調査の好み反映）

## 📈 主な結果
- **記憶（Speaker ID）**: Spatial 条件で有意向上  
  - Non‑spatial 平均 9.95 → Co‑located 13.5 → Scaled 15.25 (*F*(2,54)=21.2, *p*<.001)  
- **焦点保証**: Spatial で向上、Scaled が最良 (*F*(2,54)=9.66, *p*<.001)  
- **主観理解**: Spatial で向上 (*F*(2,54)=12.98, *p*<.001)  
- **注意要求 (GQ3)**: Non‑spatial が最悪、Scaled が最少 (*F*(2,54)=35.07, *p*<.001)  
- **嗜好順位**: Scaled audio + 画像 が最高評価、Non‑spatial が最低  
- **視覚画像の効果**: 記憶・理解には影響せず、好み向上のみ  

## 🔍 考察
1. 空間音響は**ワーキングメモリの負荷分散**を通じて記憶と理解を向上。  
2. 話者間角度を広げても雑音の少ない環境では効果差が限定的。  
3. 静的画像は情報量が少なく追加手がかりとして機能しなかった。  

## ⚠ 限界
- 高 S/N の静的再生環境で**現実的な雑音条件**を含まない。  
- 受動聴取タスクで**双方向会議**における効果は未検証。  
- 実験は物理スピーカ配置；HRTF ベース電子空間化の課題未評価。  

## 🚀 応用ポイント
- VR/デスクトップ会議への**360°話者定位**導入は記憶・理解・満足度を即時に向上させる。  
- MoL‑VR で**順序記憶を音像でタグ付け**すれば Strict スコア改善が期待。  
- 教育・リモート協働システムで**Scaled spatial audio** をデフォルト設定とする設計指針を示唆。  

---
