using System;
using UnityEngine;

namespace NewBlood
{
    public partial class LightingData
    {
        [Serializable]
        public struct LightmapData
        {
            public Texture2D m_Lightmap;
            public Texture2D m_DirLightmap;
            public Texture2D m_ShadowMask;
        }
    }
}
