---
name: lipsync-bake
description: |-
  Bakes AudioClip(s) into uLipSync BakedData assets using a calibrated Profile.
  Can bake a single clip by name, or batch-bake all AudioClips in a directory.
  The output BakedData assets can be used with uLipSyncBakedDataPlayer or Timeline tracks.
  This is the MCP equivalent of Window > uLipSync > Baked Data Generator.
---

# uLipSync / Bake AudioClips to BakedData

## How to Call

```bash
unity-mcp-cli run-tool lipsync-bake --input '{
  "profileName": "string_value",
  "audioClipName": "string_value",
  "inputDirectory": "string_value",
  "outputDirectory": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool lipsync-bake --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool lipsync-bake --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `profileName` | `string` | Yes | Name of the Profile asset to use for baking. Must be a calibrated Profile. |
| `audioClipName` | `string` | No | Name of a single AudioClip asset to bake. Mutually exclusive with inputDirectory. |
| `inputDirectory` | `string` | No | Asset directory path containing AudioClips to batch-bake (e.g. 'Assets/_M3/Audio/Voice/Episode1'). Mutually exclusive with audioClipName. |
| `outputDirectory` | `string` | No | Asset directory path for output BakedData assets (e.g. 'Assets/_M3/Audio/BakedData'). Created if it doesn't exist. Default: same directory as input clip(s). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "profileName": {
      "type": "string"
    },
    "audioClipName": {
      "type": "string"
    },
    "inputDirectory": {
      "type": "string"
    },
    "outputDirectory": {
      "type": "string"
    }
  },
  "required": [
    "profileName"
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

