using System;

namespace NewBlood
{
    public partial struct LightmappingAnalyticsData
    {
        [Serializable]
        public struct LightProbeInfo
        {
            public uint lightProbeGroupCount;
            public ulong lightProbeCount;
            public uint contributingLightProbeLitInstanceCount;
        }
    }
}
