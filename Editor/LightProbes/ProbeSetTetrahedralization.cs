using System;
using UnityEngine;

namespace NewBlood
{
    [Serializable]
    public sealed class ProbeSetTetrahedralization
    {
        [SerializeField]
        Tetrahedron[] m_Tetrahedra;

        [SerializeField]
        Vector3[] m_HullRays;

        public Tetrahedron[] tetrahedra
        {
            get => m_Tetrahedra;
            set => m_Tetrahedra = value;
        }

        public Vector3[] hullRays
        {
            get => m_HullRays;
            set => m_HullRays = value;
        }
    }
}
