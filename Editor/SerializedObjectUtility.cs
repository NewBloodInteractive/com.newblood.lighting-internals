using System.Reflection;
using UnityEditor;

namespace NewBlood
{
    static class SerializedObjectUtility
    {
        static readonly PropertyInfo s_InspectorMode = typeof(SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);

        public static void SetInspectorMode(SerializedObject serializedObject, InspectorMode inspectorMode)
        {
            s_InspectorMode.SetValue(serializedObject, (int)inspectorMode);
        }
    }
}
