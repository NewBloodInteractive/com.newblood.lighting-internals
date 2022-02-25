using System;

namespace NewBlood
{
    public partial struct LightmappingAnalyticsData
    {
        [Serializable]
        public struct LightsInfo
        {
            public string mixedBakeMode;
            public uint bakedLightCount;
            public uint mixedLightCount;
            public uint shadowCastingLightCount;
            public uint cookieLightCount;
            public uint uniqueCookieCount;
        }
    }
}
