using RMC.Projects.TeatheredDOTS.DOTS.ComponentData;
using Unity.Entities;
using Unity.Jobs;

namespace RMC.Projects.TeatheredDOTS.DOTS.Systems
{
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
}
