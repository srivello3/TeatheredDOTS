using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct MoveData : IComponentData
{
    public float3 Speed;
}