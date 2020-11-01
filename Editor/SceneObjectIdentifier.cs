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

        public static SceneObjectIdentifier GetSceneObjectIdentifier(int instanceId)
        {
            return GetSceneObjectIdentifier(EditorUtility.InstanceIDToObject(instanceId));
        }

        public static SceneObjectIdentifier GetSceneObjectIdentifier(Object targetObject)
        {
            return new SceneObjectIdentifier
            {
                targetObject = GetLocalIdentifier(targetObject),
                targetPrefab = GetLocalIdentifier(PrefabUtility.GetPrefabInstanceHandle(targetObject))
            };
        }

        public static void GetSceneObjectIdentifiers(Object[] objects, SceneObjectIdentifier[] outputIdentifiers)
        {
            for (int i = 0; i < objects.Length; i++)
                outputIdentifiers[i] = GetSceneObjectIdentifier(objects[i]);
        }

        public static void GetSceneObjectIdentifiers(int[] instanceIds, SceneObjectIdentifier[] outputIdentifiers)
        {
            for (int i = 0; i < instanceIds.Length; i++)
                outputIdentifiers[i] = GetSceneObjectIdentifier(instanceIds[i]);
        }

        public static void SceneObjectIdentifiersToObjectsSlow(Scene scene, SceneObjectIdentifier[] identifiers, Object[] outputObjects)
        {
            var sceneObjects = GetSceneObjects(scene);

            for (int i = 0; i < identifiers.Length; i++)
            {
                foreach (var sceneObject in sceneObjects)
                {
                    if (GetSceneObjectIdentifier(sceneObject).Equals(identifiers[i]))
                    {
                        outputObjects[i] = sceneObject;
                        break;
                    }
                }
            }
        }

        public static void SceneObjectIdentifiersToInstanceIDsSlow(Scene scene, SceneObjectIdentifier[] identifiers, int[] outputInstanceIDs)
        {
            var sceneObjects = GetSceneObjects(scene);
            
            for (int i = 0; i < identifiers.Length; i++)
            {
                foreach (var sceneObject in sceneObjects)
                {
                    if (GetSceneObjectIdentifier(sceneObject).Equals(identifiers[i]))
                    {
                        outputInstanceIDs[i] = sceneObject.GetInstanceID();
                        break;
                    }
                }
            }
        }

        public static Object SceneObjectIdentifierToObjectSlow(Scene scene, SceneObjectIdentifier id)
        {
            var objects = GetSceneObjects(scene);

            foreach (var sceneObject in objects)
            {
                if (GetSceneObjectIdentifier(sceneObject).Equals(id))
                    return sceneObject;
            }

            return null;
        }

        public static int SceneObjectIdentifierToInstanceIDSlow(Scene scene, SceneObjectIdentifier id)
        {
            return SceneObjectIdentifierToObjectSlow(scene, id).GetInstanceID();
        }

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

        static ulong GetLocalIdentifier(Object obj)
        {
            if (obj == null)
                return 0;

            var so = new SerializedObject(obj);
            SerializedObjectUtility.SetInspectorMode(so, InspectorMode.DebugInternal);
            return (ulong)so.FindProperty("m_LocalIdentfierInFile").longValue;
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
