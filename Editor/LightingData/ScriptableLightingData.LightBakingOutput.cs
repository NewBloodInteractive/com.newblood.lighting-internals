using System;
using UnityEngine;

namespace NewBlood
{
    public partial class ScriptableLightingData
    {
        [Serializable]
        public struct LightBakingOutput
        {
            public int probeOcclusionLightIndex;
            public int occlusionMaskChannel;
            public LightmapBakeMode lightmapBakeMode;
            public bool isBaked;

            [Serializable]
            public struct LightmapBakeMode
            {
                public LightmapBakeType lightmapBakeType;
                public MixedLightingMode mixedLightingMode;
            }
        }
    }
}
