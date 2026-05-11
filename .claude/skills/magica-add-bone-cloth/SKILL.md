---
name: magica-add-bone-cloth
description: |-
  Adds a MagicaCloth component configured as BoneCloth to a GameObject.
  BoneCloth simulates cloth using bone transforms — ideal for capes, hair, tails, skirts.
  Specify root bones that define the cloth chain.
---

# Magica Cloth / Add Bone Cloth

## How to Call

```bash
unity-mcp-cli run-tool magica-add-bone-cloth --input '{
  "targetRef": "string_value",
  "rootBoneNames": "string_value",
  "gravity": 0,
  "damping": 0,
  "radius": 0,
  "blendWeight": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool magica-add-bone-cloth --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool magica-add-bone-cloth --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `targetRef` | `any` | Yes | Reference to the target GameObject. |
| `rootBoneNames` | `any` | Yes | Names of root bone transforms (children of the target or its hierarchy). At least one required. |
| `gravity` | `number` | No | Gravity strength (0-10). Default 5. |
| `damping` | `number` | No | Damping (air resistance, 0-1). Default 0.05. |
| `radius` | `number` | No | Particle radius for collision. Default 0.02. |
| `blendWeight` | `number` | No | Blend weight between simulation and animation pose (0-1). Default 1 (full simulation). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "rootBoneNames": {
      "$ref": "#/$defs/System.String[]"
    },
    "gravity": {
      "type": "number"
    },
    "damping": {
      "type": "number"
    },
    "radius": {
      "type": "number"
    },
    "blendWeight": {
      "type": "number"
    }
  },
  "$defs": {
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
    },
    "System.String[]": {
      "type": "array",
      "items": {
        "type": "string"
      }
    }
  },
  "required": [
    "targetRef",
    "rootBoneNames"
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
      "$ref": "#/$defs/MCPTools.MagicaCloth2.Editor.Tool_MagicaCloth+AddClothResponse"
    }
  },
  "$defs": {
    "MCPTools.MagicaCloth2.Editor.Tool_MagicaCloth+AddClothResponse": {
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
        "clothType": {
          "type": "string",
          "description": "Cloth type configured"
        },
        "rootBonesFound": {
          "type": "string",
          "description": "Root bones or renderer found"
        },
        "gravity": {
          "type": "number",
          "description": "Gravity setting"
        }
      },
      "required": [
        "instanceId",
        "gravity"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

