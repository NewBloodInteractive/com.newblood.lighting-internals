using System;
using UnityEngine;

namespace NewBlood
{
    [Serializable]
    public sealed class EnlightenSceneMapping
    {
        [SerializeField]
        EnlightenRendererInformation[] m_Renderers;

        [SerializeField]
        EnlightenSystemInformation[] m_Systems;

        [SerializeField]
        Hash128[] m_Probesets;

        [SerializeField]
        EnlightenSystemAtlasInformation[] m_SystemAtlases;

        [SerializeField]
        EnlightenTerrainChunksInformation[] m_TerrainChunks;

        public EnlightenRendererInformation[] renderers
        {
            get => m_Renderers;
            set => m_Renderers = value;
        }

        public EnlightenSystemInformation[] systems
        {
            get => m_Systems;
            set => m_Systems = value;
        }

        public Hash128[] probesets
        {
            get => m_Probesets;
            set => m_Probesets = value;
        }

        public EnlightenSystemAtlasInformation[] systemAtlases
        {
            get => m_SystemAtlases;
            set => m_SystemAtlases = value;
        }

        public EnlightenTerrainChunksInformation[] terrainChunks
        {
            get => m_TerrainChunks;
            set => m_TerrainChunks = value;
        }
    }
}
