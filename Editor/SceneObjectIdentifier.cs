using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace NewBlood
{
    public struct SceneObjectIdentifier
    {
        public ulong targetObject { get; set; }

        public ulong targetPrefab { get; set; }

        public static SceneObjectIdentifier FromGlobalObjectId(GlobalObjectId id)
        {
            return new SceneObjectIdentifier
            {
                targetObject = id.targetObjectId,
                targetPrefab = id.targetPrefabId
            };
        }

        public static SceneObjectIdentifier GetSceneObjectIdentifierSlow(int instanceId)
        {
            return FromGlobalObjectId(GlobalObjectId.GetGlobalObjectIdSlow(instanceId));
        }

        public static SceneObjectIdentifier GetSceneObjectIdentifierSlow(Object targetObject)
        {
            return FromGlobalObjectId(GlobalObjectId.GetGlobalObjectIdSlow(targetObject));
        }

        public static void GetSceneObjectIdentifiersSlow(Object[] objects, SceneObjectIdentifier[] outputIdentifiers)
        {
            var gids = new GlobalObjectId[outputIdentifiers.Length];
            GlobalObjectId.GetGlobalObjectIdsSlow(objects, gids);

            for (int i = 0; i < gids.Length; i++)
                outputIdentifiers[i] = FromGlobalObjectId(gids[i]);
        }

        public static void GetSceneObjectIdentifiersSlow(int[] instanceIds, SceneObjectIdentifier[] outputIdentifiers)
        {
            var gids = new GlobalObjectId[outputIdentifiers.Length];
            GlobalObjectId.GetGlobalObjectIdsSlow(instanceIds, gids);

            for (int i = 0; i < gids.Length; i++)
                outputIdentifiers[i] = FromGlobalObjectId(gids[i]);
        }

        public static void SceneObjectIdentifiersToObjectsSlow(Scene scene, SceneObjectIdentifier[] ids, Object[] objects)
        {
            var gids = FilterGlobalObjectIds(GetGlobalObjectIdsForSceneSlow(scene), ids);
            GlobalObjectId.GlobalObjectIdentifiersToObjectsSlow(gids, objects);
        }

        public static void SceneObjectIdentifiersToInstanceIDsSlow(Scene scene, SceneObjectIdentifier[] ids, int[] instanceIds)
        {
            var gids = FilterGlobalObjectIds(GetGlobalObjectIdsForSceneSlow(scene), ids);
            GlobalObjectId.GlobalObjectIdentifiersToInstanceIDsSlow(gids, instanceIds);
        }

        public static Object SceneObjectIdentifierToObjectSlow(Scene scene, SceneObjectIdentifier id)
        {
            foreach (var gid in GetGlobalObjectIdsForSceneSlow(scene))
            {
                if (gid.targetObjectId == id.targetObject && gid.targetPrefabId == id.targetPrefab)
                    return GlobalObjectId.GlobalObjectIdentifierToObjectSlow(gid);
            }

            return null;
        }

        public static int SceneObjectIdentifierToInstanceIDSlow(Scene scene, SceneObjectIdentifier id)
        {
            foreach (var gid in GetGlobalObjectIdsForSceneSlow(scene))
            {
                if (gid.targetObjectId == id.targetObject && gid.targetPrefabId == id.targetPrefab)
                    return GlobalObjectId.GlobalObjectIdentifierToInstanceIDSlow(gid);
            }

            return 0;
        }

        static GlobalObjectId[] FilterGlobalObjectIds(GlobalObjectId[] gids, SceneObjectIdentifier[] sids)
        {
            var ids = new GlobalObjectId[sids.Length];

            for (int i = 0; i < sids.Length; i++)
            {
                foreach (var gid in gids)
                {
                    if (gid.targetObjectId == sids[i].targetObject && gid.targetPrefabId == sids[i].targetPrefab)
                    {
                        ids[i] = gid;
                        break;
                    }
                }
            }

            return ids;
        }

        static GlobalObjectId[] GetGlobalObjectIdsForSceneSlow(Scene scene)
        {
            var roots      = scene.GetRootGameObjects();
            var objects    = new List<int>();
            var transforms = new List<Transform>();

            foreach (var root in roots)
            {
                root.GetComponentsInChildren(true, transforms);
                foreach (var transform in transforms)
                {
                    objects.Add(transform.gameObject.GetInstanceID());

                    foreach (var component in transform.GetComponents<Component>())
                    {
                        objects.Add(component.GetInstanceID());
                    }
                }
            }

            var instanceIds = objects.ToArray();
            var globalIds   = new GlobalObjectId[instanceIds.Length];
            GlobalObjectId.GetGlobalObjectIdsSlow(instanceIds, globalIds);
            return globalIds;
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
