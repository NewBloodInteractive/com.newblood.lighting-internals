using System;
using System.Reflection;
using UnityEditor;

namespace NewBlood
{
    public static class LightmappingInternal
    {
        static readonly object[] s_BakeAnalyticsParameters = new object[1];

        static readonly EventInfo s_BakeAnalytics = typeof(Lightmapping).GetEvent("bakeAnalytics", BindingFlags.NonPublic | BindingFlags.Static);

        public static bool bakeAnalyticsSupported => s_BakeAnalytics != null;

        public static event Action<string> bakeAnalytics
        {
            add
            {
                s_BakeAnalyticsParameters[0] = value;
                s_BakeAnalytics?.AddMethod?.Invoke(null, s_BakeAnalyticsParameters);
            }

            remove
            {
                s_BakeAnalyticsParameters[0] = value;
                s_BakeAnalytics?.RemoveMethod?.Invoke(null, s_BakeAnalyticsParameters);
            }
        }
    }
}
