---
name: timeflow-configure-tween
description: |-
  Configures a Tween behavior on a GameObject. The GO must have a Tween component.
  All parameters optional except gameObjectName -- only provided values change.
  interpolation: None, Linear, EaseIn, EaseOut, EaseInOut, EaseInExpo, EaseOutExpo, EaseInOutExpo,
    EaseInCircle, EaseOutCircle, EaseInOutCircle, AnimationCurve, Switch.
  repeatMode: Forever, Every, None.
  minValue/maxValue: animation range (float). For vector tweens use minX/minY/minZ/maxX/maxY/maxZ.
  amount: effect strength multiplier [0-1+].
  pingPong: alternate direction each cycle.
  Use timeflow-query first to see what behaviors exist on the GameObject.
---

# Timeflow / Configure Tween

## How to Call

```bash
unity-mcp-cli run-tool timeflow-configure-tween --input '{
  "gameObjectName": "string_value",
  "interpolation": "string_value",
  "repeatMode": "string_value",
  "minValue": "string_value",
  "maxValue": "string_value",
  "minX": "string_value",
  "minY": "string_value",
  "minZ": "string_value",
  "maxX": "string_value",
  "maxY": "string_value",
  "maxZ": "string_value",
  "amount": "string_value",
  "pingPong": "string_value",
  "invertInterpolation": "string_value",
  "allowTrigger": "string_value",
  "triggerIsToggle": "string_value",
  "timeOffset": "string_value",
  "timeScale": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool timeflow-configure-tween --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool timeflow-configure-tween --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with a Tween component. |
| `interpolation` | `string` | No | Easing mode: None, Linear, EaseIn, EaseOut, EaseInOut, EaseInExpo, EaseOutExpo, EaseInOutExpo, EaseInCircle, EaseOutCircle, EaseInOutCircle, AnimationCurve, Switch. |
| `repeatMode` | `string` | No | Repeat mode: Forever, Every, None. |
| `minValue` | `any` | No | Min float value for tween range. |
| `maxValue` | `any` | No | Max float value for tween range. |
| `minX` | `any` | No | Min X component for vector tweens. |
| `minY` | `any` | No | Min Y component for vector tweens. |
| `minZ` | `any` | No | Min Z component for vector tweens. |
| `maxX` | `any` | No | Max X component for vector tweens. |
| `maxY` | `any` | No | Max Y component for vector tweens. |
| `maxZ` | `any` | No | Max Z component for vector tweens. |
| `amount` | `any` | No | Effect strength multiplier. |
| `pingPong` | `any` | No | Alternate direction each cycle. |
| `invertInterpolation` | `any` | No | Invert the interpolation curve. |
| `allowTrigger` | `any` | No | Allow external triggering. |
| `triggerIsToggle` | `any` | No | Toggle mode for triggers. |
| `timeOffset` | `any` | No | Time offset in seconds. |
| `timeScale` | `any` | No | Time scale multiplier. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "interpolation": {
      "type": "string"
    },
    "repeatMode": {
      "type": "string"
    },
    "minValue": {
      "$ref": "#/$defs/System.Single"
    },
    "maxValue": {
      "$ref": "#/$defs/System.Single"
    },
    "minX": {
      "$ref": "#/$defs/System.Single"
    },
    "minY": {
      "$ref": "#/$defs/System.Single"
    },
    "minZ": {
      "$ref": "#/$defs/System.Single"
    },
    "maxX": {
      "$ref": "#/$defs/System.Single"
    },
    "maxY": {
      "$ref": "#/$defs/System.Single"
    },
    "maxZ": {
      "$ref": "#/$defs/System.Single"
    },
    "amount": {
      "$ref": "#/$defs/System.Single"
    },
    "pingPong": {
      "$ref": "#/$defs/System.Boolean"
    },
    "invertInterpolation": {
      "$ref": "#/$defs/System.Boolean"
    },
    "allowTrigger": {
      "$ref": "#/$defs/System.Boolean"
    },
    "triggerIsToggle": {
      "$ref": "#/$defs/System.Boolean"
    },
    "timeOffset": {
      "$ref": "#/$defs/System.Single"
    },
    "timeScale": {
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

