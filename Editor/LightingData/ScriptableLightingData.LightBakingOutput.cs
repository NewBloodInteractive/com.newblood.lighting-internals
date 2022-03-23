using System;

namespace NewBlood
{
    public partial class ScriptableLightingData
    {
        [Serializable]
        public struct LightBakingOutput
        {
            public int serializedVersion;
            public int probeOcclusionLightIndex;
            public int occlusionMaskChannel;
            public LightmapBakeMode lightmapBakeMode;
            public bool isBaked;

            [Serializable]
            public struct LightmapBakeMode
            {
                public int lightmapBakeType;
                public int mixedLightingMode;
            }
        }
    }
}
