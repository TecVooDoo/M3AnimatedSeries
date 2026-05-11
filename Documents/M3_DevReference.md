# M3AnimatedSeries -- Development Reference

**Purpose:** Stable reference for M3 architecture, conventions, production pipeline, and asset candidates.
**Last Updated:** 2026-05-11
**Version:** 1.1

## Revision History

| Date | Version | Sections affected | Change |
|------|---------|-------------------|--------|
| 2026-04-09 | 1.0 | (initial) | Initial creation. Project purpose, folder structure, coding standards, character pipeline, MCP, packages, asset candidates, session workflow. |
| 2026-04-27 | 1.0 | Refactor Guidelines (new), MCP, Packages, Asset Candidates, Session Workflow (new) | Session 2-3 uncommitted edits: added Refactor Guidelines, pointed MCP at the canonical brief and noted streamableHttp/23988, swapped Feel for Juicy Actions, upgraded Timeflow row, added explicit Session Workflow. Header date stayed stale until 2026-05-11 cleanup. |
| 2026-05-11 | 1.1 | Header, Coding Standards | Added Version + Revision History header per PerProject_DocSystem v1.1 mandatory convention. Replaced inline Coding Standards bullets with canonical pointer to `Canonical/TecVooDoo_CodingStandards.md` (kept project-specific deltas only). |

---

## What M3AnimatedSeries Is

An animated series production project. The novel "Murder, Malady and Monsters" is adapted into animated episodes using Unity as the production engine.

**This project handles:**
- Character animation (Synty SidekickCharacters)
- Lip sync and facial expressions
- Timeline sequencing (per-episode timelines)
- Cinemachine camera work
- Audio (voice, music, SFX)
- Dialogue system
- Cloth/hair simulation
- VFX
- Rendering and recording final output

**This project does NOT handle:**
- Set/environment building (done in SetDesign, imported here)
- Asset evaluation (done in Sandbox)

---

## Production Pipeline

```
1. Manuscript (book chapters)
2. Gemini converts to episode script + set directions
3. SetDesign builds sets from set directions
4. Sets export to M3 as prefabs
5. M3 assembles episodes:
   a. Import sets into episode scenes
   b. Set up Synty SidekickCharacter actors
   c. Animate characters (Animancer/UMotion/Timeline)
   d. Lip sync to voice audio
   e. Cinemachine camera choreography
   f. Audio mix (Master Audio)
   g. VFX and post-processing
   h. Render final output
```

---

## Folder Structure

```
Assets/
  _M3/                        -- Project root (underscore sorts to top)
    Scenes/
      Episode1/                -- Per-episode scenes
    Characters/
      Prefabs/                 -- Character prefabs (Synty Sidekick based)
      Materials/               -- Character materials
      Animations/              -- Character animation clips
    Timeline/
      Episode1/                -- Per-episode Timeline assets
    Audio/
      Voice/                   -- Voice lines per character/episode
      Music/                   -- Background music, stems
      SFX/                     -- Sound effects
    Sets/
      Imported/                -- Set prefabs imported from SetDesign
    VFX/                       -- Episode VFX
    Scripts/
      Runtime/                 -- Production scripts
      Editor/                  -- Editor tooling
    Rendering/                 -- Render settings, post-processing profiles
    UI/                        -- Subtitles, titles, credits
  [Third-party assets]         -- Synty, Animancer, Final IK, etc.
Documents/
  M3_Status.md                 -- Primary doc: sessions, production status
  M3_DevReference.md           -- This file
```

---

## Coding Standards

**Universal TecVooDoo coding standards: see `E:\Unity\Sandbox\Documents\Canonical\TecVooDoo_CodingStandards.md` (canonical).** That file is the single source of truth across all TecVooDoo Unity projects. When it changes, the change shows in its Revision History header.

### M3-Specific

M3 is a linear animated-series production, not a game. So in addition to the universal rules:

- **No gameplay patterns.** No state machines for player input, no scene-load orchestration, no save systems. Episodes are linear Timeline playback.
- **Animation-first architecture.** Cinematic playback (Animancer + Timeline + Cinemachine) is the spine; runtime systems exist only to serve that.
- **No Dialogue System / Ink / Adventure Creator** -- voice lines are pre-baked AudioClips driven by uLipSync via Timeline. No branching narrative runtime.
- **Renderer/Recorder side has more latitude** -- one-shot offline workflows can do things that would be unacceptable in per-frame runtime code (allocations, LINQ, blocking calls).

---

## Refactor Guidelines

Carried over from the HOK refactor postmortem (DLYH was over-aggressive — had to refactor the refactor). The intent: avoid line-count targets, prefer cohesion, justify every move.

**Priorities (in order):**

1. **SOLID** — single responsibility, but don't split things that belong together. A script that does one thing cohesively can be longer than another script that's poorly factored.
2. **Memory efficiency** — no allocations in hot paths (Update / FixedUpdate / OnTriggerStay). Reuse collections, cache `GetComponent` results, avoid LINQ in tight loops.
3. **UniTask over coroutines** when the coroutine is non-trivial. Simple delay-then-fire coroutines are fine; long-running async chains warrant UniTask.
4. **Interfaces preferred, generics welcome** — easier to test, easier to swap.
5. **Grouping related things together, not splitting for line count.** Folder/file organization matters too, not just per-script.

**Don't refactor for the sake of refactoring** — needs a clear reason to change or stay. Every change needs justification: why move, why stay.

**Line count is a smell, not a target:** 3000 lines is too much, but 1500 doing one job well is fine. The DLYH targets (1000-1200) came from Claude Desktop conversation limits, not from code quality.

**When auditing for refactor:**
- Look at folder organization first — sibling files should belong together.
- Group by feature, not by type (e.g. keep related scripts for one system in a feature folder, not split across generic `Components/` or `Models/` folders).
- If a class has two clear responsibilities and they don't depend on each other, split. If they constantly call each other or share state, leave them.

---

## Character Pipeline

**Base:** Synty SidekickCharacters
- Humanoid rig with IK bones (ik_foot_l/r, ik_hand_l/r)
- Attachment bones: prop_l/r, headAttach, faceAttach, hipAttach, backAttach, shoulderAttach, elbowAttach, kneeAttach
- Bone naming: lowercase (hand_l, head, pelvis)
- Root scale 1.0
- Mixamo animations retarget correctly

**Animation Stack (per character):**
1. Base animation (Animancer Pro -- code-driven playback)
2. IK layer (Final IK -- look-at, hand placement, interaction)
3. Lip sync layer (uLipSync or equivalent -- viseme blendshapes)
4. Facial expression layer (blendshapes or texture swap)
5. Secondary motion (MagicaCloth 2 for cloth, BoingBones for hair/accessories)

**Lip Sync Approach (uLipSync 3.1.5 -- APPROVED):**
- Pre-bake voice AudioClips to BakedData assets (lipsync-bake MCP tool or Baked Data Generator window)
- BakedData drives uLipSyncBlendShape via Timeline tracks (uLipSync Track + uLipSyncTimelineEvent binding)
- One calibrated Profile per voice actor (male_01, female_01, etc.)
- AnimationClip export available for integration with Animancer layering
- May need custom viseme blendshapes on Synty characters (EditorSculpt, ENTRY-152)
- Fallback: uLipSyncTexture (texture-based face swap) if blendshapes prove difficult on Synty mesh

---

## MCP

- Unity MCP via `com.ivanmurzak.unity.mcp` (OpenUPM), `streamableHttp` transport on `http://localhost:23988`
- Custom tools via `com.tecvoodoo.mcp-tools` (local UPM package)
- TMCP tools available for: Final IK, Cinemachine, Master Audio, Dialogue System, DOTween, Feel, Timeline, Animation Rigging, Text Animator
- Migration / verification / troubleshooting: `E:\Unity\Sandbox\Documents\MCP_ConnectionBrief.md`

---

## Packages (Non-Art)

| Package | Purpose | Required |
|---------|---------|----------|
| Timeline | Episode sequencing | Yes |
| Cinemachine | Camera choreography | Yes |
| Animancer Pro | Code-driven animation | Yes |
| Final IK | Character IK | Yes |
| Master Audio 2024 | Audio system | Yes |
| DOTween Pro | Tweening/transitions | Yes |
| MagicaCloth 2 | Cloth simulation | Yes |
| uLipSync 3.1.5 | Lip sync (ENTRY-328, Approved) | Yes |
| com.tecvoodoo.mcp-tools | MCP tooling | Yes |
| com.tecvoodoo.utilities | Shared utilities | Yes |
| UniTask | Async/await | Yes |
| UMotion Pro | Animation authoring | Recommended |
| Juicy Actions 1.0.3 | Screen FX, shake, spring physics, juice | Recommended |
| Text Animator | Subtitles, titles | Recommended |
| Retarget Pro | Animation retargeting | Recommended |
| EditorSculpt | Viseme blendshape creation | Recommended |
| Boing Kit | Hair/accessory spring physics | Recommended |
| Timeflow 1.10.1 | Procedural animation (ENTRY-100, Approved) | Recommended |

**Removed from original list:**
- Dialogue System -- M3 has no interactive dialogue; voice lines are pre-baked via uLipSync + Timeline
- Ink Integration -- M3 is linear, not branching narrative
- com.tecvoodoo.games -- M3 has no gameplay

---

## Asset Candidates

Tools and assets from the Sandbox AssetLog (and external sources) relevant to M3. Install as needed. Grouped by purpose.

### Lip Sync / Facial Animation

| Entry | Asset | Verdict | Notes |
|-------|-------|---------|-------|
| -- | uLipSync (hecomi) | **Needs Eval** | Open source, phoneme-based, real-time. GitHub: `https://github.com/hecomi/uLipSync`. Clone + `file:` ref. Priority eval candidate. |
| 251 | Adventure Creator 1.85.5 | Approved, Recommended | Built-in lip sync (auto, SALSA integration, texture-based). ActionBlendShape for facial control. |
| 273 | Naninovel 1.21 | Approved, Recommended | LipSync command, character actor system. GenericActor wraps 3D mesh characters. |
| 292 | City Characters 1.2 (ITHappy) | Approved | FacePicker: 17 face expressions. Not lip sync but expression system reference. |
| 152 | EditorSculpt | Approved, Recommended | Create custom viseme blendshapes directly in Unity. Free. |
| 136 | MegaFiers 2 (Chris West) | Approved | MegaMorph blendshape system for procedural facial animation. $150. |

### Character Animation

| Entry | Asset | Verdict | Notes |
|-------|-------|---------|-------|
| 089 | Animancer Pro v8 | Approved, Recommended | **Core.** Code-driven animation, replaces Mecanim. Essential for cinematic playback. |
| 090 | Final IK (RootMotion) | Approved, Recommended | **Core.** FBBIK, LookAtIK, AimIK. Gaze, hand placement, interaction. TMCP tools built. |
| 091 | UMotion Pro | Approved, Recommended | In-Unity animation authoring/editing. Tweak clips for specific shots. |
| 243 | Retarget Pro 4.2.1 (Kinemation) | Approved, Recommended | Runtime animation retargeting across Synty body types. TMCP tools built. |
| 250 | Motion Warping 3.2.0 (Kinemation) | Approved, Recommended | Root motion warp to hit precise marks in cinematics. |
| 244 | Advanced Look Component 2.0.0 (Kinemation) | Approved, Recommended | Look-at IK for dialogue scenes. |
| 225 | Body Poser 1.4 | Approved | Pose humanoid characters for scene blocking. |
| 093 | Human Crafting Motions (Kevin Iglesias) | Approved | Animation clip library. |
| 094 | Basic Motions (Kevin Iglesias) | Approved | Animation clip library. |
| 232 | Interactor 0.999b | Conditional | Full-body IK interaction with objects. |
| 303 | KINERACTIVE 1.11 | Approved | IK interaction system. |

### Cloth / Hair / Physics

| Entry | Asset | Verdict | Notes |
|-------|-------|---------|-------|
| 095 | MagicaCloth 2 | Approved, Recommended | **Core.** Cloth sim for capes, robes, loose clothing. Jobs/Burst. |
| 256 | Boing Kit 1.2.47 | Approved | BoingBones: spring physics for hair, tails, accessories. Lighter than MagicaCloth for simple chains. |
| 148 | Fluffy Grooming Tool | Approved | GPU fur/hair grooming. Strand-based hair if needed. |
| 207 | Toolkit for Verlet Motion 2026 | Approved, Recommended | Chain/rope/rigid jewelry physics. |
| 224 | PuppetMaster 1.4 (RootMotion) | Approved, Recommended | Muscle-based physics puppet. Physical comedy, impacts, stumbling. |
| 216 | Ragdoll Animator 2 | Approved, Recommended | Blend animation <-> ragdoll for impact reactions. |
| 255 | Squash & Stretch Kit 1.1.2 | Conditional | Cartoon-style deformation for exaggerated animation. |

### Audio / Dialogue

| Entry | Asset | Verdict | Notes |
|-------|-------|---------|-------|
| 103 | Master Audio 2024 | Approved, Default | **Core.** Full audio system. TMCP tools built. |
| 214 | Dialogue System for Unity 2.2.66 | Approved, Recommended | **Core.** Conversations, actors, Lua scripting. TMCP tools built. |
| 215 | DS Addon -- Procedural Dialogue 1.0.5 | Approved | GPT dialogue generation. |
| 257 | DS OpenAI + ElevenLabs Addon 1.0.34 | Approved | TTS voice synthesis, per-character voice IDs. |
| 281 | Ink Integration 1.1.8 | Approved, Recommended | Branching narrative scripting. Works with DS. |
| 101 | Koreographer Professional | Approved, Recommended | Music-sync events. TMCP tools built. |
| 102 | Audio Preview Tool | Approved, Default | Editor QoL. |

### Timeline / Sequencing

| Entry | Asset | Verdict | Notes |
|-------|-------|---------|-------|
| 106 | Default Playables | Approved, Default | Timeline extension tracks. |
| 251 | Adventure Creator 1.85.5 | Approved, Recommended | 137 action types, ActionList cutscene system, Timeline integration. Full episode director candidate. |
| 273 | Naninovel 1.21 | Approved, Recommended | Script-driven sequencing, .nani format, ControlTimeline command. |
| 316 | Juicy Actions 1.0.3 | Approved, Recommended | Async action sequencing for procedural cinematics. |
| 100 | Timeflow 1.10.1 (Axon Genesis) | Approved, Recommended | Procedural animation engine. Complements Timeline -- tweens, easing, property binding, audio-reactive, batch animation. TMCP tools built. |

### Rendering / Post-Processing

| Entry | Asset | Verdict | Notes |
|-------|-------|---------|-------|
| 195 | Toon Kit 2 v2.3.0 | Approved, Recommended | Cel/toon shading. Matches Synty low-poly style for animated series look. |
| 200 | Outline Objects v3.1.18 | Approved, Recommended | Per-mesh stencil outlines for animated series aesthetic. |
| 191 | Outlines Post-Process v1.1.1 | Approved | Full-screen outline effect. |
| 190 | Gaussian Blur v3.0.1 | Approved, Recommended | DOF simulation, focus effects. |
| 185 | LSPP v3.3.1 | Approved, Recommended | God rays for dramatic lighting. |
| 187 | Auto Exposure v3.2.2 | Approved | Cinematic camera exposure. |
| 188 | Motion Blur v3.2.1 | Conditional | Cinematic motion blur for action. |
| 189 | HazeFX v0.5.2 | Approved | Heat/haze distortion. |
| 192 | Radial Blur v3.0.0 | Approved | Dramatic focus effects. |
| 158 | Amplify Shader Editor | Approved, Default | Custom shader authoring for series visual style. |
| 159 | Amplify Shader Pack | Approved, Default | 130+ production shaders. |
| 170 | Ghost Effect Shader | Approved, Recommended | Ghost/ethereal character effects. |
| 315 | Ghost and Shaders PRO | Approved | Spectral character rendering. |
| 098 | All In 1 3D Shader | Approved | Multi-effect shader. |
| 066 | Unity Toon Shader | Testing | Unity's toon shader alternative. |

### VFX

| Entry | Asset | Verdict | Notes |
|-------|-------|---------|-------|
| 266 | PolygonParticleFX (Synty) | Approved | Synty-style particles. Matches art pipeline. |
| 307 | Polygon Arsenal 2.07 | Approved, Recommended | Magic, energy, fire, ice FX for action sequences. |
| 202 | VFX Library v3.0.0 | Approved, Recommended | Atmospheric FX (dust, fog, fireflies, embers). |
| 171 | Responsive Smokes | Approved, Recommended | Interactive volumetric smoke. |
| 325 | Lumen: Stylized Light FX 2.0.5 | Approved | Stylized volumetric lighting. |
| 146 | MudBun | Approved | SDF VFX, claymation material presets. |

### Tweening / Feel

| Entry | Asset | Verdict | Notes |
|-------|-------|---------|-------|
| 111 | DOTween Pro | Approved, Default | **Core.** Universal tweening. TMCP tools built. |
| 241 | Feel 5.9.1 | Approved, Recommended | Camera shake, screen FX, juice. TMCP tools built. |

### Text / UI

| Entry | Asset | Verdict | Notes |
|-------|-------|---------|-------|
| 117 | Text Animator for Unity | Approved, Default | Per-character text animation. Subtitles, titles, credits. TMCP tools built. |
| 116 | UI Toolkit Text Animation 2 | Approved, Default UI | UI Toolkit integration. |
| 235 | Damage Numbers Pro 4.5.1 | Approved, Recommended | Repurposable for on-screen text effects. |

### Synty Characters

| Entry | Asset | Verdict | Notes |
|-------|-------|---------|-------|
| 291 | SidekickCharacters (Synty) | Conditional | **Core.** Humanoid rig, IK bones, attachment bones. Base for all M3 characters. |
| 265 | Synty Store Importer | Approved | Synty import pipeline tool. |

---

## Session Workflow

Every working session is bracketed by two bookends. Skipping either one degrades context for the next session.

### Session Open

1. **Read `M3_Status.md`.** Current state + last ~2 sessions live there.
2. **Verify Unity is reachable via MCP.** If the Editor isn't running, ask before doing anything that needs it.
3. **Check the console** -- 0 errors before starting work. Address any new errors before proceeding.
4. **Note open carryovers** in `M3_Status.md` -- these are pre-approved drops from prior sessions.

### Session Close

1. **Update `M3_Status.md`** with a new session entry at the top of the session list (newest-first within the recent block).
2. **Archive older sessions when `M3_Status.md` grows past ~2 sessions in the recent block** -- create `M3_StatusArchive.md` when needed.
3. **Update the Next list** in `M3_Status.md` to reflect what's left after this session.
4. **Commit and push.** Stage the working changes, write a focused commit message summarizing the session's work (the "why" -- not the diff), and push to the GitHub remote (`origin/main` on `https://github.com/TecVooDoo/M3AnimatedSeries`). The repo is the source of truth between machines and across time -- skipping the push is how work gets lost or duplicated.

If there are no code or doc changes worth committing (e.g. the session was purely investigation / playtest with no changes), still update `M3_Status.md` with the session notes and commit + push that doc-only change.
