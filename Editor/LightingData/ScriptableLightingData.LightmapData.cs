using System;
using UnityEngine;

namespace NewBlood
{
    public partial class ScriptableLightingData
    {
        [Serializable]
        public struct LightmapData
        {
            [SerializeField]
            Texture2D m_Lightmap;

            [SerializeField]
            Texture2D m_DirLightmap;

            [SerializeField]
            Texture2D m_ShadowMask;

            public Texture2D lightmap
            {
                get => m_Lightmap;
                set => m_Lightmap = value;
            }

            public Texture2D dirLightmap
            {
                get => m_DirLightmap;
                set => m_DirLightmap = value;
            }

            public Texture2D shadowMask
            {
                get => m_ShadowMask;
                set => m_ShadowMask = value;
            }
        }
    }
}
