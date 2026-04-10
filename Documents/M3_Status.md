# M3AnimatedSeries -- Status

**Purpose:** Animated series production -- adapt "Murder, Malady and Monsters" into animated episodes.
**Last Updated:** April 9, 2026

---

## Current State

**Phase:** Initial Setup (Session 2)

Script pipeline established. uLipSync evaluated and approved. MCP lip sync tools built. Synty Store Importer installed. Awaiting Tier 1 asset installs.

**Next session priorities:**
- Install Tier 1 assets (Animancer Pro, Final IK, MagicaCloth 2, Master Audio, DOTween Pro) -- Animancer FIRST (FBX catalog scan)
- Import Synty SidekickCharacters via Store Importer
- Test uLipSync with Synty characters (check for viseme blendshapes)
- First set import from SetDesign (Vertex Lab)

---

## Production Status

| Episode | Script | Sets (SetDesign) | Animation | Audio | Status |
|---------|--------|-------------------|-----------|-------|--------|
| Episode 1 | Scene 1 scripted (M3 format) | 3 sets planned (Vertex Lab, Church Int, Church Ext) | Not started | Not started | Pre-production |

---

## Session Log

### Session 2 -- April 9, 2026
- Evaluated uLipSync 3.1.5 (ENTRY-328 in Sandbox AssetLog) -- **Approved, Recommended**
  - Burst-compiled MFCC analysis, pre-bake + Timeline workflow, AnimationClip export
  - One bug found: uLipSyncTexture.cs has unconditional `using UnityEditor`
  - Open question: Synty SidekickCharacters may lack viseme blendshapes
- Built 3 MCP tools for uLipSync in TMCP package:
  - `lipsync-query` -- inspect components, list Profile/BakedData assets
  - `lipsync-configure` -- set profile, blendshape mappings, volume/smoothness
  - `lipsync-bake` -- batch bake AudioClips to BakedData assets
  - Added `HAS_ULIPSYNC` to MCPToolsDefineManager.cs
  - Updated TMCP_Status.md (~215 tools, 48 groups), TMCP_Reference.md, TMCP_ToolList.md
- Created M3_ScriptFormatGuide.md -- production script format for Gemini output
  - Tag system: [SHOT], [VO:], [LOOK:], [ANIM:], [GESTURE:], [SFX:], [AMB:], [MUS:], [BEAT], [PROP:], [TRANSITION:]
  - Naming conventions for voice lines, characters, props, animation intents
  - Asset manifest generation from script tags
  - Shot density rules, music cue requirements, inline vs standalone tag rules
- Created M3_Episode1_Script.md -- Scene 1 rewritten as format example (65 shots, 82 voice lines, 13 beats, 32 animation intents, 8 music cues)
- Installed Synty Store Importer (editor extension for bulk .unitypackage import)
- Decided on asset strategy: Dialogue System, Naninovel, Adventure Creator, Ink, Koreographer, Timeflow all SKIPPED (game/interactive-specific, not needed for linear animated series)
- Revised required package list (removed Dialogue System, added uLipSync, removed com.tecvoodoo.games)

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
| uLipSync 3.1.5 | GitHub (file: ref) | Installed, evaluated (ENTRY-328) |
| Synty Store Importer | GitHub | Installed (editor tool) |

---

## Lip Sync Evaluation

**Complete.** uLipSync 3.1.5 selected as primary lip sync solution.

- **uLipSync** (hecomi) -- **APPROVED, RECOMMENDED** (ENTRY-328). MFCC-based, Burst-compiled, pre-bake + Timeline workflow. MCP tools built (lipsync-query, lipsync-configure, lipsync-bake).
- **Remaining question:** Do Synty SidekickCharacters have viseme blendshapes? If not, use EditorSculpt (ENTRY-152) to create them, or fall back to uLipSyncTexture (texture-swap mode).

---

## Asset Install Plan (Tier 1 -- Next Session)

Install order matters. Follow this sequence:

1. **Animancer Pro** -- FIRST (triggers FBX catalog scan on all 3D assets)
2. **DOTween Pro** -- requires TextMesh Pro (should already be installed)
3. **Final IK** -- after Animancer
4. **Master Audio 2024** -- requires Addressables (install Addressables first)
5. **MagicaCloth 2** -- requires SkinnedMeshRenderer (after character import)
6. **Synty SidekickCharacters** -- via Store Importer (after Animancer)

## Asset Install Plan (Tier 2)

- Feel, Text Animator, UMotion Pro, Retarget Pro, EditorSculpt, Boing Kit, Default Playables
