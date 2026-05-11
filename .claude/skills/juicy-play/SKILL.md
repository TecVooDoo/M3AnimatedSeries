---
name: juicy-play
description: |-
  Triggers execution of a Juicy Actions trigger on a GameObject at runtime.
  Finds all ActionOnEvent-derived triggers on the GameObject and fires the one at the
  specified index. Only works in play mode -- returns an error if the editor is not playing.
---

# Juicy Actions / Play Trigger

## How to Call

```bash
unity-mcp-cli run-tool juicy-play --input '{
  "gameObjectName": "string_value",
  "triggerIndex": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool juicy-play --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool juicy-play --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with Juicy Actions trigger components. |
| `triggerIndex` | `integer` | No | Zero-based index of which trigger to fire (default 0). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "triggerIndex": {
      "type": "integer"
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

