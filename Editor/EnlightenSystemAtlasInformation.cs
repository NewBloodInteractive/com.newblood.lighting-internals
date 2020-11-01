using UnityEditor;
using UnityEngine;

namespace NewBlood
{
    public struct EnlightenSystemAtlasInformation
    {
        public int atlasSize { get; set; }

        public Hash128 atlasHash { get; set; }

        public int firstSystemId { get; set; }

        internal static void Write(SerializedProperty property, EnlightenSystemAtlasInformation value)
        {
            property.FindPropertyRelative("atlasSize").intValue = value.atlasSize;
            SerializedPropertyUtility.WriteHash128(property.FindPropertyRelative("atlasHash"), value.atlasHash);
            property.FindPropertyRelative("firstSystemId").intValue = value.firstSystemId;
        }

        internal static EnlightenSystemAtlasInformation Read(SerializedProperty property)
        {
            return new EnlightenSystemAtlasInformation
            {
                atlasSize     = property.FindPropertyRelative("atlasSize").intValue,
                atlasHash     = SerializedPropertyUtility.ReadHash128(property.FindPropertyRelative("atlasHash")),
                firstSystemId = property.FindPropertyRelative("firstSystemId").intValue
            };
        }
    }
}
