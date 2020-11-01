using UnityEditor;
using UnityEngine;

namespace NewBlood
{
    public struct EnlightenSystemInformation
    {
        public uint rendererIndex { get; set; }

        public uint rendererSize { get; set; }

        public int atlasIndex { get; set; }

        public int atlasOffsetX { get; set; }

        public int atlasOffsetY { get; set; }

        public Hash128 inputSystemHash { get; set; }

        public Hash128 radiositySystemHash { get; set; }

        internal static void Write(SerializedProperty property, EnlightenSystemInformation value)
        {
            property.FindPropertyRelative("rendererIndex").intValue = (int)value.rendererIndex;
            property.FindPropertyRelative("rendererSize").intValue  = (int)value.rendererSize;
            property.FindPropertyRelative("atlasIndex").intValue    = value.atlasIndex;
            property.FindPropertyRelative("atlasOffsetX").intValue  = value.atlasOffsetX;
            property.FindPropertyRelative("atlasOffsetY").intValue  = value.atlasOffsetY;
            SerializedPropertyUtility.WriteHash128(property.FindPropertyRelative("inputSystemHash"), value.inputSystemHash);
            SerializedPropertyUtility.WriteHash128(property.FindPropertyRelative("radiositySystemHash"), value.radiositySystemHash);
        }

        internal static EnlightenSystemInformation Read(SerializedProperty property)
        {
            return new EnlightenSystemInformation
            {
                rendererIndex       = (uint)property.FindPropertyRelative("rendererIndex").intValue,
                rendererSize        = (uint)property.FindPropertyRelative("rendererSize").intValue,
                atlasIndex          = property.FindPropertyRelative("atlasIndex").intValue,
                atlasOffsetX        = property.FindPropertyRelative("atlasOffsetX").intValue,
                atlasOffsetY        = property.FindPropertyRelative("atlasOffsetY").intValue,
                inputSystemHash     = SerializedPropertyUtility.ReadHash128(property.FindPropertyRelative("inputSystemHash")),
                radiositySystemHash = SerializedPropertyUtility.ReadHash128(property.FindPropertyRelative("radiositySystemHash"))
            };
        }
    }
}
