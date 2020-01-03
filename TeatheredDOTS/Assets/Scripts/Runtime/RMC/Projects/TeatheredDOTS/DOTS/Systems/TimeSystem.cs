using RMC.Projects.TeatheredDOTS.DOTS.ComponentData;
using Unity.Entities;
using Unity.Jobs;

namespace RMC.Projects.TeatheredDOTS.DOTS.Systems
{
	[AlwaysSynchronizeSystem]
	public class TimeSystem : JobComponentSystem
	{
		protected override JobHandle OnUpdate(JobHandle inputDeps)
		{
			float deltaTime = EntityManager.World.Time.DeltaTime;
		
			Entities.ForEach((ref TimeData timeData) =>
			{
				timeData.DeltaTime = deltaTime;
			}).Run();

			return default;
		}
	}
}
