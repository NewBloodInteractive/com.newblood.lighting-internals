using System;
using UnityEngine;

namespace NewBlood
{
    public partial class ScriptableLightingData
    {
        [Serializable]
        public struct RendererData
        {
            public Mesh uvMesh;
            public Vector4 terrainDynamicUVST;
            public Vector4 terrainChunkDynamicUVST;
            public Vector4 lightmapST;
            public Vector4 lightmapSTDynamic;
            public ushort lightmapIndex;
            public ushort lightmapIndexDynamic;
            public Hash128 explicitProbeSetHash;
        }
    }
}
