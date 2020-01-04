using System;
using System.Collections;
using RMC.Projects.TeatheredDOTS.DOTS.ComponentData;
using RMC.Projects.TeatheredDOTS.DOTS.Extensions;
using RMC.Projects.TeatheredDOTS.Traditional.DesignPatterns;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace RMC.Projects.TeatheredDOTS.Traditional.Input
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        private GameObject _prefabGameObject = null;

        private EntityManager _entityManager;
        private BlobAssetStore _blobAssetStore;
        private Entity _prefabEntity;
        private Random random = new Random();
        
        protected void Start()
        {
            random.InitState();
            
            
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            _blobAssetStore = new BlobAssetStore();

            SpawnOne();
            StartCoroutine(SpawnOneCoroutine());
        }

        private IEnumerator SpawnOneCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                SpawnOne();
            }
        }

        private void SpawnOne()
        {
            Debug.Log("SpawnOne()");

            _prefabEntity = SpawnExtensions.CreateEntityFromPrefab(_prefabGameObject, 
                _blobAssetStore);

            float screenWidth = 14;
            float randomX = - screenWidth/2 + random.NextInt(0, (int)screenWidth/2) * 2;
            
            Debug.Log(randomX);
            
            SpawnData spawnData = new SpawnData
            {
                PrefabEntity = _prefabEntity,
                Position = new float3(randomX, 0 , 0),
                Velocity = new float3(0f, 0f, 0),
            };
            
            _entityManager.AddComponentData(_entityManager.CreateEntity(), 
                spawnData);
        }
    }
}
