using Unity.Entities;

namespace RMC.Projects.TeatheredDOTS.DOTS.ComponentData
{
    [GenerateAuthoringComponent]
    public struct GameData : IComponentData
    {
        public bool IsPaused;
    }
}