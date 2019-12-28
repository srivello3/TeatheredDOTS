using Unity.Entities;
using Unity.Jobs;

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
