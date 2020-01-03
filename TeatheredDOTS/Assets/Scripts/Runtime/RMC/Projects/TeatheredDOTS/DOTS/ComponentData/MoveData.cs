using Unity.Entities;
using Unity.Mathematics;

namespace RMC.Projects.TeatheredDOTS.DOTS.ComponentData
{
    [GenerateAuthoringComponent]
    public struct MoveData : IComponentData
    {
        public float3 Speed;
    }
}