using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Extensions;
using Unity.Transforms;

[UpdateAfter(typeof(InputSystem))]
[UpdateAfter(typeof(TimeSystem))]
[AlwaysSynchronizeSystem]
public class MoveSystem : BasePauseableSystem
{
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		if (IsPaused())
		{
			return default;
		}
		
		float deltaTime = EntityManager.World.Time.DeltaTime;
 
		//Move non-teathered
		Entities
			.WithNone<IsTeatheredTagData>()
			.ForEach((ref PhysicsVelocity physicsVelocity, 
				in PhysicsMass physicsMass, in Translation translation, in Rotation rotation,
				in InputData inputData, in MoveData moveData) =>
			{

				MoveHorizontal(ref physicsVelocity, inputData, moveData,
					physicsMass, translation, rotation, deltaTime);

			}).Run();
		
		//Move all
		Entities.ForEach((ref PhysicsVelocity physicsVelocity, 
			in PhysicsMass physicsMass, in Translation translation, in Rotation rotation,
			in InputData inputData, in MoveData moveData) =>
		{
			
			MoveVertical(ref physicsVelocity, inputData, moveData, 
				physicsMass, translation, rotation, deltaTime);
			
			physicsVelocity.Angular.xyz = 0;
			physicsVelocity.Linear.z = 0;
			
		}).Run();
		
		return default;
	}

	private static void MoveVertical(ref PhysicsVelocity physicsVelocity, InputData inputData,  
		MoveData moveData, PhysicsMass physicsMass, Translation translation, Rotation rotation,
		float deltaTime)
	{
		if (!IsApproximatelyZero(inputData.AxisVertical) &&
		    IsApproximatelyZero(physicsVelocity.Linear.y))
		{
			ComponentExtensions.ApplyImpulse(
				ref physicsVelocity, physicsMass, translation,
				rotation, 
				new float3(0, moveData.Speed.y * deltaTime, 0), 
				new float3(0, 0, 0));

		}
	}
	
	private static void MoveHorizontal(ref PhysicsVelocity physicsVelocity, InputData inputData,
		MoveData moveData, PhysicsMass physicsMass, Translation translation, Rotation rotation, 
		float deltaTime)
	{
		if (!IsApproximatelyZero(inputData.AxisHorizontal))
		{
			ComponentExtensions.ApplyImpulse(
				ref physicsVelocity, physicsMass, translation,
				rotation, 
				new float3(inputData.AxisHorizontal * moveData.Speed.x * deltaTime, 0, 0), 
				new float3(0, 0, 0));
			
		}
	}

	private static bool IsApproximatelyZero(float value)
	{
		return math.abs(value) < 0.01f;
	}
}
