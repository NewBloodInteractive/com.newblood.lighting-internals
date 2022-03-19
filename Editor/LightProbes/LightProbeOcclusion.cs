using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace NewBlood
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct LightProbeOcclusion
    {
        [NonSerialized]
        [FieldOffset(0)]
        public fixed int probeOcclusionLightIndex[4];

        [SerializeField]
        [FieldOffset(0)]
        fixed int m_ProbeOcclusionLightIndex[4];

        [NonSerialized]
        [FieldOffset(16)]
        public fixed float occlusion[4];

        [SerializeField]
        [FieldOffset(16)]
        fixed float m_Occlusion[4];

        [NonSerialized]
        [FieldOffset(32)]
        public fixed byte occlusionMaskChannel[4];

        [SerializeField]
        [FieldOffset(32)]
        fixed byte m_OcclusionMaskChannel[4];
    }
}
