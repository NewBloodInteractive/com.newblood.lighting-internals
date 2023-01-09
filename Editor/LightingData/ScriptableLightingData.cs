using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Object = UnityEngine.Object;

namespace NewBlood
{
    public sealed partial class ScriptableLightingData : ScriptableObject
    {
        [SerializeField]
        LightingDataAssetRoot m_Root = new LightingDataAssetRoot();

        public int serializedVersion
        {
            get => m_Root.LightingDataAsset.serializedVersion;
            set => m_Root.LightingDataAsset.serializedVersion = value;
        }

        public SceneAsset scene
        {
            get => m_Root.LightingDataAsset.m_Scene;
            set => m_Root.LightingDataAsset.m_Scene = value;
        }

        public LightmapData[] lightmaps
        {
            get => m_Root.LightingDataAsset.m_Lightmaps;
            set => m_Root.LightingDataAsset.m_Lightmaps = value;
        }

        public Texture2D[] aoTextures
        {
            get => m_Root.LightingDataAsset.m_AOTextures;
            set => m_Root.LightingDataAsset.m_AOTextures = value;
        }

        public string[] lightmapsCacheFiles
        {
            get => m_Root.LightingDataAsset.m_LightmapsCacheFiles;
            set => m_Root.LightingDataAsset.m_LightmapsCacheFiles = value;
        }

        public LightProbes lightProbes
        {
            get => m_Root.LightingDataAsset.m_LightProbes;
            set => m_Root.LightingDataAsset.m_LightProbes = value;
        }

        public int lightmapsMode
        {
            get => m_Root.LightingDataAsset.m_LightmapsMode;
            set => m_Root.LightingDataAsset.m_LightmapsMode = value;
        }

        public SphericalHarmonicsL2 bakedAmbientProbeInLinear
        {
            get => m_Root.LightingDataAsset.m_BakedAmbientProbeInLinear;
            set => m_Root.LightingDataAsset.m_BakedAmbientProbeInLinear = value;
        }

        public RendererData[] lightmappedRendererData
        {
            get => m_Root.LightingDataAsset.m_LightmappedRendererData;
            set => m_Root.LightingDataAsset.m_LightmappedRendererData = value;
        }

        public SceneObjectIdentifier[] lightmappedRendererDataIDs
        {
            get => m_Root.LightingDataAsset.m_LightmappedRendererDataIDs;
            set => m_Root.LightingDataAsset.m_LightmappedRendererDataIDs = value;
        }

        public EnlightenSceneMapping enlightenSceneMapping
        {
            get => m_Root.LightingDataAsset.m_EnlightenSceneMapping;
            set => m_Root.LightingDataAsset.m_EnlightenSceneMapping = value;
        }

        public SceneObjectIdentifier[] enlightenSceneMappingRendererIDs
        {
            get => m_Root.LightingDataAsset.m_EnlightenSceneMappingRendererIDs;
            set => m_Root.LightingDataAsset.m_EnlightenSceneMappingRendererIDs = value;
        }

        public SceneObjectIdentifier[] lights
        {
            get => m_Root.LightingDataAsset.m_Lights;
            set => m_Root.LightingDataAsset.m_Lights = value;
        }

        public LightBakingOutput[] lightBakingOutputs
        {
            get => m_Root.LightingDataAsset.m_LightBakingOutputs;
            set => m_Root.LightingDataAsset.m_LightBakingOutputs = value;
        }

        public string[] bakedReflectionProbeCubemapCacheFiles
        {
            get => m_Root.LightingDataAsset.m_BakedReflectionProbeCubemapCacheFiles;
            set => m_Root.LightingDataAsset.m_BakedReflectionProbeCubemapCacheFiles = value;
        }

        public Texture[] bakedReflectionProbeCubemaps
        {
            get => m_Root.LightingDataAsset.m_BakedReflectionProbeCubemaps;
            set => m_Root.LightingDataAsset.m_BakedReflectionProbeCubemaps = value;
        }

        public SceneObjectIdentifier[] bakedReflectionProbes
        {
            get => m_Root.LightingDataAsset.m_BakedReflectionProbes;
            set => m_Root.LightingDataAsset.m_BakedReflectionProbes = value;
        }

        public byte[] enlightenData
        {
            get => m_Root.LightingDataAsset.m_EnlightenData;
            set => m_Root.LightingDataAsset.m_EnlightenData = value;
        }

        public int enlightenDataVersion
        {
            get => m_Root.LightingDataAsset.m_EnlightenDataVersion;
            set => m_Root.LightingDataAsset.m_EnlightenDataVersion = value;
        }

        public void Read(LightingDataAsset source)
        {
            var json = EditorJsonUtility.ToJson(source);
            EditorJsonUtility.FromJsonOverwrite(json, m_Root);
            EditorUtility.SetDirty(this);
        }

        public void Write(LightingDataAsset destination)
        {
            var json = EditorJsonUtility.ToJson(m_Root);
            EditorJsonUtility.FromJsonOverwrite(json, destination);
            EditorUtility.SetDirty(destination);
        }

        public void UpdateScene()
        {
            // Assign the lightmap settings values.
            LightmapSettings.lightmapsMode = (LightmapsMode)lightmapsMode;
            LightmapSettings.lightProbes   = lightProbes;
            
            // Build the lightmap texture array
            if (lightmaps == null)
                LightmapSettings.lightmaps = null;
            else
            {
                var lightmaps = new UnityEngine.LightmapData[this.lightmaps.Length];

                for (int i = 0; i < lightmaps.Length; i++)
                {
                    lightmaps[i] = new UnityEngine.LightmapData
                    {
                        lightmapColor = this.lightmaps[i].lightmap,
                        lightmapDir   = this.lightmaps[i].dirLightmap,
                        shadowMask    = this.lightmaps[i].shadowMask
                    };
                }

                LightmapSettings.lightmaps = lightmaps;
            }

            if (scene == null)
                return;

            if (lightBakingOutputs != null && lights != null)
            {
                var lights = new Light[this.lights.Length];
                SceneObjectIdentifier.SceneObjectIdentifiersToObjectsSlow(scene, this.lights, lights);

                for (int i = 0, n = Mathf.Min(lights.Length, lightBakingOutputs.Length); i < n; i++)
                {
                    var lightBakingOutput = lightBakingOutputs[i];

                    if (lights[i] == null)
                        continue;

                    lights[i].bakingOutput = new UnityEngine.LightBakingOutput
                    {
                        probeOcclusionLightIndex = lightBakingOutput.probeOcclusionLightIndex,
                        occlusionMaskChannel     = lightBakingOutput.occlusionMaskChannel,
                        lightmapBakeType         = (LightmapBakeType)lightBakingOutput.lightmapBakeMode.lightmapBakeType,
                        mixedLightingMode        = (MixedLightingMode)lightBakingOutput.lightmapBakeMode.mixedLightingMode,
                        isBaked                  = lightBakingOutput.isBaked,
                    };
                }
            }

            if (lightmappedRendererData != null && lightmappedRendererDataIDs != null)
            {
                var renderers = new Object[lightmappedRendererDataIDs.Length];
                SceneObjectIdentifier.SceneObjectIdentifiersToObjectsSlow(scene, lightmappedRendererDataIDs, renderers);

                for (int i = 0, n = Mathf.Min(renderers.Length, lightmappedRendererData.Length); i < n; i++)
                {
                    var rendererData = lightmappedRendererData[i];

                    if (renderers[i] is MeshRenderer renderer && renderer != null)
                    {
                        renderer.lightmapIndex               = rendererData.lightmapIndex;
                        renderer.realtimeLightmapIndex       = rendererData.lightmapIndexDynamic;
                        renderer.lightmapScaleOffset         = rendererData.lightmapST;
                        renderer.realtimeLightmapScaleOffset = rendererData.lightmapSTDynamic;
                        renderer.enlightenVertexStream       = rendererData.uvMesh;
                    }
                    else if (renderers[i] is Terrain terrain && terrain != null)
                    {
                        terrain.lightmapIndex               = rendererData.lightmapIndex;
                        terrain.realtimeLightmapIndex       = rendererData.lightmapIndexDynamic;
                        terrain.lightmapScaleOffset         = rendererData.lightmapST;
                        terrain.realtimeLightmapScaleOffset = rendererData.lightmapSTDynamic;

                        var root = new TerrainRoot
                        {
                            Terrain = new TerrainRoot.SerializedData
                            {
                                m_DynamicUVST          = rendererData.terrainDynamicUVST,
                                m_ChunkDynamicUVST     = rendererData.terrainChunkDynamicUVST,
                                m_ExplicitProbeSetHash = rendererData.explicitProbeSetHash
                            }
                        };

                        var json = EditorJsonUtility.ToJson(root);
                        EditorJsonUtility.FromJsonOverwrite(json, terrain);
                    }
                }
            }
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

        [Serializable]
        sealed class LightingDataAssetRoot
        {
            public SerializedData LightingDataAsset;

            [Serializable]
            public struct SerializedData
            {
                public int serializedVersion;
                public SceneAsset m_Scene;
                public LightmapData[] m_Lightmaps;
                public Texture2D[] m_AOTextures;
                public string[] m_LightmapsCacheFiles;
                public LightProbes m_LightProbes;
                public int m_LightmapsMode;
                public SphericalHarmonicsL2 m_BakedAmbientProbeInLinear;
                public RendererData[] m_LightmappedRendererData;
                public SceneObjectIdentifier[] m_LightmappedRendererDataIDs;
                public EnlightenSceneMapping m_EnlightenSceneMapping;
                public SceneObjectIdentifier[] m_EnlightenSceneMappingRendererIDs;
                public SceneObjectIdentifier[] m_Lights;
                public LightBakingOutput[] m_LightBakingOutputs;
                public string[] m_BakedReflectionProbeCubemapCacheFiles;
                public Texture[] m_BakedReflectionProbeCubemaps;
                public SceneObjectIdentifier[] m_BakedReflectionProbes;
                public byte[] m_EnlightenData;
                public int m_EnlightenDataVersion;
            }
        }

        [Serializable]
        sealed class TerrainRoot
        {
            public SerializedData Terrain;

            [Serializable]
            public struct SerializedData
            {
                public Vector4 m_DynamicUVST;
                public Vector4 m_ChunkDynamicUVST;
                public Hash128 m_ExplicitProbeSetHash;
            }
        }
    }
}
