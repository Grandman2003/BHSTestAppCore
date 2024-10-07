using Core.Entities.Base;

namespace Core.Entities.Behaviours;

public interface IPhysical
{
    bool hasIntersaction(Coordinates3D outsidePoint);
}