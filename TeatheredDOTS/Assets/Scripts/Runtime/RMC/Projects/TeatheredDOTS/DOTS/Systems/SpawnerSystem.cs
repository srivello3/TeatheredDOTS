using RMC.Projects.TeatheredDOTS.DOTS.ComponentData;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

namespace RMC.Projects.TeatheredDOTS.DOTS.Systems
{
	[AlwaysSynchronizeSystem]
	public class SpawnerSystem : BasePauseableSystem
	{
		private EntityCommandBuffer _entityCommandBuffer;
		
		protected override JobHandle OnUpdate(JobHandle inputDeps)
		{
			if (IsPaused())
			{
				return default;
			}

			_entityCommandBuffer = new EntityCommandBuffer(Allocator.TempJob);
			
			Entities
				.WithStructuralChanges()
				.WithoutBurst()
				.ForEach((Entity spawnEntity, ref SpawnData spawnData) =>
				{
					Entity spawnInstanceEntity = EntityManager.Instantiate(spawnData.PrefabEntity);

					Translation translation = new Translation()
					{ 
						Value = spawnData.Position
					};
					
					BobData bobData = new BobData()
					{
						PositionOriginal = spawnData.Position,
						Speed = new float3 (1,1,1),
						Amplitude = new float3 (0.25f, 0.25f, 0.25f)
					};

					EntityManager.AddComponentData(spawnInstanceEntity, translation);
					EntityManager.AddComponentData(spawnInstanceEntity, bobData);
					
					_entityCommandBuffer.DestroyEntity(spawnEntity);
					
				}).Run();
			

			_entityCommandBuffer.Playback(EntityManager);
			_entityCommandBuffer.Dispose();
			
			return default;
		}
	}
}
