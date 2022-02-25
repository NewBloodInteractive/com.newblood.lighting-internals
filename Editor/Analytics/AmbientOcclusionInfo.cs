using System;

namespace NewBlood
{
    public partial struct LightmappingAnalyticsData
    {
        [Serializable]
        public struct AmbientOcclusionInfo
        {
            public bool enabled;
            public float maxDistance;
        }
    }
}
