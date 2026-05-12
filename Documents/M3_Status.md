# M3AnimatedSeries -- Status

**Purpose:** Animated series production -- adapt "Murder, Malady and Monsters" into animated episodes.
**Last Updated:** 2026-05-11

---

## Current State

**Phase:** Post-crash recovery (Session 4)

Memory rebuilt after May 9 crash. iter-3.5 doc-system convention adopted in DevReference (Version + Revision History header, canonical pointer for Coding Standards). Unity is reopening on 6000.3.15f1. MCP plugin upgrade 0.66.1 -> 0.72 is in flight. Outstanding code/config work from Sessions 2-3 (manifest bump to 0.66.1, MCP HTTP transport, Animancer/Timeflow/ALINE/TextAnimator embedded UPM, Synty character prefabs) is being landed in a single fresh-session commit.

**Next session priorities:**
- Resume Tier 3 work: test uLipSync with Synty SidekickCharacters (viseme blendshapes question).
- First set import from SetDesign (Vertex Lab).
- Audit / remove placeholder `Assets/_M3/Audio/Music/NewMonoBehaviourScript.cs` if it was accidental (Unity-default name suggests right-click "Create > MonoBehaviour Script" by mistake).

---

## Production Status

| Episode | Script | Sets (SetDesign) | Animation | Audio | Status |
|---------|--------|-------------------|-----------|-------|--------|
| Episode 1 | Scene 1 scripted (M3 format) | 3 sets planned (Vertex Lab, Church Int, Church Ext) | Not started | Not started | Pre-production |

---

## Session Log

### Session 4 -- 2026-05-11
- **MCP 0.66.1 -> 0.72.0 upgrade landed clean** (commit 47b1b78). Direct-jump path, fourth fleet verification after HOK / SS / GRIMMORPG. No `.meta`-stub regression (that bug is specific to the legacy 0.66.1 -> 0.69.0 resolver path). 138 tools registered, `scene-list-opened` returns SampleScene cleanly. Unity simultaneously bumped 6000.3.11f1 -> 6000.3.15f1. Sub-packages restored at animation 1.1.38 / particlesystem 1.0.64 / probuilder 1.0.76.
- Updated `Canonical/MCP_ConnectionBrief.md` fleet table with M3's verified-working row (left unstaged in Sandbox; next Sandbox-session bookend will push).
- Post-crash recovery pass. Rebuilt Claude memory at `C:\Users\steph\.claude\projects\e--Unity-M3AnimatedSeries\memory\` per iter-3.5 canonical adoption: 9 files now (MEMORY.md index + user_profile, project_crash_recovery, feedback_push_permission, feedback_cross_project_commit_ownership, plus reference pointers for coding standards, universal workflow, MCP brief, M3 documents map, Sandbox AssetLog).
- Adopted PerProject_DocSystem v1.1 mandatory convention on `M3_DevReference.md`: added `Version` + `Revision History` table; slimmed Coding Standards block to a canonical pointer plus M3-specific deltas (no gameplay patterns, animation-first architecture, renderer/recorder latitude).
- Audited outstanding pre-recovery state: M3_DevReference.md and M3_Status.md carried unpushed Session 2-3 edits (Refactor Guidelines, MCP HTTP transport pointer, Juicy Actions for Feel, Timeflow upgrade, expanded Installed Assets table); manifest.json bumped MCP 0.63.3 -> 0.66.1 and dropped the three MCP sub-packages; `.mcp.json` / `.claude/mcp.json` synced with ai-game-developer / ElevenLabs / blender; embedded UPM packages (Animancer, ALINE, Timeflow, Text Animator) and new `Assets/_M3/Characters/{Prefabs,SKCCModels,Animators}` plus `Audio/Dialogue`, `Scripts/LipSync` folders untracked.
- Standing permission granted: push to `origin/master` without per-push confirmation. Saved as `feedback_push_permission.md`.
- Open question carried forward: does the MCP `.meta`-stub problem reproduce on the 0.66.1 -> 0.72 jump? M3 is the next fleet data point per `MCP_ConnectionBrief.md`.

### Session 3 -- April 27, 2026
- Migrated MCP transport from `stdio` to `streamableHttp` (port 23988). Verified connected, ping/scene-list/tool-list (141 tools) all pass. One server process parented to Unity.exe, no bind errors.
- Synced `.mcp.json` and `.claude/mcp.json` so both contain `ai-game-developer`, `ElevenLabs`, and `blender`.
- Updated M3_DevReference.md MCP section with transport + pointer to canonical brief at `E:\Unity\Sandbox\Documents\MCP_ConnectionBrief.md`.

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

| Asset | Version | Source | Notes |
|-------|---------|--------|-------|
| **Core Animation** | | | |
| Animancer Pro | 8.3.1 | Kybernetik (Custom UPM) | Code-driven animation |
| Final IK | 2.4 | Asset Store | FBBIK, LookAt, Aim |
| UMotion Pro | 1.29 | Asset Store | In-Unity animation authoring |
| Retarget Pro | 4.2.1 | Asset Store | Animation retargeting |
| Body Poser | 1.2 | Asset Store | Scene blocking poses |
| Animation Path Visualizer | 2.0.0 | Asset Store | Editor QoL |
| **Lip Sync** | | | |
| uLipSync | 3.1.5 | GitHub (Local) | ENTRY-328, MCP tools built |
| EditorSculpt | 1.70 | Asset Store | Viseme blendshape creation |
| **Audio** | | | |
| Master Audio 2024 | 1.0.4 | Asset Store | Full audio system |
| Audio Preview Tool | 1.1.0 | Asset Store | Editor QoL |
| **Sequencing / Tweening** | | | |
| Timeflow | 1.10.1 | Axon Genesis (Custom UPM) | Procedural animation engine |
| DOTween Pro | 1.0.410 | Asset Store | Universal tweening |
| Juicy Actions | 1.0.3 | Asset Store | Game feel/juice (replaces Feel) |
| Default Playables | 2.0 | Asset Store | Timeline extension tracks |
| **Physics / Simulation** | | | |
| MagicaCloth 2 | 2.18.1 | Asset Store | Cloth simulation |
| Boing Kit | 1.2 | Asset Store | Hair/accessory spring physics |
| **Text / UI** | | | |
| Text Animator | 3.5.1 | Febucci (Custom UPM) | Subtitles, titles, credits |
| Markdown for Unity | 1.0.0 | Asset Store | Editor QoL |
| **Characters / Art** | | | |
| Synty SidekickCharacters | -- | Synty Store | Base for all M3 characters |
| Synty PolygonParticleFX | -- | Synty Store | Synty-style particles |
| Synty Animations (all) | -- | Synty Store | Sidekick + generic rig clips |
| Kevin Iglesias Animations | -- | Asset Store | Basic Motions, Human Crafting |
| Synty Store Importer | -- | GitHub | Editor tool (gitignored) |
| **Editor Tools** | | | |
| ALINE | 1.7.9 | Asset Store | Debug drawing |
| vFolders 2 | 2.1.14 | Asset Store | Project window organization |
| vHierarchy 2 | 2.1.8 | Asset Store | Hierarchy window organization |
| Wingman | 1.3.0 | Asset Store | Inspector enhancement |
| Ultimate Preview Window | 1.3.3 | Asset Store | Asset preview |
| **TecVooDoo Packages** | | | |
| com.tecvoodoo.mcp-tools | 1.8.0 | Local UPM | MCP tooling (215 tools) |
| com.tecvoodoo.utilities | 1.2.0 | Local UPM | Shared utilities |
| com.tecvoodoo.games | 1.3.0 | Local UPM | Gameplay library |
| **Unity Packages** | | | |
| Timeline | 1.8.12 | Unity | Episode sequencing |
| Cinemachine | 3.1.6 | Unity | Camera choreography |
| Animation Rigging | 1.4.1 | Unity | Constraint-based IK |
| ProBuilder | 6.0.9 | Unity | Mesh editing |
| Addressables | 2.9.1 | Unity | Asset management |
| AI Navigation | 2.0.12 | Unity | NavMesh (if needed) |
| UniTask | 2.5.10 | Cysharp | Async/await |
| R3 | 1.3.0 | Cysharp (NuGet) | Reactive extensions |

---

## Lip Sync Evaluation

**Complete.** uLipSync 3.1.5 selected as primary lip sync solution.

- **uLipSync** (hecomi) -- **APPROVED, RECOMMENDED** (ENTRY-328). MFCC-based, Burst-compiled, pre-bake + Timeline workflow. MCP tools built (lipsync-query, lipsync-configure, lipsync-bake).
- **Remaining question:** Do Synty SidekickCharacters have viseme blendshapes? If not, use EditorSculpt (ENTRY-152) to create them, or fall back to uLipSyncTexture (texture-swap mode).

---

## Asset Install Status

**Tier 1 and Tier 2: COMPLETE.** All core and recommended assets installed.

**Notes:**
- Juicy Actions replaces Feel (Feel has stability issues across projects). TMCP tools built for both.
- Timeflow complements Timeline: Timeline = episode sequencer (clips, tracks, uLipSync), Timeflow = procedural layer (tweens, easing, ambient animations, property binding, audio-reactive). Timeflow can follow PlayableDirector.
- Synty animations: some clips are sidekick-specific, others target generic Synty rig. May need Retarget Pro for cross-rig clips.
- Kevin Iglesias clips (Basic Motions, Human Crafting) are Mixamo-compatible humanoid -- should retarget to Synty cleanly.

**Next steps:**
- Test uLipSync with Synty SidekickCharacters (check for viseme blendshapes)
- First set import from SetDesign (Vertex Lab)
- Character prefab pipeline (Synty modular mesh configuration per character)
