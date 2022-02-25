using System;

namespace NewBlood
{
    public partial struct LightmappingAnalyticsData
    {
        [Serializable]
        public struct LightmapInfo
        {
            public ulong occupiedTexels;
            public uint lightmapCount;
        }
    }
}
