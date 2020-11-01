using UnityEditor;
using UnityEngine;

namespace NewBlood
{
    public struct EnlightenRendererInformation
    {
        public Object renderer { get; set; }

        public Vector4 dynamicLightmapSTInSystem { get; set; }

        public int systemId { get; set; }

        public Hash128 instanceHash { get; set; }

        public Hash128 geometryHash { get; set; }

        internal static void Write(SerializedProperty property, EnlightenRendererInformation value)
        {
            property.FindPropertyRelative("renderer").objectReferenceValue          = value.renderer;
            property.FindPropertyRelative("dynamicLightmapSTInSystem").vector4Value = value.dynamicLightmapSTInSystem;
            property.FindPropertyRelative("systemId").intValue = value.systemId;
            SerializedPropertyUtility.WriteHash128(property.FindPropertyRelative("instanceHash"), value.instanceHash);
            SerializedPropertyUtility.WriteHash128(property.FindPropertyRelative("geometryHash"), value.geometryHash);
        }

        internal static EnlightenRendererInformation Read(SerializedProperty property)
        {
            return new EnlightenRendererInformation
            {
                renderer                  = property.FindPropertyRelative("renderer").objectReferenceValue,
                dynamicLightmapSTInSystem = property.FindPropertyRelative("dynamicLightmapSTInSystem").vector4Value,
                systemId                  = property.FindPropertyRelative("systemId").intValue,
                instanceHash              = SerializedPropertyUtility.ReadHash128(property.FindPropertyRelative("instanceHash")),
                geometryHash              = SerializedPropertyUtility.ReadHash128(property.FindPropertyRelative("geometryHash"))
            };
        }
    }
}
