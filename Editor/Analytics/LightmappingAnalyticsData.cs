using System;

namespace NewBlood
{
    [Serializable]
    public partial struct LightmappingAnalyticsData
    {
        public bool autoGenerate;
        public string bakeBackend;
        public bool computeRealtime;
        public bool computeBaked;
        public float indirectResolution;
        public float lightmapResolution;
        public AmbientOcclusionInfo ambientOcclusion;
        public int lightmapCompression;
        public int lightmapSize;
        public EnlightenInfo enlighten;
        public ProgressiveLightmapperInfo progressive;
        public LightmapInfo lightmaps;
        public SceneInfo scene;
        public LightsInfo lights;
        public LightProbeInfo lightProbes;
        public MemoryInfo memory;
        public string outcome;
        public string fallback;
        public string sourceView;
    }
}
