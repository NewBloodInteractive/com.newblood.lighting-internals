using System.Reflection;
using UnityEditor;

namespace NewBlood
{
    static class SerializedObjectUtility
    {
        static readonly PropertyInfo s_InspectorMode = typeof(SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);

        public static InspectorMode GetInspectorMode(SerializedObject serializedObject)
        {
            return (InspectorMode)(int)s_InspectorMode.GetValue(serializedObject);
        }

        public static void SetInspectorMode(SerializedObject serializedObject, InspectorMode inspectorMode)
        {
            s_InspectorMode.SetValue(serializedObject, (int)inspectorMode);
        }

        public static void CopySerialized(SerializedObject source, SerializedObject dest)
        {
            var iterator = source.GetIterator();

            while (iterator.Next(enterChildren: true))
            {
                var property = dest.FindProperty(iterator.propertyPath);

                if (property != null)
                {
                    CopySerialized(iterator, property);

                    if (property.isArray)
                    {
                        // If an array size changed, we need to apply that immediately.
                        dest.ApplyModifiedProperties();
                    }
                }
            }

            dest.ApplyModifiedProperties();
        }

        public static void CopySerialized(SerializedProperty source, SerializedProperty dest)
        {
            if (dest.isArray)
                dest.arraySize = source.arraySize;

            switch (dest.propertyType)
            {
            case SerializedPropertyType.String:
                dest.stringValue = source.stringValue;
                break;
            case SerializedPropertyType.LayerMask:
            case SerializedPropertyType.Integer:
            case SerializedPropertyType.Character:
            case SerializedPropertyType.Enum:
                dest.longValue = source.longValue;
                break;
            case SerializedPropertyType.Boolean:
                dest.boolValue = source.boolValue;
                break;
            case SerializedPropertyType.Float:
                dest.floatValue = source.floatValue;
                break;
            case SerializedPropertyType.Color:
                dest.colorValue = source.colorValue;
                break;
            case SerializedPropertyType.ObjectReference:
                dest.objectReferenceValue = source.objectReferenceValue;
                break;
            case SerializedPropertyType.Vector2:
                dest.vector2Value = source.vector2Value;
                break;
            case SerializedPropertyType.Vector3:
                dest.vector3Value = source.vector3Value;
                break;
            case SerializedPropertyType.Vector4:
                dest.vector4Value = source.vector4Value;
                break;
            case SerializedPropertyType.Rect:
                dest.rectValue = source.rectValue;
                break;
            case SerializedPropertyType.AnimationCurve:
                dest.animationCurveValue = source.animationCurveValue;
                break;
            case SerializedPropertyType.Bounds:
                dest.boundsValue = source.boundsValue;
                break;
        #if UNITY_2022_1_OR_NEWER
            case SerializedPropertyType.Gradient:
                dest.gradientValue = source.gradientValue;
                break;
        #endif
            case SerializedPropertyType.Quaternion:
                dest.quaternionValue = source.quaternionValue;
                break;
            case SerializedPropertyType.ExposedReference:
                dest.exposedReferenceValue = source.exposedReferenceValue;
                break;
            case SerializedPropertyType.Vector2Int:
                dest.vector2IntValue = source.vector2IntValue;
                break;
            case SerializedPropertyType.Vector3Int:
                dest.vector3IntValue = source.vector3IntValue;
                break;
            case SerializedPropertyType.RectInt:
                dest.rectIntValue = source.rectIntValue;
                break;
            case SerializedPropertyType.BoundsInt:
                dest.boundsIntValue = source.boundsIntValue;
                break;
            case SerializedPropertyType.Hash128:
                dest.hash128Value = source.hash128Value;
                break;
            }
        }
    }
}
