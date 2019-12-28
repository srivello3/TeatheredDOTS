using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

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
			axisHorizontal = Input.GetAxis("Horizontal");
			axisVertical = Input.GetAxis("Vertical");
		}
		
		bool isGetKeyDownSpacebar = Input.GetKeyDown(KeyCode.Space);
		
		Entities.ForEach((ref InputData inputData) =>
		{
			inputData.AxisHorizontal = axisHorizontal;
			inputData.AxisVertical = axisVertical;
			inputData.IsKeyDownSpacebar = isGetKeyDownSpacebar;
			
		}).Run();

		return default;
	}
}
