---
name: magica-list-cloth
description: Lists all MagicaCloth components in the current scene with their type and configuration.
---

# Magica Cloth / List Cloth in Scene

## How to Call

```bash
unity-mcp-cli run-tool magica-list-cloth --input '{}'
```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

This tool takes no input parameters.

### Input JSON Schema

```json
{
  "type": "object",
  "additionalProperties": false
}
```

## Output

### Output JSON Schema

```json
{
  "type": "object",
  "properties": {
    "result": {
      "$ref": "#/$defs/MCPTools.MagicaCloth2.Editor.Tool_MagicaCloth+ListClothResponse"
    }
  },
  "$defs": {
    "MCPTools.MagicaCloth2.Editor.Tool_MagicaCloth+ListClothResponse": {
      "type": "object",
      "properties": {
        "count": {
          "type": "integer",
          "description": "Number of MagicaCloth components found"
        },
        "details": {
          "type": "string",
          "description": "Details of each cloth component"
        }
      },
      "required": [
        "count"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

