using System;
using UnityEngine;

namespace NewBlood
{
    [Serializable]
    public struct ProbeSetIndex
    {
        [SerializeField]
        Hash128 m_Hash;

        [SerializeField]
        int m_Offset;

        [SerializeField]
        int m_Size;

        public Hash128 hash
        {
            get => m_Hash;
            set => m_Hash = value;
        }

        public int offset
        {
            get => m_Offset;
            set => m_Offset = value;
        }

        public int size
        {
            get => m_Size;
            set => m_Size = value;
        }
    }
}
