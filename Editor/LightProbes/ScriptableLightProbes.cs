using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace NewBlood
{
    public sealed class ScriptableLightProbes : ScriptableObject
    {
        [SerializeField]
        LightProbesRoot m_Root = new LightProbesRoot();

        public LightProbeData data
        {
            get => m_Root.LightProbes.m_Data;
            set => m_Root.LightProbes.m_Data = value;
        }

        public SphericalHarmonicsL2[] bakedCoefficients
        {
            get => m_Root.LightProbes.m_BakedCoefficients;
            set => m_Root.LightProbes.m_BakedCoefficients = value;
        }

        public LightProbeOcclusion[] bakedLightOcclusion
        {
            get => m_Root.LightProbes.m_BakedLightOcclusion;
            set => m_Root.LightProbes.m_BakedLightOcclusion = value;
        }

        public void Read(LightProbes source)
        {
            var json = EditorJsonUtility.ToJson(source);
            EditorJsonUtility.FromJsonOverwrite(json, m_Root);
            EditorUtility.SetDirty(this);
        }

        public void Write(LightProbes destination)
        {
            var json = EditorJsonUtility.ToJson(m_Root);
            EditorJsonUtility.FromJsonOverwrite(json, destination);
            EditorUtility.SetDirty(destination);
        }

        public static LightProbes CreateAsset()
        {
            return ObjectFactoryInternal.CreateDefaultInstance<LightProbes>();
        }

        [Serializable]
        sealed class LightProbesRoot
        {
            public SerializedData LightProbes;

            [Serializable]
            public struct SerializedData
            {
                public LightProbeData m_Data;
                public SphericalHarmonicsL2[] m_BakedCoefficients;
                public LightProbeOcclusion[] m_BakedLightOcclusion;
            }
        }
    }
}
