# M3AnimatedSeries -- Status

**Purpose:** Animated series production -- adapt "Murder, Malady and Monsters" into animated episodes.
**Last Updated:** April 9, 2026

---

## Current State

**Phase:** Initial Setup (Session 1)

Project created. Folder structure in place. Awaiting:
- Core asset installs (Animancer Pro, Final IK, MagicaCloth 2, Master Audio, Dialogue System, DOTween Pro)
- Synty SidekickCharacters import
- Lip sync solution evaluation (uLipSync candidate)
- MCP setup
- First set import from SetDesign
- Episode 1 script finalization

---

## Production Status

| Episode | Script | Sets (SetDesign) | Animation | Audio | Status |
|---------|--------|-------------------|-----------|-------|--------|
| Episode 1 | Set directions done | 3 sets planned (Vertex Lab, Church Int, Church Ext) | Not started | Not started | Pre-production |

---

## Session Log

### Session 1 -- April 9, 2026
- Created Unity 6 URP project at `E:\Unity\M3AnimatedSeries`
- Established folder structure: `Assets/_M3/` with Scenes, Characters, Timeline, Audio, Sets, VFX, Scripts, Rendering, UI
- Created CLAUDE.md, M3_Status.md, M3_DevReference.md
- Added packages to manifest (MCP, TecVooDoo, Timeline, Cinemachine, UniTask, Input System)
- Identified 50+ asset candidates across lip sync, animation, audio, rendering, VFX categories
- uLipSync (hecomi/uLipSync) identified as lip sync candidate -- needs eval
- Initialized git repo

---

## Installed Assets

| Asset | Source | Status |
|-------|--------|--------|
| (none yet) | | |

---

## Lip Sync Evaluation

Candidates to evaluate:
- **uLipSync** (hecomi) -- open source, phoneme-based, real-time. GitHub: `https://github.com/hecomi/uLipSync`. Needs clone + `file:` ref (git URLs don't work on this machine).
- **Adventure Creator** lip sync (built-in SALSA integration)
- **Naninovel** LipSync command
- **Dialogue System + ElevenLabs** addon (TTS with visemes)
- **EditorSculpt** for creating custom viseme blendshapes

Priority: Evaluate uLipSync first -- if it works well with Synty SidekickCharacters, it could be the primary solution.
