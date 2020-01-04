using Unity.Entities;
using Unity.Mathematics;

namespace RMC.Projects.TeatheredDOTS.DOTS.ComponentData
{
    public struct SpawnData : IComponentData
    {
        public Entity PrefabEntity;
        public float3 Position;
        public float3 Velocity;
    }
}