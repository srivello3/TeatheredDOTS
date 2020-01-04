using System;
using System.Collections;
using RMC.Projects.TeatheredDOTS.DOTS.ComponentData;
using RMC.Projects.TeatheredDOTS.DOTS.Extensions;
using RMC.Projects.TeatheredDOTS.Traditional.DesignPatterns;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RMC.Projects.TeatheredDOTS.Traditional.Input
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        private GameObject _prefabGameObject = null;

        private EntityManager _entityManager;
        private BlobAssetStore _blobAssetStore;

        protected void Start()
        {
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            _blobAssetStore = new BlobAssetStore();
            
            SpawnOne();
            StartCoroutine(SpawnOneCoroutine());
        }

        private IEnumerator SpawnOneCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);
                SpawnOne();
            }
        }

        private void SpawnOne()
        {
            Debug.Log("SpawnOne()");

            Entity _prefabEntity = SpawnExtensions.CreateEntityFromPrefab(_prefabGameObject, _blobAssetStore);
            Entity spawnEnity = _entityManager.CreateEntity();
            SpawnData spawnData = new SpawnData
            {
                PrefabEntity = _prefabEntity,
                Position = new float3(1, 1, 0),
                Velocity = new float3(0.1f, 0.1f, 0),
            };
            _entityManager.AddComponentData(spawnEnity, spawnData);
            
        }


    }
}
