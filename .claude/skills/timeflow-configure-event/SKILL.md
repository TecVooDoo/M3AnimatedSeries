---
name: timeflow-configure-event
description: |-
  Configures a TimeflowEvent behavior on a GameObject. The GO must have a TimeflowEvent component.
  TimeflowEvents trigger at a specific time during Timeflow playback.
  triggerTime: time in seconds when the event fires.
  targetName: name of the GameObject to send the message to.
  function: method name to call via SendMessage on the target.
  parameter: string parameter passed to the function.
  triggerLimit: max number of times to trigger (0 = unlimited).
  lockTime: prevent the trigger time from being changed in the editor.
  logEnabled: log trigger events to console.
---

# Timeflow / Configure Event

## How to Call

```bash
unity-mcp-cli run-tool timeflow-configure-event --input '{
  "gameObjectName": "string_value",
  "triggerTime": "string_value",
  "targetName": "string_value",
  "function": "string_value",
  "parameter": "string_value",
  "triggerLimit": "string_value",
  "lockTime": "string_value",
  "logEnabled": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool timeflow-configure-event --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool timeflow-configure-event --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with a TimeflowEvent component. |
| `triggerTime` | `any` | No | Time in seconds when the event fires. |
| `targetName` | `string` | No | Name of the target GameObject for SendMessage. |
| `function` | `string` | No | Method name to call on the target. |
| `parameter` | `string` | No | String parameter to pass to the function. |
| `triggerLimit` | `any` | No | Max trigger count (0 = unlimited). |
| `lockTime` | `any` | No | Lock trigger time in editor. |
| `logEnabled` | `any` | No | Log trigger events to console. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "triggerTime": {
      "$ref": "#/$defs/System.Single"
    },
    "targetName": {
      "type": "string"
    },
    "function": {
      "type": "string"
    },
    "parameter": {
      "type": "string"
    },
    "triggerLimit": {
      "$ref": "#/$defs/System.Int32"
    },
    "lockTime": {
      "$ref": "#/$defs/System.Boolean"
    },
    "logEnabled": {
      "$ref": "#/$defs/System.Boolean"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    },
    "System.Int32": {
      "type": "integer"
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

