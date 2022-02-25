using System;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace NewBlood
{
    [Serializable]
    public struct SceneObjectIdentifier : IEquatable<SceneObjectIdentifier>
    {
        public ulong targetObject;

        public ulong targetPrefab;

        public SceneObjectIdentifier(GlobalObjectId id)
        {
            if (id.identifierType != 2)
                throw new ArgumentException("GlobalObjectId must refer to a scene object.", nameof(id));

            targetObject = id.targetObjectId;
            targetPrefab = id.targetPrefabId;
        }

        public bool Equals(SceneObjectIdentifier other)
        {
            return targetObject == other.targetObject && targetPrefab == other.targetPrefab;
        }

        public GlobalObjectId ToGlobalObjectId(SceneAsset scene)
        {
            return ToGlobalObjectId(AssetDatabase.GUIDFromAssetPath(AssetDatabase.GetAssetPath(scene)));
        }

        public GlobalObjectId ToGlobalObjectId(Scene scene)
        {
            return ToGlobalObjectId(AssetDatabase.GUIDFromAssetPath(scene.path));
        }

        public GlobalObjectId ToGlobalObjectId(GUID sceneGuid)
        {
            GlobalObjectId id;
            GlobalObjectId.TryParse($"GlobalObjectId_V1-2-{sceneGuid}-{targetObject}-{targetPrefab}", out id);
            return id;
        }
    }
}
