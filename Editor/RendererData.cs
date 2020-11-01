using UnityEngine;
using UnityEditor;

namespace NewBlood
{
    public class RendererData
    {
        public Mesh uvMesh { get; set; }

        public Vector4 terrainDynamicUVST { get; set; }

        public Vector4 terrainChunkDynamicUVST { get; set; }

        public ushort lightmapIndex { get; set; }

        public ushort lightmapIndexDynamic { get; set; }

        public Vector4 lightmapST { get; set; }

        public Vector4 lightmapSTDynamic { get; set; }

        public Hash128 explicitProbeSetHash { get; set; }

        internal static void Write(SerializedProperty property, RendererData value)
        {
            property.FindPropertyRelative("uvMesh").objectReferenceValue          = value.uvMesh;
            property.FindPropertyRelative("terrainDynamicUVST").vector4Value      = value.terrainDynamicUVST;
            property.FindPropertyRelative("terrainChunkDynamicUVST").vector4Value = value.terrainChunkDynamicUVST;
            property.FindPropertyRelative("lightmapIndex").intValue               = value.lightmapIndex;
            property.FindPropertyRelative("lightmapIndexDynamic").intValue        = value.lightmapIndexDynamic;
            property.FindPropertyRelative("lightmapST").vector4Value              = value.lightmapST;
            property.FindPropertyRelative("lightmapSTDynamic").vector4Value       = value.lightmapSTDynamic;
            SerializedPropertyUtility.WriteHash128(property.FindPropertyRelative("explicitProbeSetHash"), value.explicitProbeSetHash);
        }

        internal static RendererData Read(SerializedProperty property)
        {
            return new RendererData
            {
                uvMesh                  = property.FindPropertyRelative("uvMesh").objectReferenceValue as Mesh,
                terrainDynamicUVST      = property.FindPropertyRelative("terrainDynamicUVST").vector4Value,
                terrainChunkDynamicUVST = property.FindPropertyRelative("terrainChunkDynamicUVST").vector4Value,
                lightmapIndex           = (ushort)property.FindPropertyRelative("lightmapIndex").intValue,
                lightmapIndexDynamic    = (ushort)property.FindPropertyRelative("lightmapIndexDynamic").intValue,
                lightmapST              = property.FindPropertyRelative("lightmapST").vector4Value,
                lightmapSTDynamic       = property.FindPropertyRelative("lightmapSTDynamic").vector4Value,
                explicitProbeSetHash    = SerializedPropertyUtility.ReadHash128(property.FindPropertyRelative("explicitProbeSetHash"))
            };
        }
    }
}
