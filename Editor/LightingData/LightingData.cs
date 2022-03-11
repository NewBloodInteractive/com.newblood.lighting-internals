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
            EditorUtility.SetDirty(this);
        }

        public void Save(LightingDataAsset asset)
        {
            var source = new SerializedObject(this);
            var dest   = new SerializedObject(asset);
            SerializedObjectUtility.SetInspectorMode(dest, InspectorMode.DebugInternal);
            SerializedObjectUtility.CopySerialized(source, dest);
            EditorUtility.SetDirty(asset);
        }

        public void UpdateScene()
        {
            var lights    = new Light[m_Lights.Length];
            var renderers = new Object[m_LightmappedRendererDataIDs.Length];
            SceneObjectIdentifier.SceneObjectIdentifiersToObjectsSlow(m_Scene, m_Lights, lights);
            SceneObjectIdentifier.SceneObjectIdentifiersToObjectsSlow(m_Scene, m_LightmappedRendererDataIDs, renderers);

            for (int i = 0; i < m_LightBakingOutputs.Length; i++)
            {
                var lightBakingOutput  = m_LightBakingOutputs[i];
                lights[i].bakingOutput = new UnityEngine.LightBakingOutput
                {
                    probeOcclusionLightIndex = lightBakingOutput.probeOcclusionLightIndex,
                    occlusionMaskChannel     = lightBakingOutput.occlusionMaskChannel,
                    lightmapBakeType         = lightBakingOutput.lightmapBakeMode.lightmapBakeType,
                    mixedLightingMode        = lightBakingOutput.lightmapBakeMode.mixedLightingMode,
                    isBaked                  = lightBakingOutput.isBaked,
                };
            }

            for (int i = 0; i < renderers.Length; i++)
            {
                var rendererData = m_LightmappedRendererData[i];

                if (renderers[i] is MeshRenderer)
                {
                    var renderer                         = (MeshRenderer)renderers[i];
                    renderer.lightmapIndex               = rendererData.lightmapIndex;
                    renderer.realtimeLightmapIndex       = rendererData.lightmapIndexDynamic;
                    renderer.lightmapScaleOffset         = rendererData.lightmapST;
                    renderer.realtimeLightmapScaleOffset = rendererData.lightmapSTDynamic;
                    renderer.enlightenVertexStream       = rendererData.uvMesh;
                }
                else if (renderers[i] is Terrain)
                {
                    var terrain                         = (Terrain)renderers[i];
                    terrain.lightmapIndex               = rendererData.lightmapIndex;
                    terrain.realtimeLightmapIndex       = rendererData.lightmapIndexDynamic;
                    terrain.lightmapScaleOffset         = rendererData.lightmapST;
                    terrain.realtimeLightmapScaleOffset = rendererData.lightmapSTDynamic;

                    // These values aren't exposed publicly on the Terrain class.
                    var serializedObject = new SerializedObject(terrain);

                    // Ensure the SerializedObject is in DebugInternal mode.
                    SerializedObjectUtility.SetInspectorMode(serializedObject, InspectorMode.DebugInternal);

                    // TODO: It might be better to use EditorJsonUtility to assign "hidden" values for backcompat.
                    var dynamicUVST          = serializedObject.FindProperty("m_DynamicUVST");
                    var chunkDynamicUVST     = serializedObject.FindProperty("m_ChunkDynamicUVST");
                    var explicitProbeSetHash = serializedObject.FindProperty("m_ExplicitProbeSetHash");

                    // Now we can actually assign the values.
                    dynamicUVST.vector4Value          = rendererData.terrainDynamicUVST;
                    chunkDynamicUVST.vector4Value     = rendererData.terrainChunkDynamicUVST;
                    explicitProbeSetHash.hash128Value = rendererData.explicitProbeSetHash;
                    serializedObject.ApplyModifiedPropertiesWithoutUndo();
                }
            }

            // Build the lightmap texture array
            var lightmaps = new UnityEngine.LightmapData[m_Lightmaps.Length];
            
            for (int i = 0; i < lightmaps.Length; i++)
            {
                lightmaps[i] = new UnityEngine.LightmapData
                {
                    lightmapColor = m_Lightmaps[i].lightmap,
                    lightmapDir   = m_Lightmaps[i].dirLightmap,
                    shadowMask    = m_Lightmaps[i].shadowMask
                };
            }

            // Assign the lightmap settings values.
            LightmapSettings.lightmapsMode = (LightmapsMode)m_LightmapsMode;
            LightmapSettings.lightProbes   = m_LightProbes;
            LightmapSettings.lightmaps     = lightmaps;
        }

        public static LightingDataAsset CreateAsset()
        {
            // Unfortunately, ObjectFactory.CreateDefaultInstance is not public, so we need to reflect into it.
            var asset = ObjectFactoryInternal.CreateDefaultInstance<LightingDataAsset>();

            // We have to use FromJsonOverwrite instead of SerializedObject, because the latter will call the
            // native LightingDataAsset::CheckConsistency method, which will check the enlighten data version
            // and produce a warning if it does not match the expected value.
            EditorJsonUtility.FromJsonOverwrite("{ \"LightingDataAsset\": { \"m_EnlightenDataVersion\": 112 } }", asset);
            return asset;
        }
    }
}
