using System;

namespace NewBlood
{
    public partial struct LightmappingAnalyticsData
    {
        [Serializable]
        public struct ProgressiveLightmapperInfo
        {
            public int directSamples;
            public int indirectSamples;
            public int bounces;
            public bool prioritizeView;
            public int minBounces;
        }
    }
}
