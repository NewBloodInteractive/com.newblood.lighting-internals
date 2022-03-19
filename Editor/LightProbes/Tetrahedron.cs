using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace NewBlood
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct Tetrahedron
    {
        [NonSerialized]
        [FieldOffset(0)]
        public fixed int indices[4];

        [SerializeField]
        [FieldOffset(0)]
        [MetadataName("indices[0]")]
        int indices0;

        [SerializeField]
        [FieldOffset(4)]
        [MetadataName("indices[1]")]
        int indices1;

        [SerializeField]
        [FieldOffset(8)]
        [MetadataName("indices[2]")]
        int indices2;

        [SerializeField]
        [FieldOffset(12)]
        [MetadataName("indices[3]")]
        int indices3;

        [NonSerialized]
        [FieldOffset(16)]
        public fixed int neighbors[4];

        [SerializeField]
        [FieldOffset(16)]
        [MetadataName("neighbors[0]")]
        int neighbors0;

        [SerializeField]
        [FieldOffset(20)]
        [MetadataName("neighbors[1]")]
        int neighbors1;

        [SerializeField]
        [FieldOffset(24)]
        [MetadataName("neighbors[2]")]
        int neighbors2;

        [SerializeField]
        [FieldOffset(28)]
        [MetadataName("neighbors[3]")]
        int neighbors3;

        [FieldOffset(32)]
        public Matrix3x4f matrix;

        [FieldOffset(80)]
        public bool isValid;
    }
}
