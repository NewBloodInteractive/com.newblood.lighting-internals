using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using System.Runtime.InteropServices;

namespace NewBlood
{
    static class SerializedPropertyUtility
    {
        [StructLayout(LayoutKind.Explicit)]
        unsafe struct RawHash128
        {
            [FieldOffset(0)]
            public Hash128 Hash;

            [FieldOffset(0)]
            public fixed byte Bytes[16];
        }

        public unsafe static void WriteHash128(SerializedProperty property, Hash128 hash)
        {
            var raw = new RawHash128 { Hash = hash };
            property.FindPropertyRelative("bytes[0]").intValue  = raw.Bytes[0];
            property.FindPropertyRelative("bytes[1]").intValue  = raw.Bytes[1];
            property.FindPropertyRelative("bytes[2]").intValue  = raw.Bytes[2];
            property.FindPropertyRelative("bytes[3]").intValue  = raw.Bytes[3];
            property.FindPropertyRelative("bytes[4]").intValue  = raw.Bytes[4];
            property.FindPropertyRelative("bytes[5]").intValue  = raw.Bytes[5];
            property.FindPropertyRelative("bytes[6]").intValue  = raw.Bytes[6];
            property.FindPropertyRelative("bytes[7]").intValue  = raw.Bytes[7];
            property.FindPropertyRelative("bytes[8]").intValue  = raw.Bytes[8];
            property.FindPropertyRelative("bytes[9]").intValue  = raw.Bytes[9];
            property.FindPropertyRelative("bytes[10]").intValue = raw.Bytes[10];
            property.FindPropertyRelative("bytes[11]").intValue = raw.Bytes[11];
            property.FindPropertyRelative("bytes[12]").intValue = raw.Bytes[12];
            property.FindPropertyRelative("bytes[13]").intValue = raw.Bytes[13];
            property.FindPropertyRelative("bytes[14]").intValue = raw.Bytes[14];
            property.FindPropertyRelative("bytes[15]").intValue = raw.Bytes[15];
        }

        public unsafe static Hash128 ReadHash128(SerializedProperty property)
        {
            var raw = new RawHash128();
            raw.Bytes[ 0] = (byte)property.FindPropertyRelative("bytes[0]").intValue;
            raw.Bytes[ 1] = (byte)property.FindPropertyRelative("bytes[1]").intValue;
            raw.Bytes[ 2] = (byte)property.FindPropertyRelative("bytes[2]").intValue;
            raw.Bytes[ 3] = (byte)property.FindPropertyRelative("bytes[3]").intValue;
            raw.Bytes[ 4] = (byte)property.FindPropertyRelative("bytes[4]").intValue;
            raw.Bytes[ 5] = (byte)property.FindPropertyRelative("bytes[5]").intValue;
            raw.Bytes[ 6] = (byte)property.FindPropertyRelative("bytes[6]").intValue;
            raw.Bytes[ 7] = (byte)property.FindPropertyRelative("bytes[7]").intValue;
            raw.Bytes[ 8] = (byte)property.FindPropertyRelative("bytes[8]").intValue;
            raw.Bytes[ 9] = (byte)property.FindPropertyRelative("bytes[9]").intValue;
            raw.Bytes[10] = (byte)property.FindPropertyRelative("bytes[10]").intValue;
            raw.Bytes[11] = (byte)property.FindPropertyRelative("bytes[11]").intValue;
            raw.Bytes[12] = (byte)property.FindPropertyRelative("bytes[12]").intValue;
            raw.Bytes[13] = (byte)property.FindPropertyRelative("bytes[13]").intValue;
            raw.Bytes[14] = (byte)property.FindPropertyRelative("bytes[14]").intValue;
            raw.Bytes[15] = (byte)property.FindPropertyRelative("bytes[15]").intValue;
            return raw.Hash;
        }

        public static void WriteLightmapData(SerializedProperty property, LightmapData data)
        {
            property.FindPropertyRelative("m_Lightmap").objectReferenceValue    = data.lightmapColor;
            property.FindPropertyRelative("m_DirLightmap").objectReferenceValue = data.lightmapDir;
            property.FindPropertyRelative("m_ShadowMask").objectReferenceValue  = data.shadowMask;
        }

        public static LightmapData ReadLightmapData(SerializedProperty property)
        {
            return new LightmapData
            {
                lightmapColor = property.FindPropertyRelative("m_Lightmap").objectReferenceValue as Texture2D,
                lightmapDir   = property.FindPropertyRelative("m_DirLightmap").objectReferenceValue as Texture2D,
                shadowMask    = property.FindPropertyRelative("m_ShadowMask").objectReferenceValue as Texture2D,
            };
        }

        public static void WriteSphericalHarmonicsL2(SerializedProperty property, SphericalHarmonicsL2 probe)
        {
            property.FindPropertyRelative("sh[ 0]").floatValue = probe[0, 0];
            property.FindPropertyRelative("sh[ 1]").floatValue = probe[0, 1];
            property.FindPropertyRelative("sh[ 2]").floatValue = probe[0, 2];
            property.FindPropertyRelative("sh[ 3]").floatValue = probe[0, 3];
            property.FindPropertyRelative("sh[ 4]").floatValue = probe[0, 4];
            property.FindPropertyRelative("sh[ 5]").floatValue = probe[0, 5];
            property.FindPropertyRelative("sh[ 6]").floatValue = probe[0, 6];
            property.FindPropertyRelative("sh[ 7]").floatValue = probe[0, 7];
            property.FindPropertyRelative("sh[ 8]").floatValue = probe[0, 8];
            property.FindPropertyRelative("sh[ 9]").floatValue = probe[0, 9];
            property.FindPropertyRelative("sh[10]").floatValue = probe[0, 10];
            property.FindPropertyRelative("sh[11]").floatValue = probe[0, 11];
            property.FindPropertyRelative("sh[12]").floatValue = probe[0, 12];
            property.FindPropertyRelative("sh[13]").floatValue = probe[0, 13];
            property.FindPropertyRelative("sh[14]").floatValue = probe[0, 14];
            property.FindPropertyRelative("sh[15]").floatValue = probe[0, 15];
            property.FindPropertyRelative("sh[16]").floatValue = probe[0, 16];
            property.FindPropertyRelative("sh[17]").floatValue = probe[0, 17];
            property.FindPropertyRelative("sh[18]").floatValue = probe[0, 18];
            property.FindPropertyRelative("sh[19]").floatValue = probe[0, 19];
            property.FindPropertyRelative("sh[20]").floatValue = probe[0, 20];
            property.FindPropertyRelative("sh[21]").floatValue = probe[0, 21];
            property.FindPropertyRelative("sh[22]").floatValue = probe[0, 22];
            property.FindPropertyRelative("sh[23]").floatValue = probe[0, 23];
            property.FindPropertyRelative("sh[24]").floatValue = probe[0, 24];
            property.FindPropertyRelative("sh[25]").floatValue = probe[0, 25];
            property.FindPropertyRelative("sh[26]").floatValue = probe[0, 26];
        }

        public static SphericalHarmonicsL2 ReadSphericalHarmonicsL2(SerializedProperty property)
        {
            return new SphericalHarmonicsL2
            {
                [0,  0] = property.FindPropertyRelative("sh[ 0]").floatValue,
                [0,  1] = property.FindPropertyRelative("sh[ 1]").floatValue,
                [0,  2] = property.FindPropertyRelative("sh[ 2]").floatValue,
                [0,  3] = property.FindPropertyRelative("sh[ 3]").floatValue,
                [0,  4] = property.FindPropertyRelative("sh[ 4]").floatValue,
                [0,  5] = property.FindPropertyRelative("sh[ 5]").floatValue,
                [0,  6] = property.FindPropertyRelative("sh[ 6]").floatValue,
                [0,  7] = property.FindPropertyRelative("sh[ 7]").floatValue,
                [0,  8] = property.FindPropertyRelative("sh[ 8]").floatValue,
                [0,  9] = property.FindPropertyRelative("sh[ 9]").floatValue,
                [0, 10] = property.FindPropertyRelative("sh[10]").floatValue,
                [0, 11] = property.FindPropertyRelative("sh[11]").floatValue,
                [0, 12] = property.FindPropertyRelative("sh[12]").floatValue,
                [0, 13] = property.FindPropertyRelative("sh[13]").floatValue,
                [0, 14] = property.FindPropertyRelative("sh[14]").floatValue,
                [0, 15] = property.FindPropertyRelative("sh[15]").floatValue,
                [0, 16] = property.FindPropertyRelative("sh[16]").floatValue,
                [0, 17] = property.FindPropertyRelative("sh[17]").floatValue,
                [0, 18] = property.FindPropertyRelative("sh[18]").floatValue,
                [0, 19] = property.FindPropertyRelative("sh[19]").floatValue,
                [0, 20] = property.FindPropertyRelative("sh[20]").floatValue,
                [0, 21] = property.FindPropertyRelative("sh[21]").floatValue,
                [0, 22] = property.FindPropertyRelative("sh[22]").floatValue,
                [0, 23] = property.FindPropertyRelative("sh[23]").floatValue,
                [0, 24] = property.FindPropertyRelative("sh[24]").floatValue,
                [0, 25] = property.FindPropertyRelative("sh[25]").floatValue,
                [0, 26] = property.FindPropertyRelative("sh[26]").floatValue,
            };
        }

        public static void WriteLightBakingOutput(SerializedProperty property, LightBakingOutput output)
        {
            property.FindPropertyRelative("probeOcclusionLightIndex").intValue           = output.probeOcclusionLightIndex;
            property.FindPropertyRelative("occlusionMaskChannel").intValue               = output.occlusionMaskChannel;
            property.FindPropertyRelative("lightmapBakeMode.lightmapBakeType").intValue  = (int)output.lightmapBakeType;
            property.FindPropertyRelative("lightmapBakeMode.mixedLightingMode").intValue = (int)output.mixedLightingMode;
            property.FindPropertyRelative("isBaked").boolValue                           = output.isBaked;
        }

        public static LightBakingOutput ReadLightBakingOutput(SerializedProperty property)
        {
            return new LightBakingOutput
            {
                probeOcclusionLightIndex = property.FindPropertyRelative("probeOcclusionLightIndex").intValue,
                occlusionMaskChannel     = property.FindPropertyRelative("occlusionMaskChannel").intValue,
                lightmapBakeType         = (LightmapBakeType)property.FindPropertyRelative("lightmapBakeMode.lightmapBakeType").intValue,
                mixedLightingMode        = (MixedLightingMode)property.FindPropertyRelative("lightmapBakeMode.mixedLightingMode").intValue,
                isBaked                  = property.FindPropertyRelative("isBaked").boolValue
            };
        }

        public static T[] ReadArray<T>(SerializedProperty property, Func<SerializedProperty, T> reader)
        {
            var array = new T[property.arraySize];

            for (int i = 0; i < array.Length; i++)
                array[i] = reader.Invoke(property.GetArrayElementAtIndex(i));

            return array;
        }

        public static void WriteArray<T>(SerializedProperty property, Action<SerializedProperty, T> writer, T[] array)
        {
            property.arraySize = array.Length;

            for (int i = 0; i < array.Length; i++)
            {
                writer.Invoke(property.GetArrayElementAtIndex(i), array[i]);
            }

            property.serializedObject.ApplyModifiedProperties();
        }

        public static void WriteArrayAndApply<T>(SerializedProperty property, Action<SerializedProperty, T> writer, T[] array)
        {
            WriteArray(property, writer, array);
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}
