---
name: magica-add-capsule-collider
description: |-
  Adds a MagicaCapsuleCollider to a GameObject (typically a bone).
  Capsule colliders are best for limbs (arms, legs, torso).
  Direction sets the capsule axis: X, Y, or Z.
---

# Magica Cloth / Add Capsule Collider

## How to Call

```bash
unity-mcp-cli run-tool magica-add-capsule-collider --input '{
  "targetRef": "string_value",
  "startRadius": 0,
  "endRadius": 0,
  "length": 0,
  "direction": "string_value",
  "center": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool magica-add-capsule-collider --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool magica-add-capsule-collider --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `targetRef` | `any` | Yes | Reference to the target GameObject (usually a bone). |
| `startRadius` | `number` | No | Start radius of the capsule. Default 0.05. |
| `endRadius` | `number` | No | End radius of the capsule. Default 0.05. |
| `length` | `number` | No | Length of the capsule. Default 0.2. |
| `direction` | `string` | No | Capsule direction axis: 'X', 'Y', or 'Z'. Default 'X'. |
| `center` | `any` | No | Local center offset. Default (0,0,0). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/AIGD.GameObjectRef"
    },
    "startRadius": {
      "type": "number"
    },
    "endRadius": {
      "type": "number"
    },
    "length": {
      "type": "number"
    },
    "direction": {
      "type": "string"
    },
    "center": {
      "$ref": "#/$defs/UnityEngine.Vector3"
    }
  },
  "$defs": {
    "System.Type": {
      "type": "string"
    },
    "AIGD.GameObjectRef": {
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
    },
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
    }
  },
  "required": [
    "targetRef"
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
      "$ref": "#/$defs/MCPTools.MagicaCloth2.Editor.Tool_MagicaCloth+AddColliderResponse"
    }
  },
  "$defs": {
    "MCPTools.MagicaCloth2.Editor.Tool_MagicaCloth+AddColliderResponse": {
      "type": "object",
      "properties": {
        "gameObjectName": {
          "type": "string",
          "description": "Name of the GameObject"
        },
        "instanceId": {
          "type": "integer",
          "description": "Instance ID"
        },
        "colliderType": {
          "type": "string",
          "description": "Collider type added"
        },
        "size": {
          "type": "string",
          "description": "Collider size"
        }
      },
      "required": [
        "instanceId"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

