using UnityEditor;

namespace NewBlood
{
    public struct EnlightenTerrainChunksInformation
    {
        public int firstSystemId { get; set; }

        public int numChunksInX { get; set; }

        public int numChunksInY { get; set; }

        internal static void Write(SerializedProperty property, EnlightenTerrainChunksInformation value)
        {
            property.FindPropertyRelative("firstSystemId").intValue = value.firstSystemId;
            property.FindPropertyRelative("numChunksInX").intValue  = value.numChunksInX;
            property.FindPropertyRelative("numChunksInY").intValue  = value.numChunksInY;
        }

        internal static EnlightenTerrainChunksInformation Read(SerializedProperty property)
        {
            return new EnlightenTerrainChunksInformation
            {
                firstSystemId = property.FindPropertyRelative("firstSystemId").intValue,
                numChunksInX  = property.FindPropertyRelative("numChunksInX").intValue,
                numChunksInY  = property.FindPropertyRelative("numChunksInY").intValue
            };
        }
    }
}
