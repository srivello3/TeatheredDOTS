using RMC.Projects.TeatheredDOTS.DOTS.ComponentData;
using RMC.Projects.TeatheredDOTS.Traditional.Input;
using Unity.Entities;
using Unity.Jobs;

namespace RMC.Projects.TeatheredDOTS.DOTS.Systems
{
	[AlwaysSynchronizeSystem]
	public class InputSystem : BasePauseableSystem
	{
		protected override JobHandle OnUpdate(JobHandle inputDeps)
		{
			//Only SOME keys work while paused
			float axisHorizontal = 0;
			float axisVertical = 0;
		
			if (!IsPaused())
			{
				axisHorizontal = InputManager.Instance.Move.x;
				axisVertical = InputManager.Instance.Move.y;
			}

			bool isGetKeyDownSpacebar = InputManager.Instance.IsPause;
		
			Entities.ForEach((ref InputData inputData) =>
			{
				inputData.AxisHorizontal = axisHorizontal;
				inputData.AxisVertical = axisVertical;
				inputData.IsKeyDownSpacebar = isGetKeyDownSpacebar;
			
			}).Run();

			return default;
		}
	}
}
