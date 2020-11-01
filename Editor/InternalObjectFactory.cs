using System;
using System.Reflection;
using UnityEditor;
using Object = UnityEngine.Object;

namespace NewBlood
{
    static class InternalObjectFactory
    {
        static readonly Func<Type, Object> s_CreateDefaultInstance = (Func<Type, Object>)typeof(ObjectFactory)
            .GetMethod("CreateDefaultInstance", BindingFlags.NonPublic | BindingFlags.Static)
            .CreateDelegate(typeof(Func<Type, Object>));

        public static Object CreateDefaultInstance(Type type)
        {
            return s_CreateDefaultInstance(type);
        }

        public static T CreateDefaultInstance<T>()
            where T : Object
        {
            return (T)s_CreateDefaultInstance(typeof(T));
        }
    }
}
