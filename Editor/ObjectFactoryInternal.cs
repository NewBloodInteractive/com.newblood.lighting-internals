using System;
using System.Reflection;
using UnityEditor;
using Object = UnityEngine.Object;

namespace NewBlood
{
    static class ObjectFactoryInternal
    {
        static readonly MethodInfo s_CreateDefaultInstance = typeof(ObjectFactory).GetMethod("CreateDefaultInstance", BindingFlags.NonPublic | BindingFlags.Static);

        static readonly Func<Type, Object> s_CreateDefaultInstanceFunc = (Func<Type, Object>)s_CreateDefaultInstance.CreateDelegate(typeof(Func<Type, Object>));

        public static Object CreateDefaultInstance(Type type)
        {
            return s_CreateDefaultInstanceFunc(type);
        }

        public static T CreateDefaultInstance<T>()
            where T : Object
        {
            return (T)s_CreateDefaultInstanceFunc(typeof(T));
        }
    }
}
