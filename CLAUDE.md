# M3AnimatedSeries -- Claude Instructions

## Project

- **Purpose:** Animated series production -- adapt "Murder, Malady and Monsters" novel into animated episodes using Unity
- **Engine:** Unity 6, URP
- **Path:** `E:\Unity\M3AnimatedSeries`
- **Root:** `Assets/_M3/`
- **Developer:** TecVooDoo LLC / Rune (Stephen Brandon)

## Docs -- Read These First

| Question | Read This |
|----------|-----------|
| Where are we at? | `Documents/M3_Status.md` |
| Architecture, standards? | `Documents/M3_DevReference.md` |
| Asset candidates for this project? | `Documents/M3_DevReference.md` -- Asset Candidates section |
| Asset evals? | `E:\Unity\Sandbox\Documents\Sandbox_AssetLog.md` (Sandbox is single source) |

## What This Project Does

1. **Animated series production** -- Episodes are produced here: character animation, lip sync, Timeline sequencing, Cinemachine cameras, audio, dialogue, rendering/recording.
2. **Sets import from SetDesign** -- Environment/set prefabs are built in `E:\Unity\SetDesign` and imported here. This project does NOT build sets.
3. **Character pipeline** -- Synty SidekickCharacters with lip sync, facial expressions, cloth/hair simulation, IK, and animation retargeting.
4. **Script-to-screen** -- Book manuscript is converted to episode scripts (via Gemini), then animated here.

## Production Pipeline

```
Manuscript (book) --> Gemini (script + set directions) --> SetDesign (build sets)
                                                      --> M3 (animate episodes)
Sets import from SetDesign --> M3 scenes
Characters (Synty Sidekick) + Animation + Lip Sync + Audio --> Timeline --> Render
```

## Coding Standards

- **No `var`** -- explicit types always
- **No per-frame allocations/LINQ** -- cache, pool, reuse
- **ASCII only** in docs and identifiers
- **sealed** on MonoBehaviours unless inheritance intended
- **Prefer async/await (UniTask)** over coroutines
- **Prefer interfaces and generics** -- decouple systems, reduce duplication
- **Extract by responsibility** not line count
- **Vanilla SO architecture** -- GameEvent/GameEventListener for events (NOT SOAP)

## Key Rules

- **Sets are built in SetDesign** -- don't build environments here, import them
- **Asset evals live in Sandbox** -- don't create eval docs here
- **NEVER assume APIs** -- read actual source before writing code
- **GDD/scripts are user's docs** -- update only when asked

## MCP

- Unity MCP via `com.ivanmurzak.unity.mcp` (OpenUPM). Port in `.claude/mcp.json` -- update after MCP install.
- Custom tools via `com.tecvoodoo.mcp-tools` (local UPM package)
- `script-execute` is the power tool (Roslyn). C# `<>` gets HTML-encoded -- use `typeof()` casts.
- MCP disconnects during domain reload -- wait for auto-reconnect.

## Critical Gotchas

- **Animancer Pro** -- install BEFORE 3D art assets (FBX catalog scan)
- **More Mountains Feel** -- does NOT trigger FBX scan (safe to install anytime)
- **Master Audio 2024** -- install Addressables FIRST
- **DOTween Pro** -- install TextMesh Pro FIRST
- **Odin Inspector** -- never remove from installed project
- **UPM Git URLs don't work** on this machine -- clone repo, use `file:` reference
- **Synty SidekickCharacters skeleton** -- two extra bones: `IK_foot_root` and `IK_hand_root`. Handle in Final IK setup. Modular mesh fails FBBIK auto-detect -- assign BipedReferences manually via `Animator.GetBoneTransform(HumanBodyBones)`.
- **MagicaCloth 2** -- requires SkinnedMeshRenderer. MeshCloth locks all verts with MeshRenderer.
- **Random ambiguity** -- `using Unity.Mathematics;` + `using UnityEngine;` = CS0104. Fix: `using Random = UnityEngine.Random;`
