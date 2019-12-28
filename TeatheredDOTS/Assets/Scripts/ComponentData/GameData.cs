using Unity.Entities;

[GenerateAuthoringComponent]
public struct GameData : IComponentData
{
    public bool IsPaused;
}