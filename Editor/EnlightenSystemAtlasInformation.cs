using System;
using UnityEngine;

namespace NewBlood
{
    [Serializable]
    public struct EnlightenSystemAtlasInformation
    {
        public int atlasSize;
        public Hash128 atlasHash;
        public int firstSystemId;
    }
}
