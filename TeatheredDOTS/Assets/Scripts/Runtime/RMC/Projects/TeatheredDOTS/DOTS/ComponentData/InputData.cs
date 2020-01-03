using Unity.Entities;

namespace RMC.Projects.TeatheredDOTS.DOTS.ComponentData
{
    [GenerateAuthoringComponent]
    public struct InputData : IComponentData
    {
        public float AxisVertical;
        public float AxisHorizontal;
        public bool IsKeyDownSpacebar;
    }
}