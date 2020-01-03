using Unity.Entities;

[GenerateAuthoringComponent]
public struct TimeData : IComponentData
{
    public float DeltaTime;
}