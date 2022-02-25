using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace NewBlood
{
    public sealed partial class LightingData : ScriptableObject
    {
        [SerializeField]
        SceneAsset m_Scene;

        [SerializeField]
        LightmapData[] m_Lightmaps;

        [SerializeField]
        Texture2D[] m_AOTextures;

        [SerializeField]
        string[] m_LightmapsCacheFiles;

        [SerializeField]
        LightProbes m_LightProbes;

        [SerializeField]
        int m_LightmapsMode;

        [SerializeField]
        SphericalHarmonicsL2 m_BakedAmbientProbeInLinear;

        [SerializeField]
        RendererData[] m_LightmappedRendererData;

        [SerializeField]
        SceneObjectIdentifier[] m_LightmappedRendererDataIDs;

        [SerializeField]
        EnlightenSceneMapping m_EnlightenSceneMapping;

        [SerializeField]
        SceneObjectIdentifier[] m_EnlightenSceneMappingRendererIDs;

        [SerializeField]
        SceneObjectIdentifier[] m_Lights;

        [SerializeField]
        LightBakingOutput[] m_LightBakingOutputs;

        [SerializeField]
        string[] m_BakedReflectionProbeCubemapCacheFiles;

        [SerializeField]
        Texture[] m_BakedReflectionProbeCubemaps;

        [SerializeField]
        SceneObjectIdentifier[] m_BakedReflectionProbes;

        [SerializeField]
        byte[] m_EnlightenData;

        [SerializeField]
        int m_EnlightenDataVersion;

        public SceneAsset scene
        {
            get => m_Scene;
            set => m_Scene = value;
        }

        public LightmapData[] lightmaps
        {
            get => m_Lightmaps;
            set => m_Lightmaps = value;
        }

        public Texture2D[] aoTextures
        {
            get => m_AOTextures;
            set => m_AOTextures = value;
        }

        public string[] lightmapsCacheFiles
        {
            get => m_LightmapsCacheFiles;
            set => m_LightmapsCacheFiles = value;
        }

        public LightProbes lightProbes
        {
            get => m_LightProbes;
            set => m_LightProbes = value;
        }

        public int lightmapsMode
        {
            get => m_LightmapsMode;
            set => m_LightmapsMode = value;
        }

        public SphericalHarmonicsL2 bakedAmbientProbeInLinear
        {
            get => m_BakedAmbientProbeInLinear;
            set => m_BakedAmbientProbeInLinear = value;
        }

        public RendererData[] lightmappedRendererData
        {
            get => m_LightmappedRendererData;
            set => m_LightmappedRendererData = value;
        }

        public SceneObjectIdentifier[] lightmappedRendererDataIDs
        {
            get => m_LightmappedRendererDataIDs;
            set => m_LightmappedRendererDataIDs = value;
        }

        public EnlightenSceneMapping enlightenSceneMapping
        {
            get => m_EnlightenSceneMapping;
            set => m_EnlightenSceneMapping = value;
        }

        public SceneObjectIdentifier[] enlightenSceneMappingRendererIDs
        {
            get => m_EnlightenSceneMappingRendererIDs;
            set => m_EnlightenSceneMappingRendererIDs = value;
        }

        public SceneObjectIdentifier[] lights
        {
            get => m_Lights;
            set => m_Lights = value;
        }

        public LightBakingOutput[] lightBakingOutputs
        {
            get => m_LightBakingOutputs;
            set => m_LightBakingOutputs = value;
        }

        public string[] bakedReflectionProbeCubemapCacheFiles
        {
            get => m_BakedReflectionProbeCubemapCacheFiles;
            set => m_BakedReflectionProbeCubemapCacheFiles = value;
        }

        public Texture[] bakedReflectionProbeCubemaps
        {
            get => m_BakedReflectionProbeCubemaps;
            set => m_BakedReflectionProbeCubemaps = value;
        }

        public SceneObjectIdentifier[] bakedReflectionProbes
        {
            get => m_BakedReflectionProbes;
            set => m_BakedReflectionProbes = value;
        }

        public byte[] enlightenData
        {
            get => m_EnlightenData;
            set => m_EnlightenData = value;
        }

        public int enlightenDataVersion
        {
            get => m_EnlightenDataVersion;
            set => m_EnlightenDataVersion = value;
        }

        public void Initialize(LightingDataAsset asset)
        {
            var source = new SerializedObject(asset);
            var dest   = new SerializedObject(this);
            SerializedObjectUtility.SetInspectorMode(source, InspectorMode.DebugInternal);
            SerializedObjectUtility.CopySerialized(source, dest);
        }

        public void Save(LightingDataAsset asset)
        {
            var source = new SerializedObject(this);
            var dest   = new SerializedObject(asset);
            SerializedObjectUtility.SetInspectorMode(dest, InspectorMode.DebugInternal);
            SerializedObjectUtility.CopySerialized(source, dest);
        }
    }
}
