using Unity.Entities;
using Unity.Jobs;

[AlwaysSynchronizeSystem]
public class GameSystem : JobComponentSystem
{
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		Entities
			.ForEach((ref GameData gameData, ref InputData inputData) =>
			{
				if (inputData.IsKeyDownSpacebar)
				{
					gameData.IsPaused = !gameData.IsPaused;
				}

			}).Run();

		return default;
	}
}
