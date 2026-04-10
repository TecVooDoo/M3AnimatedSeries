---
name: lipsync-query
description: |-
  Reports all uLipSync components on a GameObject hierarchy and their configuration.
  Checks for: uLipSync (analyzer), uLipSyncBlendShape, uLipSyncBakedDataPlayer,
  uLipSyncTimelineEvent, uLipSyncTexture, uLipSyncAnimator.
  Also lists available Profile and BakedData assets in the project.
---

# uLipSync / Query Components

## How to Call

```bash
unity-mcp-cli run-tool lipsync-query --input '{
  "gameObjectName": "string_value",
  "listAssets": false
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool lipsync-query --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool lipsync-query --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | No | Name of the GameObject to inspect. Searches entire hierarchy for uLipSync components. Leave empty to list available Profile/BakedData assets only. |
| `listAssets` | `boolean` | No | If true, also lists all Profile and BakedData assets in the project. Default: false. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "listAssets": {
      "type": "boolean"
    }
  }
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

