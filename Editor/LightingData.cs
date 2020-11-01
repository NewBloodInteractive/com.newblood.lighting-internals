using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace NewBlood
{
    public class LightingData
    {
        public SceneAsset scene
        {
            get => m_Scene.objectReferenceValue as SceneAsset;
            set { m_Scene.objectReferenceValue = value; m_Object.ApplyModifiedProperties(); }
        }

        public LightmapData[] lightmaps
        {
            get => SerializedPropertyUtility.ReadArray(m_Lightmaps, SerializedPropertyUtility.ReadLightmapData);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_Lightmaps, SerializedPropertyUtility.WriteLightmapData, value);
        }

        public Texture2D[] aoTextures
        {
            get => SerializedPropertyUtility.ReadArray(m_AOTextures, property => property.objectReferenceValue as Texture2D);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_AOTextures, (property, value) => property.objectReferenceValue = value, value);
        }

        public string[] lightmapsCacheFiles
        {
            get => SerializedPropertyUtility.ReadArray(m_LightmapsCacheFiles, property => property.stringValue);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_LightmapsCacheFiles, (property, value) => property.stringValue = value, value);
        }

        public LightProbes lightProbes
        {
            get => m_LightProbes.objectReferenceValue as LightProbes;
            set { m_LightProbes.objectReferenceValue = value; m_Object.ApplyModifiedProperties(); }
        }

        public LightmapsMode lightmapsMode
        {
            get => (LightmapsMode)m_LightmapsMode.intValue;
            set { m_LightmapsMode.intValue = (int)value; m_Object.ApplyModifiedProperties(); }
        }

        public SphericalHarmonicsL2 bakedAmbientProbeInLinear
        {
            get => SerializedPropertyUtility.ReadSphericalHarmonicsL2(m_BakedAmbientProbeInLinear);
            set { SerializedPropertyUtility.WriteSphericalHarmonicsL2(m_BakedAmbientProbeInLinear, value); m_Object.ApplyModifiedProperties(); }
        }

        public RendererData lightmappedRendererData
        {
            get => RendererData.Read(m_LightmappedRendererData);
            set { RendererData.Write(m_LightmappedRendererData, value); m_Object.ApplyModifiedProperties(); }
        }

        public SceneObjectIdentifier[] lightmappedRendererDataIDs
        {
            get => SerializedPropertyUtility.ReadArray(m_LightmappedRendererDataIDs, SceneObjectIdentifier.Read);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_LightmappedRendererDataIDs, SceneObjectIdentifier.Write, value);
        }

        public EnlightenSceneMapping enlightenSceneMapping
        {
            get => new EnlightenSceneMapping(m_EnlightenSceneMapping);
            set { EnlightenSceneMapping.Write(m_EnlightenSceneMapping, value); m_Object.ApplyModifiedProperties(); }
        }

        public SceneObjectIdentifier[] enlightenSceneMappingRendererIDs
        {
            get => SerializedPropertyUtility.ReadArray(m_EnlightenSceneMappingRendererIDs, SceneObjectIdentifier.Read);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_EnlightenSceneMappingRendererIDs, SceneObjectIdentifier.Write, value);
        }

        public SceneObjectIdentifier[] lights
        {
            get => SerializedPropertyUtility.ReadArray(m_Lights, SceneObjectIdentifier.Read);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_Lights, SceneObjectIdentifier.Write, value);
        }

        public LightBakingOutput[] lightBakingOutputs
        {
            get => SerializedPropertyUtility.ReadArray(m_LightBakingOutputs, SerializedPropertyUtility.ReadLightBakingOutput);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_LightBakingOutputs, SerializedPropertyUtility.WriteLightBakingOutput, value);
        }

        public string[] bakedReflectionProbeCubemapCacheFiles
        {
            get => SerializedPropertyUtility.ReadArray(m_BakedReflectionProbeCubemapCacheFiles, property => property.stringValue);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_BakedReflectionProbeCubemapCacheFiles, (property, value) => property.stringValue = value, value);
        }

        public Texture[] bakedReflectionProbeCubemaps
        {
            get => SerializedPropertyUtility.ReadArray(m_BakedReflectionProbeCubemaps, property => property.objectReferenceValue as Texture);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_BakedReflectionProbeCubemaps, (property, value) => property.objectReferenceValue = value, value);
        }

        public SceneObjectIdentifier[] bakedReflectionProbes
        {
            get => SerializedPropertyUtility.ReadArray(m_BakedReflectionProbes, SceneObjectIdentifier.Read);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_BakedReflectionProbes, SceneObjectIdentifier.Write, value);
        }

        public byte[] enlightenData
        {
            get => SerializedPropertyUtility.ReadArray(m_EnlightenData, property => (byte)property.intValue);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_EnlightenData, (property, value) => property.intValue = value, value);
        }

        public int enlightenDataVersion
        {
            get => m_EnlightenDataVersion.intValue;
            set { m_EnlightenDataVersion.intValue = value; m_Object.ApplyModifiedProperties(); }
        }

        public LightingData(LightingDataAsset asset)
        {
            if (asset == null)
                throw new ArgumentNullException(nameof(asset));

            m_Object = new SerializedObject(asset);

            // Changing inspectorMode to DebugInternal allows us to see inaccessible values in LightingDataAsset.
            SerializedObjectUtility.SetInspectorMode(m_Object, InspectorMode.DebugInternal);

            m_Scene                                 = m_Object.FindProperty("m_Scene");
            m_Lightmaps                             = m_Object.FindProperty("m_Lightmaps");
            m_AOTextures                            = m_Object.FindProperty("m_AOTextures");
            m_LightmapsCacheFiles                   = m_Object.FindProperty("m_LightmapsCacheFiles");
            m_LightProbes                           = m_Object.FindProperty("m_LightProbes");
            m_LightmapsMode                         = m_Object.FindProperty("m_LightmapsMode");
            m_BakedAmbientProbeInLinear             = m_Object.FindProperty("m_BakedAmbientProbeInLinear");
            m_LightmappedRendererData               = m_Object.FindProperty("m_LightmappedRendererData");
            m_LightmappedRendererDataIDs            = m_Object.FindProperty("m_LightmappedRendererDataIDs");
            m_EnlightenSceneMapping                 = m_Object.FindProperty("m_EnlightenSceneMapping");
            m_EnlightenSceneMappingRendererIDs      = m_Object.FindProperty("m_EnlightenSceneMappingRendererIDs");
            m_Lights                                = m_Object.FindProperty("m_Lights");
            m_LightBakingOutputs                    = m_Object.FindProperty("m_LightBakingOutputs");
            m_BakedReflectionProbeCubemapCacheFiles = m_Object.FindProperty("m_BakedReflectionProbeCubemapCacheFiles");
            m_BakedReflectionProbeCubemaps          = m_Object.FindProperty("m_BakedReflectionProbeCubemaps");
            m_BakedReflectionProbes                 = m_Object.FindProperty("m_BakedReflectionProbes");
            m_EnlightenData                         = m_Object.FindProperty("m_EnlightenData");
            m_EnlightenDataVersion                  = m_Object.FindProperty("m_EnlightenDataVersion");
        }

        readonly SerializedObject m_Object;

        readonly SerializedProperty m_Scene;

        readonly SerializedProperty m_Lightmaps;

        readonly SerializedProperty m_AOTextures;

        readonly SerializedProperty m_LightmapsCacheFiles;

        readonly SerializedProperty m_LightProbes;

        readonly SerializedProperty m_LightmapsMode;

        readonly SerializedProperty m_BakedAmbientProbeInLinear;

        readonly SerializedProperty m_LightmappedRendererData;

        readonly SerializedProperty m_LightmappedRendererDataIDs;

        readonly SerializedProperty m_EnlightenSceneMapping;

        readonly SerializedProperty m_EnlightenSceneMappingRendererIDs;

        readonly SerializedProperty m_Lights;

        readonly SerializedProperty m_LightBakingOutputs;

        readonly SerializedProperty m_BakedReflectionProbeCubemapCacheFiles;

        readonly SerializedProperty m_BakedReflectionProbeCubemaps;

        readonly SerializedProperty m_BakedReflectionProbes;

        readonly SerializedProperty m_EnlightenData;

        readonly SerializedProperty m_EnlightenDataVersion;
    }
}
