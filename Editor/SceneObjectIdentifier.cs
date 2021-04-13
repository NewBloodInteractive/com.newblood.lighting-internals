using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace NewBlood
{
    public struct SceneObjectIdentifier : IEquatable<SceneObjectIdentifier>
    {
        public ulong targetObject { get; set; }

        public ulong targetPrefab { get; set; }

        public bool Equals(SceneObjectIdentifier other)
        {
            return targetObject == other.targetObject && targetPrefab == other.targetPrefab;
        }

        public static SceneObjectIdentifier FromGlobalObjectId(GlobalObjectId id)
        {
            return new SceneObjectIdentifier
            {
                targetObject = id.targetObjectId,
                targetPrefab = id.targetPrefabId
            };
        }

        public static SceneObjectIdentifier GetSceneObjectIdentifierSlow(Object targetObject)
        {
            return FromGlobalObjectId(GlobalObjectId.GetGlobalObjectIdSlow(targetObject));
        }

        public static void GetSceneObjectIdentifiersSlow(Object[] objects, SceneObjectIdentifier[] outputIdentifiers)
        {
            var globalIds = new GlobalObjectId[outputIdentifiers.Length];
            GlobalObjectId.GetGlobalObjectIdsSlow(objects, globalIds);

            for (int i = 0; i < objects.Length; i++)
                outputIdentifiers[i] = FromGlobalObjectId(globalIds[i]);
        }

        public static void SceneObjectIdentifiersToObjectsSlow(Scene scene, SceneObjectIdentifier[] identifiers, Object[] outputObjects)
        {
            var objects = GetSceneObjects(scene);
            var ids     = new SceneObjectIdentifier[objects.Length];
            GetSceneObjectIdentifiersSlow(objects, ids);
            
            for (int i = 0; i < identifiers.Length; i++)
            {
                for (int j = 0; j < objects.Length; j++)
                {
                    if (identifiers[i].Equals(ids[j]))
                    {
                        outputObjects[i] = objects[j];
                        break;
                    }
                }
            }
        }

        public static Object SceneObjectIdentifierToObjectSlow(Scene scene, SceneObjectIdentifier id)
        {
            var objects = GetSceneObjects(scene);
            var ids     = new SceneObjectIdentifier[objects.Length];
            GetSceneObjectIdentifiersSlow(objects, ids);

            for (int i = 0; i < objects.Length; i++)
            {
                if (ids[i].Equals(id))
                    return objects[i];
            }

            return null;
        }

    #if UNITY_2020_1_OR_NEWER
        public static SceneObjectIdentifier GetSceneObjectIdentifierSlow(int instanceId)
        {
            return FromGlobalObjectId(GlobalObjectId.GetGlobalObjectIdSlow(instanceId));
        }

        public static void GetSceneObjectIdentifiersSlow(int[] instanceIds, SceneObjectIdentifier[] outputIdentifiers)
        {
            var globalIds = new GlobalObjectId[outputIdentifiers.Length];
            GlobalObjectId.GetGlobalObjectIdsSlow(instanceIds, globalIds);

            for (int i = 0; i < instanceIds.Length; i++)
                outputIdentifiers[i] = FromGlobalObjectId(globalIds[i]);
        }

        public static void SceneObjectIdentifiersToInstanceIDsSlow(Scene scene, SceneObjectIdentifier[] identifiers, int[] outputInstanceIDs)
        {
            var objects = GetSceneObjects(scene);
            var ids     = new SceneObjectIdentifier[objects.Length];
            GetSceneObjectIdentifiersSlow(objects, ids);

            for (int i = 0; i < identifiers.Length; i++)
            {
                for (int j = 0; j < objects.Length; j++)
                {
                    if (identifiers[i].Equals(ids[j]))
                    {
                        outputInstanceIDs[i] = objects[j].GetInstanceID();
                        break;
                    }
                }
            }
        }

        public static int SceneObjectIdentifierToInstanceIDSlow(Scene scene, SceneObjectIdentifier id)
        {
            return SceneObjectIdentifierToObjectSlow(scene, id).GetInstanceID();
        }
    #endif

        static Object[] GetSceneObjects(Scene scene)
        {
            var roots      = scene.GetRootGameObjects();
            var transforms = new List<Transform>();
            var objects    = new List<Object>();

            foreach (var root in roots)
            {
                root.GetComponentsInChildren(true, transforms);
                foreach (var transform in transforms)
                {
                    objects.Add(transform.gameObject);

                    foreach (var component in transform.GetComponents<Component>())
                    {
                        objects.Add(component);
                    }
                }
            }

            return objects.ToArray();
        }

        internal static void Write(SerializedProperty property, SceneObjectIdentifier value)
        {
            property.FindPropertyRelative("targetObject").longValue = (long)value.targetObject;
            property.FindPropertyRelative("targetPrefab").longValue = (long)value.targetPrefab;
        }

        internal static SceneObjectIdentifier Read(SerializedProperty property)
        {
            return new SceneObjectIdentifier
            {
                targetObject = (ulong)property.FindPropertyRelative("targetObject").longValue,
                targetPrefab = (ulong)property.FindPropertyRelative("targetPrefab").longValue
            };
        }
    }
}
