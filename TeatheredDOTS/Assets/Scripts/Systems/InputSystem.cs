using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class InputSystem : JobComponentSystem
{
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		float axisHorizontal = Input.GetAxis("Horizontal");
		float axisVertical = Input.GetAxis("Vertical");
		
		Entities.ForEach((ref InputData inputData) =>
		{
			inputData.AxisHorizontal = axisHorizontal;
			inputData.AxisVertical = axisVertical;
		}).Run();

		return default;
	}
}
