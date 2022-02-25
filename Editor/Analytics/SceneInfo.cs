using System;

namespace NewBlood
{
    public partial struct LightmappingAnalyticsData
    {
        [Serializable]
        public struct SceneInfo
        {
            public uint contributingInstanceCount;
            public uint meshCount;
            public ulong totalTriangleCount;
        }
    }
}
