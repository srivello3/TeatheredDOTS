using RMC.Projects.TeatheredDOTS.DOTS.ComponentData;
using Unity.Entities;
using Unity.Jobs;

namespace RMC.Projects.TeatheredDOTS.DOTS.Systems
{
    [AlwaysSynchronizeSystem]
    public class BasePauseableSystem : JobComponentSystem
    {
        //TODO: This "BasePauseableSystem" instance is being run.
        //I actually only want its children 
        //to run. How do I do that?
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return default;
        }

        protected bool IsPaused()
        {
            bool isPaused = false;
		
            //TODO: I COULD assume there is exactly one of these...
            Entities
                .ForEach((ref GameData gameData) =>
                {
                    isPaused = gameData.IsPaused;
				
                }).Run();

            return isPaused;
        }
    }
}
