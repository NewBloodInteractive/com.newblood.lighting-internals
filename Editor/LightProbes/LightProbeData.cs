using System;
using UnityEngine;

namespace NewBlood
{
    [Serializable]
    public sealed class LightProbeData
    {
        [SerializeField]
        ProbeSetTetrahedralization m_Tetrahedralization;

        [SerializeField]
        ProbeSetIndex[] m_ProbeSets;

        [SerializeField]
        bool[] m_DeringSettings;

        [SerializeField]
        Vector3[] m_Positions;

        [SerializeField]
        Pair<Hash128, int>[] m_NonTetrahedralizedProbeSetIndexMap;

        public ProbeSetTetrahedralization tetrahedralization
        {
            get => m_Tetrahedralization;
            set => m_Tetrahedralization = value;
        }

        public ProbeSetIndex[] probeSets
        {
            get => m_ProbeSets;
            set => m_ProbeSets = value;
        }

        public bool[] deringSettings
        {
            get => m_DeringSettings;
            set => m_DeringSettings = value;
        }

        public Vector3[] positions
        {
            get => m_Positions;
            set => m_Positions = value;
        }

        public Pair<Hash128, int>[] nonTetrahedralizedProbeSetIndexMap
        {
            get => m_NonTetrahedralizedProbeSetIndexMap;
            set => m_NonTetrahedralizedProbeSetIndexMap = value;
        }
    }
}
