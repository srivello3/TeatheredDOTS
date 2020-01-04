
using Unity.Entities;
using UnityEngine;

namespace RMC.Projects.TeatheredDOTS.DOTS.Extensions
{
    public static class SpawnExtensions
    {
        public static Entity CreateEntityFromPrefab(GameObject prefabGameObject, BlobAssetStore blobAssetStore)
        {
            return GameObjectConversionUtility.ConvertGameObjectHierarchy(prefabGameObject,
                GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blobAssetStore));
        }
    }
}
