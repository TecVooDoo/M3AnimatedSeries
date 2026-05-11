---
name: magica-add-wind
description: |-
  Creates a new GameObject with a MagicaWindZone component.
  Wind zones affect all MagicaCloth in the scene (GlobalDirection) or within an area.
  Modes: GlobalDirection (whole scene), SphereDirection, BoxDirection, SphereRadial.
---

# Magica Cloth / Add Wind Zone

## How to Call

```bash
unity-mcp-cli run-tool magica-add-wind --input '{
  "name": "string_value",
  "mode": "string_value",
  "strength": 0,
  "turbulence": 0,
  "directionAngleX": 0,
  "directionAngleY": 0,
  "radius": 0,
  "boxSize": "string_value",
  "position": "string_value",
  "parentGameObjectRef": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool magica-add-wind --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool magica-add-wind --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `name` | `string` | No | Name for the wind zone GameObject. Default 'MagicaWind'. |
| `mode` | `string` | No | Wind mode: 'GlobalDirection', 'SphereDirection', 'BoxDirection', 'SphereRadial'. Default 'GlobalDirection'. |
| `strength` | `number` | No | Wind strength in m/s (0-30). Default 5. |
| `turbulence` | `number` | No | Turbulence rate (0-1). Default 1. |
| `directionAngleX` | `number` | No | Wind direction X angle (-180 to 180). Default 0. |
| `directionAngleY` | `number` | No | Wind direction Y angle (-180 to 180). Default 0. |
| `radius` | `number` | No | Sphere radius (for sphere modes). Default 10. |
| `boxSize` | `any` | No | Box size (for BoxDirection). Default (10,10,10). |
| `position` | `any` | No | World position. Default (0,0,0). |
| `parentGameObjectRef` | `any` | No | Parent GameObject reference. Null for scene root. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "name": {
      "type": "string"
    },
    "mode": {
      "type": "string"
    },
    "strength": {
      "type": "number"
    },
    "turbulence": {
      "type": "number"
    },
    "directionAngleX": {
      "type": "number"
    },
    "directionAngleY": {
      "type": "number"
    },
    "radius": {
      "type": "number"
    },
    "boxSize": {
      "$ref": "#/$defs/UnityEngine.Vector3"
    },
    "position": {
      "$ref": "#/$defs/UnityEngine.Vector3"
    },
    "parentGameObjectRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    }
  },
  "$defs": {
    "UnityEngine.Vector3": {
      "type": "object",
      "properties": {
        "x": {
          "type": "number"
        },
        "y": {
          "type": "number"
        },
        "z": {
          "type": "number"
        }
      },
      "required": [
        "x",
        "y",
        "z"
      ],
      "additionalProperties": false
    },
    "System.Type": {
      "type": "string"
    },
    "com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef": {
      "type": "object",
      "properties": {
        "instanceID": {
          "type": "integer",
          "description": "instanceID of the UnityEngine.Object. If it is '0' and 'path', 'name', 'assetPath' and 'assetGuid' is not provided, empty or null, then it will be used as 'null'. Priority: 1 (Recommended)"
        },
        "path": {
          "type": "string",
          "description": "Path of a GameObject in the hierarchy Sample 'character/hand/finger/particle'. Priority: 2."
        },
        "name": {
          "type": "string",
          "description": "Name of a GameObject in hierarchy. Priority: 3."
        },
        "assetType": {
          "$ref": "#/$defs/System.Type",
          "description": "Type of the asset."
        },
        "assetPath": {
          "type": "string",
          "description": "Path to the asset within the project. Starts with 'Assets/'"
        },
        "assetGuid": {
          "type": "string",
          "description": "Unique identifier for the asset."
        }
      },
      "required": [
        "instanceID"
      ],
      "description": "Find GameObject in opened Prefab or in the active Scene."
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
      "$ref": "#/$defs/MCPTools.MagicaCloth2.Editor.Tool_MagicaCloth+AddWindResponse"
    }
  },
  "$defs": {
    "MCPTools.MagicaCloth2.Editor.Tool_MagicaCloth+AddWindResponse": {
      "type": "object",
      "properties": {
        "gameObjectName": {
          "type": "string",
          "description": "Name of the wind zone GameObject"
        },
        "instanceId": {
          "type": "integer",
          "description": "Instance ID"
        },
        "windMode": {
          "type": "string",
          "description": "Wind mode"
        },
        "strength": {
          "type": "number",
          "description": "Wind strength (m/s)"
        },
        "turbulence": {
          "type": "number",
          "description": "Turbulence rate"
        }
      },
      "required": [
        "instanceId",
        "strength",
        "turbulence"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

