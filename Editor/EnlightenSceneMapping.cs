using UnityEditor;
using UnityEngine;

namespace NewBlood
{
    public class EnlightenSceneMapping
    {
        public EnlightenRendererInformation[] renderers
        {
            get => SerializedPropertyUtility.ReadArray(m_Renderers, EnlightenRendererInformation.Read);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_Renderers, EnlightenRendererInformation.Write, value);
        }

        public EnlightenSystemInformation[] systems
        {
            get => SerializedPropertyUtility.ReadArray(m_Systems, EnlightenSystemInformation.Read);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_Systems, EnlightenSystemInformation.Write, value);
        }

        public Hash128[] probesets
        {
            get => SerializedPropertyUtility.ReadArray(m_Probesets, SerializedPropertyUtility.ReadHash128);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_Probesets, SerializedPropertyUtility.WriteHash128, value);
        }

        public EnlightenSystemAtlasInformation[] systemAtlases
        {
            get => SerializedPropertyUtility.ReadArray(m_SystemAtlases, EnlightenSystemAtlasInformation.Read);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_SystemAtlases, EnlightenSystemAtlasInformation.Write, value);
        }

        public EnlightenTerrainChunksInformation[] terrainChunks
        {
            get => SerializedPropertyUtility.ReadArray(m_TerrainChunks, EnlightenTerrainChunksInformation.Read);
            set => SerializedPropertyUtility.WriteArrayAndApply(m_TerrainChunks, EnlightenTerrainChunksInformation.Write, value);
        }

        internal EnlightenSceneMapping(SerializedProperty property)
        {
            m_Renderers     = property.FindPropertyRelative("m_Renderers");
            m_Systems       = property.FindPropertyRelative("m_Systems");
            m_Probesets     = property.FindPropertyRelative("m_Probesets");
            m_SystemAtlases = property.FindPropertyRelative("m_SystemAtlases");
            m_TerrainChunks = property.FindPropertyRelative("m_TerrainChunks");
        }

        internal static void Write(SerializedProperty property, EnlightenSceneMapping mapping)
        {
            SerializedPropertyUtility.WriteArrayAndApply(property.FindPropertyRelative("m_Renderers"), EnlightenRendererInformation.Write, mapping.renderers);
            SerializedPropertyUtility.WriteArrayAndApply(property.FindPropertyRelative("m_Systems"), EnlightenSystemInformation.Write, mapping.systems);
            SerializedPropertyUtility.WriteArrayAndApply(property.FindPropertyRelative("m_Probesets"), SerializedPropertyUtility.WriteHash128, mapping.probesets);
            SerializedPropertyUtility.WriteArrayAndApply(property.FindPropertyRelative("m_SystemAtlases"), EnlightenSystemAtlasInformation.Write, mapping.systemAtlases);
            SerializedPropertyUtility.WriteArrayAndApply(property.FindPropertyRelative("m_TerrainChunks"), EnlightenTerrainChunksInformation.Write, mapping.terrainChunks);
        }

        readonly SerializedProperty m_Renderers;

        readonly SerializedProperty m_Systems;

        readonly SerializedProperty m_Probesets;

        readonly SerializedProperty m_SystemAtlases;

        readonly SerializedProperty m_TerrainChunks;
    }
}
