---
name: timeflow-control
description: |-
  Controls Timeflow playback on a GameObject.
  action options:
    Play -- start playback from current position.
    PlayFromStart -- start playback from StartTime.
    PlayReverse -- play in reverse.
    Stop -- stop playback.
    Pause -- pause playback (keeps current time).
    SetTime -- jump to a specific time (requires time parameter).
  time: target time in seconds (used with SetTime action, or to set before Play).
  timeScale: set GlobalTimeScale (playback speed multiplier).
  loop: enable or disable looping.
  Works in both edit mode and play mode (Timeflow uses ExecuteInEditMode).
---

# Timeflow / Playback Control

## How to Call

```bash
unity-mcp-cli run-tool timeflow-control --input '{
  "gameObjectName": "string_value",
  "action": "string_value",
  "time": "string_value",
  "timeScale": "string_value",
  "loop": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool timeflow-control --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool timeflow-control --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with the Timeflow component. |
| `action` | `string` | Yes | Action: Play, PlayFromStart, PlayReverse, Stop, Pause, or SetTime. |
| `time` | `any` | No | Target time in seconds (for SetTime action). |
| `timeScale` | `any` | No | Playback speed multiplier. |
| `loop` | `any` | No | Enable or disable looping. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "action": {
      "type": "string"
    },
    "time": {
      "$ref": "#/$defs/System.Single"
    },
    "timeScale": {
      "$ref": "#/$defs/System.Single"
    },
    "loop": {
      "$ref": "#/$defs/System.Boolean"
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
    "gameObjectName",
    "action"
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

