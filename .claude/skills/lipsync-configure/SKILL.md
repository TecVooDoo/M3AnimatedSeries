---
name: lipsync-configure
description: |-
  Configures uLipSync components on a GameObject.
  Can set the Profile on the uLipSync analyzer, configure uLipSyncBlendShape mappings
  (phoneme-to-blendshape-index pairs), and adjust volume/smoothness parameters.
  For blendshape mappings, provide phonemes and blendShapeNames as comma-separated lists
  (e.g. phonemes='A,I,U,E,O' blendShapeNames='viseme_aa,viseme_ih,viseme_ou,viseme_E,viseme_oh').
---

# uLipSync / Configure Components

## How to Call

```bash
unity-mcp-cli run-tool lipsync-configure --input '{
  "gameObjectName": "string_value",
  "profileName": "string_value",
  "phonemes": "string_value",
  "blendShapeNames": "string_value",
  "skinnedMeshRendererName": "string_value",
  "minVolume": "string_value",
  "maxVolume": "string_value",
  "smoothness": "string_value",
  "usePhonemeBlend": "string_value",
  "playerVolume": "string_value",
  "timeOffset": "string_value",
  "outputSoundGain": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool lipsync-configure --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool lipsync-configure --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with uLipSync components. |
| `profileName` | `string` | No | Name of the Profile asset to assign to the uLipSync analyzer. Must match an existing Profile asset name. |
| `phonemes` | `string` | No | (BlendShape) Comma-separated phoneme names (e.g. 'A,I,U,E,O,N,-'). Must match phonemes in the Profile. |
| `blendShapeNames` | `string` | No | (BlendShape) Comma-separated blendshape names on the SkinnedMeshRenderer (e.g. 'viseme_aa,viseme_ih,viseme_ou,viseme_E,viseme_oh,viseme_nn,viseme_sil'). Must match count of phonemes. |
| `skinnedMeshRendererName` | `string` | No | (BlendShape) Name of the SkinnedMeshRenderer GameObject to target. If not set, uses the existing assignment. |
| `minVolume` | `any` | No | (BlendShape) Minimum volume threshold (log10). Default: -2.5 |
| `maxVolume` | `any` | No | (BlendShape) Maximum volume threshold (log10). Default: -1.5 |
| `smoothness` | `any` | No | (BlendShape) Mouth response smoothness [0-0.3]. Default: 0.05 |
| `usePhonemeBlend` | `any` | No | (BlendShape) Use phoneme blend mode (weighted blend vs winner-take-all). Default: false |
| `playerVolume` | `any` | No | (BakedDataPlayer) Volume [0-1]. Default: 1 |
| `timeOffset` | `any` | No | (BakedDataPlayer) Time offset in seconds [-0.3 to 0.3]. Positive = mouth opens earlier. Default: 0.1 |
| `outputSoundGain` | `any` | No | (Analyzer) Output sound gain [0-1]. Set to 0 to mute playback while analyzing. Default: 1 |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "profileName": {
      "type": "string"
    },
    "phonemes": {
      "type": "string"
    },
    "blendShapeNames": {
      "type": "string"
    },
    "skinnedMeshRendererName": {
      "type": "string"
    },
    "minVolume": {
      "$ref": "#/$defs/System.Single"
    },
    "maxVolume": {
      "$ref": "#/$defs/System.Single"
    },
    "smoothness": {
      "$ref": "#/$defs/System.Single"
    },
    "usePhonemeBlend": {
      "$ref": "#/$defs/System.Boolean"
    },
    "playerVolume": {
      "$ref": "#/$defs/System.Single"
    },
    "timeOffset": {
      "$ref": "#/$defs/System.Single"
    },
    "outputSoundGain": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    },
    "System.Boolean": {
      "type": "boolean"
    }
  },
  "required": [
    "gameObjectName"
  ]
}
```

## Output

### Output JSON Schema

```json
{
  "type": "object",
  "properties": {
    "result": {
      "type": "string"
    }
  },
  "required": [
    "result"
  ]
}
```

