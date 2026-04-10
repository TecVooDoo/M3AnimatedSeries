# M3 Script Format Guide

**Purpose:** Defines the episode script format for Gemini output. Scripts drive the entire production pipeline -- they declare what assets are needed, not just what happens in the scene.
**Audience:** Gemini (script generation), Claude (Unity production), Human (review)
**Last Updated:** April 9, 2026

---

## Key Principle

**Nothing exists yet when the script is written.** No prefabs, no audio files, no animation clips, no props. The script is a production plan that:

1. Declares every asset needed (characters, props, audio, animations)
2. Uses consistent naming conventions so assets connect automatically when created
3. Provides enough detail for Claude to build the Unity scene without guessing

The script is the CONTRACT between writing (Gemini) and production (Claude in Unity).

---

## Naming Conventions

These conventions are locked. Every asset created downstream follows them.

### Voice Lines
```
Pattern: ep{E}_sc{S}_{character}_{NNN}.wav
Example: ep1_sc1_pandora_001.wav

E = episode number (no padding)
S = scene number (no padding)
character = lowercase character name
NNN = three-digit line number, sequential per character per scene
```

### Characters
```
Pattern: {CharacterName}
Example: Pandora, Siple, Luci, Eve

- Use the character's proper name exactly as written in the manuscript
- No suffixes, no variants -- one name per character across all episodes
- Costume/outfit variants noted in the CHARACTER REGISTRY, not the name
```

### Props
```
Pattern: prop_{descriptive_name}
Example: prop_apple, prop_eulogy_paper, prop_coffin

- Lowercase, underscores
- Descriptive enough to find or create
```

### Animation Intents
```
Pattern: {category}_{action}
Example: gesture_shrug, react_frustrated, locomotion_pace, interact_slam_table

Categories:
  idle_*        Standing, sitting, waiting (idle_crossed_arms, idle_hands_hips, idle_pose, idle_sigh)
  locomotion_*  Walk, run, pace, stumble, step, turn, lean (locomotion_pace, locomotion_run, locomotion_walk)
  gesture_*     Shrug, point, wave, nod, headshake (gesture_shrug, gesture_point, gesture_wave)
  react_*       Frustrated, surprised, scared, relieved, defeated, angry, smug (react_frustrated, react_defeated)
  interact_*    Slam table, pick up, grab, release, bite, drop (interact_grab, interact_release)
  combat_*      (future use)
  custom_*      Anything that needs to be authored in UMotion (custom_check_appearance)
```

These are INTENTS, not clip names. Claude maps intents to available clips (Mixamo, Kevin Iglesias, custom) during production. If no clip exists, the intent flags what needs to be created.

**Cost guidance:** Generic intents (`react_frustrated`, `gesture_nod`, `idle_crossed_arms`, `locomotion_walk`) are cheap -- clip libraries have these. Specific interactions (`interact_grab_throat`, `interact_shush`, `interact_poke`) require custom animation work. Use specific intents when the story demands it, but prefer generic intents for filler moments.

---

## Script Structure

### Episode Header (required, once per episode)

```
[EPISODE]
Number: 1
Title: The Vertex & The Funeral
Runtime: 10-12 min
Scenes: 3

[CHARACTERS]
| Name    | Description                            | Outfit       | Voice       |
|---------|----------------------------------------|--------------|-------------|
| Pandora | Frustrated scientist, lab coat         | lab_coat     | female_01   |
| Dad     | Pandora's father (voice only, intercom)| none         | male_01     |
| Iris    | AI assistant (voice only, ambient)     | none         | female_03   |
| Luci    | Imposing, beautiful but terrifying     | dark_formal  | male_02     |
| Eve     | Luci's companion, curious and timid    | simple_dress | female_02   |
| Siple   | Small thin blue Faelend creature       | faelend_blue | creature_01 |

[PROPS]
| Prop ID          | Description                     | Used In   | Interaction            |
|------------------|---------------------------------|-----------|------------------------|
| prop_apple       | A fresh apple                   | Scene 1   | Luci holds, Eve bites  |
| prop_mirror      | Wall or standing mirror         | Scene 1   | Pandora checks teeth   |
| prop_souvenir    | Unknown object held by Siple    | Scene 1   | Luci takes from Siple  |

[SETS]
| Scene | Set                              | Set ID | Reuse     |
|-------|----------------------------------|--------|-----------|
| 1     | The Vertex Lab                   | SET_A  | Recurring |
| 2     | Traditional Church Interior      | SET_B  | One-off   |
| 3     | Church Front Steps & Parking Lot | SET_C  | One-off   |

[VOICE LINE PATTERN]
ep1_sc{S}_{character}_{NNN}.wav
```

**Notes on the header:**
- `Outfit` is a tag, not a file path. Claude uses it to configure the Synty SidekickCharacter modular mesh.
- `Voice` is a profile tag. Claude creates one uLipSync Profile per voice, calibrated from sample audio. Multiple characters can share a profile if their voice is similar.
- Characters with `(voice only)` in their description have no on-screen prefab. Their audio plays from an intercom, ambient source, or is non-spatial.
- `Props` lists every interactable or notable object. Static set dressing (pews, monitors, etc.) is part of the set, not the script.
- `Sets` references the Set Directions document. Claude imports these from SetDesign.

---

### Scene Block

```
=== SCENE {N} ===
{INT/EXT}. {LOCATION} - {TIME}
SET: {Set name} ({Set ID})
CAST: {Character list with brief emotional state}
```

---

### Shots and Dialogue

Each shot is a continuous camera take. A new `[SHOT]` tag means a camera cut.

**CRITICAL RULE: One `[SHOT]` tag every 3-5 dialogue exchanges, or at every emotional shift.** A scene with 80 dialogue lines needs 20-30 shots, not 5. More cuts is always better than fewer -- Claude can combine shots in Timeline, but cannot split a single shot after the fact.

When in doubt about when to cut:
- New character speaks for the first time? New shot.
- Emotional tone changes? New shot.
- Character moves significantly? New shot.
- Important reaction? Close-up shot.
- 5 exchanges have passed? New shot.

---

### Tag Reference

#### Shot Tag
```
[SHOT {N} | {Type}, {Movement} | Subject: {who} | Duration: {seconds}]

Type:      Wide, Mid, Close-up, Extreme Close-up, Over-shoulder, POV, Two-Shot
Movement:  Static, Pan, Tilt, Track, Dolly, Handheld, Crane
Height:    (optional) Low, Eye, High, Bird -- defaults to Eye if omitted
Subject:   Who/what is in frame
Duration:  Approximate seconds (Claude adjusts to fit dialogue)
```

Optionally add a line of scene direction after the shot tag describing what the camera sees. This is not dialogue -- it's visual storytelling context.

#### Dialogue Line
```
CHARACTER_NAME                                       [VO: {filename_without_ext}]
[LOOK: {target}] [ANIM: {intent} | {description}]
Dialogue text here. Can be multiple lines.
Continues until next tag or character name.
```

- `[VO: ...]` -- Voice line filename (without extension). Follows naming convention. **Every spoken line MUST have a [VO:] tag.**
- `[LOOK: ...]` -- Who/what this character is looking at during this line. Maps to Final IK LookAtIK. **Include on every line.** Default is the person being addressed. Use object names (floor, ceiling, prop_apple, entryway) when looking elsewhere.
- `[ANIM: ...]` -- Animation intent during this line. On a dialogue line (under a speaker name), **omit the character name** -- it's already known from the speaker. Only include the character name on standalone `[ANIM:]` tags between dialogue blocks.
- `[GESTURE: ...]` -- Quick gesture layered on top (nod, headshake, shrug, point). Upper-body only. Same rule: **omit character name when under a speaker.**

**Inline vs Standalone tags:**
```
-- INLINE (under a speaker -- NO character name needed):
PANDORA                                              [VO: ep1_sc1_pandora_002]
[LOOK: ceiling] [ANIM: react_frustrated | sighs heavily]
Yes. Three times now.

-- STANDALONE (between dialogue blocks -- character name REQUIRED):
[ANIM: Pandora | locomotion_pace | pacing along frosted glass walls]
```

#### Beat Tag (REQUIRED for pacing)
```
[BEAT {N} | {timestamp}] {description}
```

Mark every major dramatic shift. Timestamps are approximate. Beats help Claude lay out the Timeline, identify music transition points, and flag scenes running long or short.

A typical 5-minute scene has 8-15 beats. Examples:
```
[BEAT 1 | 0:00] Cold open -- Pandora's experiment has failed
[BEAT 2 | 0:50] Dad's matchmaking attempt -- comedy beat
[BEAT 3 | 1:30] Dad's terrible joke -- tension relief
[BEAT 4 | 2:15] Iris announces Luci -- tone shifts to tension
[BEAT 5 | 2:30] Pandora's vanity moment -- she cares how she looks
[BEAT 6 | 2:50] Luci and Eve arrive -- power entrance
[BEAT 7 | 3:20] The flood reveal -- Luci's cruelty
[BEAT 8 | 3:55] Pandora breaks -- emotional low point
```

#### Music Tags (REQUIRED at every beat change)

Every `[BEAT]` should have a corresponding `[MUS:]` transition. If the emotional tone changes, the music changes.

```
[MUS: {id} | Fade: {in/out} {seconds}]

-- Fade out the previous cue, then fade in the new one:
[MUS: lab_comedy_light | Fade: out 2s]
[MUS: luci_tension_build | Fade: in 3s]
```

Music IDs are descriptive mood tags, not file paths:
- `lab_ambient_tension` -- not "track_04.wav"
- `luci_tension_build` -- not "scary_music.mp3"

Claude maps these to sourced music tracks or flags them as needed.

#### SFX and Ambience Tags
```
[SFX: {id} | Source: {object or character} | {Spatial/Global}]
[AMB: {id} | Loop | Volume: {low/med/high}]
```

- `SFX` = one-shot sound effect. `Source` is the scene object it originates from. `Spatial` = 3D positioned; `Global` = non-directional.
- `AMB` = ambient loop. Plays continuously until scene ends or a new `[AMB:]` replaces it.

For voice-only characters (Dad, Iris), use `Global` for the source since they come from an intercom/AI system, not a point in the room.

#### Prop Interaction Tag
```
[PROP: {Character} | {prop_id} | {action}]

Examples:
[PROP: Eve | prop_apple | holding in right hand]
[PROP: Eve | prop_apple | bites]
[PROP: Luci | prop_apple | holding (revealed from prop_souvenir)]
```

Maps to IK hand targets and prop attachment bones on the Synty skeleton. Note prop transfers between characters explicitly -- Claude needs to know when a prop changes hands.

#### Transition Tag
```
[TRANSITION: {type} | Duration: {seconds}]

Types: Cut, Fade to Black, Fade from Black, Cross Dissolve, Wipe
```

**Required at the end of every scene.** Default between scenes if omitted: Cut.

---

## Scene Asset Manifest

Every scene should end with an asset manifest block. This is the production checklist that Claude uses to track what needs to be created.

```
=== SCENE {N} ASSET MANIFEST ===

**Voice Lines: {total} total**
- {Character}: {count} lines (ep1_sc1_{char}_001 through _{NNN})
- ...

**Shots: {total}**

**Animation Intents (unique): {count}**
| Intent | Category | Clip Likelihood | Notes |
|--------|----------|----------------|-------|
| react_frustrated | React | HIGH | Mixamo/generic |
| interact_grab_throat | Interact | LOW | Custom needed |
| custom_check_appearance | Custom | NONE | UMotion authoring |
| ...

**SFX: {count} unique**
- {id} (x{uses} uses)
- ...

**Ambience: {count}**
- {id}

**Music Cues: {count}**
- {id} ({when used})
- ...

**Props: {count}**
- {prop_id} ({description, who interacts})
- ...
```

Clip Likelihood values:
- **HIGH** -- Common animation, clip libraries will have this (idle, walk, run, nod, shrug, wave, basic reactions)
- **MEDIUM** -- Exists in some libraries, may need retargeting or adjustment
- **LOW** -- Specific interaction, likely needs custom animation work
- **NONE** -- Must be authored from scratch in UMotion

---

## What Gemini Does NOT Need to Specify

- **Unity component values** -- no FOV numbers, no Vector3 positions, no volume floats. Use descriptive terms (Wide/Close, low/high, left/right).
- **Specific animation clip names or file paths** -- use intents. Claude maps to available clips.
- **Blendshape or facial expression details** -- uLipSync handles mouth; Claude layers emotion from context.
- **Render settings, post-processing, lighting values** -- per-set art direction, handled in SetDesign or by Claude.
- **Technical Unity terminology** -- keep the script readable by humans.

---

## Workflow Summary

```
1. Human provides manuscript chapter to Gemini
2. Gemini outputs script in THIS format (header + scenes + asset manifests)
3. Human reviews script for story accuracy
4. Claude reads script and generates:
   a. Validates asset manifest (checks for missing VO tags, untagged lines, etc.)
   b. Scene structure (Timeline layout from beats and shots)
   c. Camera list (Cinemachine setup from shot tags)
   d. Voice line recording checklist (from VO tags)
   e. Animation sourcing checklist (from ANIM/GESTURE intents)
5. Assets are created/sourced:
   - Voice lines recorded or TTS generated
   - Animation clips sourced from libraries or authored in UMotion
   - Props modeled or sourced from Synty packs
   - Sets imported from SetDesign
6. Claude assembles the episode in Unity:
   - Import set from SetDesign
   - Place and configure character prefabs (Synty SidekickCharacters)
   - Batch-bake voice lines to uLipSync BakedData (lipsync-bake tool)
   - Create Timeline with:
     - Camera cuts (Cinemachine tracks from shot tags)
     - Animation clips (Animancer playback from intents)
     - Lip sync (uLipSync Timeline tracks from BakedData)
     - Audio (Master Audio groups from SFX/AMB/MUS tags)
     - IK targets (Final IK look-at from LOOK tags)
   - Render final output
```

---

## Reference

A complete example script (Episode 1, Scene 1 -- 65 shots, 82 voice lines, 13 beats) is available at:
`Documents/M3_Episode1_Script.md`

Use this as the gold standard for format, density, and tag coverage.

---

**End of Document**
