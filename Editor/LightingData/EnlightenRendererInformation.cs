using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NewBlood
{
    [Serializable]
    public struct EnlightenRendererInformation
    {
        public Object renderer;
        public Vector4 dynamicLightmapSTInSystem;
        public int systemId;
        public Hash128 instanceHash;
        public Hash128 geometryHash;
    }
}
