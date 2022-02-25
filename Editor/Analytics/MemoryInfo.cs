using System;

namespace NewBlood
{
    public partial struct LightmappingAnalyticsData
    {
        [Serializable]
        public struct MemoryInfo
        {
            public uint maxTilingModeDuringBake;
        }
    }
}
