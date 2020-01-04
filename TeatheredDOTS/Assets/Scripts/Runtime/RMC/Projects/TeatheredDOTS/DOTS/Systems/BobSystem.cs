using RMC.Projects.TeatheredDOTS.DOTS.ComponentData;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace RMC.Projects.TeatheredDOTS.DOTS.Systems
{
	[AlwaysSynchronizeSystem]
	public class BobSystem : BasePauseableSystem
	{
		protected override JobHandle OnUpdate(JobHandle inputDeps)
		{
			if (IsPaused())
			{
				return default;
			}

			float deltaTime = (float)EntityManager.World.Time.ElapsedTime;
			
			Entities
				.ForEach((ref Translation translation, in BobData bobData) =>
				{
					translation.Value = new float3(
						translation.Value.x,
						bobData.PositionOriginal.y + bobData.Amplitude.y * math.sin(bobData.Speed.y * deltaTime),
						translation.Value.z);
						
				}).Run();
			
			return default;
		}
	}
}
