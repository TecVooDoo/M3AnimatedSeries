using UnityEngine;

namespace M3.LipSync
{
    /// <summary>
    /// Mirrors left-side blendshapes to their right-side counterparts.
    /// Attach alongside uLipSyncBlendShape on the same GameObject.
    /// </summary>
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public sealed class LipSyncBlendShapeMirror : MonoBehaviour
    {
        [System.Serializable]
        public struct BlendShapePair
        {
            public int leftIndex;
            public int rightIndex;
        }

        [SerializeField] private SkinnedMeshRenderer targetMesh;
        [SerializeField] private BlendShapePair[] pairs = System.Array.Empty<BlendShapePair>();

        private void LateUpdate()
        {
            if (targetMesh == null) return;

            for (int i = 0; i < pairs.Length; i++)
            {
                float weight = targetMesh.GetBlendShapeWeight(pairs[i].leftIndex);
                targetMesh.SetBlendShapeWeight(pairs[i].rightIndex, weight);
            }
        }
    }
}
