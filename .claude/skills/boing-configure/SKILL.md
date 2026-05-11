---
name: boing-configure
description: |-
  Configures a Boing Kit component on a GameObject. Specify the componentType and only the
  parameters you want to change -- all others remain untouched.
  componentType must be one of: Effector, Behavior, Bones, or ReactorField.
  For Effector: radius, fullEffectRadiusRatio, maxImpulseSpeed, continuousMotion, moveDistance, linearImpulse, rotationAngle, angularImpulse.
  For Behavior: enablePositionEffect, enableRotationEffect, enableScaleEffect.
  For ReactorField: cellSize, cellsX, cellsY, cellsZ, falloffMode, falloffRatio, enablePositionEffect, enableRotationEffect, enablePropagation.
---

# Boing Kit / Configure Component

## How to Call

```bash
unity-mcp-cli run-tool boing-configure --input '{
  "gameObjectName": "string_value",
  "componentType": "string_value",
  "radius": "string_value",
  "fullEffectRadiusRatio": "string_value",
  "maxImpulseSpeed": "string_value",
  "continuousMotion": "string_value",
  "moveDistance": "string_value",
  "linearImpulse": "string_value",
  "rotationAngle": "string_value",
  "angularImpulse": "string_value",
  "enablePositionEffect": "string_value",
  "enableRotationEffect": "string_value",
  "enableScaleEffect": "string_value",
  "cellSize": "string_value",
  "cellsX": "string_value",
  "cellsY": "string_value",
  "cellsZ": "string_value",
  "falloffMode": "string_value",
  "falloffRatio": "string_value",
  "enablePropagation": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool boing-configure --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool boing-configure --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with the Boing Kit component. |
| `componentType` | `string` | Yes | Component type to configure: Effector, Behavior, Bones, or ReactorField. |
| `radius` | `any` | No | (Effector) Effect radius. |
| `fullEffectRadiusRatio` | `any` | No | (Effector) Ratio of full effect within radius [0-1]. |
| `maxImpulseSpeed` | `any` | No | (Effector) Maximum impulse speed. |
| `continuousMotion` | `any` | No | (Effector) Enable continuous motion effect. |
| `moveDistance` | `any` | No | (Effector) Move distance for impulse. |
| `linearImpulse` | `any` | No | (Effector) Linear impulse strength. |
| `rotationAngle` | `any` | No | (Effector) Rotation angle for angular effect. |
| `angularImpulse` | `any` | No | (Effector) Angular impulse strength. |
| `enablePositionEffect` | `any` | No | (Behavior/ReactorField) Enable position effect. |
| `enableRotationEffect` | `any` | No | (Behavior/ReactorField) Enable rotation effect. |
| `enableScaleEffect` | `any` | No | (Behavior) Enable scale effect. |
| `cellSize` | `any` | No | (ReactorField) Size of each reactor cell. |
| `cellsX` | `any` | No | (ReactorField) Number of cells along the X axis. |
| `cellsY` | `any` | No | (ReactorField) Number of cells along the Y axis. |
| `cellsZ` | `any` | No | (ReactorField) Number of cells along the Z axis. |
| `falloffMode` | `string` | No | (ReactorField) Falloff mode (e.g. None, Linear, Quadratic). |
| `falloffRatio` | `any` | No | (ReactorField) Falloff ratio [0-1]. |
| `enablePropagation` | `any` | No | (ReactorField) Enable propagation of effects across cells. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "componentType": {
      "type": "string"
    },
    "radius": {
      "$ref": "#/$defs/System.Single"
    },
    "fullEffectRadiusRatio": {
      "$ref": "#/$defs/System.Single"
    },
    "maxImpulseSpeed": {
      "$ref": "#/$defs/System.Single"
    },
    "continuousMotion": {
      "$ref": "#/$defs/System.Boolean"
    },
    "moveDistance": {
      "$ref": "#/$defs/System.Single"
    },
    "linearImpulse": {
      "$ref": "#/$defs/System.Single"
    },
    "rotationAngle": {
      "$ref": "#/$defs/System.Single"
    },
    "angularImpulse": {
      "$ref": "#/$defs/System.Single"
    },
    "enablePositionEffect": {
      "$ref": "#/$defs/System.Boolean"
    },
    "enableRotationEffect": {
      "$ref": "#/$defs/System.Boolean"
    },
    "enableScaleEffect": {
      "$ref": "#/$defs/System.Boolean"
    },
    "cellSize": {
      "$ref": "#/$defs/System.Single"
    },
    "cellsX": {
      "$ref": "#/$defs/System.Int32"
    },
    "cellsY": {
      "$ref": "#/$defs/System.Int32"
    },
    "cellsZ": {
      "$ref": "#/$defs/System.Int32"
    },
    "falloffMode": {
      "type": "string"
    },
    "falloffRatio": {
      "$ref": "#/$defs/System.Single"
    },
    "enablePropagation": {
      "$ref": "#/$defs/System.Boolean"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    },
    "System.Boolean": {
      "type": "boolean"
    },
    "System.Int32": {
      "type": "integer"
    }
  },
  "required": [
    "gameObjectName",
    "componentType"
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

