using System;

namespace NewBlood
{
    public partial struct LightmappingAnalyticsData
    {
        [Serializable]
        public struct EnlightenInfo
        {
            public FinalGatherInfo finalGather;

            [Serializable]
            public struct FinalGatherInfo
            {
                public bool enabled;
                public int rayCount;
                public bool denoise;
            }
        }
    }
}
