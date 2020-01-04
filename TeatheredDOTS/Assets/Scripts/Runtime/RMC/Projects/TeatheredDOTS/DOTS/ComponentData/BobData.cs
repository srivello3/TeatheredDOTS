using Unity.Entities;
using Unity.Mathematics;

namespace RMC.Projects.TeatheredDOTS.DOTS.ComponentData
{
    public struct BobData : IComponentData
    {
        public float3 PositionOriginal;
        public float3 Speed;
        public float3 Amplitude;
    }
}