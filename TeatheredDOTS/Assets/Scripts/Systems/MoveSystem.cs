using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public class MoveSystem : JobComponentSystem
{
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		float deltaTime = Time.DeltaTime;

		Entities.ForEach((ref Translation trans, in InputData inputData, in MoveData moveData) =>
		{
			trans.Value.x = trans.Value.x + inputData.AxisHorizontal * deltaTime * moveData.Speed;
			trans.Value.y = trans.Value.y + inputData.AxisVertical * deltaTime * moveData.Speed;
		}).Run();

		return default;
	}
}
