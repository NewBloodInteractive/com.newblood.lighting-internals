using System;
using UnityEngine;

namespace NewBlood
{
    [Serializable]
    public struct EnlightenSystemInformation
    {
        public int rendererIndex;
        public int rendererSize;
        public int atlasIndex;
        public int atlasOffsetX;
        public int atlasOffsetY;
        public Hash128 inputSystemHash;
        public Hash128 radiositySystemHash;
    }
}
