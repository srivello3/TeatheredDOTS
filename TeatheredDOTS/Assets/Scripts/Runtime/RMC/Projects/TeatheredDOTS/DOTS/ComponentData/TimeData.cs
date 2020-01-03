using Unity.Entities;

namespace RMC.Projects.TeatheredDOTS.DOTS.ComponentData
{
    [GenerateAuthoringComponent]
    public struct TimeData : IComponentData
    {
        public float DeltaTime;
    }
}