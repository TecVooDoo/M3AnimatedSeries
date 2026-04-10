# M3AnimatedSeries -- Development Reference

**Purpose:** Stable reference for M3 architecture, conventions, production pipeline, and asset candidates.
**Last Updated:** April 9, 2026

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

- No `var` keyword -- explicit types always
- No per-frame allocations/LINQ -- cache, pool, reuse
- ASCII-only in code and identifiers
- `sealed` on MonoBehaviours unless inheritance intended
- Prefer async/await (UniTask) over coroutines
- Prefer interfaces and generics -- decouple systems, reduce duplication
- Extract by responsibility not line count
- Vanilla SO architecture -- GameEvent/GameEventListener for events (NOT SOAP)

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

- Unity MCP via `com.ivanmurzak.unity.mcp` (OpenUPM)
- Custom tools via `com.tecvoodoo.mcp-tools` (local UPM package)
- TMCP tools available for: Final IK, Cinemachine, Master Audio, Dialogue System, DOTween, Feel, Timeline, Animation Rigging, Text Animator

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
| Feel | Camera shake, screen FX | Recommended |
| Text Animator | Subtitles, titles | Recommended |
| Retarget Pro | Animation retargeting | Recommended |
| EditorSculpt | Viseme blendshape creation | Recommended |
| Boing Kit | Hair/accessory spring physics | Recommended |

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
| 100 | Timeflow Animation System | Conditional | Alternative animation sequencer. |

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
