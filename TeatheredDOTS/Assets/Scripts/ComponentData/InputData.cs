using Unity.Entities;

[GenerateAuthoringComponent]
public struct InputData : IComponentData
{
    public float AxisVertical;
    public float AxisHorizontal;
}